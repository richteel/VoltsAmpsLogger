using System.Windows.Forms;
using DualVoltAmpMeter.Data;

namespace DualVoltAmpMeter.Controls
{
    public partial class MeterDisplay : UserControl
    {
        public string Title
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

        public MeterDisplay()
        {
            InitializeComponent();
        }

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
