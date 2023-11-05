using System.Text.Json.Serialization;

namespace Link_Backend_EF.Resources.Extras
{
    public class AWSGyroArduinoDataResource
    {
        [JsonPropertyName("accel_x")]
        public decimal AccelX { get; set; }
        [JsonPropertyName("accel_y")]
        public double AccelY { get; set; }
        [JsonPropertyName("accel_z")]
        public double AccelZ { get; set; }
        [JsonPropertyName("rot_x")]
        public double RotX { get; set; }
        [JsonPropertyName("rot_y")]
        public double RotY { get; set; }
        [JsonPropertyName("rot_z")]
        public double RotZ { get; set; }
    }

    public class AWSGyroArduinoDataListResource
    {
        [JsonPropertyName("gyros")]
        public List<AWSHeartArduinoDataResource> Gyros { get; set; }
    }
}
