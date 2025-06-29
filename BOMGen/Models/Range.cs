using Newtonsoft.Json;

namespace BOMGen.Models
{
    public class Range
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("events")]
        public List<Event> Events { get; set; }
    }
}
