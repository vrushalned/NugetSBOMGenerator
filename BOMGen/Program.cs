using BOMGen.Services;
using System.CommandLine;
using System.CommandLine.Parsing;

namespace BOMGen;

class Program
{
    public async static Task<int> Main(string[] args)
    {
        List<Dictionary<string, string>> sbom = new();
        Option<string> projectOption = new("--path")
        {
            Description = "The project path"
        };
        Option<string> outputOption = new("--output")
        {
            Description = "The sbom output path"
        };
        Option<string> sbomOption = new("--sbom")
        {
            Description = "The sbom path"
        };
        Option<string> reportOutputOption = new("--vulnreport")
        {
            Description = "The vulnerability report output path"
        };
        Option<string> internalFeedOption = new("--internal-feed")
        {
            Description = "Organization internal-feed path"
        };

        RootCommand rootCommand = new("Generate your .NET SBOM");
        rootCommand.Options.Add(projectOption);
        rootCommand.Options.Add(outputOption);
        rootCommand.Options.Add(sbomOption);
        rootCommand.Options.Add(reportOutputOption);
        rootCommand.Options.Add(internalFeedOption);

        ParseResult parseResult = rootCommand.Parse(args);
        var projectPath = parseResult.GetValue<string>(projectOption);
        var outputPath = parseResult.GetValue<string>(outputOption);
        var sbomPath = parseResult.GetValue<string>(sbomOption);
        var reportPath = parseResult.GetValue<string>(reportOutputOption);
        var internalFeed = parseResult.GetValue<string>(internalFeedOption);

        Console.WriteLine($"Project path:{projectPath} ...");
        Console.WriteLine($"Output path:{outputPath} ...");

        if (!string.IsNullOrEmpty(projectPath))
        {
           
            Console.WriteLine($"Fetching project references from {projectPath} ...");
            var references = ProjectFileReader.GetProjectReferences(projectPath);
            if (references != null) 
            {
                Console.WriteLine("Creating SBOM!");
                foreach(var (reference, version) in references)
                {
                    
                    var metadata = await NugetPackageMetdataHandler.GetMetadataAsync(reference, version, false, internalFeed);
                    if (metadata is not null)
                        sbom.Add(metadata);

                }
            }
            else
            {
                Console.WriteLine("No package references detected!");
            }

        }
        if (!string.IsNullOrEmpty(outputPath)) 
        {
            
            if (sbom is not null && sbom.Any())
            {
                Console.WriteLine($"Writing SBOM to {outputPath}...");
                WriteToFile.WriteSBOM(outputPath, sbom);
            }
            else
                Console.WriteLine("No SBOM Generated!");

        }

        if (!string.IsNullOrEmpty(sbomPath) && !string.IsNullOrEmpty(reportPath)) {
               await ProcessSBOMService.ProcessSBOMAsync(sbomPath, reportPath);
        }

        foreach (ParseError parseError in parseResult.Errors)
        {
            Console.Error.WriteLine(parseError.Message);
        }

        return await parseResult.InvokeAsync();

    }

    
}