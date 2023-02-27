using System.Text.Json.Serialization;

namespace DualVoltAmpMeter.Data
{
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
}
