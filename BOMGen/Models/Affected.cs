using Newtonsoft.Json;

namespace BOMGen.Models
{
    public class Affected
    {
        [JsonProperty("package")]
        public Package Package { get; set; }

        [JsonProperty("ranges")]
        public List<Range> Ranges { get; set; }

        [JsonProperty("versions")]
        public List<string> Versions { get; set; }

        [JsonProperty("database_specific")]
        public DatabaseSpecific DatabaseSpecific { get; set; }
    }
}
