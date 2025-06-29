using Newtonsoft.Json;

namespace BOMGen.Models
{
    public class ApiResponse
    {
        [JsonProperty("vulns")]
        public List<Vuln> Vulns { get; set; }
        public Dictionary<string, string> Result { get; set; }
    }

   

    
}
