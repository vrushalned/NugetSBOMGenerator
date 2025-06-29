namespace BOMGen.Models
{
    public class PackageVulnerabiltityCheck
    {
        public PackageMetadata PackageMetadata { get; set; }
        public List<Vuln> Vulnerabilities { get; set; }

        public bool IsVulnerable { get; set; }
    }
}
