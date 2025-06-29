using BOMGen.Models;
using System.Text.Json;

namespace BOMGen
{
    public static class WriteToFile
    {
        public static void WriteSBOM(string outputPath, List<Dictionary<string, string>> sbom)
        {
            string formatted = JsonSerializer.Serialize(sbom, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                writer.Write(formatted);
            }
        }

        public static void WriteProcessedSBOM(string outputPath, List<PackageVulnerabiltityCheck> packageVulnerabiltityChecks)
        {
            string formatted = JsonSerializer.Serialize(packageVulnerabiltityChecks, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                writer.Write(formatted);
            }
        }
    }
}
