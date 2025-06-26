using BOMGen.Constants;
using NuGet.Common;
using NuGet.Packaging;
using NuGet.Packaging.Core;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using NuGet.Versioning;

namespace BOMGen
{
    public static class NugetPackageMetdataHandler
    {
        private static readonly string _url = Constants.Constants.RegistryUrl;
        private static SourceRepository _sourceRepository = Repository.Factory.GetCoreV3(_url);

        public static async Task<Dictionary<string, string>> GetMetadataAsync(string packageName, string version)
        {
            var metadata = new Dictionary<string, string>();

            var resource = await _sourceRepository.GetResourceAsync<PackageMetadataResource>();
            var identity = new PackageIdentity(packageName, new NuGetVersion(version));
            var package = await resource.GetMetadataAsync(identity, new SourceCacheContext(),NullLogger.Instance, CancellationToken.None);

            if(package is not null)
            {
                metadata["Id"] = packageName;
                metadata["Version"] = version;
                metadata["Description"] =  package.Description ?? "N/A";
                metadata["Author"] = package.Authors ?? "N/A";
                metadata["License"] = package.LicenseMetadata?.License ?? package.LicenseUrl?.ToString() ?? "N/A";
                metadata["ProjectUrl"] = package.ProjectUrl?.ToString() ?? "N/A";
                metadata["Published"] = package.Published?.ToString("u") ?? "N/A";
            }

            return metadata;

        }

    }
}
