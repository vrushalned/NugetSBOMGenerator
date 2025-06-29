using Newtonsoft.Json;

namespace BOMGen.Models
{
    public class PackageDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
