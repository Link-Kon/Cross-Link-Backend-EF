using System.Text.Json.Serialization;

namespace Link_Backend_EF.Resources.Extras
{
    public class AWSGyroArduinoDataResource
    {
        [JsonPropertyName("accel_x")]
        public decimal AccelX { get; set; }
        [JsonPropertyName("accel_y")]
        public decimal AccelY { get; set; }
        [JsonPropertyName("accel_z")]
        public decimal AccelZ { get; set; }
        [JsonPropertyName("rot_x")]
        public decimal RotX { get; set; }
        [JsonPropertyName("rot_y")]
        public decimal RotY { get; set; }
        [JsonPropertyName("rot_z")]
        public decimal RotZ { get; set; }
    }

    public class AWSGyroArduinoDataListResource
    {
        [JsonPropertyName("gyros")]
        public List<AWSGyroArduinoDataResource> Gyros { get; set; }
    }
}
