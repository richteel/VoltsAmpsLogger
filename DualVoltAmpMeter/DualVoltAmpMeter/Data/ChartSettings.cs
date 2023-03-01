namespace DualVoltAmpMeter.Data
{
    public class ChartSettings
    {
        /*********************************************************************************
         * Properties 
         *********************************************************************************/
        public double TimeMin { get; set; }
        public double TimeMax { get; set; }
        public double VoltageMin { get; set; }
        public double VoltageMax { get; set; }
        public double CurrentMin { get; set; }
        public double CurrentMax { get; set; }


        /*********************************************************************************
         * Class Constructor 
         *********************************************************************************/
        public ChartSettings() { 
            TimeMin = -20;
            TimeMax = 0;
            VoltageMin = 0;
            VoltageMax = 10;
            CurrentMin = 0;
            CurrentMax = 1;
        }

        public bool Validate()
        {
            bool isvalid = true;

            if (TimeMin > TimeMax) { isvalid = false; }
            if (VoltageMin > VoltageMax) { isvalid = false; }
            if (CurrentMin > CurrentMax) { isvalid = false; }

            return isvalid;
        }
    }
}
