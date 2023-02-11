using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoltsAmpsLogger
{
    public partial class UC_Meter : UserControl
    {
        public string channelName
        {
            get { return lblChannel.Text; }
            set { lblChannel.Text = value; }
        }

        public double V_In
        {
            get
            {
                double.TryParse(txtVin.Text, out double i);

                return i;
            }
            set
            {
                txtVin.Text = value.ToString();
            }
        }

        public double V_Out
        {
            get
            {
                double.TryParse(txtVout.Text, out double i);

                return i;
            }
            set
            {
                txtVout.Text = value.ToString();
            }
        }

        public double V_Shunt
        {
            get
            {
                double.TryParse(txtVshunt.Text, out double i);

                return i;
            }
            set
            {
                txtVshunt.Text = value.ToString();
            }
        }

        public double I_Shunt
        {
            get
            {
                double.TryParse(txtIshunt.Text, out double i);

                return i;
            }
            set
            {
                txtIshunt.Text = value.ToString();
            }
        }

        public double Powr_Cal
        {
            get
            {
                double.TryParse(txtPowrCal.Text, out double i);

                return i;
            }
            set
            {
                txtPowrCal.Text = value.ToString();
            }
        }

        public double Power
        {
            get
            {
                double.TryParse(txtPower.Text, out double i);

                return i;
            }
            set
            {
                txtPower.Text = value.ToString();
            }
        }

        public UC_Meter()
        {
            InitializeComponent();
        }
        /*
        public UC_Meter(string channelName, double v_In, double v_Out, double v_Shunt, double i_Shunt, double powr_Cal, double power)
        {
            InitializeComponent();
            this.channelName = channelName;
            V_In = v_In;
            V_Out = v_Out;
            V_Shunt = v_Shunt;
            I_Shunt = i_Shunt;
            Powr_Cal = powr_Cal;
            Power = power;
        }

        public UC_Meter(string channelName, Meter meter)
        {
            this.channelName = channelName;
            V_In = meter.VIN_IN;
            V_Out = meter.VIN_OUT;
            V_Shunt = meter.ShuntV;
            I_Shunt = meter.ShuntC;
            Powr_Cal = meter.PowerCal;
            Power = meter.PowerRegister;
        }
        */

        public void Update(Meter meter)
        {
            V_In = meter.VIN_IN;
            V_Out = meter.VIN_OUT;
            V_Shunt = meter.ShuntV;
            I_Shunt = meter.ShuntC;
            Powr_Cal = meter.PowerCal;
            Power = meter.PowerRegister;
        }
    }
}
