using Newtonsoft.Json;

namespace BOMGen.Models
{
    public class Vuln
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        //[JsonProperty("summary")]
        //public string Summary { get; set; }

        //[JsonProperty("details")]
        //public string Details { get; set; }

        //[JsonProperty("aliases")]
        //public List<string> Aliases { get; set; }

        [JsonProperty("modified")]
        public DateTime Modified { get; set; }

    //    [JsonProperty("published")]
    //    public DateTime Published { get; set; }

    //    [JsonProperty("related")]
    //    public List<string> Related { get; set; }

    //    [JsonProperty("database_specific")]
    //    public DatabaseSpecific DatabaseSpecific { get; set; }

    //    [JsonProperty("references")]
    //    public List<Reference> References { get; set; }

    //    [JsonProperty("affected")]
    //    public List<Affected> Affected { get; set; }

    //    [JsonProperty("schema_version")]
    //    public string SchemaVersion { get; set; }

    //    [JsonProperty("severity")]
    //    public List<Severity> Severity { get; set; }
    }
}
