namespace VoltsAmpsLogger
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.timerUpdateUI = new System.Windows.Forms.Timer(this.components);
            this.saveFileData = new System.Windows.Forms.SaveFileDialog();
            this.saveFileChartImage = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDataFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveChartImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serialPortAdvancedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.teelSysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gitHubPagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hacksterioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblComStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSpring = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblMeterFoundStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panChartButtons = new System.Windows.Forms.Panel();
            this.cmdPause = new System.Windows.Forms.Button();
            this.cmdStart = new System.Windows.Forms.Button();
            this.cmdHideShow = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageMeters = new System.Windows.Forms.TabPage();
            this.tabPageChartSettings = new System.Windows.Forms.TabPage();
            this.lblChartMinMaxError = new System.Windows.Forms.Label();
            this.panCurrent = new System.Windows.Forms.Panel();
            this.panCurrentMax = new System.Windows.Forms.Panel();
            this.lblAmpsMax = new System.Windows.Forms.Label();
            this.txtCurrentMax = new System.Windows.Forms.TextBox();
            this.lblCurrentMax = new System.Windows.Forms.Label();
            this.panCurrentMin = new System.Windows.Forms.Panel();
            this.lblAmpsMin = new System.Windows.Forms.Label();
            this.txtCurrentMin = new System.Windows.Forms.TextBox();
            this.lblCurrentMin = new System.Windows.Forms.Label();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.panVoltage = new System.Windows.Forms.Panel();
            this.panVoltageMax = new System.Windows.Forms.Panel();
            this.lblVoltsMax = new System.Windows.Forms.Label();
            this.txtVoltageMax = new System.Windows.Forms.TextBox();
            this.lblVoltageMax = new System.Windows.Forms.Label();
            this.panVoltageMin = new System.Windows.Forms.Panel();
            this.lblVoltsMin = new System.Windows.Forms.Label();
            this.txtVoltageMin = new System.Windows.Forms.TextBox();
            this.lblVoltageMin = new System.Windows.Forms.Label();
            this.lblVoltage = new System.Windows.Forms.Label();
            this.panTime = new System.Windows.Forms.Panel();
            this.panTimeMax = new System.Windows.Forms.Panel();
            this.lblSecondsMax = new System.Windows.Forms.Label();
            this.txtTimeMax = new System.Windows.Forms.TextBox();
            this.labTimeMax = new System.Windows.Forms.Label();
            this.panTimeMin = new System.Windows.Forms.Panel();
            this.lblSecondsMin = new System.Windows.Forms.Label();
            this.txtTimeMin = new System.Windows.Forms.TextBox();
            this.labTimeMin = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.tabPagePort = new System.Windows.Forms.TabPage();
            this.grpFormat = new System.Windows.Forms.GroupBox();
            this.rbTextTab = new System.Windows.Forms.RadioButton();
            this.rbJson = new System.Windows.Forms.RadioButton();
            this.grpOptions = new System.Windows.Forms.GroupBox();
            this.chkSerial = new System.Windows.Forms.CheckBox();
            this.chkDisplay = new System.Windows.Forms.CheckBox();
            this.cmdFindMeter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panPort = new System.Windows.Forms.Panel();
            this.cbPort = new System.Windows.Forms.ComboBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblInstruction = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.meter2 = new VoltsAmpsLogger.UC_Meter();
            this.meter1 = new VoltsAmpsLogger.UC_Meter();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panChartButtons.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageMeters.SuspendLayout();
            this.tabPageChartSettings.SuspendLayout();
            this.panCurrent.SuspendLayout();
            this.panCurrentMax.SuspendLayout();
            this.panCurrentMin.SuspendLayout();
            this.panVoltage.SuspendLayout();
            this.panVoltageMax.SuspendLayout();
            this.panVoltageMin.SuspendLayout();
            this.panTime.SuspendLayout();
            this.panTimeMax.SuspendLayout();
            this.panTimeMin.SuspendLayout();
            this.tabPagePort.SuspendLayout();
            this.grpFormat.SuspendLayout();
            this.grpOptions.SuspendLayout();
            this.panPort.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerUpdateUI
            // 
            this.timerUpdateUI.Interval = 250;
            this.timerUpdateUI.Tick += new System.EventHandler(this.TimerUpdateUI_Tick);
            // 
            // saveFileData
            // 
            this.saveFileData.FileName = "ScopeData";
            this.saveFileData.Filter = "CSV file|*.csv|Tab Delimited Text file|*.txt|JSON file|*.json";
            this.saveFileData.Title = "Save Data File";
            // 
            // saveFileChartImage
            // 
            this.saveFileChartImage.FileName = "ScopeImage";
            this.saveFileChartImage.Filter = "PNG file|*.png|JPG file|*.jpg|GIF file|*.gif|BMP file|*.bmp|TIFF file|*\\\'tiff";
            this.saveFileChartImage.Title = "Save Chart Image";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveDataFileToolStripMenuItem,
            this.saveChartImageToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // saveDataFileToolStripMenuItem
            // 
            this.saveDataFileToolStripMenuItem.Name = "saveDataFileToolStripMenuItem";
            this.saveDataFileToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.saveDataFileToolStripMenuItem.Text = "Save &Data File";
            this.saveDataFileToolStripMenuItem.Click += new System.EventHandler(this.SaveDataFileToolStripMenuItem_Click);
            // 
            // saveChartImageToolStripMenuItem
            // 
            this.saveChartImageToolStripMenuItem.Name = "saveChartImageToolStripMenuItem";
            this.saveChartImageToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.saveChartImageToolStripMenuItem.Text = "Save &Chart Image";
            this.saveChartImageToolStripMenuItem.Click += new System.EventHandler(this.SaveChartImageToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(163, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serialPortAdvancedToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            this.toolsToolStripMenuItem.Visible = false;
            // 
            // serialPortAdvancedToolStripMenuItem
            // 
            this.serialPortAdvancedToolStripMenuItem.Name = "serialPortAdvancedToolStripMenuItem";
            this.serialPortAdvancedToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.serialPortAdvancedToolStripMenuItem.Text = "Serial Port &Advanced Options";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.toolStripMenuItem2,
            this.teelSysToolStripMenuItem,
            this.gitHubPagesToolStripMenuItem,
            this.hacksterioToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(143, 6);
            // 
            // teelSysToolStripMenuItem
            // 
            this.teelSysToolStripMenuItem.Name = "teelSysToolStripMenuItem";
            this.teelSysToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.teelSysToolStripMenuItem.Text = "&TeelSys";
            this.teelSysToolStripMenuItem.Click += new System.EventHandler(this.TeelSysToolStripMenuItem_Click);
            // 
            // gitHubPagesToolStripMenuItem
            // 
            this.gitHubPagesToolStripMenuItem.Name = "gitHubPagesToolStripMenuItem";
            this.gitHubPagesToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.gitHubPagesToolStripMenuItem.Text = "&GitHub Pages";
            this.gitHubPagesToolStripMenuItem.Click += new System.EventHandler(this.GitHubPagesToolStripMenuItem_Click);
            // 
            // hacksterioToolStripMenuItem
            // 
            this.hacksterioToolStripMenuItem.Name = "hacksterioToolStripMenuItem";
            this.hacksterioToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.hacksterioToolStripMenuItem.Text = "&hackster.io";
            this.hacksterioToolStripMenuItem.Click += new System.EventHandler(this.HacksterioToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblComStatus,
            this.lblSpring,
            this.lblMeterFoundStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblComStatus
            // 
            this.lblComStatus.AutoSize = false;
            this.lblComStatus.Name = "lblComStatus";
            this.lblComStatus.Size = new System.Drawing.Size(180, 17);
            this.lblComStatus.Text = "Status: Not Connected";
            // 
            // lblSpring
            // 
            this.lblSpring.Name = "lblSpring";
            this.lblSpring.Size = new System.Drawing.Size(511, 17);
            this.lblSpring.Spring = true;
            // 
            // lblMeterFoundStatus
            // 
            this.lblMeterFoundStatus.Name = "lblMeterFoundStatus";
            this.lblMeterFoundStatus.Size = new System.Drawing.Size(94, 17);
            this.lblMeterFoundStatus.Text = "Meter not found";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.chart1);
            this.splitContainer1.Panel1.Controls.Add(this.panChartButtons);
            this.splitContainer1.Panel1.Controls.Add(this.cmdHideShow);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(800, 404);
            this.splitContainer1.SplitterDistance = 506;
            this.splitContainer1.TabIndex = 4;
            // 
            // chart1
            // 
            chartArea1.AxisX.Maximum = 20D;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX.Title = "Time (s)";
            chartArea1.AxisY.Title = "Volts (V)";
            chartArea1.AxisY2.Title = "Current (A)";
            chartArea1.BackColor = System.Drawing.Color.Silver;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.BackColor = System.Drawing.Color.Silver;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.Red;
            series1.Legend = "Legend1";
            series1.Name = "Channel 1 - Volts";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Color = System.Drawing.Color.Green;
            series2.Legend = "Legend1";
            series2.Name = "Channel 1 - Amps";
            series2.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Color = System.Drawing.Color.Blue;
            series3.Legend = "Legend1";
            series3.Name = "Channel 2 - Volts";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series4.Color = System.Drawing.Color.Yellow;
            series4.Legend = "Legend1";
            series4.Name = "Channel 2 - Amps";
            series4.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(488, 379);
            this.chart1.TabIndex = 7;
            this.chart1.Text = "chart1";
            // 
            // panChartButtons
            // 
            this.panChartButtons.Controls.Add(this.cmdPause);
            this.panChartButtons.Controls.Add(this.cmdStart);
            this.panChartButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panChartButtons.Location = new System.Drawing.Point(0, 379);
            this.panChartButtons.Name = "panChartButtons";
            this.panChartButtons.Size = new System.Drawing.Size(488, 25);
            this.panChartButtons.TabIndex = 6;
            this.panChartButtons.Resize += new System.EventHandler(this.PanChartButtons_Resize);
            // 
            // cmdPause
            // 
            this.cmdPause.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdPause.Enabled = false;
            this.cmdPause.Location = new System.Drawing.Point(100, 0);
            this.cmdPause.Name = "cmdPause";
            this.cmdPause.Size = new System.Drawing.Size(388, 25);
            this.cmdPause.TabIndex = 3;
            this.cmdPause.Text = "Pause";
            this.cmdPause.UseVisualStyleBackColor = true;
            this.cmdPause.Click += new System.EventHandler(this.CmdPause_Click);
            // 
            // cmdStart
            // 
            this.cmdStart.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmdStart.Location = new System.Drawing.Point(0, 0);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(100, 25);
            this.cmdStart.TabIndex = 2;
            this.cmdStart.Text = "Start";
            this.cmdStart.UseVisualStyleBackColor = true;
            this.cmdStart.Click += new System.EventHandler(this.CmdStart_Click);
            // 
            // cmdHideShow
            // 
            this.cmdHideShow.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmdHideShow.Location = new System.Drawing.Point(488, 0);
            this.cmdHideShow.Name = "cmdHideShow";
            this.cmdHideShow.Size = new System.Drawing.Size(18, 404);
            this.cmdHideShow.TabIndex = 0;
            this.cmdHideShow.Text = ">";
            this.cmdHideShow.UseVisualStyleBackColor = true;
            this.cmdHideShow.Click += new System.EventHandler(this.CmdHideShow_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Controls.Add(this.tabPageMeters);
            this.tabControl1.Controls.Add(this.tabPageChartSettings);
            this.tabControl1.Controls.Add(this.tabPagePort);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(290, 404);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPageMeters
            // 
            this.tabPageMeters.Controls.Add(this.meter2);
            this.tabPageMeters.Controls.Add(this.meter1);
            this.tabPageMeters.Location = new System.Drawing.Point(23, 4);
            this.tabPageMeters.Name = "tabPageMeters";
            this.tabPageMeters.Size = new System.Drawing.Size(263, 396);
            this.tabPageMeters.TabIndex = 2;
            this.tabPageMeters.Text = "Meters";
            this.tabPageMeters.UseVisualStyleBackColor = true;
            // 
            // tabPageChartSettings
            // 
            this.tabPageChartSettings.Controls.Add(this.lblChartMinMaxError);
            this.tabPageChartSettings.Controls.Add(this.panCurrent);
            this.tabPageChartSettings.Controls.Add(this.panVoltage);
            this.tabPageChartSettings.Controls.Add(this.panTime);
            this.tabPageChartSettings.Location = new System.Drawing.Point(23, 4);
            this.tabPageChartSettings.Name = "tabPageChartSettings";
            this.tabPageChartSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageChartSettings.Size = new System.Drawing.Size(263, 396);
            this.tabPageChartSettings.TabIndex = 1;
            this.tabPageChartSettings.Text = "Chart Settings";
            this.tabPageChartSettings.UseVisualStyleBackColor = true;
            // 
            // lblChartMinMaxError
            // 
            this.lblChartMinMaxError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblChartMinMaxError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChartMinMaxError.ForeColor = System.Drawing.Color.Red;
            this.lblChartMinMaxError.Location = new System.Drawing.Point(3, 252);
            this.lblChartMinMaxError.Name = "lblChartMinMaxError";
            this.lblChartMinMaxError.Padding = new System.Windows.Forms.Padding(3);
            this.lblChartMinMaxError.Size = new System.Drawing.Size(257, 141);
            this.lblChartMinMaxError.TabIndex = 7;
            this.lblChartMinMaxError.Text = "ERROR: Enter numeric value for: {0}";
            this.lblChartMinMaxError.Visible = false;
            // 
            // panCurrent
            // 
            this.panCurrent.Controls.Add(this.panCurrentMax);
            this.panCurrent.Controls.Add(this.panCurrentMin);
            this.panCurrent.Controls.Add(this.lblCurrent);
            this.panCurrent.Dock = System.Windows.Forms.DockStyle.Top;
            this.panCurrent.Location = new System.Drawing.Point(3, 169);
            this.panCurrent.Name = "panCurrent";
            this.panCurrent.Padding = new System.Windows.Forms.Padding(3);
            this.panCurrent.Size = new System.Drawing.Size(257, 83);
            this.panCurrent.TabIndex = 6;
            // 
            // panCurrentMax
            // 
            this.panCurrentMax.Controls.Add(this.lblAmpsMax);
            this.panCurrentMax.Controls.Add(this.txtCurrentMax);
            this.panCurrentMax.Controls.Add(this.lblCurrentMax);
            this.panCurrentMax.Dock = System.Windows.Forms.DockStyle.Top;
            this.panCurrentMax.Location = new System.Drawing.Point(3, 54);
            this.panCurrentMax.Name = "panCurrentMax";
            this.panCurrentMax.Padding = new System.Windows.Forms.Padding(3);
            this.panCurrentMax.Size = new System.Drawing.Size(251, 26);
            this.panCurrentMax.TabIndex = 5;
            // 
            // lblAmpsMax
            // 
            this.lblAmpsMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAmpsMax.Location = new System.Drawing.Point(116, 3);
            this.lblAmpsMax.Name = "lblAmpsMax";
            this.lblAmpsMax.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblAmpsMax.Size = new System.Drawing.Size(132, 20);
            this.lblAmpsMax.TabIndex = 5;
            this.lblAmpsMax.Text = "Amps";
            this.lblAmpsMax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCurrentMax
            // 
            this.txtCurrentMax.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtCurrentMax.Location = new System.Drawing.Point(56, 3);
            this.txtCurrentMax.Name = "txtCurrentMax";
            this.txtCurrentMax.Size = new System.Drawing.Size(60, 20);
            this.txtCurrentMax.TabIndex = 1;
            this.txtCurrentMax.Tag = "Current Max";
            this.txtCurrentMax.Text = "1";
            this.txtCurrentMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCurrentMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtChartSetting_KeyPress);
            this.txtCurrentMax.Validating += new System.ComponentModel.CancelEventHandler(this.TxtChartSetting_Validating);
            // 
            // lblCurrentMax
            // 
            this.lblCurrentMax.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblCurrentMax.Location = new System.Drawing.Point(3, 3);
            this.lblCurrentMax.Name = "lblCurrentMax";
            this.lblCurrentMax.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.lblCurrentMax.Size = new System.Drawing.Size(53, 20);
            this.lblCurrentMax.TabIndex = 0;
            this.lblCurrentMax.Text = "Max";
            this.lblCurrentMax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panCurrentMin
            // 
            this.panCurrentMin.Controls.Add(this.lblAmpsMin);
            this.panCurrentMin.Controls.Add(this.txtCurrentMin);
            this.panCurrentMin.Controls.Add(this.lblCurrentMin);
            this.panCurrentMin.Dock = System.Windows.Forms.DockStyle.Top;
            this.panCurrentMin.Location = new System.Drawing.Point(3, 28);
            this.panCurrentMin.Name = "panCurrentMin";
            this.panCurrentMin.Padding = new System.Windows.Forms.Padding(3);
            this.panCurrentMin.Size = new System.Drawing.Size(251, 26);
            this.panCurrentMin.TabIndex = 4;
            // 
            // lblAmpsMin
            // 
            this.lblAmpsMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAmpsMin.Location = new System.Drawing.Point(116, 3);
            this.lblAmpsMin.Name = "lblAmpsMin";
            this.lblAmpsMin.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblAmpsMin.Size = new System.Drawing.Size(132, 20);
            this.lblAmpsMin.TabIndex = 4;
            this.lblAmpsMin.Text = "Amps";
            this.lblAmpsMin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCurrentMin
            // 
            this.txtCurrentMin.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtCurrentMin.Location = new System.Drawing.Point(56, 3);
            this.txtCurrentMin.Name = "txtCurrentMin";
            this.txtCurrentMin.Size = new System.Drawing.Size(60, 20);
            this.txtCurrentMin.TabIndex = 1;
            this.txtCurrentMin.Tag = "Current Min";
            this.txtCurrentMin.Text = "0";
            this.txtCurrentMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCurrentMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtChartSetting_KeyPress);
            this.txtCurrentMin.Validating += new System.ComponentModel.CancelEventHandler(this.TxtChartSetting_Validating);
            // 
            // lblCurrentMin
            // 
            this.lblCurrentMin.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblCurrentMin.Location = new System.Drawing.Point(3, 3);
            this.lblCurrentMin.Name = "lblCurrentMin";
            this.lblCurrentMin.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.lblCurrentMin.Size = new System.Drawing.Size(53, 20);
            this.lblCurrentMin.TabIndex = 0;
            this.lblCurrentMin.Text = "Min";
            this.lblCurrentMin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCurrent
            // 
            this.lblCurrent.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrent.Location = new System.Drawing.Point(3, 3);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(251, 25);
            this.lblCurrent.TabIndex = 3;
            this.lblCurrent.Text = "Current";
            this.lblCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panVoltage
            // 
            this.panVoltage.Controls.Add(this.panVoltageMax);
            this.panVoltage.Controls.Add(this.panVoltageMin);
            this.panVoltage.Controls.Add(this.lblVoltage);
            this.panVoltage.Dock = System.Windows.Forms.DockStyle.Top;
            this.panVoltage.Location = new System.Drawing.Point(3, 86);
            this.panVoltage.Name = "panVoltage";
            this.panVoltage.Padding = new System.Windows.Forms.Padding(3);
            this.panVoltage.Size = new System.Drawing.Size(257, 83);
            this.panVoltage.TabIndex = 5;
            // 
            // panVoltageMax
            // 
            this.panVoltageMax.Controls.Add(this.lblVoltsMax);
            this.panVoltageMax.Controls.Add(this.txtVoltageMax);
            this.panVoltageMax.Controls.Add(this.lblVoltageMax);
            this.panVoltageMax.Dock = System.Windows.Forms.DockStyle.Top;
            this.panVoltageMax.Location = new System.Drawing.Point(3, 54);
            this.panVoltageMax.Name = "panVoltageMax";
            this.panVoltageMax.Padding = new System.Windows.Forms.Padding(3);
            this.panVoltageMax.Size = new System.Drawing.Size(251, 26);
            this.panVoltageMax.TabIndex = 5;
            // 
            // lblVoltsMax
            // 
            this.lblVoltsMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVoltsMax.Location = new System.Drawing.Point(116, 3);
            this.lblVoltsMax.Name = "lblVoltsMax";
            this.lblVoltsMax.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblVoltsMax.Size = new System.Drawing.Size(132, 20);
            this.lblVoltsMax.TabIndex = 4;
            this.lblVoltsMax.Text = "Volts";
            this.lblVoltsMax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtVoltageMax
            // 
            this.txtVoltageMax.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtVoltageMax.Location = new System.Drawing.Point(56, 3);
            this.txtVoltageMax.Name = "txtVoltageMax";
            this.txtVoltageMax.Size = new System.Drawing.Size(60, 20);
            this.txtVoltageMax.TabIndex = 1;
            this.txtVoltageMax.Tag = "Voltage Max";
            this.txtVoltageMax.Text = "10";
            this.txtVoltageMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtVoltageMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtChartSetting_KeyPress);
            this.txtVoltageMax.Validating += new System.ComponentModel.CancelEventHandler(this.TxtChartSetting_Validating);
            // 
            // lblVoltageMax
            // 
            this.lblVoltageMax.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblVoltageMax.Location = new System.Drawing.Point(3, 3);
            this.lblVoltageMax.Name = "lblVoltageMax";
            this.lblVoltageMax.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.lblVoltageMax.Size = new System.Drawing.Size(53, 20);
            this.lblVoltageMax.TabIndex = 0;
            this.lblVoltageMax.Text = "Max";
            this.lblVoltageMax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panVoltageMin
            // 
            this.panVoltageMin.Controls.Add(this.lblVoltsMin);
            this.panVoltageMin.Controls.Add(this.txtVoltageMin);
            this.panVoltageMin.Controls.Add(this.lblVoltageMin);
            this.panVoltageMin.Dock = System.Windows.Forms.DockStyle.Top;
            this.panVoltageMin.Location = new System.Drawing.Point(3, 28);
            this.panVoltageMin.Name = "panVoltageMin";
            this.panVoltageMin.Padding = new System.Windows.Forms.Padding(3);
            this.panVoltageMin.Size = new System.Drawing.Size(251, 26);
            this.panVoltageMin.TabIndex = 4;
            // 
            // lblVoltsMin
            // 
            this.lblVoltsMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVoltsMin.Location = new System.Drawing.Point(116, 3);
            this.lblVoltsMin.Name = "lblVoltsMin";
            this.lblVoltsMin.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblVoltsMin.Size = new System.Drawing.Size(132, 20);
            this.lblVoltsMin.TabIndex = 3;
            this.lblVoltsMin.Text = "Volts";
            this.lblVoltsMin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtVoltageMin
            // 
            this.txtVoltageMin.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtVoltageMin.Location = new System.Drawing.Point(56, 3);
            this.txtVoltageMin.Name = "txtVoltageMin";
            this.txtVoltageMin.Size = new System.Drawing.Size(60, 20);
            this.txtVoltageMin.TabIndex = 1;
            this.txtVoltageMin.Tag = "Voltage Min";
            this.txtVoltageMin.Text = "0";
            this.txtVoltageMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtVoltageMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtChartSetting_KeyPress);
            this.txtVoltageMin.Validating += new System.ComponentModel.CancelEventHandler(this.TxtChartSetting_Validating);
            // 
            // lblVoltageMin
            // 
            this.lblVoltageMin.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblVoltageMin.Location = new System.Drawing.Point(3, 3);
            this.lblVoltageMin.Name = "lblVoltageMin";
            this.lblVoltageMin.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.lblVoltageMin.Size = new System.Drawing.Size(53, 20);
            this.lblVoltageMin.TabIndex = 0;
            this.lblVoltageMin.Text = "Min";
            this.lblVoltageMin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblVoltage
            // 
            this.lblVoltage.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblVoltage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVoltage.Location = new System.Drawing.Point(3, 3);
            this.lblVoltage.Name = "lblVoltage";
            this.lblVoltage.Size = new System.Drawing.Size(251, 25);
            this.lblVoltage.TabIndex = 3;
            this.lblVoltage.Text = "Voltage";
            this.lblVoltage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panTime
            // 
            this.panTime.Controls.Add(this.panTimeMax);
            this.panTime.Controls.Add(this.panTimeMin);
            this.panTime.Controls.Add(this.lblTime);
            this.panTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTime.Location = new System.Drawing.Point(3, 3);
            this.panTime.Name = "panTime";
            this.panTime.Padding = new System.Windows.Forms.Padding(3);
            this.panTime.Size = new System.Drawing.Size(257, 83);
            this.panTime.TabIndex = 4;
            // 
            // panTimeMax
            // 
            this.panTimeMax.Controls.Add(this.lblSecondsMax);
            this.panTimeMax.Controls.Add(this.txtTimeMax);
            this.panTimeMax.Controls.Add(this.labTimeMax);
            this.panTimeMax.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTimeMax.Location = new System.Drawing.Point(3, 54);
            this.panTimeMax.Name = "panTimeMax";
            this.panTimeMax.Padding = new System.Windows.Forms.Padding(3);
            this.panTimeMax.Size = new System.Drawing.Size(251, 26);
            this.panTimeMax.TabIndex = 5;
            // 
            // lblSecondsMax
            // 
            this.lblSecondsMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSecondsMax.Location = new System.Drawing.Point(116, 3);
            this.lblSecondsMax.Name = "lblSecondsMax";
            this.lblSecondsMax.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblSecondsMax.Size = new System.Drawing.Size(132, 20);
            this.lblSecondsMax.TabIndex = 3;
            this.lblSecondsMax.Text = "Seconds";
            this.lblSecondsMax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTimeMax
            // 
            this.txtTimeMax.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtTimeMax.Enabled = false;
            this.txtTimeMax.Location = new System.Drawing.Point(56, 3);
            this.txtTimeMax.Name = "txtTimeMax";
            this.txtTimeMax.Size = new System.Drawing.Size(60, 20);
            this.txtTimeMax.TabIndex = 1;
            this.txtTimeMax.Tag = "Time Max";
            this.txtTimeMax.Text = "0";
            this.txtTimeMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTimeMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtChartSetting_KeyPress);
            this.txtTimeMax.Validating += new System.ComponentModel.CancelEventHandler(this.TxtChartSetting_Validating);
            // 
            // labTimeMax
            // 
            this.labTimeMax.Dock = System.Windows.Forms.DockStyle.Left;
            this.labTimeMax.Location = new System.Drawing.Point(3, 3);
            this.labTimeMax.Name = "labTimeMax";
            this.labTimeMax.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.labTimeMax.Size = new System.Drawing.Size(53, 20);
            this.labTimeMax.TabIndex = 0;
            this.labTimeMax.Text = "Max";
            this.labTimeMax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panTimeMin
            // 
            this.panTimeMin.Controls.Add(this.lblSecondsMin);
            this.panTimeMin.Controls.Add(this.txtTimeMin);
            this.panTimeMin.Controls.Add(this.labTimeMin);
            this.panTimeMin.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTimeMin.Location = new System.Drawing.Point(3, 28);
            this.panTimeMin.Name = "panTimeMin";
            this.panTimeMin.Padding = new System.Windows.Forms.Padding(3);
            this.panTimeMin.Size = new System.Drawing.Size(251, 26);
            this.panTimeMin.TabIndex = 4;
            // 
            // lblSecondsMin
            // 
            this.lblSecondsMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSecondsMin.Location = new System.Drawing.Point(116, 3);
            this.lblSecondsMin.Name = "lblSecondsMin";
            this.lblSecondsMin.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblSecondsMin.Size = new System.Drawing.Size(132, 20);
            this.lblSecondsMin.TabIndex = 2;
            this.lblSecondsMin.Text = "Seconds";
            this.lblSecondsMin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTimeMin
            // 
            this.txtTimeMin.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtTimeMin.Location = new System.Drawing.Point(56, 3);
            this.txtTimeMin.Name = "txtTimeMin";
            this.txtTimeMin.Size = new System.Drawing.Size(60, 20);
            this.txtTimeMin.TabIndex = 1;
            this.txtTimeMin.Tag = "Time Min";
            this.txtTimeMin.Text = "-20";
            this.txtTimeMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTimeMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtChartSetting_KeyPress);
            this.txtTimeMin.Validating += new System.ComponentModel.CancelEventHandler(this.TxtChartSetting_Validating);
            // 
            // labTimeMin
            // 
            this.labTimeMin.Dock = System.Windows.Forms.DockStyle.Left;
            this.labTimeMin.Location = new System.Drawing.Point(3, 3);
            this.labTimeMin.Name = "labTimeMin";
            this.labTimeMin.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.labTimeMin.Size = new System.Drawing.Size(53, 20);
            this.labTimeMin.TabIndex = 0;
            this.labTimeMin.Text = "Min";
            this.labTimeMin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTime
            // 
            this.lblTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(3, 3);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(251, 25);
            this.lblTime.TabIndex = 3;
            this.lblTime.Text = "Time";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPagePort
            // 
            this.tabPagePort.Controls.Add(this.grpFormat);
            this.tabPagePort.Controls.Add(this.grpOptions);
            this.tabPagePort.Controls.Add(this.cmdFindMeter);
            this.tabPagePort.Controls.Add(this.label1);
            this.tabPagePort.Controls.Add(this.panPort);
            this.tabPagePort.Controls.Add(this.lblInstruction);
            this.tabPagePort.Location = new System.Drawing.Point(23, 4);
            this.tabPagePort.Name = "tabPagePort";
            this.tabPagePort.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePort.Size = new System.Drawing.Size(263, 396);
            this.tabPagePort.TabIndex = 0;
            this.tabPagePort.Text = "Port Settings";
            this.tabPagePort.UseVisualStyleBackColor = true;
            // 
            // grpFormat
            // 
            this.grpFormat.Controls.Add(this.rbTextTab);
            this.grpFormat.Controls.Add(this.rbJson);
            this.grpFormat.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFormat.Location = new System.Drawing.Point(3, 153);
            this.grpFormat.Name = "grpFormat";
            this.grpFormat.Size = new System.Drawing.Size(257, 40);
            this.grpFormat.TabIndex = 24;
            this.grpFormat.TabStop = false;
            this.grpFormat.Text = "Format";
            // 
            // rbTextTab
            // 
            this.rbTextTab.AutoSize = true;
            this.rbTextTab.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbTextTab.Location = new System.Drawing.Point(56, 16);
            this.rbTextTab.Name = "rbTextTab";
            this.rbTextTab.Size = new System.Drawing.Size(74, 21);
            this.rbTextTab.TabIndex = 1;
            this.rbTextTab.Tag = "tab";
            this.rbTextTab.Text = "Text (Tab)";
            this.rbTextTab.UseVisualStyleBackColor = true;
            // 
            // rbJson
            // 
            this.rbJson.AutoSize = true;
            this.rbJson.Checked = true;
            this.rbJson.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbJson.Location = new System.Drawing.Point(3, 16);
            this.rbJson.Name = "rbJson";
            this.rbJson.Size = new System.Drawing.Size(53, 21);
            this.rbJson.TabIndex = 0;
            this.rbJson.TabStop = true;
            this.rbJson.Tag = "json";
            this.rbJson.Text = "JSON";
            this.rbJson.UseVisualStyleBackColor = true;
            // 
            // grpOptions
            // 
            this.grpOptions.Controls.Add(this.chkSerial);
            this.grpOptions.Controls.Add(this.chkDisplay);
            this.grpOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpOptions.Location = new System.Drawing.Point(3, 113);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Size = new System.Drawing.Size(257, 40);
            this.grpOptions.TabIndex = 23;
            this.grpOptions.TabStop = false;
            this.grpOptions.Text = "Options";
            // 
            // chkSerial
            // 
            this.chkSerial.AutoSize = true;
            this.chkSerial.Checked = true;
            this.chkSerial.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSerial.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkSerial.Location = new System.Drawing.Point(63, 16);
            this.chkSerial.Name = "chkSerial";
            this.chkSerial.Size = new System.Drawing.Size(52, 21);
            this.chkSerial.TabIndex = 12;
            this.chkSerial.Text = "Serial";
            this.chkSerial.UseVisualStyleBackColor = true;
            // 
            // chkDisplay
            // 
            this.chkDisplay.AutoSize = true;
            this.chkDisplay.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkDisplay.Location = new System.Drawing.Point(3, 16);
            this.chkDisplay.Name = "chkDisplay";
            this.chkDisplay.Size = new System.Drawing.Size(60, 21);
            this.chkDisplay.TabIndex = 11;
            this.chkDisplay.Text = "Display";
            this.chkDisplay.UseVisualStyleBackColor = true;
            // 
            // cmdFindMeter
            // 
            this.cmdFindMeter.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdFindMeter.Location = new System.Drawing.Point(3, 90);
            this.cmdFindMeter.Name = "cmdFindMeter";
            this.cmdFindMeter.Size = new System.Drawing.Size(257, 23);
            this.cmdFindMeter.TabIndex = 22;
            this.cmdFindMeter.Text = "Find Meter";
            this.cmdFindMeter.UseVisualStyleBackColor = true;
            this.cmdFindMeter.Click += new System.EventHandler(this.CmdFindMeter_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(3, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 30);
            this.label1.TabIndex = 21;
            this.label1.Text = "Click the find meter button to search for the serial port that the meter is conne" +
    "cted to.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panPort
            // 
            this.panPort.Controls.Add(this.cbPort);
            this.panPort.Controls.Add(this.lblPort);
            this.panPort.Dock = System.Windows.Forms.DockStyle.Top;
            this.panPort.Location = new System.Drawing.Point(3, 33);
            this.panPort.Name = "panPort";
            this.panPort.Padding = new System.Windows.Forms.Padding(3);
            this.panPort.Size = new System.Drawing.Size(257, 27);
            this.panPort.TabIndex = 3;
            // 
            // cbPort
            // 
            this.cbPort.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbPort.FormattingEnabled = true;
            this.cbPort.Location = new System.Drawing.Point(66, 3);
            this.cbPort.Name = "cbPort";
            this.cbPort.Size = new System.Drawing.Size(188, 21);
            this.cbPort.TabIndex = 1;
            this.cbPort.SelectedIndexChanged += new System.EventHandler(this.CbPort_SelectedIndexChanged);
            // 
            // lblPort
            // 
            this.lblPort.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblPort.Location = new System.Drawing.Point(3, 3);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(63, 21);
            this.lblPort.TabIndex = 0;
            this.lblPort.Text = "Port:";
            this.lblPort.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblInstruction
            // 
            this.lblInstruction.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInstruction.Location = new System.Drawing.Point(3, 3);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(257, 30);
            this.lblInstruction.TabIndex = 0;
            this.lblInstruction.Text = "Select options for connecting to the meter.";
            this.lblInstruction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // meter2
            // 
            this.meter2.channelName = "Channel 2";
            this.meter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.meter2.I_Shunt = 0D;
            this.meter2.Location = new System.Drawing.Point(0, 184);
            this.meter2.Name = "meter2";
            this.meter2.Padding = new System.Windows.Forms.Padding(3);
            this.meter2.Power = 0D;
            this.meter2.Powr_Cal = 0D;
            this.meter2.Size = new System.Drawing.Size(263, 184);
            this.meter2.TabIndex = 1;
            this.meter2.V_In = 0D;
            this.meter2.V_Out = 0D;
            this.meter2.V_Shunt = 0D;
            // 
            // meter1
            // 
            this.meter1.channelName = "Channel 1";
            this.meter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.meter1.I_Shunt = 0D;
            this.meter1.Location = new System.Drawing.Point(0, 0);
            this.meter1.Name = "meter1";
            this.meter1.Padding = new System.Windows.Forms.Padding(3);
            this.meter1.Power = 0D;
            this.meter1.Powr_Cal = 0D;
            this.meter1.Size = new System.Drawing.Size(263, 184);
            this.meter1.TabIndex = 0;
            this.meter1.V_In = 0D;
            this.meter1.V_Out = 0D;
            this.meter1.V_Shunt = 0D;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form2";
            this.Text = "Voltage and Current Logger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.Shown += new System.EventHandler(this.Form2_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panChartButtons.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageMeters.ResumeLayout(false);
            this.tabPageChartSettings.ResumeLayout(false);
            this.panCurrent.ResumeLayout(false);
            this.panCurrentMax.ResumeLayout(false);
            this.panCurrentMax.PerformLayout();
            this.panCurrentMin.ResumeLayout(false);
            this.panCurrentMin.PerformLayout();
            this.panVoltage.ResumeLayout(false);
            this.panVoltageMax.ResumeLayout(false);
            this.panVoltageMax.PerformLayout();
            this.panVoltageMin.ResumeLayout(false);
            this.panVoltageMin.PerformLayout();
            this.panTime.ResumeLayout(false);
            this.panTimeMax.ResumeLayout(false);
            this.panTimeMax.PerformLayout();
            this.panTimeMin.ResumeLayout(false);
            this.panTimeMin.PerformLayout();
            this.tabPagePort.ResumeLayout(false);
            this.grpFormat.ResumeLayout(false);
            this.grpFormat.PerformLayout();
            this.grpOptions.ResumeLayout(false);
            this.grpOptions.PerformLayout();
            this.panPort.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerUpdateUI;
        private System.Windows.Forms.SaveFileDialog saveFileData;
        private System.Windows.Forms.SaveFileDialog saveFileChartImage;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDataFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveChartImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serialPortAdvancedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem teelSysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gitHubPagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hacksterioToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button cmdHideShow;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageMeters;
        private UC_Meter meter2;
        private UC_Meter meter1;
        private System.Windows.Forms.TabPage tabPageChartSettings;
        private System.Windows.Forms.TabPage tabPagePort;
        private System.Windows.Forms.Panel panPort;
        private System.Windows.Forms.ComboBox cbPort;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.Panel panCurrent;
        private System.Windows.Forms.Panel panCurrentMax;
        private System.Windows.Forms.TextBox txtCurrentMax;
        private System.Windows.Forms.Label lblCurrentMax;
        private System.Windows.Forms.Panel panCurrentMin;
        private System.Windows.Forms.TextBox txtCurrentMin;
        private System.Windows.Forms.Label lblCurrentMin;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.Panel panVoltage;
        private System.Windows.Forms.Panel panVoltageMax;
        private System.Windows.Forms.TextBox txtVoltageMax;
        private System.Windows.Forms.Label lblVoltageMax;
        private System.Windows.Forms.Panel panVoltageMin;
        private System.Windows.Forms.TextBox txtVoltageMin;
        private System.Windows.Forms.Label lblVoltageMin;
        private System.Windows.Forms.Label lblVoltage;
        private System.Windows.Forms.Panel panTime;
        private System.Windows.Forms.Panel panTimeMax;
        private System.Windows.Forms.TextBox txtTimeMax;
        private System.Windows.Forms.Label labTimeMax;
        private System.Windows.Forms.Panel panTimeMin;
        private System.Windows.Forms.TextBox txtTimeMin;
        private System.Windows.Forms.Label labTimeMin;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblAmpsMax;
        private System.Windows.Forms.Label lblAmpsMin;
        private System.Windows.Forms.Label lblVoltsMax;
        private System.Windows.Forms.Label lblVoltsMin;
        private System.Windows.Forms.Label lblSecondsMax;
        private System.Windows.Forms.Label lblSecondsMin;
        private System.Windows.Forms.ToolStripStatusLabel lblComStatus;
        private System.Windows.Forms.GroupBox grpFormat;
        private System.Windows.Forms.RadioButton rbTextTab;
        private System.Windows.Forms.RadioButton rbJson;
        private System.Windows.Forms.GroupBox grpOptions;
        private System.Windows.Forms.CheckBox chkSerial;
        private System.Windows.Forms.CheckBox chkDisplay;
        private System.Windows.Forms.Button cmdFindMeter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripStatusLabel lblMeterFoundStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblSpring;
        private System.Windows.Forms.Label lblChartMinMaxError;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Panel panChartButtons;
        private System.Windows.Forms.Button cmdPause;
        private System.Windows.Forms.Button cmdStart;
    }
}