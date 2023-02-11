namespace VoltsAmpsLogger
{
    partial class Form1
    {
        /// <summary>
<<<<<<< HEAD
        /// Required designer variable.
=======
        ///  Required designer variable.
>>>>>>> 0ae4f0228b8dd0c02d8207d7c7b3640f26c81c25
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
<<<<<<< HEAD
        /// Clean up any resources being used.
=======
        ///  Clean up any resources being used.
>>>>>>> 0ae4f0228b8dd0c02d8207d7c7b3640f26c81c25
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
<<<<<<< HEAD
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
=======
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
>>>>>>> 0ae4f0228b8dd0c02d8207d7c7b3640f26c81c25
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
<<<<<<< HEAD
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.portToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baudRateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblComStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cmdStart = new System.Windows.Forms.Button();
            this.lblConnectInstruction = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.saveDataFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialogData = new System.Windows.Forms.SaveFileDialog();
            this.saveChartImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialogChart = new System.Windows.Forms.SaveFileDialog();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gitHubPagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uC_Meter2 = new VoltsAmpsLogger.UC_Meter();
            this.uC_Meter1 = new VoltsAmpsLogger.UC_Meter();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
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
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.portToolStripMenuItem,
            this.baudRateToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            this.toolsToolStripMenuItem.DropDownOpening += new System.EventHandler(this.toolsToolStripMenuItem_DropDownOpening);
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
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblComStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 454);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblComStatus
            // 
            this.lblComStatus.Name = "lblComStatus";
            this.lblComStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 33);
            this.panel1.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 57);
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
            this.splitContainer1.Panel2.Controls.Add(this.cmdStart);
            this.splitContainer1.Panel2.Controls.Add(this.lblConnectInstruction);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(3);
            this.splitContainer1.Size = new System.Drawing.Size(800, 397);
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
            this.chart1.Size = new System.Drawing.Size(563, 397);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // cmdStart
            // 
            this.cmdStart.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdStart.Enabled = false;
            this.cmdStart.Location = new System.Drawing.Point(3, 54);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(227, 23);
            this.cmdStart.TabIndex = 1;
            this.cmdStart.Text = "Start";
            this.cmdStart.UseVisualStyleBackColor = true;
            this.cmdStart.Click += new System.EventHandler(this.cmdStart_Click);
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
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // saveDataFileToolStripMenuItem
            // 
            this.saveDataFileToolStripMenuItem.Name = "saveDataFileToolStripMenuItem";
            this.saveDataFileToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.saveDataFileToolStripMenuItem.Text = "Save &Data File";
            this.saveDataFileToolStripMenuItem.Click += new System.EventHandler(this.saveDataFileToolStripMenuItem_Click);
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
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // saveFileDialogData
            // 
            this.saveFileDialogData.FileName = "ScopeData";
            this.saveFileDialogData.Filter = "CSV file|*.csv|Tab Delimited Text file|*.txt|JSON file|*.json";
            this.saveFileDialogData.Title = "Save Data FIle";
            // 
            // saveChartImageToolStripMenuItem
            // 
            this.saveChartImageToolStripMenuItem.Name = "saveChartImageToolStripMenuItem";
            this.saveChartImageToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.saveChartImageToolStripMenuItem.Text = "Save &Chart Image";
            this.saveChartImageToolStripMenuItem.Click += new System.EventHandler(this.saveChartImageToolStripMenuItem_Click);
            // 
            // saveFileDialogChart
            // 
            this.saveFileDialogChart.FileName = "ScopeImage";
            this.saveFileDialogChart.Filter = "PNG file|*.png|JPG file|*.jpg|GIF file|*.gif|BMP file|*.bmp|TIFF file|*\'tiff";
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
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // gitHubPagesToolStripMenuItem
            // 
            this.gitHubPagesToolStripMenuItem.Name = "gitHubPagesToolStripMenuItem";
            this.gitHubPagesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.gitHubPagesToolStripMenuItem.Text = "&GitHub Pages";
            this.gitHubPagesToolStripMenuItem.Click += new System.EventHandler(this.gitHubPagesToolStripMenuItem_Click);
            // 
            // uC_Meter2
            // 
            this.uC_Meter2.channelName = "Channel 2";
            this.uC_Meter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.uC_Meter2.I_Shunt = 0D;
            this.uC_Meter2.Location = new System.Drawing.Point(3, 227);
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
            this.uC_Meter1.Location = new System.Drawing.Point(3, 77);
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
        private System.Windows.Forms.Button cmdStart;
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
    }
}

=======
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Form1";
        }

        #endregion
    }
}
>>>>>>> 0ae4f0228b8dd0c02d8207d7c7b3640f26c81c25
