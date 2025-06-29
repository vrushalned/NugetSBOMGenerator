using Newtonsoft.Json;

namespace BOMGen.Models
{
    public class PackageMetadata
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Version")]
        public string Version { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Author")]
        public string Author { get; set; }

        [JsonProperty("License")]
        public string License { get; set; }

        [JsonProperty("ProjectUrl")]
        public string ProjectUrl { get; set; }

        [JsonProperty("Published")]
        public string Published { get; set; }
    }

}
