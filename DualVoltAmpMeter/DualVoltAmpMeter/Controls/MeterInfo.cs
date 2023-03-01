using System.Text;
using System.Windows.Forms;
using DualVoltAmpMeter.Comms;

namespace DualVoltAmpMeter.Controls
{
    public partial class MeterInfo : UserControl
    {
        /*********************************************************************************
         * Fields 
         *********************************************************************************/
        MeterConnection _meterConn;

        /*********************************************************************************
         * Properties 
         *********************************************************************************/
        public MeterConnection MeterConn
        {
            get => _meterConn;
            set
            {
                _meterConn = value;
                UpdateInfo(value);
            }
        }


        /*********************************************************************************
         * Class Constructor 
         *********************************************************************************/
        public MeterInfo()
        {
            InitializeComponent();
        }

        /*********************************************************************************
         * Private Methods 
         *********************************************************************************/


        /*********************************************************************************
         * Event Handlers
         *********************************************************************************/



        /*********************************************************************************
         * Public Methods 
         *********************************************************************************/
        public void UpdateInfo(MeterConnection meterConnection)
        {
            _meterConn = meterConnection;

            if (_meterConn == null)
            {
                txtInformation.Text = "Not Connected";
                return;
            }

            StringBuilder infoText = new StringBuilder();

            infoText.Append("Status: ");
            infoText.AppendLine(_meterConn.MeterConnected ? "Connected" : "Not Connected");

            if (_meterConn.MeterConnected)
            {
                infoText.Append("COM Port: ");
                infoText.AppendLine(_meterConn.MeterSerialPort.PortName);

                infoText.Append("Hardware Version: ");
                if (_meterConn.MeterVersionHardware == null)
                {
                    infoText.AppendLine();
                }
                else
                {
                    infoText.AppendLine(_meterConn.MeterVersionHardware.Substring(3));
                }

                infoText.Append("Software Version: ");
                if (_meterConn.MeterVersionSoftware == null)
                {
                    infoText.AppendLine();
                }
                else
                {
                    infoText.AppendLine(_meterConn.MeterVersionSoftware.Substring(3));
                }
            }

            txtInformation.Text = infoText.ToString();
        }


        /*********************************************************************************
         * Public Events 
         *********************************************************************************/
    }
}
