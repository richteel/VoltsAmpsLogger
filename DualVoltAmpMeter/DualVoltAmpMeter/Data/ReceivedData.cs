using System;

namespace DualVoltAmpMeter.Data
{
    public class ReceivedData
    {
        public DateTime receivedDateTime { get; set; }
        public string receivedText { get; set; }

        public ReceivedData(string data)
        {
            receivedDateTime = DateTime.Now;
            receivedText = data;
        }
    }
}
