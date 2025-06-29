using Newtonsoft.Json;

namespace BOMGen.Models
{
    public class Reference
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
