using System;

namespace DualVoltAmpMeter.Data
{
    public class Reading
    {
        public double time { get; set; }
        public Meter channel_1 { get; set; }
        public Meter channel_2 { get; set; }
        public DateTime received { get; set; }
    }
}
