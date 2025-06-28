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

        RootCommand rootCommand = new("Generate your .NET SBOM");
        rootCommand.Options.Add(projectOption);
        rootCommand.Options.Add(outputOption);

        ParseResult parseResult = rootCommand.Parse(args);
        var projectPath = parseResult.GetValue<string>(projectOption);
        var outputPath = parseResult.GetValue<string>(outputOption);

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
                    var metadata = await NugetPackageMetdataHandler.GetMetadataAsync(reference, version);
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
        foreach (ParseError parseError in parseResult.Errors)
        {
            Console.Error.WriteLine(parseError.Message);
        }

        return await parseResult.InvokeAsync();

    }

    
}