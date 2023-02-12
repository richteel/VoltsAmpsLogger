// REF: https://stackoverflow.com/questions/50076045/chart-auto-scroll-oscilloscope-effect

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using System.IO.Ports;
using System.Collections;
using System.Text.Json;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

namespace VoltsAmpsLogger
{
    public partial class Form1 : Form
    {
        /*********************************************************************************
         * Fields 
         *********************************************************************************/
        private ComPortItem[] _comPortItems;
        private ComPortItem _comPortItemSelected;
        private ArrayList _readings;
        private SerialPort _serialPort;
        private long _readingCount;

        private string[] _baudRates = {
            "300", "600", "1200", "2400", "4800", "9600", "14400",
            "19200", "28800", "31250", "38400", "57600", "115200"
        };
        private string _baudRateSelected = "115200";
        private const int _maxReadingsBufferSize = 1024;

        /*********************************************************************************
         * Class Constructor 
         *********************************************************************************/
        public Form1()
        {
            InitializeComponent();

            _comPortItemSelected = new ComPortItem() { Port = 0, Description = "", Name = "" };
            _comPortItems = null;
            _readings = new ArrayList();
        }

        /*********************************************************************************
         * Private Methods 
         *********************************************************************************/
        /// <summary>
        /// Clears the chart and provides default visualization so the chart appears, 
        /// such as on form load.
        /// </summary>
        private void ClearChart()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(ClearChart), new object[] { });
                return;
            }

            ChartArea ca = chart1.ChartAreas[0];
            Series channel1Volts = chart1.Series[0];
            Series channel1Current = chart1.Series[1];
            Series channel2Volts = chart1.Series[2];
            Series channel2Current = chart1.Series[3];

            ca.AxisY.Minimum = 0;
            ca.AxisY.Maximum = 10;
            ca.AxisY2.Minimum = 0;
            ca.AxisY2.Maximum = 1;
            ca.RecalculateAxesScale();

            channel1Volts.Points.AddXY(0, 0);
            channel1Current.Points.AddXY(0, 0);
            channel2Volts.Points.AddXY(0, 0);
            channel2Current.Points.AddXY(0, 0);
        }

        /// <summary>
        /// Opens the selected COM port that is saved in the _comPortItemSelected variable's Name property.
        /// </summary>
        /// <remarks>
        /// The Raspberry Pi Pico requires both Request to Send (RTS) and Data Terminal Ready (DTR) to be enabled.
        /// It took a couple of hours to find that this was necessary.
        /// </remarks>
        private void ConnectToComPort()
        {
            if (string.IsNullOrEmpty(_comPortItemSelected.Name)) { return; }

            int b = int.Parse(_baudRateSelected);

            _serialPort = new SerialPort(_comPortItemSelected.Name, int.Parse(_baudRateSelected));
            _serialPort.ReadTimeout = 5000;
            // These two required for Raspberry Pico
            // https://forum.arduino.cc/t/solved-c-win10-serial-terminal-not-receive-strings-from-pico-arduino-ide/1080783/4
            _serialPort.RtsEnable = true;
            _serialPort.DtrEnable = true;

            _serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPort_DataReceived);
            _serialPort.Open();
        }

        /// <summary>
        /// Saves the data stored in the field, _readings, to the a delimited file with the 
        /// delimiter passed to the method.
        /// </summary>
        /// <param name="filename">The full filename, with path and extension, to save the data.</param>
        /// <param name="delimiter">The delimiter used to separate the columns of data in each row.</param>
        /// <remarks>
        /// The number of rows saved is limited by the size of _readings, which is limited by the 
        /// value of _maxReadingsBufferSize.
        /// </remarks>
        private void SaveDataFileDelimited(string filename, string delimiter)
        {
            string dataFormatString =
                "{0}" + delimiter +
                "{1}" + delimiter +
                "{2}" + delimiter +
                "{3}" + delimiter +
                "{4}" + delimiter +
                "{5}" + delimiter +
                "{6}" + delimiter +
                "{7}" + delimiter +
                "{8}" + delimiter +
                "{9}" + delimiter +
                "{10}" + delimiter +
                "{11}" + delimiter +
                "{12}" + delimiter +
                "{13}";

            using (StreamWriter file = new StreamWriter(filename))
            {
                // Write Headers
                file.WriteLine(string.Format(dataFormatString, "Received", "time.monotonic", "V-In (Channel 1)",
                    "V-Out (Channel 1)", "V-Shunt (Channel 1)", "I-Shunt (Channel 1)", "Power-Calculated (Channel 1)",
                    "Power (Channel 1)", "V-In (Channel 2)", "V-Out (Channel 2)", "V-Shunt (Channel 2)",
                    "I-Shunt (Channel 2)", "Power-Calculated (Channel 2)", "Power (Channel 2)"));

                foreach (var readVals in _readings)
                {
                    Reading reading = (Reading)readVals;

                    file.WriteLine(string.Format(dataFormatString, reading.received, reading.time,
                        reading.channel_1.VIN_IN, reading.channel_1.VIN_OUT, reading.channel_1.ShuntV,
                        reading.channel_1.ShuntC, reading.channel_1.PowerCal, reading.channel_1.PowerRegister,
                        reading.channel_2.VIN_IN, reading.channel_2.VIN_OUT, reading.channel_2.ShuntV,
                        reading.channel_2.ShuntC, reading.channel_2.PowerCal, reading.channel_2.PowerRegister));
                }
            }
        }

        /// <summary>
        /// Saves the data stored in the field, _readings, to a JSON data file.
        /// </summary>
        /// <param name="filename">The full filename, with path and extension, to save the data.</param>
        /// <remarks>
        /// The number of rows saved is limited by the size of _readings, which is limited by the 
        /// value of _maxReadingsBufferSize.
        /// </remarks>
        private void SaveDataFileJson(string filename)
        {
            using (StreamWriter file = new StreamWriter(filename))
            {
                file.Write(JsonSerializer.Serialize(_readings, new JsonSerializerOptions { WriteIndented = true }));
            }
        }

        /// <summary>
        /// Updates the chart data based on the last 20 seconds of data contained in _readings. The number of points
        /// shown may be more or less than 20 as the data is selected by time received from the current time.
        /// </summary>
        private void UpdateChart()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(UpdateChart), new object[] { });
                return;
            }

            ChartArea ca = chart1.ChartAreas[0];
            Series channel1Volts = chart1.Series[0];
            Series channel1Current = chart1.Series[1];
            Series channel2Volts = chart1.Series[2];
            Series channel2Current = chart1.Series[3];

            const int SECONDS_TO_DISPLAY = 20;

            DateTime zeroTime = DateTime.Now.AddSeconds(-1 * SECONDS_TO_DISPLAY);

            int startDataIndex = 0;

            // Find stating data point index
            for (int pointIdx = _readings.Count - 1; pointIdx > 0; pointIdx--)
            {
                if (((Reading)_readings[pointIdx]).received <= zeroTime)
                {
                    startDataIndex = pointIdx;
                    break;
                }
            }

            channel1Volts.Points.Clear();
            channel1Current.Points.Clear();
            channel2Volts.Points.Clear();
            channel2Current.Points.Clear();

            int nextDataIndex = startDataIndex;

            for (int i = startDataIndex; i < _readings.Count; i++)
            {
                Reading nextReading = ((Reading)_readings[i]);

                double secondsValue = ((TimeSpan)(nextReading.received - zeroTime)).TotalSeconds;
                channel1Volts.Points.AddXY(secondsValue, nextReading.channel_1.VIN_OUT);
                channel1Current.Points.AddXY(secondsValue, nextReading.channel_1.ShuntC);
                channel2Volts.Points.AddXY(secondsValue, nextReading.channel_2.VIN_OUT);
                channel2Current.Points.AddXY(secondsValue, nextReading.channel_2.ShuntC);
            }

            ca.AxisY.Minimum = double.NaN;
            ca.AxisY.Maximum = double.NaN;
            ca.AxisY2.Minimum = double.NaN;
            ca.AxisY2.Maximum = double.NaN;
            ca.RecalculateAxesScale();
        }

        /// <summary>
        /// Updates the values shown in the UC_Meter controls on the form.
        /// </summary>
        /// <param name="meterCtrl">The UC_Meter control to update</param>
        /// <param name="meterVals">The values to be displayed in the control.</param>
        private void UpdateMeter(UC_Meter meterCtrl, Meter meterVals)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<UC_Meter, Meter>(UpdateMeter), new object[] { meterCtrl, meterVals });
                return;
            }

            meterCtrl.Update(meterVals);
        }

        /// <summary>
        /// Updates the status text in the status strip at the bottom of the form. It also changes the text
        /// and enable properties of the cmdStart button.
        /// </summary>
        /// <remarks>
        /// Called every time the timer fires.
        /// </remarks>
        private void UpdateStatus()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(UpdateStatus), new object[] { });
                return;
            }

            // Update connected status
            bool value = _serialPort != null && _serialPort.IsOpen;

            if (value)
            {
                lblComStatus.Text = "Status: Connected";
                cmdStart.Text = "Stop";
            }
            else
            {
                lblComStatus.Text = "Status: Not connected";
                cmdStart.Text = "Start";

                if (!string.IsNullOrEmpty(_comPortItemSelected.Name))
                {
                    List<COMPortInfo> currentPorts = COMPortInfo.GetCOMPortsInfo();
                    COMPortInfo selectedCom = currentPorts.Where(i => i.Name == _comPortItemSelected.Name).FirstOrDefault();

                    // Check if Selected COM port still exists
                    if (selectedCom == null)
                    {
                        _comPortItemSelected = new ComPortItem() { Port = 0, Description = "", Name = "" };
                        cmdStart.Enabled = false;
                    }
                }
            }

            // Update data points
            lblDataReceived.Text = string.Format("Received: {0:n0} measurements", _readingCount);
        }

        /*********************************************************************************
         * Event Handlers 
         *********************************************************************************/
        /// <summary>
        /// Event handler for the Help > About menu item. It shows the AboutBox1 form.
        /// </summary>
        /// <param name="sender">The object that fired the event.</param>
        /// <param name="e">Event information related to this event.</param>
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutBox1 box = new AboutBox1())
            {
                box.ShowDialog(this);
            }
        }

        /// <summary>
        /// Event handler for the Tools > Baud Rate menu item. It assigns a value to the _baudRateSelected field.
        /// </summary>
        /// <param name="sender">The object that fired the event.</param>
        /// <param name="e">Event information related to this event.</param>
        /// <remarks>
        /// This menu item may be removed in the future as this seems to not be necessary for Serial over USB
        /// emulation, as the data is sent as fast as possible. It may be handly though in case someone uses a 
        /// hardware COM port on the PC and connects, through level shifters, to a microcontroller.
        /// </remarks>
        private void BaudRateToolStripMenuItemBaud_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            menuItem.Checked = true;
            _baudRateSelected = menuItem.Text;

            foreach (ToolStripMenuItem mnuItem in menuItem.GetCurrentParent().Items)
            {
                if (menuItem.Text != mnuItem.Text)
                {
                    mnuItem.Checked = false;
                }
            }
        }

        /// <summary>
        /// Event handler for the Start/Stop button. It starts or stop the collection of data from the serial port.
        /// </summary>
        /// <param name="sender">The object that fired the event.</param>
        /// <param name="e">Event information related to this event.</param>
        private void CmdStart_Click(object sender, EventArgs e)
        {
            Button me = (Button)sender;

            if (me.Text == "Start")
            {
                ConnectToComPort();
            }
            else
            {
                _serialPort.Close();
            }

            UpdateStatus();
        }

        /// <summary>
        /// Event handler for the File > Exit menu item. It ends the application.
        /// </summary>
        /// <param name="sender">The object that fired the event.</param>
        /// <param name="e">Event information related to this event.</param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.MessageLoop)
            {
                // WinForms app
                Application.Exit();
            }
            else
            {
                // Console app
                Environment.Exit(1);
            }
        }

        /// <summary>
        /// Event handler for when the form loads. It adds the Baud Rates to the menu and sets displays the default chart.
        /// </summary>
        /// <param name="sender">The object that fired the event.</param>
        /// <param name="e">Event information related to this event.</param>
        /// <remarks>
        /// If the ClearChart method is not called here, the chart appears as a white box when the form loads.
        /// Panel1 is also hidden as it is not used in this version. It may be used in a future version to provide easier
        /// access to the port selection and format of the measurement data.
        /// </remarks>
        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;

            foreach (string baud in _baudRates)
            {
                ToolStripItem toolStripItem = baudRateToolStripMenuItem.DropDownItems.Add(baud, null, BaudRateToolStripMenuItemBaud_Click);

                if (baud == _baudRateSelected)
                {
                    ((ToolStripMenuItem)toolStripItem).Checked = true;
                }
            }
            ClearChart();
        }

        /// <summary>
        /// Event handler for the Help > GitHub Pages menu item. It open the user's web browser to show the GitHub
        /// Project Pages.
        /// </summary>
        /// <param name="sender">The object that fired the event.</param>
        /// <param name="e">Event information related to this event.</param>
        private void GitHubPagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = "https://richteel.github.io/VoltsAmpsLogger/";

            System.Diagnostics.Process.Start(url);
        }

        /// <summary>
        /// Event handler for the Tools > Port menu item. It places a check mark to the selected port
        /// and unchecks all the other ports. It also assigns a value to the _comPortItemSelected field.
        /// </summary>
        /// <param name="sender">The object that fired the event.</param>
        /// <param name="e">Event information related to this event.</param>
        private void PortToolStripMenuItemPort_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            menuItem.Checked = true;
            cmdStart.Enabled = true;

            foreach (ComPortItem comPortItem in _comPortItems)
            {
                string altPortText = string.Format("{0} – {1}", comPortItem.Name, comPortItem.Description);
                if (menuItem.Text == comPortItem.Description || menuItem.Text == altPortText)
                {
                    _comPortItemSelected = comPortItem;
                    break;
                }
            }
        }

        /// <summary>
        /// Event handler for the File > Save Chart Image menu item.
        /// </summary>
        /// <param name="sender">The object that fired the event.</param>
        /// <param name="e">Event information related to this event.</param>
        /// <exception cref="NotImplementedException"></exception>
        private void SaveChartImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // PNG file|*.png|JPG file|*.jpg|GIF file|*.gif|BMP file|*.bmp|TIFF file|*'tiff
            if (saveFileDialogChart.ShowDialog(this) == DialogResult.OK)
            {
                switch (saveFileDialogChart.FilterIndex)
                {
                    case 1: // PNG
                        chart1.SaveImage(saveFileDialogChart.FileName, ChartImageFormat.Png);
                        break;
                    case 2: // JPG
                        chart1.SaveImage(saveFileDialogChart.FileName, ChartImageFormat.Jpeg);
                        break;
                    case 3: // GIF
                        chart1.SaveImage(saveFileDialogChart.FileName, ChartImageFormat.Gif);
                        break;
                    case 4: // BMP
                        chart1.SaveImage(saveFileDialogChart.FileName, ChartImageFormat.Bmp);
                        break;
                    case 5: // TIFF
                        chart1.SaveImage(saveFileDialogChart.FileName, ChartImageFormat.Tiff);
                        break;
                    default:    // Unknown
                        throw new NotImplementedException();
                }
            }
        }

        /// <summary>
        /// Event handler for the File > Save Chart Data menu item.
        /// </summary>
        /// <param name="sender">The object that fired the event.</param>
        /// <param name="e">Event information related to this event.</param>
        /// <exception cref="NotImplementedException"></exception>
        private void SaveDataFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // CSV file|*.csv|Tab Delimited Text file|*.txt|JSON file|*.json
            if (saveFileDialogData.ShowDialog(this) == DialogResult.OK)
            {
                switch (saveFileDialogData.FilterIndex)
                {
                    case 1: // CSV
                        SaveDataFileDelimited(saveFileDialogData.FileName, ",");
                        break;
                    case 2: // Text (Tab Delimited)
                        SaveDataFileDelimited(saveFileDialogData.FileName, "\t");
                        break;
                    case 3: // JSON
                        SaveDataFileJson(saveFileDialogData.FileName);
                        break;
                    default:    // Unknown
                        throw new NotImplementedException();
                }
            }
        }

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

            string data = port.ReadLine();

            try
            {
                Reading dataObj = JsonSerializer.Deserialize<Reading>(data);

                if (dataObj == null) { return; }

                dataObj.received = DateTime.Now;

                UpdateMeter(uC_Meter1, dataObj.channel_1);
                UpdateMeter(uC_Meter2, dataObj.channel_2);

                _readings.Add(dataObj);

                while (_readings.Count > _maxReadingsBufferSize)
                {
                    _readings.RemoveAt(0);
                }

                _readingCount++;

                UpdateChart();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                UpdateStatus();
            }
        }

        /// <summary>
        /// Event handler for the Timer. It updates the status text as well as changing the 
        /// Start/Stop button if necessary.
        /// </summary>
        /// <param name="sender">The object that fired the event.</param>
        /// <param name="e">Event information related to this event.</param>
        /// <remarks>
        /// The use of a timer was to address how to know if the device was unplugged from the PC.
        /// It would be nice if the SerialPort Object had an event handler for it but it does not.
        /// </remarks>
        private void Timer1_Tick(object sender, EventArgs e)
        {
            UpdateStatus();
        }

        /// <summary>
        /// Event handler for the Tool menu item when it is opening to update the list of COM ports.
        /// </summary>
        /// <param name="sender">The object that fired the event.</param>
        /// <param name="e">Event information related to this event.</param>
        private void ToolsToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            portToolStripMenuItem.DropDownItems.Clear();

            List<COMPortInfo> comPortInfos = COMPortInfo.GetCOMPortsInfo();
            bool selectedfound = false;

            _comPortItems = new ComPortItem[comPortInfos.Count];
            int portIndex = 0;

            foreach (COMPortInfo comPortInfo in comPortInfos)
            {
                int portNumber = int.Parse(comPortInfo.Name.Substring(3));

                _comPortItems[portIndex] = new ComPortItem()
                {
                    Port = portNumber,
                    Name = comPortInfo.Name,
                    Description = comPortInfo.Description
                };

                ToolStripItem toolStripItem = portToolStripMenuItem.DropDownItems.Add(comPortInfo.Description, null, PortToolStripMenuItemPort_Click);

                if (!comPortInfo.Description.Contains(comPortInfo.Name))
                {
                    toolStripItem.Text = string.Format("{0} – {1}", comPortInfo.Name, comPortInfo.Description);
                }

                if (!string.IsNullOrEmpty(_comPortItemSelected.Name) && _comPortItemSelected.Name == comPortInfo.Name)
                {
                    ((ToolStripMenuItem)toolStripItem).Checked = true;
                }

                if (_comPortItemSelected.Description == toolStripItem.Text)
                {
                    selectedfound = true;
                }
                portIndex++;
            }

            if (!selectedfound || comPortInfos.Count == 0)
            {
                _comPortItemSelected = new ComPortItem() { Port = 0, Description = "", Name = "" };
                cmdStart.Enabled = false;
                cmdStart.Text = "Start";
            }
            else
            {
                cmdStart.Enabled = true;
            }
        }
    }
}
