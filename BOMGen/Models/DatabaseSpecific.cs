using Newtonsoft.Json;

namespace BOMGen.Models
{
    public class DatabaseSpecific
    {
        [JsonProperty("github_reviewed_at")]
        public DateTime GithubReviewedAt { get; set; }

        [JsonProperty("github_reviewed")]
        public bool GithubReviewed { get; set; }

        [JsonProperty("severity")]
        public string Severity { get; set; }

        [JsonProperty("cwe_ids")]
        public List<string> CweIds { get; set; }

        [JsonProperty("nvd_published_at")]
        public DateTime NvdPublishedAt { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }
    }
}
