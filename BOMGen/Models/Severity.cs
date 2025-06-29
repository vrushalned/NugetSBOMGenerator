using Newtonsoft.Json;

namespace BOMGen.Models
{
    public class Severity
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("score")]
        public string Score { get; set; }
    }
}
