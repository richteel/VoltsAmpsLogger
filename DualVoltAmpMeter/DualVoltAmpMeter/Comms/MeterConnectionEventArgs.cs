using DualVoltAmpMeter.Data;
using System;

namespace DualVoltAmpMeter.Comms
{
    public class MeterConnectionEventArgs : EventArgs
    {
        public bool Connected { get; set; }
        public ComPortItem ComPort { get; set; }
    }
}
