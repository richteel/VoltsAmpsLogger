using System;
using System.Text.Json.Serialization;

namespace VoltsAmpsLogger
{
    public class ComPortItem
    {
        public int Port { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class Meter
    {
        [JsonPropertyName("PowerRegister")]
        public double PowerRegister { get; set; }
        [JsonPropertyName("VIN_OUT")]
        public double VIN_OUT { get; set; }
        [JsonPropertyName("VIN_IN")]
        public double VIN_IN { get; set; }
        [JsonPropertyName("ShuntV")]
        public double ShuntV { get; set; }
        [JsonPropertyName("ShuntC")]
        public double ShuntC { get; set; }
        [JsonPropertyName("PowerCal")]
        public double PowerCal { get; set; }
    }

    public class Reading
    {
        public double time { get; set; }
        public Meter channel_1 { get; set; }
        public Meter channel_2 { get; set; }
        public DateTime received { get; set; }
    }
}
