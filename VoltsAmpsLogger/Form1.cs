<<<<<<< HEAD
﻿// REF: https://stackoverflow.com/questions/50076045/chart-auto-scroll-oscilloscope-effect

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

using System.IO.Ports;
using System.Collections;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

=======
>>>>>>> 0ae4f0228b8dd0c02d8207d7c7b3640f26c81c25
namespace VoltsAmpsLogger
{
    public partial class Form1 : Form
    {
<<<<<<< HEAD
        private const int _maxReadingsBufferSize = 1024;

        private ComPortItem _comPortItemSelected;
        private ComPortItem[] _comPortItems;
        private SerialPort _serialPort;
        //private Queue<Reading> _readingQueue;
        private ArrayList readings;

        private string[] _baudRates = {
            "300", "600", "1200", "2400", "4800", "9600", "14400",
            "19200", "28800", "31250", "38400", "57600", "115200"
        };

        private string _baudRateSelected = "115200";

        public Form1()
        {
            InitializeComponent();

            _comPortItemSelected = new ComPortItem() { Port = 0, Description = "", Name = "" };
            _comPortItems = null;
            //_readingQueue = new Queue<Reading>();
            readings = new ArrayList();
        }

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

        private void UpdateStatus()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(UpdateStatus), new object[] { });
                return;
            }

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
        }

        private void ConnectToComPort()
        {
            //lblComStatus.Text = "Status: Not connected";

            if (string.IsNullOrEmpty(_comPortItemSelected.Name)) { return; }

            int b = int.Parse(_baudRateSelected);

            _serialPort = new SerialPort(_comPortItemSelected.Name, int.Parse(_baudRateSelected));
            _serialPort.ReadTimeout = 5000;
            // These two required for Raspberry Pico
            // https://forum.arduino.cc/t/solved-c-win10-serial-terminal-not-receive-strings-from-pico-arduino-ide/1080783/4
            _serialPort.RtsEnable = true;
            _serialPort.DtrEnable = true;

            _serialPort.DataReceived += new SerialDataReceivedEventHandler(portDataReceived);
            _serialPort.Open();
        }

        private void portDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort port = sender as SerialPort;

            if (port == null)
            {
                return;
            }

            // AppendTextBox(port.ReadLine());

            string data = port.ReadLine();

            try
            {
                Reading dataObj = JsonSerializer.Deserialize<Reading>(data);

                if (dataObj == null) { return; }

                //_readingQueue.Enqueue((Reading)dataObj);
                dataObj.received = DateTime.Now;

                UpdateMeter(uC_Meter1, dataObj.channel_1);
                UpdateMeter(uC_Meter2, dataObj.channel_2);

                readings.Add(dataObj);

                while (readings.Count > _maxReadingsBufferSize)
                {
                    readings.RemoveAt(0);
                }

                Console.WriteLine(data);

                updateChart();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                UpdateStatus();
            }
        }

        private void UpdateMeter(UC_Meter meterCtrl, Meter meterVals)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<UC_Meter, Meter>(UpdateMeter), new object[] { meterCtrl, meterVals });
                return;
            }

            meterCtrl.Update(meterVals);
        }

        private void updateChart()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(updateChart), new object[] { });
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
            for (int pointIdx = readings.Count - 1; pointIdx > 0; pointIdx--)
            {
                if (((Reading)readings[pointIdx]).received <= zeroTime)
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

            for (int i = startDataIndex; i < readings.Count; i++)
            {
                Reading nextReading = ((Reading)readings[i]);

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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

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

        private void toolsToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
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

                ToolStripItem toolStripItem = portToolStripMenuItem.DropDownItems.Add(comPortInfo.Description, null, portToolStripMenuItemPort_Click);

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

        private void portToolStripMenuItemPort_Click(object sender, EventArgs e)
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

        private void cmdStart_Click(object sender, EventArgs e)
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateStatus();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void saveDataFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
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

                foreach (var readVals in readings)
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

        private void SaveDataFileJson(string filename)
        {
            using (StreamWriter file = new StreamWriter(filename))
            {
                file.Write(JsonSerializer.Serialize(readings, new JsonSerializerOptions { WriteIndented = true }));
            }
        }

        private void saveChartImageToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutBox1 box = new AboutBox1())
            {
                box.ShowDialog(this);
            }
        }

        private void gitHubPagesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }


    public class ComPortItem
    {
        public int Port { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class Meter
    {
        [JsonPropertyName("PowerRegister")]
        public double PowerRegister { get; set; }
        [JsonPropertyName("VIN_OUT")]
        public double VIN_OUT { get; set; }
        [JsonPropertyName("VIN_IN")]
        public double VIN_IN { get; set; }
        [JsonPropertyName("ShuntV")]
        public double ShuntV { get; set; }
        [JsonPropertyName("ShuntC")]
        public double ShuntC { get; set; }
        [JsonPropertyName("PowerCal")]
        public double PowerCal { get; set; }
    }

    public class Reading
    {
        public double time { get; set; }
        public Meter channel_1 { get; set; }
        public Meter channel_2 { get; set; }
        public DateTime received { get; set; }
    }
}
=======
        public Form1()
        {
            InitializeComponent();
        }
    }
}
>>>>>>> 0ae4f0228b8dd0c02d8207d7c7b3640f26c81c25
