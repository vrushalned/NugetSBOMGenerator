using BOMGen.Models;
using Newtonsoft.Json;
using System;
using System.Text.Json;

namespace BOMGen.Services
{
    public static class ProcessSBOMService
    {
        public async static Task ProcessSBOMAsync(string sbomPath, string outputPath)
        {
            if (File.Exists(sbomPath))
            {
                string json = File.ReadAllText(sbomPath);

                try
                {
                    var packages = System.Text.Json.JsonSerializer.Deserialize<List<PackageMetadata>>(json);

                    if (packages != null)
                    {
                        Queries queries = new Queries();
                        foreach (var package in packages)
                        {
                            ApiRequest request = new ApiRequest();
                            request.Version = package.Version;
                            request.Package.Name = package.Id;
                            queries.ApiRequests.Add(request);
                        }
                        Console.WriteLine("Checking OSV databases....");
                        APIHandler handler = new APIHandler();
                        var requestJson = JsonConvert.SerializeObject(queries);
                        var response = await handler.PostAsync(requestJson, "/v1/querybatch");
                        response = response ?? new();
                        if (response != null )
                        {
                            var responseEntry = response.Results ?? new();
                            Console.WriteLine("Preparing report....");
                            List<PackageVulnerabiltityCheck> packageVulnerabiltityChecks = new();

                            for (int i = 0; i < packages.Count; i++)
                            {
                                PackageVulnerabiltityCheck packageVulnerabiltityCheck = new();
                                
                                packageVulnerabiltityCheck.PackageMetadata = packages[i];
                                var entry = responseEntry.ElementAtOrDefault(i);
                                if (entry != null)
                                {
                                    if (entry.Vulns != null && entry.Vulns.Any())
                                    {
                                        packageVulnerabiltityCheck.IsVulnerable = true;
                                        packageVulnerabiltityCheck.Vulnerabilities = entry.Vulns;
                                    }
                                }
                                else
                                {
                                    packageVulnerabiltityCheck.IsVulnerable = false;
                                }

                                packageVulnerabiltityChecks.Add(packageVulnerabiltityCheck);
                            }

                            if (packageVulnerabiltityChecks != null && packageVulnerabiltityChecks.Any()) 
                            {
                                Console.WriteLine($"Writing report to {outputPath}");
                                WriteToFile.WriteProcessedSBOM(outputPath, packageVulnerabiltityChecks);
                            
                            }
                            else
                            {
                                Console.WriteLine("There was an issue processing your SBOM, sorry for the inconvenience!");
                            }
                        }

                        

                    }

                }
                catch (System.Text.Json.JsonException ex)
                {
                    Console.WriteLine($"Invalid JSON: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
    }
}
