using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DualVoltAmpMeter.Data;

namespace DualVoltAmpMeter.Controls
{
    public partial class MeterChartSettings : UserControl
    {
        public ChartSettings Settings
        {
            get
            {
                return new ChartSettings()
                {
                    TimeMin = double.Parse(txtTimeMin.Text),
                    TimeMax = double.Parse(txtTimeMax.Text),
                    VoltageMin = double.Parse(txtVoltageMin.Text),
                    VoltageMax = double.Parse(txtVoltageMax.Text),
                    CurrentMin = double.Parse(txtCurrentMin.Text),
                    CurrentMax = double.Parse(txtCurrentMax.Text),
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
