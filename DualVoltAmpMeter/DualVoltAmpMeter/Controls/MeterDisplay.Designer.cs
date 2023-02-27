namespace DualVoltAmpMeter.Controls
{
    partial class MeterDisplay
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
            this.lblPowerUnits = new System.Windows.Forms.Label();
            this.lblPower = new System.Windows.Forms.Label();
            this.panPower = new System.Windows.Forms.Panel();
            this.txtPower = new System.Windows.Forms.TextBox();
            this.lblPowerCalUnits = new System.Windows.Forms.Label();
            this.txtPowrCal = new System.Windows.Forms.TextBox();
            this.lblPowrCalc = new System.Windows.Forms.Label();
            this.panPowrCal = new System.Windows.Forms.Panel();
            this.lblIShuntUnits = new System.Windows.Forms.Label();
            this.txtIshunt = new System.Windows.Forms.TextBox();
            this.lblIshunt = new System.Windows.Forms.Label();
            this.lblVShuntUnits = new System.Windows.Forms.Label();
            this.txtVshunt = new System.Windows.Forms.TextBox();
            this.panIshunt = new System.Windows.Forms.Panel();
            this.lblVshunt = new System.Windows.Forms.Label();
            this.panVshunt = new System.Windows.Forms.Panel();
            this.lblVoutUnits = new System.Windows.Forms.Label();
            this.txtVout = new System.Windows.Forms.TextBox();
            this.lblVout = new System.Windows.Forms.Label();
            this.panVout = new System.Windows.Forms.Panel();
            this.lblVinUnits = new System.Windows.Forms.Label();
            this.txtVin = new System.Windows.Forms.TextBox();
            this.lblVin = new System.Windows.Forms.Label();
            this.panVin = new System.Windows.Forms.Panel();
            this.lblChannel = new System.Windows.Forms.Label();
            this.panPower.SuspendLayout();
            this.panPowrCal.SuspendLayout();
            this.panIshunt.SuspendLayout();
            this.panVshunt.SuspendLayout();
            this.panVout.SuspendLayout();
            this.panVin.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPowerUnits
            // 
            this.lblPowerUnits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPowerUnits.Location = new System.Drawing.Point(143, 3);
            this.lblPowerUnits.Name = "lblPowerUnits";
            this.lblPowerUnits.Size = new System.Drawing.Size(120, 20);
            this.lblPowerUnits.TabIndex = 3;
            this.lblPowerUnits.Text = "W";
            this.lblPowerUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPower
            // 
            this.lblPower.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblPower.Location = new System.Drawing.Point(3, 3);
            this.lblPower.Name = "lblPower";
            this.lblPower.Size = new System.Drawing.Size(60, 20);
            this.lblPower.TabIndex = 0;
            this.lblPower.Text = "Power:";
            this.lblPower.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panPower
            // 
            this.panPower.Controls.Add(this.lblPowerUnits);
            this.panPower.Controls.Add(this.txtPower);
            this.panPower.Controls.Add(this.lblPower);
            this.panPower.Dock = System.Windows.Forms.DockStyle.Top;
            this.panPower.Location = new System.Drawing.Point(0, 153);
            this.panPower.Name = "panPower";
            this.panPower.Padding = new System.Windows.Forms.Padding(3);
            this.panPower.Size = new System.Drawing.Size(266, 26);
            this.panPower.TabIndex = 13;
            // 
            // txtPower
            // 
            this.txtPower.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtPower.Location = new System.Drawing.Point(63, 3);
            this.txtPower.Name = "txtPower";
            this.txtPower.ReadOnly = true;
            this.txtPower.Size = new System.Drawing.Size(80, 20);
            this.txtPower.TabIndex = 1;
            this.txtPower.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPowerCalUnits
            // 
            this.lblPowerCalUnits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPowerCalUnits.Location = new System.Drawing.Point(143, 3);
            this.lblPowerCalUnits.Name = "lblPowerCalUnits";
            this.lblPowerCalUnits.Size = new System.Drawing.Size(120, 20);
            this.lblPowerCalUnits.TabIndex = 3;
            this.lblPowerCalUnits.Text = "W";
            this.lblPowerCalUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPowrCal
            // 
            this.txtPowrCal.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtPowrCal.Location = new System.Drawing.Point(63, 3);
            this.txtPowrCal.Name = "txtPowrCal";
            this.txtPowrCal.ReadOnly = true;
            this.txtPowrCal.Size = new System.Drawing.Size(80, 20);
            this.txtPowrCal.TabIndex = 1;
            this.txtPowrCal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPowrCalc
            // 
            this.lblPowrCalc.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblPowrCalc.Location = new System.Drawing.Point(3, 3);
            this.lblPowrCalc.Name = "lblPowrCalc";
            this.lblPowrCalc.Size = new System.Drawing.Size(60, 20);
            this.lblPowrCalc.TabIndex = 0;
            this.lblPowrCalc.Text = "Powr-Cal:";
            this.lblPowrCalc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panPowrCal
            // 
            this.panPowrCal.Controls.Add(this.lblPowerCalUnits);
            this.panPowrCal.Controls.Add(this.txtPowrCal);
            this.panPowrCal.Controls.Add(this.lblPowrCalc);
            this.panPowrCal.Dock = System.Windows.Forms.DockStyle.Top;
            this.panPowrCal.Location = new System.Drawing.Point(0, 127);
            this.panPowrCal.Name = "panPowrCal";
            this.panPowrCal.Padding = new System.Windows.Forms.Padding(3);
            this.panPowrCal.Size = new System.Drawing.Size(266, 26);
            this.panPowrCal.TabIndex = 12;
            // 
            // lblIShuntUnits
            // 
            this.lblIShuntUnits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIShuntUnits.Location = new System.Drawing.Point(143, 3);
            this.lblIShuntUnits.Name = "lblIShuntUnits";
            this.lblIShuntUnits.Size = new System.Drawing.Size(120, 20);
            this.lblIShuntUnits.TabIndex = 3;
            this.lblIShuntUnits.Text = "A";
            this.lblIShuntUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtIshunt
            // 
            this.txtIshunt.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtIshunt.Location = new System.Drawing.Point(63, 3);
            this.txtIshunt.Name = "txtIshunt";
            this.txtIshunt.ReadOnly = true;
            this.txtIshunt.Size = new System.Drawing.Size(80, 20);
            this.txtIshunt.TabIndex = 1;
            this.txtIshunt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblIshunt
            // 
            this.lblIshunt.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblIshunt.Location = new System.Drawing.Point(3, 3);
            this.lblIshunt.Name = "lblIshunt";
            this.lblIshunt.Size = new System.Drawing.Size(60, 20);
            this.lblIshunt.TabIndex = 0;
            this.lblIshunt.Text = "I-Shunt:";
            this.lblIshunt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblVShuntUnits
            // 
            this.lblVShuntUnits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVShuntUnits.Location = new System.Drawing.Point(143, 3);
            this.lblVShuntUnits.Name = "lblVShuntUnits";
            this.lblVShuntUnits.Size = new System.Drawing.Size(120, 20);
            this.lblVShuntUnits.TabIndex = 3;
            this.lblVShuntUnits.Text = "V";
            this.lblVShuntUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtVshunt
            // 
            this.txtVshunt.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtVshunt.Location = new System.Drawing.Point(63, 3);
            this.txtVshunt.Name = "txtVshunt";
            this.txtVshunt.ReadOnly = true;
            this.txtVshunt.Size = new System.Drawing.Size(80, 20);
            this.txtVshunt.TabIndex = 1;
            this.txtVshunt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panIshunt
            // 
            this.panIshunt.Controls.Add(this.lblIShuntUnits);
            this.panIshunt.Controls.Add(this.txtIshunt);
            this.panIshunt.Controls.Add(this.lblIshunt);
            this.panIshunt.Dock = System.Windows.Forms.DockStyle.Top;
            this.panIshunt.Location = new System.Drawing.Point(0, 101);
            this.panIshunt.Name = "panIshunt";
            this.panIshunt.Padding = new System.Windows.Forms.Padding(3);
            this.panIshunt.Size = new System.Drawing.Size(266, 26);
            this.panIshunt.TabIndex = 11;
            // 
            // lblVshunt
            // 
            this.lblVshunt.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblVshunt.Location = new System.Drawing.Point(3, 3);
            this.lblVshunt.Name = "lblVshunt";
            this.lblVshunt.Size = new System.Drawing.Size(60, 20);
            this.lblVshunt.TabIndex = 0;
            this.lblVshunt.Text = "V-Shunt:";
            this.lblVshunt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panVshunt
            // 
            this.panVshunt.Controls.Add(this.lblVShuntUnits);
            this.panVshunt.Controls.Add(this.txtVshunt);
            this.panVshunt.Controls.Add(this.lblVshunt);
            this.panVshunt.Dock = System.Windows.Forms.DockStyle.Top;
            this.panVshunt.Location = new System.Drawing.Point(0, 75);
            this.panVshunt.Name = "panVshunt";
            this.panVshunt.Padding = new System.Windows.Forms.Padding(3);
            this.panVshunt.Size = new System.Drawing.Size(266, 26);
            this.panVshunt.TabIndex = 10;
            // 
            // lblVoutUnits
            // 
            this.lblVoutUnits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVoutUnits.Location = new System.Drawing.Point(143, 3);
            this.lblVoutUnits.Name = "lblVoutUnits";
            this.lblVoutUnits.Size = new System.Drawing.Size(120, 20);
            this.lblVoutUnits.TabIndex = 3;
            this.lblVoutUnits.Text = "V";
            this.lblVoutUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtVout
            // 
            this.txtVout.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtVout.Location = new System.Drawing.Point(63, 3);
            this.txtVout.Name = "txtVout";
            this.txtVout.ReadOnly = true;
            this.txtVout.Size = new System.Drawing.Size(80, 20);
            this.txtVout.TabIndex = 1;
            this.txtVout.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblVout
            // 
            this.lblVout.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblVout.Location = new System.Drawing.Point(3, 3);
            this.lblVout.Name = "lblVout";
            this.lblVout.Size = new System.Drawing.Size(60, 20);
            this.lblVout.TabIndex = 0;
            this.lblVout.Text = "V-Out:";
            this.lblVout.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panVout
            // 
            this.panVout.Controls.Add(this.lblVoutUnits);
            this.panVout.Controls.Add(this.txtVout);
            this.panVout.Controls.Add(this.lblVout);
            this.panVout.Dock = System.Windows.Forms.DockStyle.Top;
            this.panVout.Location = new System.Drawing.Point(0, 49);
            this.panVout.Name = "panVout";
            this.panVout.Padding = new System.Windows.Forms.Padding(3);
            this.panVout.Size = new System.Drawing.Size(266, 26);
            this.panVout.TabIndex = 9;
            // 
            // lblVinUnits
            // 
            this.lblVinUnits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVinUnits.Location = new System.Drawing.Point(143, 3);
            this.lblVinUnits.Name = "lblVinUnits";
            this.lblVinUnits.Size = new System.Drawing.Size(120, 20);
            this.lblVinUnits.TabIndex = 2;
            this.lblVinUnits.Text = "V";
            this.lblVinUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtVin
            // 
            this.txtVin.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtVin.Location = new System.Drawing.Point(63, 3);
            this.txtVin.Name = "txtVin";
            this.txtVin.ReadOnly = true;
            this.txtVin.Size = new System.Drawing.Size(80, 20);
            this.txtVin.TabIndex = 1;
            this.txtVin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblVin
            // 
            this.lblVin.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblVin.Location = new System.Drawing.Point(3, 3);
            this.lblVin.Name = "lblVin";
            this.lblVin.Size = new System.Drawing.Size(60, 20);
            this.lblVin.TabIndex = 0;
            this.lblVin.Text = "V-In:";
            this.lblVin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panVin
            // 
            this.panVin.Controls.Add(this.lblVinUnits);
            this.panVin.Controls.Add(this.txtVin);
            this.panVin.Controls.Add(this.lblVin);
            this.panVin.Dock = System.Windows.Forms.DockStyle.Top;
            this.panVin.Location = new System.Drawing.Point(0, 23);
            this.panVin.Name = "panVin";
            this.panVin.Padding = new System.Windows.Forms.Padding(3);
            this.panVin.Size = new System.Drawing.Size(266, 26);
            this.panVin.TabIndex = 8;
            // 
            // lblChannel
            // 
            this.lblChannel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChannel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChannel.Location = new System.Drawing.Point(0, 0);
            this.lblChannel.Name = "lblChannel";
            this.lblChannel.Size = new System.Drawing.Size(266, 23);
            this.lblChannel.TabIndex = 7;
            this.lblChannel.Text = "Channel";
            this.lblChannel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MeterDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panPower);
            this.Controls.Add(this.panPowrCal);
            this.Controls.Add(this.panIshunt);
            this.Controls.Add(this.panVshunt);
            this.Controls.Add(this.panVout);
            this.Controls.Add(this.panVin);
            this.Controls.Add(this.lblChannel);
            this.Name = "MeterDisplay";
            this.Size = new System.Drawing.Size(266, 180);
            this.panPower.ResumeLayout(false);
            this.panPower.PerformLayout();
            this.panPowrCal.ResumeLayout(false);
            this.panPowrCal.PerformLayout();
            this.panIshunt.ResumeLayout(false);
            this.panIshunt.PerformLayout();
            this.panVshunt.ResumeLayout(false);
            this.panVshunt.PerformLayout();
            this.panVout.ResumeLayout(false);
            this.panVout.PerformLayout();
            this.panVin.ResumeLayout(false);
            this.panVin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPowerUnits;
        private System.Windows.Forms.Label lblPower;
        private System.Windows.Forms.Panel panPower;
        private System.Windows.Forms.TextBox txtPower;
        private System.Windows.Forms.Label lblPowerCalUnits;
        private System.Windows.Forms.TextBox txtPowrCal;
        private System.Windows.Forms.Label lblPowrCalc;
        private System.Windows.Forms.Panel panPowrCal;
        private System.Windows.Forms.Label lblIShuntUnits;
        private System.Windows.Forms.TextBox txtIshunt;
        private System.Windows.Forms.Label lblIshunt;
        private System.Windows.Forms.Label lblVShuntUnits;
        private System.Windows.Forms.TextBox txtVshunt;
        private System.Windows.Forms.Panel panIshunt;
        private System.Windows.Forms.Label lblVshunt;
        private System.Windows.Forms.Panel panVshunt;
        private System.Windows.Forms.Label lblVoutUnits;
        private System.Windows.Forms.TextBox txtVout;
        private System.Windows.Forms.Label lblVout;
        private System.Windows.Forms.Panel panVout;
        private System.Windows.Forms.Label lblVinUnits;
        private System.Windows.Forms.TextBox txtVin;
        private System.Windows.Forms.Label lblVin;
        private System.Windows.Forms.Panel panVin;
        private System.Windows.Forms.Label lblChannel;
    }
}
