using System.Windows.Forms.DataVisualization.Charting;

namespace DualVoltAmpMeter
{
    partial class frmMain
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
            DualVoltAmpMeter.Data.ChartSettings chartSettings1 = new DualVoltAmpMeter.Data.ChartSettings();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblComStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressbarFindMeter = new System.Windows.Forms.ToolStripProgressBar();
            this.lblSpring = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblMeterFoundStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDataFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveChartImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.teelSysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gitHubPagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hacksterioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabMeters = new System.Windows.Forms.TabPage();
            this.tabChartSettings = new System.Windows.Forms.TabPage();
            this.tabMeterInfo = new System.Windows.Forms.TabPage();
            this.cmdFindMeter = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cmdPause = new System.Windows.Forms.Button();
            this.cmdHideShow = new System.Windows.Forms.Button();
            this.timerFindMeter = new System.Windows.Forms.Timer(this.components);
            this.timerUiUpdate = new System.Windows.Forms.Timer(this.components);
            this.meterChannel2 = new DualVoltAmpMeter.Controls.MeterDisplay();
            this.meterChannel1 = new DualVoltAmpMeter.Controls.MeterDisplay();
            this.meterChartSettings1 = new DualVoltAmpMeter.Controls.MeterChartSettings();
            this.meterInfo1 = new DualVoltAmpMeter.Controls.MeterInfo();
            this.saveFileData = new System.Windows.Forms.SaveFileDialog();
            this.saveFileChartImage = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabMeters.SuspendLayout();
            this.tabChartSettings.SuspendLayout();
            this.tabMeterInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblComStatus,
            this.progressbarFindMeter,
            this.lblSpring,
            this.lblMeterFoundStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblComStatus
            // 
            this.lblComStatus.Name = "lblComStatus";
            this.lblComStatus.Size = new System.Drawing.Size(126, 17);
            this.lblComStatus.Text = "Status: Not Connected";
            // 
            // progressbarFindMeter
            // 
            this.progressbarFindMeter.Name = "progressbarFindMeter";
            this.progressbarFindMeter.Size = new System.Drawing.Size(100, 16);
            this.progressbarFindMeter.Visible = false;
            // 
            // lblSpring
            // 
            this.lblSpring.Name = "lblSpring";
            this.lblSpring.Size = new System.Drawing.Size(565, 17);
            this.lblSpring.Spring = true;
            // 
            // lblMeterFoundStatus
            // 
            this.lblMeterFoundStatus.Name = "lblMeterFoundStatus";
            this.lblMeterFoundStatus.Size = new System.Drawing.Size(94, 17);
            this.lblMeterFoundStatus.Text = "Meter not found";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveDataFileToolStripMenuItem,
            this.saveChartImageToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // saveDataFileToolStripMenuItem
            // 
            this.saveDataFileToolStripMenuItem.Name = "saveDataFileToolStripMenuItem";
            this.saveDataFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveDataFileToolStripMenuItem.Text = "Save &Data File";
            this.saveDataFileToolStripMenuItem.Click += new System.EventHandler(this.SaveDataFileToolStripMenuItem_Click);
            // 
            // saveChartImageToolStripMenuItem
            // 
            this.saveChartImageToolStripMenuItem.Name = "saveChartImageToolStripMenuItem";
            this.saveChartImageToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveChartImageToolStripMenuItem.Text = "Save &Chart Image";
            this.saveChartImageToolStripMenuItem.Click += new System.EventHandler(this.SaveChartImageToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.toolStripMenuItem1,
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
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(143, 6);
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.chart1);
            this.splitContainer1.Panel2.Controls.Add(this.cmdPause);
            this.splitContainer1.Panel2.Controls.Add(this.cmdHideShow);
            this.splitContainer1.Size = new System.Drawing.Size(800, 404);
            this.splitContainer1.SplitterDistance = 220;
            this.splitContainer1.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Right;
            this.tabControl1.Controls.Add(this.tabMeters);
            this.tabControl1.Controls.Add(this.tabChartSettings);
            this.tabControl1.Controls.Add(this.tabMeterInfo);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(220, 404);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1_SelectedIndexChanged);
            // 
            // tabMeters
            // 
            this.tabMeters.Controls.Add(this.meterChannel2);
            this.tabMeters.Controls.Add(this.meterChannel1);
            this.tabMeters.Location = new System.Drawing.Point(4, 4);
            this.tabMeters.Name = "tabMeters";
            this.tabMeters.Padding = new System.Windows.Forms.Padding(3);
            this.tabMeters.Size = new System.Drawing.Size(193, 396);
            this.tabMeters.TabIndex = 0;
            this.tabMeters.Text = "Meters";
            this.tabMeters.UseVisualStyleBackColor = true;
            // 
            // tabChartSettings
            // 
            this.tabChartSettings.Controls.Add(this.meterChartSettings1);
            this.tabChartSettings.Location = new System.Drawing.Point(4, 4);
            this.tabChartSettings.Name = "tabChartSettings";
            this.tabChartSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabChartSettings.Size = new System.Drawing.Size(193, 396);
            this.tabChartSettings.TabIndex = 1;
            this.tabChartSettings.Text = "Chart Settings";
            this.tabChartSettings.UseVisualStyleBackColor = true;
            // 
            // tabMeterInfo
            // 
            this.tabMeterInfo.Controls.Add(this.cmdFindMeter);
            this.tabMeterInfo.Controls.Add(this.meterInfo1);
            this.tabMeterInfo.Location = new System.Drawing.Point(4, 4);
            this.tabMeterInfo.Name = "tabMeterInfo";
            this.tabMeterInfo.Size = new System.Drawing.Size(193, 396);
            this.tabMeterInfo.TabIndex = 2;
            this.tabMeterInfo.Text = "Meter Info";
            this.tabMeterInfo.UseVisualStyleBackColor = true;
            // 
            // cmdFindMeter
            // 
            this.cmdFindMeter.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdFindMeter.Location = new System.Drawing.Point(0, 223);
            this.cmdFindMeter.Name = "cmdFindMeter";
            this.cmdFindMeter.Size = new System.Drawing.Size(193, 23);
            this.cmdFindMeter.TabIndex = 3;
            this.cmdFindMeter.Text = "Find Meter";
            this.cmdFindMeter.UseVisualStyleBackColor = true;
            this.cmdFindMeter.Click += new System.EventHandler(this.cmdFindMeter_Click);
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
            this.chart1.Location = new System.Drawing.Point(18, 0);
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
            this.chart1.Size = new System.Drawing.Size(558, 379);
            this.chart1.TabIndex = 7;
            this.chart1.Text = "chart1";
            // 
            // cmdPause
            // 
            this.cmdPause.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cmdPause.Location = new System.Drawing.Point(18, 379);
            this.cmdPause.Name = "cmdPause";
            this.cmdPause.Size = new System.Drawing.Size(558, 25);
            this.cmdPause.TabIndex = 4;
            this.cmdPause.Text = "Pause";
            this.cmdPause.UseVisualStyleBackColor = true;
            this.cmdPause.Click += new System.EventHandler(this.CmdPause_Click);
            // 
            // cmdHideShow
            // 
            this.cmdHideShow.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmdHideShow.Location = new System.Drawing.Point(0, 0);
            this.cmdHideShow.Name = "cmdHideShow";
            this.cmdHideShow.Size = new System.Drawing.Size(18, 404);
            this.cmdHideShow.TabIndex = 0;
            this.cmdHideShow.Text = "<";
            this.cmdHideShow.UseVisualStyleBackColor = true;
            this.cmdHideShow.Click += new System.EventHandler(this.CmdHideShow_Click);
            // 
            // timerFindMeter
            // 
            this.timerFindMeter.Interval = 3000;
            this.timerFindMeter.Tick += new System.EventHandler(this.TimerFindMeter_Tick);
            // 
            // timerUiUpdate
            // 
            this.timerUiUpdate.Interval = 200;
            this.timerUiUpdate.Tick += new System.EventHandler(this.TimerUiUpdate_Tick);
            // 
            // meterChannel2
            // 
            this.meterChannel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.meterChannel2.I_Shunt = 0D;
            this.meterChannel2.Location = new System.Drawing.Point(3, 188);
            this.meterChannel2.Name = "meterChannel2";
            this.meterChannel2.Power = 0D;
            this.meterChannel2.Powr_Cal = 0D;
            this.meterChannel2.Size = new System.Drawing.Size(187, 185);
            this.meterChannel2.TabIndex = 1;
            this.meterChannel2.Title = "Channel 2";
            this.meterChannel2.V_In = 0D;
            this.meterChannel2.V_Out = 0D;
            this.meterChannel2.V_Shunt = 0D;
            // 
            // meterChannel1
            // 
            this.meterChannel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.meterChannel1.I_Shunt = 0D;
            this.meterChannel1.Location = new System.Drawing.Point(3, 3);
            this.meterChannel1.Name = "meterChannel1";
            this.meterChannel1.Power = 0D;
            this.meterChannel1.Powr_Cal = 0D;
            this.meterChannel1.Size = new System.Drawing.Size(187, 185);
            this.meterChannel1.TabIndex = 0;
            this.meterChannel1.Title = "Channel 1";
            this.meterChannel1.V_In = 0D;
            this.meterChannel1.V_Out = 0D;
            this.meterChannel1.V_Shunt = 0D;
            // 
            // meterChartSettings1
            // 
            this.meterChartSettings1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.meterChartSettings1.Location = new System.Drawing.Point(3, 3);
            this.meterChartSettings1.Name = "meterChartSettings1";
            chartSettings1.CurrentMax = 1D;
            chartSettings1.CurrentMin = 0D;
            chartSettings1.TimeMax = 0D;
            chartSettings1.TimeMin = -20D;
            chartSettings1.VoltageMax = 10D;
            chartSettings1.VoltageMin = 0D;
            this.meterChartSettings1.Settings = chartSettings1;
            this.meterChartSettings1.Size = new System.Drawing.Size(187, 390);
            this.meterChartSettings1.TabIndex = 0;
            this.meterChartSettings1.SettingsChanged += new System.EventHandler<System.EventArgs>(this.MeterChartSettings1_SettingsChanged);
            // 
            // meterInfo1
            // 
            this.meterInfo1.Dock = System.Windows.Forms.DockStyle.Top;
            this.meterInfo1.Location = new System.Drawing.Point(0, 0);
            this.meterInfo1.MeterConn = null;
            this.meterInfo1.Name = "meterInfo1";
            this.meterInfo1.Size = new System.Drawing.Size(193, 223);
            this.meterInfo1.TabIndex = 0;
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
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Dual Volt Amp Meter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabMeters.ResumeLayout(false);
            this.tabChartSettings.ResumeLayout(false);
            this.tabMeterInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDataFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveChartImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem teelSysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gitHubPagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hacksterioToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel lblComStatus;
        private System.Windows.Forms.ToolStripProgressBar progressbarFindMeter;
        private System.Windows.Forms.ToolStripStatusLabel lblSpring;
        private System.Windows.Forms.ToolStripStatusLabel lblMeterFoundStatus;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabMeters;
        private System.Windows.Forms.TabPage tabChartSettings;
        private System.Windows.Forms.TabPage tabMeterInfo;
        private System.Windows.Forms.Button cmdHideShow;
        private Controls.MeterDisplay meterChannel2;
        private Controls.MeterDisplay meterChannel1;
        private System.Windows.Forms.Timer timerFindMeter;
        private Controls.MeterInfo meterInfo1;
        private System.Windows.Forms.Button cmdFindMeter;
        private Controls.MeterChartSettings meterChartSettings1;
        private System.Windows.Forms.Button cmdPause;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Timer timerUiUpdate;
        private System.Windows.Forms.SaveFileDialog saveFileData;
        private System.Windows.Forms.SaveFileDialog saveFileChartImage;
    }
}

