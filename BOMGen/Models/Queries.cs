using Newtonsoft.Json;

namespace BOMGen.Models
{
    public class Queries
    {
        [JsonProperty("queries")]
        public List<ApiRequest> ApiRequests { get; set; } = new List<ApiRequest>();
    }
}
