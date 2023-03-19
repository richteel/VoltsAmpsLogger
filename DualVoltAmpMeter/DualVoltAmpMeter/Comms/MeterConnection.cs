using System;
using System.Collections.Generic;
using System.IO.Ports;
using DualVoltAmpMeter.Data;
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
                ReadTimeout = 5000,
                WriteTimeout = 5000,
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
                if (Connect())
                {
                    SendData(".do.");

                    _serialPort.Close();
                }
                
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
            catch (System.IO.IOException ex)
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
                // Console.WriteLine("COM Port: " + _comPort.Name);
                // Console.WriteLine("Received: " + data);
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
            if (data.StartsWith("HW "))
            {
                _meterVersionHardware = data;
                OnMeterInfoChanged();
                return;
            }
            if (data.StartsWith("SW "))
            {
                _meterVersionSoftware = data;
                OnMeterInfoChanged();
                return;
            }

            try
            {
                Reading dataObj = JsonSerializer.Deserialize<Reading>(data);

                if (dataObj == null) { return; }

                dataObj.received = DateTime.Now;
                _readings.Add(dataObj);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Received " + data);
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
                // handler(this, new MeterConnectionEventArgs() { Connected = _meterConnected, ComPort = _comPort });
                handler.BeginInvoke(this,
                    new MeterConnectionEventArgs() { Connected = _meterConnected, ComPort = _comPort }, null, null);
            }
        }

        public event EventHandler<EventArgs> MeterInfoChanged;
        private void OnMeterInfoChanged()
        {
            if (_disposedValue)
            {
                return;
            }

            EventHandler<EventArgs> handler = MeterInfoChanged;
            if (handler != null)
            {
                // handler(this, new EventArgs() { });
                handler.BeginInvoke(this, new EventArgs(), null, null);
            }
        }
    }
}
