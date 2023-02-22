﻿namespace VoltsAmpsLogger
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDataFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveChartImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.portToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baudRateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gitHubPagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblComStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDataReceived = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblBytesToRead = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panCommand = new System.Windows.Forms.Panel();
            this.chkSerial = new System.Windows.Forms.CheckBox();
            this.chkDisplay = new System.Windows.Forms.CheckBox();
            this.panSpace = new System.Windows.Forms.Panel();
            this.panPort = new System.Windows.Forms.Panel();
            this.cbPort = new System.Windows.Forms.ComboBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblConnectInstruction = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialogData = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialogChart = new System.Windows.Forms.SaveFileDialog();
            this.cmdStart = new System.Windows.Forms.Button();
            this.uC_Meter2 = new VoltsAmpsLogger.UC_Meter();
            this.uC_Meter1 = new VoltsAmpsLogger.UC_Meter();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panCommand.SuspendLayout();
            this.panPort.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
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
            this.portToolStripMenuItem,
            this.baudRateToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            this.toolsToolStripMenuItem.DropDownOpening += new System.EventHandler(this.ToolsToolStripMenuItem_DropDownOpening);
            // 
            // portToolStripMenuItem
            // 
            this.portToolStripMenuItem.Name = "portToolStripMenuItem";
            this.portToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.portToolStripMenuItem.Text = "&Port";
            // 
            // baudRateToolStripMenuItem
            // 
            this.baudRateToolStripMenuItem.Name = "baudRateToolStripMenuItem";
            this.baudRateToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.baudRateToolStripMenuItem.Text = "&Baud Rate";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.gitHubPagesToolStripMenuItem});
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
            // gitHubPagesToolStripMenuItem
            // 
            this.gitHubPagesToolStripMenuItem.Name = "gitHubPagesToolStripMenuItem";
            this.gitHubPagesToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.gitHubPagesToolStripMenuItem.Text = "&GitHub Pages";
            this.gitHubPagesToolStripMenuItem.Click += new System.EventHandler(this.GitHubPagesToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblComStatus,
            this.lblDataReceived,
            this.lblBytesToRead});
            this.statusStrip1.Location = new System.Drawing.Point(0, 454);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblComStatus
            // 
            this.lblComStatus.AutoSize = false;
            this.lblComStatus.Name = "lblComStatus";
            this.lblComStatus.Size = new System.Drawing.Size(150, 17);
            this.lblComStatus.Text = "Status: Not Connected";
            // 
            // lblDataReceived
            // 
            this.lblDataReceived.AutoSize = false;
            this.lblDataReceived.Name = "lblDataReceived";
            this.lblDataReceived.Size = new System.Drawing.Size(200, 17);
            this.lblDataReceived.Text = "Received: 0 measurements";
            // 
            // lblBytesToRead
            // 
            this.lblBytesToRead.AutoSize = false;
            this.lblBytesToRead.Name = "lblBytesToRead";
            this.lblBytesToRead.Size = new System.Drawing.Size(200, 17);
            this.lblBytesToRead.Text = "BytesToRead";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmdStart);
            this.panel1.Controls.Add(this.panCommand);
            this.panel1.Controls.Add(this.panSpace);
            this.panel1.Controls.Add(this.panPort);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 27);
            this.panel1.TabIndex = 2;
            // 
            // panCommand
            // 
            this.panCommand.AutoSize = true;
            this.panCommand.BackColor = System.Drawing.SystemColors.Control;
            this.panCommand.Controls.Add(this.chkSerial);
            this.panCommand.Controls.Add(this.chkDisplay);
            this.panCommand.Dock = System.Windows.Forms.DockStyle.Left;
            this.panCommand.Location = new System.Drawing.Point(250, 0);
            this.panCommand.Name = "panCommand";
            this.panCommand.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.panCommand.Size = new System.Drawing.Size(118, 27);
            this.panCommand.TabIndex = 5;
            // 
            // chkSerial
            // 
            this.chkSerial.AutoSize = true;
            this.chkSerial.Checked = true;
            this.chkSerial.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSerial.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkSerial.Location = new System.Drawing.Point(63, 0);
            this.chkSerial.Name = "chkSerial";
            this.chkSerial.Size = new System.Drawing.Size(52, 27);
            this.chkSerial.TabIndex = 9;
            this.chkSerial.Text = "Serial";
            this.chkSerial.UseVisualStyleBackColor = true;
            // 
            // chkDisplay
            // 
            this.chkDisplay.AutoSize = true;
            this.chkDisplay.Checked = true;
            this.chkDisplay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDisplay.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkDisplay.Location = new System.Drawing.Point(3, 0);
            this.chkDisplay.Name = "chkDisplay";
            this.chkDisplay.Size = new System.Drawing.Size(60, 27);
            this.chkDisplay.TabIndex = 8;
            this.chkDisplay.Text = "Display";
            this.chkDisplay.UseVisualStyleBackColor = true;
            // 
            // panSpace
            // 
            this.panSpace.Dock = System.Windows.Forms.DockStyle.Left;
            this.panSpace.Location = new System.Drawing.Point(230, 0);
            this.panSpace.Name = "panSpace";
            this.panSpace.Size = new System.Drawing.Size(20, 27);
            this.panSpace.TabIndex = 4;
            // 
            // panPort
            // 
            this.panPort.Controls.Add(this.cbPort);
            this.panPort.Controls.Add(this.lblPort);
            this.panPort.Dock = System.Windows.Forms.DockStyle.Left;
            this.panPort.Location = new System.Drawing.Point(0, 0);
            this.panPort.Name = "panPort";
            this.panPort.Padding = new System.Windows.Forms.Padding(3);
            this.panPort.Size = new System.Drawing.Size(230, 27);
            this.panPort.TabIndex = 1;
            // 
            // cbPort
            // 
            this.cbPort.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbPort.FormattingEnabled = true;
            this.cbPort.Location = new System.Drawing.Point(66, 3);
            this.cbPort.Name = "cbPort";
            this.cbPort.Size = new System.Drawing.Size(161, 21);
            this.cbPort.TabIndex = 1;
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 51);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.chart1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.uC_Meter2);
            this.splitContainer1.Panel2.Controls.Add(this.uC_Meter1);
            this.splitContainer1.Panel2.Controls.Add(this.lblConnectInstruction);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(3);
            this.splitContainer1.Size = new System.Drawing.Size(800, 403);
            this.splitContainer1.SplitterDistance = 563;
            this.splitContainer1.TabIndex = 3;
            // 
            // chart1
            // 
            chartArea1.AxisX.Interval = 5D;
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
            this.chart1.Size = new System.Drawing.Size(563, 403);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // lblConnectInstruction
            // 
            this.lblConnectInstruction.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblConnectInstruction.Location = new System.Drawing.Point(3, 3);
            this.lblConnectInstruction.Margin = new System.Windows.Forms.Padding(3);
            this.lblConnectInstruction.Name = "lblConnectInstruction";
            this.lblConnectInstruction.Size = new System.Drawing.Size(227, 51);
            this.lblConnectInstruction.TabIndex = 0;
            this.lblConnectInstruction.Text = "To get started, select a COM Port from the Tools > Port menu, then click the \"Sta" +
    "rt\" button to acquire and display data.";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // saveFileDialogData
            // 
            this.saveFileDialogData.FileName = "ScopeData";
            this.saveFileDialogData.Filter = "CSV file|*.csv|Tab Delimited Text file|*.txt|JSON file|*.json";
            this.saveFileDialogData.Title = "Save Data FIle";
            // 
            // saveFileDialogChart
            // 
            this.saveFileDialogChart.FileName = "ScopeImage";
            this.saveFileDialogChart.Filter = "PNG file|*.png|JPG file|*.jpg|GIF file|*.gif|BMP file|*.bmp|TIFF file|*\'tiff";
            // 
            // cmdStart
            // 
            this.cmdStart.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmdStart.Enabled = false;
            this.cmdStart.Location = new System.Drawing.Point(368, 0);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(75, 27);
            this.cmdStart.TabIndex = 6;
            this.cmdStart.Text = "Start";
            this.cmdStart.UseVisualStyleBackColor = true;
            this.cmdStart.Click += new System.EventHandler(this.CmdStart_Click);
            // 
            // uC_Meter2
            // 
            this.uC_Meter2.channelName = "Channel 2";
            this.uC_Meter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.uC_Meter2.I_Shunt = 0D;
            this.uC_Meter2.Location = new System.Drawing.Point(3, 204);
            this.uC_Meter2.Name = "uC_Meter2";
            this.uC_Meter2.Padding = new System.Windows.Forms.Padding(3);
            this.uC_Meter2.Power = 0D;
            this.uC_Meter2.Powr_Cal = 0D;
            this.uC_Meter2.Size = new System.Drawing.Size(227, 150);
            this.uC_Meter2.TabIndex = 3;
            this.uC_Meter2.V_In = 0D;
            this.uC_Meter2.V_Out = 0D;
            this.uC_Meter2.V_Shunt = 0D;
            // 
            // uC_Meter1
            // 
            this.uC_Meter1.channelName = "Channel 1";
            this.uC_Meter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uC_Meter1.I_Shunt = 0D;
            this.uC_Meter1.Location = new System.Drawing.Point(3, 54);
            this.uC_Meter1.Name = "uC_Meter1";
            this.uC_Meter1.Padding = new System.Windows.Forms.Padding(3);
            this.uC_Meter1.Power = 0D;
            this.uC_Meter1.Powr_Cal = 0D;
            this.uC_Meter1.Size = new System.Drawing.Size(227, 150);
            this.uC_Meter1.TabIndex = 2;
            this.uC_Meter1.V_In = 0D;
            this.uC_Meter1.V_Out = 0D;
            this.uC_Meter1.V_Shunt = 0D;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 476);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Voltage and Current Logger";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panCommand.ResumeLayout(false);
            this.panCommand.PerformLayout();
            this.panPort.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem portToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem baudRateToolStripMenuItem;
        private System.Windows.Forms.Label lblConnectInstruction;
        private System.Windows.Forms.ToolStripStatusLabel lblComStatus;
        private System.Windows.Forms.Timer timer1;
        private UC_Meter uC_Meter1;
        private UC_Meter uC_Meter2;
        private System.Windows.Forms.ToolStripMenuItem saveDataFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialogData;
        private System.Windows.Forms.ToolStripMenuItem saveChartImageToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialogChart;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gitHubPagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel lblDataReceived;
        private System.Windows.Forms.ToolStripStatusLabel lblBytesToRead;
        private System.Windows.Forms.Panel panCommand;
        private System.Windows.Forms.CheckBox chkSerial;
        private System.Windows.Forms.CheckBox chkDisplay;
        private System.Windows.Forms.Panel panSpace;
        private System.Windows.Forms.Panel panPort;
        private System.Windows.Forms.ComboBox cbPort;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Button cmdStart;
    }
}

