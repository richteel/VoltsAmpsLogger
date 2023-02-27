using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;
using DualVoltAmpMeter.Data;
using System.Reflection.Emit;
using System.Windows.Forms;
using System.Text.Json;

namespace DualVoltAmpMeter.Comms
{
    public class MeterConnection
    {
        /*********************************************************************************
         * Fields 
         *********************************************************************************/
        private ComPortItem _comPort;
        private string _errorMessage;
        private bool _meterConnected;
        private string _meterVersionHardware;
        private string _meterVersionSoftware;
        private List<Reading> _readings;
        private int _readingsMaxCount;
        private SerialPort _serialPort;

        // To detect redundant calls
        private bool _disposedValue = false;


        /*********************************************************************************
         * Properties 
         *********************************************************************************/
        public ComPortItem ComPort => _comPort;
        public string ErrorMessage => _errorMessage;
        public bool MeterConnected => _meterConnected;
        public List<Reading> MeterReadings => _readings;
        public int MeterReadingsMaxCount
        {
            get { return _readingsMaxCount; }
            set { _readingsMaxCount = value; }
        }
        public SerialPort MeterSerialPort => _serialPort;
        public string MeterVersionHardware => _meterVersionHardware;
        public string MeterVersionSoftware => _meterVersionSoftware;


        /*********************************************************************************
         * Class Constructor 
         *********************************************************************************/
        public MeterConnection(ComPortItem ComPort)
        {
            _comPort = ComPort;
            _meterConnected = false;
            _readings = new List<Reading>();
            Console.WriteLine("MeterConnection - Clearing Connected flag for " + ComPort.Name);

            _serialPort = new SerialPort(_comPort.Name)
            {
                ReadTimeout = 2000,
                WriteTimeout = 2000,
                // These two required for Raspberry Pico
                // https://forum.arduino.cc/t/solved-c-win10-serial-terminal-not-receive-strings-from-pico-arduino-ide/1080783/4
                DtrEnable = true,
                RtsEnable = true,
            };
            _serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPort_DataReceived);
        }

        ~MeterConnection()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                if (!Connect())
                {
                    return;
                }

                SendData(".do.");

                _serialPort.Close();
                _serialPort = null;

                _disposedValue = true;

                Console.WriteLine("Meter Connection " + _comPort.Name + " disposed.");
            }
        }

        /*********************************************************************************
         * Private Methods 
         *********************************************************************************/
        private bool Connect()
        {
            _errorMessage = "";

            if (_serialPort == null)
            {
                _errorMessage = "ERROR: COM Port not set";
                _meterConnected = false;
                return false;
            }

            if (_serialPort.IsOpen)
            {
                return true;
            }

            _meterConnected = false;
            Console.WriteLine("Connect - Clearing Connected flag for " + ComPort.Name);

            try
            {
                _serialPort.Open();
            }
            catch (System.UnauthorizedAccessException ex)
            {
                _errorMessage = string.Format("ERROR: {0} Port is in use.", _comPort.Name);
                Console.WriteLine(ex.Message);
                return false;
            }

            return _serialPort.IsOpen;
        }


        /*********************************************************************************
         * Event Handlers
         *********************************************************************************/
        /// <summary>
        /// Event handler that fires when data is received by the serial port.
        /// If the data is in a valid format, it is saved to the _readings ArrayList. If the number of 
        /// _readings is greater than the _maxReadingsBufferSize, the oldest items are removed.
        /// </summary>
        /// <param name="sender">The object that fired the event.</param>
        /// <param name="e">Event information related to this event.</param>
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort port = sender as SerialPort;

            if (port == null)
            {
                return;
            }

            string data = "";

            try
            {
                data = port.ReadLine().Trim();
            }
            catch (System.IO.IOException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            catch (System.TimeoutException ex)
            {
                Console.WriteLine(ex.ToString());
            }

            if (string.IsNullOrEmpty(data))
            {
                return;
            }

            if (data == ".METER-HERE.")
            {
                _meterConnected = true;
                Console.WriteLine("SerialPort_DataReceived - Setting Connected flag for " + ComPort.Name);
                OnConnectStatusChanged();
                SendData(".v.");
                return;
            }
            else if (data.StartsWith("HW "))
            {
                _meterVersionHardware = data;
                return;
            }
            else if (data.StartsWith("SW "))
            {
                _meterVersionSoftware = data;
                return;
            }

            try
            {
                Reading dataObj = JsonSerializer.Deserialize<Reading>(data);

                if (dataObj == null) { return; }

                dataObj.received = DateTime.Now;
                _readings.Add(dataObj);

                // Limit the number of items in the ArrayList
                while (_readings.Count > _readingsMaxCount)
                {
                    _readings.RemoveAt(0);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        /*********************************************************************************
         * Public Methods 
         *********************************************************************************/
        public void CheckIfMeterIsConnected()
        {
            _meterConnected = false;
            Console.WriteLine("CheckIfMeterIsConnected - Clearing Connected flag for " + ComPort.Name);

            SendData(".findmeter.");
        }

        public void SendData(string message)
        {
            if (!Connect())
            {
                return;
            }

            if (_serialPort.IsOpen)
            {
                string stringToSend = message + "\r\n";
                try
                {
                    _serialPort.WriteLine(stringToSend);
                }
                catch (System.TimeoutException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (System.IO.IOException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void StartMonitoring(bool stopDisplayUpdate = true)
        {
            if (stopDisplayUpdate)
            {
                SendData(".so.");
            }
            else
            {
                SendData(".sd.");
            }
        }

        public void StopMonitoring()
        {
            SendData(".do.");
        }

        /*********************************************************************************
         * Public Events 
         *********************************************************************************/
        public event EventHandler<MeterConnectionEventArgs> ConnectStatusChanged;
        private void OnConnectStatusChanged()
        {
            if (_disposedValue)
            {
                return;
            }

            EventHandler<MeterConnectionEventArgs> handler = ConnectStatusChanged;
            if (handler != null)
            {
                handler(this, new MeterConnectionEventArgs() { Connected = _meterConnected, ComPort = _comPort });
            }
        }
    }

    public class MeterConnectionEventArgs : EventArgs
    {
        public bool Connected { get; set; }
        public ComPortItem ComPort { get; set; }
    }
}
