namespace DualVoltAmpMeter.Controls
{
    partial class MeterChartSettings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTime = new System.Windows.Forms.Label();
            this.panTimeMin = new System.Windows.Forms.Panel();
            this.lblSecondsMin = new System.Windows.Forms.Label();
            this.txtTimeMin = new System.Windows.Forms.TextBox();
            this.labTimeMin = new System.Windows.Forms.Label();
            this.panTimeMax = new System.Windows.Forms.Panel();
            this.lblSecondsMax = new System.Windows.Forms.Label();
            this.txtTimeMax = new System.Windows.Forms.TextBox();
            this.labTimeMax = new System.Windows.Forms.Label();
            this.lblVoltage = new System.Windows.Forms.Label();
            this.panVoltageMin = new System.Windows.Forms.Panel();
            this.lblVoltsMin = new System.Windows.Forms.Label();
            this.txtVoltageMin = new System.Windows.Forms.TextBox();
            this.lblVoltageMin = new System.Windows.Forms.Label();
            this.panVoltageMax = new System.Windows.Forms.Panel();
            this.lblVoltsMax = new System.Windows.Forms.Label();
            this.txtVoltageMax = new System.Windows.Forms.TextBox();
            this.lblVoltageMax = new System.Windows.Forms.Label();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.panCurrentMin = new System.Windows.Forms.Panel();
            this.lblAmpsMin = new System.Windows.Forms.Label();
            this.txtCurrentMin = new System.Windows.Forms.TextBox();
            this.lblCurrentMin = new System.Windows.Forms.Label();
            this.panCurrentMax = new System.Windows.Forms.Panel();
            this.lblAmpsMax = new System.Windows.Forms.Label();
            this.txtCurrentMax = new System.Windows.Forms.TextBox();
            this.lblCurrentMax = new System.Windows.Forms.Label();
            this.lblChartMinMaxError = new System.Windows.Forms.Label();
            this.panTimeMin.SuspendLayout();
            this.panTimeMax.SuspendLayout();
            this.panVoltageMin.SuspendLayout();
            this.panVoltageMax.SuspendLayout();
            this.panCurrentMin.SuspendLayout();
            this.panCurrentMax.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTime
            // 
            this.lblTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(0, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(362, 25);
            this.lblTime.TabIndex = 4;
            this.lblTime.Text = "Time";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panTimeMin
            // 
            this.panTimeMin.Controls.Add(this.lblSecondsMin);
            this.panTimeMin.Controls.Add(this.txtTimeMin);
            this.panTimeMin.Controls.Add(this.labTimeMin);
            this.panTimeMin.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTimeMin.Location = new System.Drawing.Point(0, 25);
            this.panTimeMin.Name = "panTimeMin";
            this.panTimeMin.Padding = new System.Windows.Forms.Padding(3);
            this.panTimeMin.Size = new System.Drawing.Size(362, 26);
            this.panTimeMin.TabIndex = 5;
            // 
            // lblSecondsMin
            // 
            this.lblSecondsMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSecondsMin.Location = new System.Drawing.Point(116, 3);
            this.lblSecondsMin.Name = "lblSecondsMin";
            this.lblSecondsMin.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblSecondsMin.Size = new System.Drawing.Size(243, 20);
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
            // panTimeMax
            // 
            this.panTimeMax.Controls.Add(this.lblSecondsMax);
            this.panTimeMax.Controls.Add(this.txtTimeMax);
            this.panTimeMax.Controls.Add(this.labTimeMax);
            this.panTimeMax.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTimeMax.Location = new System.Drawing.Point(0, 51);
            this.panTimeMax.Name = "panTimeMax";
            this.panTimeMax.Padding = new System.Windows.Forms.Padding(3);
            this.panTimeMax.Size = new System.Drawing.Size(362, 26);
            this.panTimeMax.TabIndex = 6;
            // 
            // lblSecondsMax
            // 
            this.lblSecondsMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSecondsMax.Location = new System.Drawing.Point(116, 3);
            this.lblSecondsMax.Name = "lblSecondsMax";
            this.lblSecondsMax.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblSecondsMax.Size = new System.Drawing.Size(243, 20);
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
            // lblVoltage
            // 
            this.lblVoltage.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblVoltage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVoltage.Location = new System.Drawing.Point(0, 77);
            this.lblVoltage.Name = "lblVoltage";
            this.lblVoltage.Size = new System.Drawing.Size(362, 25);
            this.lblVoltage.TabIndex = 7;
            this.lblVoltage.Text = "Voltage";
            this.lblVoltage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panVoltageMin
            // 
            this.panVoltageMin.Controls.Add(this.lblVoltsMin);
            this.panVoltageMin.Controls.Add(this.txtVoltageMin);
            this.panVoltageMin.Controls.Add(this.lblVoltageMin);
            this.panVoltageMin.Dock = System.Windows.Forms.DockStyle.Top;
            this.panVoltageMin.Location = new System.Drawing.Point(0, 102);
            this.panVoltageMin.Name = "panVoltageMin";
            this.panVoltageMin.Padding = new System.Windows.Forms.Padding(3);
            this.panVoltageMin.Size = new System.Drawing.Size(362, 26);
            this.panVoltageMin.TabIndex = 8;
            // 
            // lblVoltsMin
            // 
            this.lblVoltsMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVoltsMin.Location = new System.Drawing.Point(116, 3);
            this.lblVoltsMin.Name = "lblVoltsMin";
            this.lblVoltsMin.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblVoltsMin.Size = new System.Drawing.Size(243, 20);
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
            // panVoltageMax
            // 
            this.panVoltageMax.Controls.Add(this.lblVoltsMax);
            this.panVoltageMax.Controls.Add(this.txtVoltageMax);
            this.panVoltageMax.Controls.Add(this.lblVoltageMax);
            this.panVoltageMax.Dock = System.Windows.Forms.DockStyle.Top;
            this.panVoltageMax.Location = new System.Drawing.Point(0, 128);
            this.panVoltageMax.Name = "panVoltageMax";
            this.panVoltageMax.Padding = new System.Windows.Forms.Padding(3);
            this.panVoltageMax.Size = new System.Drawing.Size(362, 26);
            this.panVoltageMax.TabIndex = 9;
            // 
            // lblVoltsMax
            // 
            this.lblVoltsMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVoltsMax.Location = new System.Drawing.Point(116, 3);
            this.lblVoltsMax.Name = "lblVoltsMax";
            this.lblVoltsMax.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblVoltsMax.Size = new System.Drawing.Size(243, 20);
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
            // lblCurrent
            // 
            this.lblCurrent.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrent.Location = new System.Drawing.Point(0, 154);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(362, 25);
            this.lblCurrent.TabIndex = 10;
            this.lblCurrent.Text = "Current";
            this.lblCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panCurrentMin
            // 
            this.panCurrentMin.Controls.Add(this.lblAmpsMin);
            this.panCurrentMin.Controls.Add(this.txtCurrentMin);
            this.panCurrentMin.Controls.Add(this.lblCurrentMin);
            this.panCurrentMin.Dock = System.Windows.Forms.DockStyle.Top;
            this.panCurrentMin.Location = new System.Drawing.Point(0, 179);
            this.panCurrentMin.Name = "panCurrentMin";
            this.panCurrentMin.Padding = new System.Windows.Forms.Padding(3);
            this.panCurrentMin.Size = new System.Drawing.Size(362, 26);
            this.panCurrentMin.TabIndex = 11;
            // 
            // lblAmpsMin
            // 
            this.lblAmpsMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAmpsMin.Location = new System.Drawing.Point(116, 3);
            this.lblAmpsMin.Name = "lblAmpsMin";
            this.lblAmpsMin.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblAmpsMin.Size = new System.Drawing.Size(243, 20);
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
            // panCurrentMax
            // 
            this.panCurrentMax.Controls.Add(this.lblAmpsMax);
            this.panCurrentMax.Controls.Add(this.txtCurrentMax);
            this.panCurrentMax.Controls.Add(this.lblCurrentMax);
            this.panCurrentMax.Dock = System.Windows.Forms.DockStyle.Top;
            this.panCurrentMax.Location = new System.Drawing.Point(0, 205);
            this.panCurrentMax.Name = "panCurrentMax";
            this.panCurrentMax.Padding = new System.Windows.Forms.Padding(3);
            this.panCurrentMax.Size = new System.Drawing.Size(362, 26);
            this.panCurrentMax.TabIndex = 12;
            // 
            // lblAmpsMax
            // 
            this.lblAmpsMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAmpsMax.Location = new System.Drawing.Point(116, 3);
            this.lblAmpsMax.Name = "lblAmpsMax";
            this.lblAmpsMax.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblAmpsMax.Size = new System.Drawing.Size(243, 20);
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
            // lblChartMinMaxError
            // 
            this.lblChartMinMaxError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblChartMinMaxError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChartMinMaxError.ForeColor = System.Drawing.Color.Red;
            this.lblChartMinMaxError.Location = new System.Drawing.Point(0, 231);
            this.lblChartMinMaxError.Name = "lblChartMinMaxError";
            this.lblChartMinMaxError.Padding = new System.Windows.Forms.Padding(3);
            this.lblChartMinMaxError.Size = new System.Drawing.Size(362, 89);
            this.lblChartMinMaxError.TabIndex = 13;
            this.lblChartMinMaxError.Text = "ERROR: Enter numeric value for: {0}";
            this.lblChartMinMaxError.Visible = false;
            // 
            // MeterChartSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblChartMinMaxError);
            this.Controls.Add(this.panCurrentMax);
            this.Controls.Add(this.panCurrentMin);
            this.Controls.Add(this.lblCurrent);
            this.Controls.Add(this.panVoltageMax);
            this.Controls.Add(this.panVoltageMin);
            this.Controls.Add(this.lblVoltage);
            this.Controls.Add(this.panTimeMax);
            this.Controls.Add(this.panTimeMin);
            this.Controls.Add(this.lblTime);
            this.Name = "MeterChartSettings";
            this.Size = new System.Drawing.Size(362, 320);
            this.panTimeMin.ResumeLayout(false);
            this.panTimeMin.PerformLayout();
            this.panTimeMax.ResumeLayout(false);
            this.panTimeMax.PerformLayout();
            this.panVoltageMin.ResumeLayout(false);
            this.panVoltageMin.PerformLayout();
            this.panVoltageMax.ResumeLayout(false);
            this.panVoltageMax.PerformLayout();
            this.panCurrentMin.ResumeLayout(false);
            this.panCurrentMin.PerformLayout();
            this.panCurrentMax.ResumeLayout(false);
            this.panCurrentMax.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Panel panTimeMin;
        private System.Windows.Forms.Label lblSecondsMin;
        private System.Windows.Forms.TextBox txtTimeMin;
        private System.Windows.Forms.Label labTimeMin;
        private System.Windows.Forms.Panel panTimeMax;
        private System.Windows.Forms.Label lblSecondsMax;
        private System.Windows.Forms.TextBox txtTimeMax;
        private System.Windows.Forms.Label labTimeMax;
        private System.Windows.Forms.Label lblVoltage;
        private System.Windows.Forms.Panel panVoltageMin;
        private System.Windows.Forms.Label lblVoltsMin;
        private System.Windows.Forms.TextBox txtVoltageMin;
        private System.Windows.Forms.Label lblVoltageMin;
        private System.Windows.Forms.Panel panVoltageMax;
        private System.Windows.Forms.Label lblVoltsMax;
        private System.Windows.Forms.TextBox txtVoltageMax;
        private System.Windows.Forms.Label lblVoltageMax;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.Panel panCurrentMin;
        private System.Windows.Forms.Label lblAmpsMin;
        private System.Windows.Forms.TextBox txtCurrentMin;
        private System.Windows.Forms.Label lblCurrentMin;
        private System.Windows.Forms.Panel panCurrentMax;
        private System.Windows.Forms.Label lblAmpsMax;
        private System.Windows.Forms.TextBox txtCurrentMax;
        private System.Windows.Forms.Label lblCurrentMax;
        private System.Windows.Forms.Label lblChartMinMaxError;
    }
}
