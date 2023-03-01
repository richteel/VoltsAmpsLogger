using DualVoltAmpMeter.Comms;
using DualVoltAmpMeter.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;
using System.Windows.Forms.DataVisualization.Charting;

namespace DualVoltAmpMeter
{
    public partial class frmMain : Form
    {
        /*********************************************************************************
         * Constants 
         *********************************************************************************/
        private const int VOLTAGE_1_SERIES_INDEX = 0;
        private const int CURRENT_1_SERIES_INDEX = 1;
        private const int VOLTAGE_2_SERIES_INDEX = 2;
        private const int CURRENT_2_SERIES_INDEX = 3;

        private const int FINDMETER_WAIT_SECONDS = 10;

        /*********************************************************************************
         * Fields 
         *********************************************************************************/
        private List<MeterConnection> _meterConnections = new List<MeterConnection>();
        private MeterConnection _meterConnection;
        private string _settingFile;
        private AppSettings _appSettings;
        private int _maxMeterReadings = 2048;
        private DateTime _lastread = DateTime.MinValue;
        private DateTime _findTimeout = DateTime.MinValue;

        /*********************************************************************************
         * Class Constructor 
         *********************************************************************************/
        public frmMain()
        {
            InitializeComponent();

            _settingFile = Path.ChangeExtension(Application.ExecutablePath, "json");
            _appSettings = new AppSettings();
        }

        /*********************************************************************************
         * Private Methods 
         *********************************************************************************/
        private void ChartChangeScale()
        {
            ChartArea ca = chart1.ChartAreas[0];
            Series channel1Volts = chart1.Series[VOLTAGE_1_SERIES_INDEX];
            Series channel1Current = chart1.Series[CURRENT_1_SERIES_INDEX];
            Series channel2Volts = chart1.Series[VOLTAGE_2_SERIES_INDEX];
            Series channel2Current = chart1.Series[CURRENT_2_SERIES_INDEX];

            ChartSettings chartSettings = meterChartSettings1.Settings;

            ca.AxisX.Minimum = chartSettings.TimeMin;
            ca.AxisX.Maximum = chartSettings.TimeMax;
            ca.AxisY.Minimum = chartSettings.VoltageMin;
            ca.AxisY.Maximum = chartSettings.VoltageMax;
            ca.AxisY2.Minimum = chartSettings.CurrentMin;
            ca.AxisY2.Maximum = chartSettings.CurrentMax;
            ca.RecalculateAxesScale();

            if (channel1Volts.Points.Count == 0)
            {
                channel1Volts.Points.AddXY(0, 0);
                channel1Current.Points.AddXY(0, 0);
                channel2Volts.Points.AddXY(0, 0);
                channel2Current.Points.AddXY(0, 0);
            }
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

                foreach (var readVals in _meterConnection.MeterReadings.ToList())
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
                file.Write(JsonSerializer.Serialize(_meterConnection.MeterReadings, new JsonSerializerOptions { WriteIndented = true }));
            }
        }

        private void SaveSettings()
        {
            if (WindowState == FormWindowState.Normal)
            {
                _appSettings.WindowHeight = Height;
                _appSettings.WindowLeft = Left;
                _appSettings.WindowTop = Top;
                _appSettings.WindowWidth = Width;
            }
            _appSettings.WindowState = WindowState;

            _appSettings.OptionPanelCollapsed = splitContainer1.Panel1Collapsed;
            _appSettings.OptionPanelSplitterDistance = splitContainer1.SplitterDistance;
            _appSettings.OptionPanelTabIndex = tabControl1.SelectedIndex;

            if (meterChartSettings1.Settings.Validate())
            {
                _appSettings.MeterChartSettings = meterChartSettings1.Settings;
            }

            _appSettings.MeterMaxReadings = _maxMeterReadings;

            string json = JsonSerializer.Serialize(_appSettings);
            File.WriteAllText(_settingFile, json);
        }

        private void UpdateMeterConnectionInfo()
        {
            meterInfo1.UpdateInfo(_meterConnection);

            string connStatus = (_meterConnection != null && _meterConnection.MeterConnected) ? "Connected" : "Not Connected";
            if (_meterConnection != null && _meterConnection.ComPort != null)
            {
                Console.WriteLine("Meter Connection changed on " + _meterConnection.ComPort.Name + " to " + connStatus);
            }

            lblComStatus.Text = connStatus;
            lblMeterFoundStatus.Text = (_meterConnection != null && _meterConnection.MeterConnected) ? "Meter on " + _meterConnection.ComPort.Name : "Meter not found";
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
            using (frmAbout box = new frmAbout())
            {
                box.ShowDialog(this);
            }
        }

        private void cmdFindMeter_Click(object sender, EventArgs e)
        {
            timerFindMeter.Enabled = false;

            if (_meterConnection != null && _meterConnection.MeterConnected)
            {
                cmdFindMeter.Enabled = false;
                return;
            }

            timerUiUpdate.Enabled = false;
            _lastread = DateTime.MinValue;
            cmdFindMeter.Enabled = false;
            this.Cursor = Cursors.WaitCursor;

            _meterConnection?.Dispose();
            _meterConnection = null;

            UpdateMeterConnectionInfo();

            if (_meterConnections.Count > 0)
            {
                foreach (MeterConnection conn in _meterConnections)
                {
                    conn.Dispose();
                }
            }

            List<ComPortItem> ports = ComPortItem.GetCOMPortsInfo();
            _meterConnections = new List<MeterConnection>();

            foreach (ComPortItem port in ports)
            {
                MeterConnection mConn = new MeterConnection(port) {
                    MeterReadingsMaxCount = _maxMeterReadings
                };
                mConn.ConnectStatusChanged += Meter_ConnectedStatusChanged;
                mConn.MeterInfoChanged += Meter_MeterInfoChanged;

                _meterConnections.Add(mConn);
                mConn.CheckIfMeterIsConnected();
            }

            _findTimeout = DateTime.Now.AddSeconds(FINDMETER_WAIT_SECONDS);
            timerFindMeter.Enabled = true;
        }

        /// <summary>
        /// Hide and show the settings side panel
        /// </summary>
        /// <param name="sender">The object that fired the event.</param>
        /// <param name="e">Event information related to this event.</param>
        private void CmdHideShow_Click(object sender, EventArgs e)
        {
            if (splitContainer1.Panel1Collapsed)
            {
                splitContainer1.Panel1Collapsed = false;
                cmdHideShow.Text = "<";
            }
            else
            {
                splitContainer1.Panel1Collapsed = true;
                cmdHideShow.Text = ">";
            }
        }

        private void CmdPause_Click(object sender, EventArgs e)
        {
            timerUiUpdate.Enabled = !timerUiUpdate.Enabled;

            cmdPause.Text = timerUiUpdate.Enabled? "Pause" : "Resume";
        }

        /// <summary>
        /// Event handler for the File > Exit menu item. It ends the application.
        /// </summary>
        /// <param name="sender">The object that fired the event.</param>
        /// <param name="e">Event information related to this event.</param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_meterConnection != null && _meterConnection.MeterConnected)
            {
                _meterConnection.Dispose();
                _meterConnection = null;
            }

            SaveSettings();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            bool loadDefaults = false;
            bool settingsFileExists = File.Exists(_settingFile);

            if ((ModifierKeys & Keys.Shift) != 0 || !settingsFileExists)
            {
                loadDefaults = true;
            }

            if (!loadDefaults)
            {
                using (StreamReader r = new StreamReader(_settingFile))
                {
                    string json = r.ReadToEnd();
                    try
                    {
                        _appSettings = JsonSerializer.Deserialize<AppSettings>(json);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        Console.WriteLine("Loading default settings");
                        _appSettings = new AppSettings();
                    }
                }
            }

            Height = _appSettings.WindowHeight;
            Left = _appSettings.WindowLeft;
            Top = _appSettings.WindowTop;
            Width = _appSettings.WindowWidth;
            WindowState = _appSettings.WindowState;

            splitContainer1.Panel1Collapsed = _appSettings.OptionPanelCollapsed;
            splitContainer1.SplitterDistance = _appSettings.OptionPanelSplitterDistance;
            tabControl1.SelectedIndex = _appSettings.OptionPanelTabIndex;

            meterChartSettings1.Settings = _appSettings.MeterChartSettings;
            _maxMeterReadings = _appSettings.MeterMaxReadings;

            ChartChangeScale();

            cmdFindMeter_Click(cmdFindMeter, null);
        }

        /// <summary>
        /// Event handler for the Help > GitHub Pages menu item.
        /// It opens the browser and navigates to the Dual Volt Amp Meter project page on the GitHub Pages.
        /// </summary>
        /// <param name="sender">The object that fired the event.</param>
        /// <param name="e">Event information related to this event.</param>
        private void GitHubPagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = "https://richteel.github.io/VoltsAmpsLogger/";

            System.Diagnostics.Process.Start(url);
        }

        /// <summary>
        /// Event handler for the Help > hackster.io menu item.
        /// It opens the browser and navigates to the Dual Volt Amp Meter project page on the hackster.io.
        /// </summary>
        /// <param name="sender">The object that fired the event.</param>
        /// <param name="e">Event information related to this event.</param>
        private void HacksterioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = "https://www.hackster.io/richjteel/dual-channel-voltage-and-current-monitor-e829df";

            System.Diagnostics.Process.Start(url);
        }

        private void Meter_ConnectedStatusChanged(object sender, MeterConnectionEventArgs e)
        {
            if (InvokeRequired || !IsHandleCreated)
            {
                Invoke(new Action<object, MeterConnectionEventArgs>(Meter_ConnectedStatusChanged), new object[] { sender, e });
                return;
            }

            string connStatus = e.Connected ? "Connected" : "Not Connected";
            if (e.ComPort != null)
            {
                Console.WriteLine("Meter Connection changed on " + e.ComPort.Name + " to " + connStatus);
            }

            lblComStatus.Text = connStatus;
            lblMeterFoundStatus.Text = e.Connected ? "Meter on " + e.ComPort.Name : "Meter not found";
        }

        private void Meter_MeterInfoChanged(object sender, EventArgs e)
        {
            if (InvokeRequired || !IsHandleCreated)
            {
                Invoke(new Action<object, EventArgs>(Meter_MeterInfoChanged), new object[] { sender, e });
                return;
            }

            UpdateMeterConnectionInfo();
        }

        private void MeterChartSettings1_SettingsChanged(object sender, EventArgs e)
        {
            if (InvokeRequired || !IsHandleCreated)
            {
                Invoke(new Action<object, EventArgs>(MeterChartSettings1_SettingsChanged), new object[] { sender, e });
                return;
            }

            ChartChangeScale();
        }

        /// <summary>
        /// Event handler for the File > Save Chart Image menu item.
        /// Saves the currently displayed chart as an image.
        /// </summary>
        /// <param name="sender">The object that fired the event.</param>
        /// <param name="e">Event information related to this event.</param>
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
                        throw new Exception("Unknown FilterIndex while saving chart image file");
                }
            }
        }

        /// <summary>
        /// Event handler for the File > Save Data File menu item.
        /// Saves the reading buffer data to a text file.
        /// </summary>
        /// <param name="sender">The object that fired the event.</param>
        /// <param name="e">Event information related to this event.</param>
        private void SaveDataFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_meterConnection == null || _meterConnection.MeterReadings == null || _meterConnection.MeterReadings.Count == 0)
            {
                MessageBox.Show(this, "No data to save.", "ERROR: No Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
                        throw new Exception("Unknown FilterIndex while saving data file");
                }
            }
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateMeterConnectionInfo();
        }

        /// <summary>
        /// Event handler for the Help > TeelSys menu item.
        /// It opens the browser and navigates to the TeelSys website.
        /// </summary>
        /// <param name="sender">The object that fired the event.</param>
        /// <param name="e">Event information related to this event.</param>
        private void TeelSysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = "https://teelsys.com/";

            System.Diagnostics.Process.Start(url);
        }

        private void TimerFindMeter_Tick(object sender, EventArgs e)
        {
            timerFindMeter.Enabled = false;

            foreach (MeterConnection conn in _meterConnections)
            {
                if (conn.MeterConnected && _meterConnection == null)
                {
                    _meterConnection = conn;
                    Console.WriteLine("frmMain - Found meter on " + conn.ComPort.Name);
                }
                else
                {
                    conn.Dispose();
                }
            }

            if (_meterConnection == null && DateTime.Now < _findTimeout)
            {
                timerFindMeter.Enabled = true;
                return;
            }

            Console.WriteLine("Clearing Connections");
            _meterConnections.Clear();

            if (_meterConnection == null)
            {
                cmdFindMeter.Enabled = true;
            }

            this.Cursor = Cursors.Default;

            if (_meterConnection != null)
            {
                _meterConnection.StartMonitoring();
                timerUiUpdate.Enabled = true;
            }
            else
            {
                MessageBox.Show(this, "Meter not found.\r\nClick the \"Find Meter\" button on " +
                    "the \"Meter Info\" tab once the meter is connected to try again.", "Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            UpdateMeterConnectionInfo();
        }

        private void TimerUiUpdate_Tick(object sender, EventArgs e)
        {
            // If there is no data, return
            if (_meterConnection == null || _meterConnection.MeterReadings == null || _meterConnection.MeterReadings.Count == 0)
            {
                return;
            }

            // Add points to the chart control
            ChartArea ca = chart1.ChartAreas[0];
            Series channel1Volts = chart1.Series[VOLTAGE_1_SERIES_INDEX];
            Series channel1Current = chart1.Series[CURRENT_1_SERIES_INDEX];
            Series channel2Volts = chart1.Series[VOLTAGE_2_SERIES_INDEX];
            Series channel2Current = chart1.Series[CURRENT_2_SERIES_INDEX];

            double secondsToDisplay = ca.Axes[0].Maximum - ca.Axes[0].Minimum;

            DateTime minTime = DateTime.Now.AddSeconds(-1 * secondsToDisplay);

            int startDataIndex = 0;

            // Find stating data point index
            for (int pointIdx = _meterConnection.MeterReadings.Count - 1; pointIdx > 0; pointIdx--)
            {
                if (pointIdx < _meterConnection.MeterReadings.Count && _meterConnection.MeterReadings[pointIdx].received <= minTime)
                {
                    startDataIndex = pointIdx;
                    break;
                }
            }
            channel1Volts.Points.Clear();
            channel1Current.Points.Clear();
            channel2Volts.Points.Clear();
            channel2Current.Points.Clear();

            for (int i = startDataIndex; i < _meterConnection.MeterReadings.Count; i++)
            {
                Reading nextReading = _meterConnection.MeterReadings[i];

                double secondsValue = (nextReading.received - DateTime.Now).TotalSeconds;
                channel1Volts.Points.AddXY(secondsValue, nextReading.channel_1.VIN_OUT);
                channel1Current.Points.AddXY(secondsValue, nextReading.channel_1.ShuntC);
                channel2Volts.Points.AddXY(secondsValue, nextReading.channel_2.VIN_OUT);
                channel2Current.Points.AddXY(secondsValue, nextReading.channel_2.ShuntC);
            }

            meterChannel1.Update(_meterConnection.MeterReadings[_meterConnection.MeterReadings.Count - 1].channel_1);
            meterChannel2.Update(_meterConnection.MeterReadings[_meterConnection.MeterReadings.Count - 1].channel_2);

            _lastread = _meterConnection.MeterReadings[_meterConnection.MeterReadings.Count - 1].received;

            // If no reading have been received in 10 seconds, then assume that the meter has been unplugged,
            // so start looking for it again.
            if ((DateTime.Now - _lastread).TotalSeconds > 10)
            {
                timerUiUpdate.Enabled = false;
                _meterConnection.Dispose();
                _meterConnection = null;

                cmdFindMeter_Click(cmdFindMeter, null);
            }
        }
    }
}
