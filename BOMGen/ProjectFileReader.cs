using System.Text.Json;
using System.Xml.Linq;

namespace BOMGen
{
    public static class ProjectFileReader
    {
        public static List<(string,string)> GetProjectReferences(string projectPath)
        {
            var references = new List<(string,string)> ();

            var dependencies = XDocument.Load(projectPath).Descendants("PackageReference");

            foreach (var item in dependencies)
            {
                string packageId = item.Attribute("Include")?.Value ?? string.Empty;
                string version = item.Attribute("Version")?.Value ?? string.Empty;
                Console.WriteLine($"Package: {packageId} Version: {version}");
                references.Add((packageId, version));
            }
            return references;
        }
    }
}
