using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace VoltsAmpsLogger
{
    public partial class Form2 : Form
    {
        /*********************************************************************************
         * Constants 
         *********************************************************************************/
        private const int VOLTAGE_1_SERIES_INDEX = 0;
        private const int CURRENT_1_SERIES_INDEX = 1;
        private const int VOLTAGE_2_SERIES_INDEX = 2;
        private const int CURRENT_2_SERIES_INDEX = 3;

        /*********************************************************************************
         * Fields 
         *********************************************************************************/
        private COMPortInfo _comPortItemSelected;
        private Queue<ReceivedData> _receivedLines = new Queue<ReceivedData>();
        private SerialPort _serialPort;

        private List<Reading> _readings;
        private const int _maxReadingsBufferSize = 2048;



        /*********************************************************************************
         * Class Constructor 
         *********************************************************************************/
        public Form2()
        {
            InitializeComponent();
            _readings = new List<Reading>();
        }

        /*********************************************************************************
         * Private Methods 
         *********************************************************************************/
        private void ChartChangeScale()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(ChartChangeScale), new object[] { });
                return;
            }

            ChartArea ca = chart1.ChartAreas[0];
            Series channel1Volts = chart1.Series[VOLTAGE_1_SERIES_INDEX];
            Series channel1Current = chart1.Series[CURRENT_1_SERIES_INDEX];
            Series channel2Volts = chart1.Series[VOLTAGE_2_SERIES_INDEX];
            Series channel2Current = chart1.Series[CURRENT_2_SERIES_INDEX];

            ca.AxisX.Minimum = double.Parse(txtTimeMin.Text);
            ca.AxisX.Maximum = double.Parse(txtTimeMax.Text);
            ca.AxisY.Minimum = double.Parse(txtVoltageMin.Text);
            ca.AxisY.Maximum = double.Parse(txtVoltageMax.Text);
            ca.AxisY2.Minimum = double.Parse(txtCurrentMin.Text);
            ca.AxisY2.Maximum = double.Parse(txtCurrentMax.Text);
            ca.RecalculateAxesScale();

            if (channel1Volts.Points.Count == 0)
            {
                channel1Volts.Points.AddXY(0, 0);
                channel1Current.Points.AddXY(0, 0);
                channel2Volts.Points.AddXY(0, 0);
                channel2Current.Points.AddXY(0, 0);
            }
        }

        private void ChartUpdate()
        {
            // Add received lines
            if (_receivedLines.Count > 0)
            {
                while (_receivedLines.Count > 0)
                {
                    ReceivedData data = _receivedLines.Dequeue();
                    try
                    {
                        Reading dataObj = JsonSerializer.Deserialize<Reading>(data.receivedText);

                        if (dataObj == null) { continue; }

                        dataObj.received = data.receivedDateTime;
                        _readings.Add(dataObj);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            // Limit the number of items in the ArrayList
            while (_readings.Count > _maxReadingsBufferSize)
            {
                _readings.RemoveAt(0);
            }

            // If there is no data, return
            if (_readings.Count == 0)
            {
                return;
            }

            // If chart updates are paused, return
            if (cmdPause.Text != "Pause")
            {
                return;
            }

            // Add points to the chart control
            ChartArea ca = chart1.ChartAreas[0];
            Series channel1Volts = chart1.Series[0];
            Series channel1Current = chart1.Series[1];
            Series channel2Volts = chart1.Series[2];
            Series channel2Current = chart1.Series[3];

            double secondsToDisplay = ca.Axes[0].Maximum - ca.Axes[0].Minimum;

            DateTime minTime = DateTime.Now.AddSeconds(-1 * secondsToDisplay);

            int startDataIndex = 0;

            // Find stating data point index
            for (int pointIdx = _readings.Count - 1; pointIdx > 0; pointIdx--)
            {
                if (pointIdx < _readings.Count && _readings[pointIdx].received <= minTime)
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
                Reading nextReading = _readings[i];

                double secondsValue = (nextReading.received - DateTime.Now).TotalSeconds;
                channel1Volts.Points.AddXY(secondsValue, nextReading.channel_1.VIN_OUT);
                channel1Current.Points.AddXY(secondsValue, nextReading.channel_1.ShuntC);
                channel2Volts.Points.AddXY(secondsValue, nextReading.channel_2.VIN_OUT);
                channel2Current.Points.AddXY(secondsValue, nextReading.channel_2.ShuntC);
            }

            meter1.Update(_readings[_readings.Count - 1].channel_1);
            meter2.Update(_readings[_readings.Count - 1].channel_2);
        }

        private void FindMeter()
        {
            lblMeterFoundStatus.Text = "Looking for meter";
            cmdFindMeter.Enabled = false;
            timerUpdateUI.Enabled = false;

            List<COMPortInfo> comportsList = COMPortInfo.GetCOMPortsInfo();

            // Loop through the available COM Ports
            // Send ".findmeter."
            // Wait 1 second for response
            // If ".METER-HERE." received, use port. If not move to next port
            foreach (COMPortInfo portInfo in comportsList)
            {
                _comPortItemSelected = new COMPortInfo() { Description = portInfo.Description, Name = portInfo.Name };
                SerialPortConnect(true);
                DateTime endTime = DateTime.Now.AddSeconds(2.5);
                _receivedLines.Clear();
                SerialPortSend(".findmeter.");
                bool portFound = false;
                while (!portFound && DateTime.Now < endTime)
                {
                    try
                    {
                        //Console.WriteLine(string.Format("Now ({0}) < _endTime{1}? ", DateTime.Now, endTime));
                        if (_receivedLines.Any(o => o.receivedText == ".METER-HERE."))
                        {
                            portFound = true;
                        }
                        _receivedLines.Clear();
                    }
                    catch (System.InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
                if (portFound)
                {
                    Console.WriteLine("**** Found Meter on {0} ****", _comPortItemSelected.Name);
                    break;
                }
                else
                {
                    SerialPortDisconnect();
                    _comPortItemSelected = null;
                }
            }

            FindMeterAlert();
            SerialPortDisconnect();

            cmdFindMeter.Enabled = true;

            StatusReset();
            StatusUpdate();
        }

        void FindMeterAlert()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(FindMeterAlert), new object[] { });
                return;
            }

            string message = "Did not find meter. Make certain that it is connected.";
            if (_comPortItemSelected != null)
            {
                message = String.Format("Meter found on {0}", _comPortItemSelected.Name);
            }

            lblMeterFoundStatus.Text = message;
            MessageBox.Show(this, message, "Find Meter", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    Reading reading = readVals;

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
        /// Opens the selected COM port that is saved in the _comPortItemSelected variable's Name property.
        /// </summary>
        /// <remarks>
        /// The Raspberry Pi Pico requires both Request to Send (RTS) and Data Terminal Ready (DTR) to be enabled.
        /// It took a couple of hours to find that this was necessary.
        /// </remarks>
        private void SerialPortConnect(bool suppressErrors = false)
        {
            if (_comPortItemSelected == null || string.IsNullOrEmpty(_comPortItemSelected.Name)) { return; }

            timerUpdateUI.Enabled = false;

            SerialPortDisconnect();

            StatusReset();

            _serialPort = new SerialPort(_comPortItemSelected.Name)
            {
                ReadTimeout = 2000,
                WriteTimeout = 2000,
                // These two required for Raspberry Pico
                // https://forum.arduino.cc/t/solved-c-win10-serial-terminal-not-receive-strings-from-pico-arduino-ide/1080783/4
                RtsEnable = true,
                DtrEnable = true
            };

            _serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPort_DataReceived);
            try
            {
                _serialPort.Open();
            }
            catch (System.UnauthorizedAccessException ex)
            {
                if (!suppressErrors)
                {
                    MessageBox.Show(this, string.Format("ERROR: {0} Port is in use.", _comPortItemSelected.Name),
                        "Failed to Open Port", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Console.WriteLine(ex.Message);
            }

            StatusUpdate();
        }

        /// <summary>
        /// Disconnect from the serial port if connected.
        /// </summary>
        private void SerialPortDisconnect()
        {
            if (_serialPort != null)
            {
                if (_serialPort.IsOpen)
                {
                    string cmdToSend = string.Format(".{0}{1}.", "d", "o");
                    SerialPortSend(cmdToSend);
                }

                _serialPort.Close();
                _serialPort = null;
            }
        }

        private void SerialPortSend(string message, bool sendCrLf = false)
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                string stringToSend = message + (sendCrLf ? "\r\n" : "");
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

        private void StatusReset()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(StatusReset), new object[] { });
                return;
            }

        }

        private void StatusUpdate()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(StatusUpdate), new object[] { });
                return;
            }

            timerUpdateUI.Enabled = false;

            // Update connected status
            bool connected = _serialPort != null && _serialPort.IsOpen;

            if (connected)
            {
                lblComStatus.Text = "Status: Connected";
                cmdStart.Text = "Stop";
                cmdPause.Enabled = true;

                ChartUpdate();
            }
            else
            {
                lblComStatus.Text = "Status: Not connected";
                cmdStart.Text = "Start";
                cmdPause.Enabled = false;

                List<COMPortInfo> currentPorts = COMPortInfo.GetCOMPortsInfo();
                COMPortInfo selectedCom = null;

                if (_comPortItemSelected != null && !string.IsNullOrEmpty(_comPortItemSelected.Name))
                {
                    selectedCom = currentPorts.Where(i => i.Name == _comPortItemSelected.Name).FirstOrDefault();
                }

                // Update COM Port list
                if (cbPort.Items.Count != currentPorts.Count)
                {
                    cbPort.Text = "";
                    cbPort.Items.Clear();
                    foreach (COMPortInfo port in currentPorts)
                    {
                        int itemIdx = cbPort.Items.Add(port);

                        if (selectedCom != null && cbPort.Items[itemIdx] == selectedCom)
                        {
                            cbPort.SelectedIndex = itemIdx;
                        }
                    }
                }

                // Clear selected COM if it was unplugged
                if (_comPortItemSelected != null && !string.IsNullOrEmpty(_comPortItemSelected.Name))
                {
                    // Check if Selected COM port still exists
                    if (selectedCom == null)
                    {
                        _comPortItemSelected = null;
                    }
                }

                if (_comPortItemSelected == null)
                {
                    cmdStart.Enabled = false;
                }
            }

            if (_serialPort == null || !_serialPort.IsOpen)
            {
                timerUpdateUI.Enabled = false;
            }
            else
            {
                timerUpdateUI.Enabled = true;
            }
        }


        /*********************************************************************************
         * Event Handlers 
         *********************************************************************************/
        /// <summary>
        /// Help > About menu item clicked. Show the about dialog
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
        /// Sets the Selected COM Port when item is selected.
        /// </summary>
        /// <param name="sender">The object that fired the event.</param>
        /// <param name="e">Event information related to this event.</param>
        private void CbPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdStart.Enabled = false;

            if (cbPort.SelectedIndex > -1)
            {
                cmdStart.Enabled = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">The object that fired the event.</param>
        /// <param name="e">Event information related to this event.</param>
        private void CmdFindMeter_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            FindMeter();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">The object that fired the event.</param>
        /// <param name="e">Event information related to this event.</param>
        private void CmdHideShow_Click(object sender, EventArgs e)
        {
            if (splitContainer1.Panel2Collapsed)
            {
                splitContainer1.Panel2Collapsed = false;
                cmdHideShow.Text = ">";
            }
            else
            {
                splitContainer1.Panel2Collapsed = true;
                cmdHideShow.Text = "<";
            }
        }

        private void CmdPause_Click(object sender, EventArgs e)
        {
            Button me = (Button)sender;

            if (me.Text == "Pause")
            {
                me.Text = "Resume";
            }
            else
            {
                me.Text = "Pause";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">The object that fired the event.</param>
        /// <param name="e">Event information related to this event.</param>
        private void CmdStart_Click(object sender, EventArgs e)
        {
            Button me = (Button)sender;

            if (me.Text == "Start")
            {
                cmdPause.Text = "Pause";
                _comPortItemSelected = (COMPortInfo)cbPort.SelectedItem;
                SerialPortConnect();
            }
            else
            {
                cmdPause.Text = "Pause";
                SerialPortDisconnect();
            }

            // Send command
            if (_serialPort != null && _serialPort.IsOpen)
            {
                RadioButton checkedButton = grpFormat.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);

                if (checkedButton != null)
                {
                    switch (checkedButton.Tag.ToString().ToLower())
                    {
                        case "json":
                            SerialPortSend(".j.");
                            break;
                        case "tab":
                            SerialPortSend(".t.");
                            break;
                        default:
                            break;
                    }
                }

                string display = chkDisplay.Checked ? "d" : "o";
                string serial = chkSerial.Checked ? "s" : "o";
                string cmdToSend = string.Format(".{0}{1}.", display, serial);

                SerialPortSend(cmdToSend);
            }

            StatusUpdate();
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
            //else
            //{
            //    // Console app
            //    Environment.Exit(1);
            //}
        }

        /// <summary>
        /// When the form closes, put the meter in display only mode.
        /// </summary>
        /// <param name="sender">The object that fired the event.</param>
        /// <param name="e">Event information related to this event.</param>
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            SerialPortDisconnect();
        }

        /// <summary>
        /// Event handler for when the form loads.
        /// </summary>
        /// <param name="sender">The object that fired the event.</param>
        /// <param name="e">Event information related to this event.</param>
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Event handler for when the form is first shown.
        /// </summary>
        /// <param name="sender">The object that fired the event.</param>
        /// <param name="e">Event information related to this event.</param>
        private void Form2_Shown(object sender, EventArgs e)
        {
            PanChartButtons_Resize(panChartButtons, null);
            ChartChangeScale();
            this.Cursor = Cursors.WaitCursor;
            FindMeter();
            this.Cursor = Cursors.Default;
        }

        private void GitHubPagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = "https://richteel.github.io/VoltsAmpsLogger/";

            System.Diagnostics.Process.Start(url);
        }

        private void HacksterioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = "https://www.hackster.io/richjteel/dual-channel-voltage-and-current-monitor-e829df";

            System.Diagnostics.Process.Start(url);
        }

        private void PanChartButtons_Resize(object sender, EventArgs e)
        {
            cmdStart.Width = panChartButtons.Width / 2;
        }

        private void SaveChartImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // PNG file|*.png|JPG file|*.jpg|GIF file|*.gif|BMP file|*.bmp|TIFF file|*'tiff
            if (saveFileChartImage.ShowDialog(this) == DialogResult.OK)
            {
                switch (saveFileChartImage.FilterIndex)
                {
                    case 1: // PNG
                        chart1.SaveImage(saveFileChartImage.FileName, ChartImageFormat.Png);
                        break;
                    case 2: // JPG
                        chart1.SaveImage(saveFileChartImage.FileName, ChartImageFormat.Jpeg);
                        break;
                    case 3: // GIF
                        chart1.SaveImage(saveFileChartImage.FileName, ChartImageFormat.Gif);
                        break;
                    case 4: // BMP
                        chart1.SaveImage(saveFileChartImage.FileName, ChartImageFormat.Bmp);
                        break;
                    case 5: // TIFF
                        chart1.SaveImage(saveFileChartImage.FileName, ChartImageFormat.Tiff);
                        break;
                    default:    // Unknown
                        throw new NotImplementedException();
                }
            }
        }

        private void SaveDataFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // CSV file|*.csv|Tab Delimited Text file|*.txt|JSON file|*.json
            if (saveFileData.ShowDialog(this) == DialogResult.OK)
            {
                switch (saveFileData.FilterIndex)
                {
                    case 1: // CSV
                        SaveDataFileDelimited(saveFileData.FileName, ",");
                        break;
                    case 2: // Text (Tab Delimited)
                        SaveDataFileDelimited(saveFileData.FileName, "\t");
                        break;
                    case 3: // JSON
                        SaveDataFileJson(saveFileData.FileName);
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

            _receivedLines.Enqueue(new ReceivedData(data));
        }

        private void TeelSysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = "https://teelsys.com/";

            System.Diagnostics.Process.Start(url);
        }

        private void TimerUpdateUI_Tick(object sender, EventArgs e)
        {
            StatusUpdate();
        }

        private void TxtChartSetting_Validating(object sender, CancelEventArgs e)
        {
            TextBox txtBox = (TextBox)sender;
            lblChartMinMaxError.Visible = false;
            lblChartMinMaxError.Text = string.Format("ERROR: Enter numeric value for: {0}", txtBox.Tag);
            if (!double.TryParse(txtBox.Text, out _))
            {
                e.Cancel = true;
                lblChartMinMaxError.Visible = true;
                return;
            }

            double min = 0;
            double max = 0;
            bool isMin = txtBox.Name.Contains("Min");
            string item = txtBox.Tag.ToString().Split(' ')[1];

            if (isMin)
            {
                lblChartMinMaxError.Text = string.Format("ERROR: Min must be less than max for: {0}", item);
                min = double.Parse(txtBox.Text);
                TextBox txtBox2 = (TextBox)this.Controls.Find(txtBox.Name.Replace("Min", "Max"), true).FirstOrDefault();
                max = double.Parse(txtBox2.Text);
            }
            else
            {
                lblChartMinMaxError.Text = string.Format("ERROR: Max must be greater than min for: {0}", item);
                max = double.Parse(txtBox.Text);
                TextBox txtBox2 = (TextBox)this.Controls.Find(txtBox.Name.Replace("Max", "Min"), true).FirstOrDefault();
                min = double.Parse(txtBox2.Text);
            }

            if (min > max || min == max)
            {
                lblChartMinMaxError.Visible = true;
                e.Cancel = true;
                return;
            }

            ChartChangeScale();
        }

        private void TxtChartSetting_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txtBox = sender as TextBox;

            if (e.KeyChar == '\r')
            {
                TxtChartSetting_Validating(txtBox, new CancelEventArgs());
            }
        }
    }
}
