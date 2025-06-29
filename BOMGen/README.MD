# NugetSBOMGenerator - .NET SBOM Generator and Vulnerability Scanner

NugetSBOMGenerator is a command-line tool that generates a Software Bill of Materials (SBOM) from your .NET project, enriches it with NuGet package metadata, and checks for known vulnerabilities using the OSV (Open Source Vulnerabilities) API.

## Features

- Extracts dependencies from `.csproj` files
- Fetches metadata from NuGet (author, license, project URL, etc.)
- Outputs a JSON-formatted SBOM
- Scans dependencies against the OSV database
- Outputs a vulnerability report matching each dependency

## Installation

Clone the repository and build the project:

```bash
git clone https://github.com/vrushalned/NugetSBOMGenerator.git
cd BOMGen\BOMGen
dotnet build
```

## Generate an SBOM
```bash
dotnet run --path <project-path> --output <output-path>
```

## Generate Vulnerability Report with OSV database

```bash
dotnet run --sbom <sbom-path> --vulnreport <report-path>
```
