using System.Text.Json.Serialization;

namespace Link_Backend_EF.Resources.Extras
{
    public class AWSHeartArduinoDataResource
    {
        [JsonPropertyName("red")]
        public decimal Red { get; set; }
        //[JsonPropertyName("infra_red")]
        //public int InfraRed { get; set; }
    }
    public class AWSHeartArduinoDataListResource
    {
        [JsonPropertyName("reds")]
        public List<AWSHeartArduinoDataResource> Reds { get; set; }
    }
}
