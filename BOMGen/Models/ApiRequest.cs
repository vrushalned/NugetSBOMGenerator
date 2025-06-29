using Newtonsoft.Json;

namespace BOMGen.Models
{
    public class ApiRequest
    {
        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("package")]
        public PackageDto Package { get; set; } = new PackageDto();
    }
}
