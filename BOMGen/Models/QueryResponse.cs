using Newtonsoft.Json;

namespace BOMGen.Models
{
    public class QueryResponse
    {
        [JsonProperty("results")]
        public List<ApiResponse>? Results { get; set; }
    }
}
