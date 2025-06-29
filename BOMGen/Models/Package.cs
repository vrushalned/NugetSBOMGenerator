using Newtonsoft.Json;

namespace BOMGen.Models
{
    public class Package
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("ecosystem")]
        public string Ecosystem { get; set; }

        [JsonProperty("purl")]
        public string Purl { get; set; }
    }
}
