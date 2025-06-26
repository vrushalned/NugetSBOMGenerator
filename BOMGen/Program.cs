
using BOMGen;
using Newtonsoft.Json;


var metadata = await NugetPackageMetdataHandler.GetMetadataAsync("Newtonsoft.Json", "13.0.1");

var json = JsonConvert.SerializeObject(metadata);
Console.WriteLine(json);