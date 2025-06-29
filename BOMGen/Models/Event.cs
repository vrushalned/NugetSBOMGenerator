using Newtonsoft.Json;

namespace BOMGen.Models
{
    public class Event
    {
        [JsonProperty("introduced")]
        public string Introduced { get; set; }

        [JsonProperty("fixed")]
        public string Fixed { get; set; }
    }
}
