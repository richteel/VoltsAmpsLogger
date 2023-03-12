using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DualVoltAmpMeter.Data;
using DualVoltAmpMeter.Comms;

namespace DualVoltAmpMeter.Controls
{
    public partial class MeterChartSettings : UserControl
    {
        public ChartSettings Settings
        {
            get
            {
                double timeMin, timeMax, voltageMin, voltageMax, currentMin, currentMax;
                int dataSecondsMax;

                double.TryParse(txtTimeMin.Text, out timeMin);
                double.TryParse(txtTimeMax.Text, out timeMax);
                double.TryParse(txtVoltageMin.Text, out voltageMin);
                double.TryParse(txtVoltageMax.Text, out voltageMax);
                double.TryParse(txtCurrentMin.Text, out currentMin);
                double.TryParse(txtCurrentMax.Text, out currentMax);
                int.TryParse(txtDataSecondsMax.Text, out dataSecondsMax);

                return new ChartSettings()
                {
                    TimeMin = timeMin,
                    TimeMax = timeMax,
                    VoltageMin = voltageMin,
                    VoltageMax = voltageMax,
                    CurrentMin = currentMin,
                    CurrentMax = currentMax,
                    DataSecondsMax = dataSecondsMax,
                };
            }
            set
            {
                txtTimeMin.Text = value.TimeMin.ToString();
                txtTimeMax.Text = value.TimeMax.ToString();
                txtVoltageMin.Text = value.VoltageMin.ToString();
                txtVoltageMax.Text = value.VoltageMax.ToString();
                txtCurrentMin.Text = value.CurrentMin.ToString();
                txtCurrentMax.Text = value.CurrentMax.ToString();
                txtDataSecondsMax.Text = value.DataSecondsMax.ToString();
            }
        }

        public MeterChartSettings()
        {
            InitializeComponent();
        }

        private void TxtChartSetting_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txtBox = sender as TextBox;

            if (e.KeyChar == '\r')
            {
                TxtChartSetting_Validating(txtBox, new CancelEventArgs());
            }
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

            bool isMin = txtBox.Name.Contains("Min");
            bool dataSeconds = (txtBox.Tag.ToString() == "Data Seconds");
            string item = txtBox.Tag.ToString().Split(' ')[1];
            double min;
            double max;

            if (isMin)
            {
                lblChartMinMaxError.Text = string.Format("ERROR: Min must be less than max for: {0}", item);
                double.TryParse(txtBox.Text, out min);
                TextBox txtBox2 = (TextBox)this.Controls.Find(txtBox.Name.Replace("Min", "Max"), true).FirstOrDefault();
                double.TryParse(txtBox2.Text, out max);
            }
            else if (dataSeconds)
            {
                lblChartMinMaxError.Text = string.Format("ERROR: Max must be between: {0} and {1}",
                    MeterConnection.MinMeterDataSeconds, MeterConnection.MaxMeterDataSeconds);
                min = double.Parse(txtBox.Text);
                max = MeterConnection.MaxMeterDataSeconds;

                if (min < MeterConnection.MinMeterDataSeconds)
                {
                    max = min;
                    min = MeterConnection.MinMeterDataSeconds;
                }
            }
            else
            {
                lblChartMinMaxError.Text = string.Format("ERROR: Max must be greater than min for: {0}", item);
                double.TryParse(txtBox.Text, out max);
                TextBox txtBox2 = (TextBox)this.Controls.Find(txtBox.Name.Replace("Max", "Min"), true).FirstOrDefault();
                double.TryParse(txtBox2.Text, out min);
            }

            if (min > max || min == max)
            {
                lblChartMinMaxError.Visible = true;
                e.Cancel = true;
                return;
            }

            OnSettingsChanged();
        }

        /*********************************************************************************
         * Public Events 
         *********************************************************************************/
        public event EventHandler<EventArgs> SettingsChanged;
        private void OnSettingsChanged()
        {
            EventHandler<EventArgs> handler = SettingsChanged;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }
    }
}
