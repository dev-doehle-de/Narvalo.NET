Overview
========
       
Technology footprint
--------------------
  
- Most developments are done in C#.
- Static and quality analysis are done with StyleCop, FxCop, Gendarme, Code Contracts
  and a tailor-made script.
- All tasks are fully automated with MSBuild, PowerShell (PSake) and F# scripts.
             
Extra care has been taken to completely isolate the CI environment and to keep the development
inside Visual Studio as smooth and swift as they can be.

Prerequisites
-------------

- [Visual Studio Community 2013](http://msdn.microsoft.com/en-us/visual-studio-community-vs.aspx)
- PowerShell v3

Optional components:
- [StyleCop](http://stylecop.codeplex.com) for source analysis integration inside Visual Studio.
- [Code Contracts extension for Visual Studio](https://visualstudiogallery.msdn.microsoft.com/1ec7db13-3363-46c9-851f-1ce455f66970)
- [.NET Portability Analyzer](https://visualstudiogallery.msdn.microsoft.com/1177943e-cfb7-4822-a8a6-e56c7905292b)
  to help evaluate portability across .NET platforms.

Components necessary to run the build scripts:
- Code Contracts (see above).
- [Microsoft Visual Studio 2013 SDK](http://www.microsoft.com/en-us/download/details.aspx?id=40758),
  prerequisite for the Modeling SDK (see below).
- [Modeling SDK for Microsoft Visual Studio 2013](http://www.microsoft.com/en-us/download/details.aspx?id=40754),
  provides T4 integration in MSBuild.
- Microsoft .NET 4.5.1 Developer Pack(?),  Microsoft Windows SDK for Windows 8.1(?)
  or .NET Framework SDK for PEVerify.exe.

Project Layout
--------------

- `.nuget`, NuGet configuration.
- `docs`, documentation. 
- `etc`, shared configurations.
- `packages`, local repository of NuGet packages.
- `samples`, sample projects.
- `src`, source directory.
- `src\NuGet`, NuGet projects.
- `src\Common`, shared source files.
- `tests`, test projects.
- `tools`, build and maintenance scripts.
- `work`, temporary directory created during builds.

Solutions
---------

There are four solutions.

### Narvalo.sln

This solution contains all projects. This is not used for daily work but rather
for deep refactoring and proceeding NuGet packages updates and restores.
It also contains one project not included elsewhere: Narvalo.Externs.

### Narvalo Maintenance.sln

Contains documentation, settings, maintenance scripts and projects:
- MyGet, private NuGet server.
- NuGetAgent, a NuGet publishing tool.
- Prose, a literal programming tool.

### Narvalo (Core).sln

This solution contains the core library projects:
- Narvalo.Core, focus on functional programming patterns.
- Narvalo.Common, collection of utilities and extension methods.
- Narvalo.Web, focus on web development.
- Narvalo.Ghostscript, a .NET wrapper for GhostScript.
- Narvalo.Brouillons, a "fourre-tout" of unfinished or severely broken codes.

developer tools:
- Narvalo.Build, collection of MSBuild tasks.
- Narvalo.PowerShell, collection of PowerShell modules.
- Narvalo.StyleCop.CSharp, custom C# rules for StyleCop.

and the test projects:
- Narvalo.Benchmarks, the benchmarking project.
- Narvalo.Facts, the test project.

### Narvalo (Mvp).sln

This solution contains all MVP related projects:
- Narvalo.Mvp
- Narvalo.Mvp.Web
- Narvalo.Mvp.Windows.Forms
- Narvalo.Mvp.Facts, the test project.
- Sample MVP projects.

How to initialize a new project
-------------------------------

The following procedure enables us to centralize all settings into a single place.
Except for Code Contracts, there should be no need to edit the project properties anymore.
For more the details about this shared configuration, see the section "Global settings" below.

Create a project and add it to Narvalo (Core).sln or Narvalo (Mvp).sln, and also
to the Narvalo.sln solution.

Edit the project file:
- add the following line at the bottom of the project file, just BEFORE the Microsoft targets:
```xml
<Import Project="..\..\tools\Narvalo.Common.props" />
```
- remove all sections about Debug, Release and CodeContracts.
- remove all properties configured globally.

A typical project file should then look like this:
```xml
<?xml version="1.0" encoding="utf-8"?>
<Project ToolsVersion="12.0" DefaultTargets="Build" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <Import Project="$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props" Condition="Exists('$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props')" />
  <PropertyGroup>
    <ProjectGuid>{XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX}</ProjectGuid>
    <OutputType>Library</OutputType>
    <AppDesignerFolder>Properties</AppDesignerFolder>
    <RootNamespace>Narvalo.XXX</RootNamespace>
    <AssemblyName>Narvalo.XXX</AssemblyName>
  </PropertyGroup>
  <ItemGroup>
    <Reference Include="System" />
    ...
  </ItemGroup>
  <ItemGroup>
    <Compile Include="Properties\AssemblyInfo.cs" />
  </ItemGroup>
  <Import Project="..\..\tools\Narvalo.Common.props" />
  <Import Project="$(MSBuildToolsPath)\Microsoft.CSharp.targets" />
</Project>
```

### Add Versioning

Create a version property file: {ProjectName}.Version.props.

For core libraries:
```xml
<?xml version="1.0" encoding="utf-8" ?>
<Project ToolsVersion="12.0" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <Import Project="$(RepositorySettingsDir)Narvalo.Core.CurrentVersion.props" />
</Project>
```

for MVP libraries: 
```xml
<?xml version="1.0" encoding="utf-8" ?>
<Project ToolsVersion="12.0" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <Import Project="$(RepositorySettingsDir)Narvalo.Mvp.CurrentVersion.props" />
</Project>
```              

### Configure StyleCop for Visual Studio

Edit the local StyleCop settings and link it to "etc\Strict.SourceAnalysis"
or just copy the settings from another project (but not Narvalo.Core).
                
Narvalo.Core is the only project including a StyleCop configuration with actual rules.
If you need to update the settings, do it there. When you are finished, copy the 
content of the new configuration to the shared one "etc\Strict.SourceAnalysis".

These settings only affect StyleCop when run explicitly from within Visual Studio.
During Build, StyleCop is called from `Narvalo.Common.targets`.

### Special Cases

#### Desktop applications
Desktop applications should include a .ini containing:
```
[.NET Framework Debugging Control]
GenerateTrackingInfo=0
AllowOptimize=1
```
Ensure that it is copied to the output directory.

#### Test projects

#### Sample projects

### Overriding the global settings

Create a property file {ProjectName}.props with the following content (this is just a sample):
```xml
<?xml version="1.0" encoding="utf-8" ?>
<Project ToolsVersion="12.0" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <PropertyGroup>
    <SourceAnalysisOverrideSettingsFile>$(RepositorySettingsDir)Empty.SourceAnalysis</SourceAnalysisOverrideSettingsFile>
    <CodeAnalysisRuleSet>MinimumRecommendedRules.ruleset</CodeAnalysisRuleSet>
  </PropertyGroup>

  <Target Name="_WarnOnTemporaryOverriddenSettings" BeforeTargets="Build">
    <Warning Text="We temporarily override the Source Analysis settings for $(AssemblyName)."
             Condition=" '$(SourceAnalysisEnabled)' == 'true' "/>
    <Warning Text="We temporarily override the Code Analysis settings for $(AssemblyName)."
             Condition=" '$(BuildingInsideVisualStudio)' == 'true' Or '$(RunCodeAnalysis)' == 'true' " />
  </Target>
</Project>
```
        
### Code Contracts

When a project is ready for Code Contracts, add the following lines to the 
local property file {ProjectName}.props:
```xml
<PropertyGroup Condition=" '$(BuildingInsideVisualStudio)' != 'true' ">
  <CodeContractsReferenceAssembly>Build</CodeContractsReferenceAssembly>
</PropertyGroup>
```

### Global settings
               
Three build configurations are available:
- Debug configuration is optimized for development.
- Release configuration is optimized for safety.
- CodeContracts is solely for Code Contracts analysis.

Add relevant files as linked files to the "Properties" folder
- Shared assembly informations: `etc\AssemblyInfo.Common.cs`
- Code Analysis dictionary: `etc\CodeAnalysisDictionary.xml` with build action _CodeAnalysisDictionary_
- Strong Name Key: `etc\Narvalo.snk`

In Debug mode:
- "Build" panel, treat all warnings as errors.
- "Build" panel, check for arithmetic overflow/underflow.
- "Code Analysis" panel, use "Narvalo Rules".

In Release mode:
- "Build" panel, suppress compiler warnings 1591.
- "Build" panel, treat all warnings as errors.
- "Build" panel, output XML documentation file.
- "Code Analysis" panel, use "Narvalo Rules" and enable Code Analysis
  on Build.

For all modes:
- "Signing" panel, sign the assembly using the "etc\Narvalo.snk" key.
- "Build" panel, uncheck "Prefer 32-bit" if checked.
- "Code Analysis" panel, uncheck "Suppress results from generated code (managed only)".

Build Infrastructure
--------------------
                  
The main build script is `make.ps1` at the root of the repository.

Add the project to Make.Foundations.proj when it is ready for publication.

Update external dependencies
----------------------------

### NuGet Updates

For package updates, use the Narvalo.sln solution.

**WARNING** If the NuGet core framework is updated, do not forget to also update `tools\nuget.exe`:
```
tools\nuget.exe update self
```

### Visual Studio or Framework Updates

After upgrading Visual Studio, do not forget to update the `VisualStudioVersion` property in both 
Shared.props and build.cmd. We might also need to update the `SDK40ToolsPath` property.
          
Appendices
----------

### Assembly Versioning

- AssemblyVersion, version used by the runtime.
  MAJOR.MINOR.0.0
- AssemblyFileVersion, version as seen in the file explorer,
  also used to uniquely identify a build.
  MAJOR.MINOR.BUILD.REVISION
- AssemblyInformationalVersion, the product version. In most cases
  this is the version I shall use for NuGet package versioning.
  This attribute follows semantic versioning rules.
  MAJOR.MINOR.PATCH(-PreRelaseLabel)

MAJOR, MINOR, PATCH and PreRelaseLabel (alpha, beta) are manually set.

BUILD and REVISION are generated automatically:
- Inside Visual Studio, I don't mind if the versions do not change between builds.
- Continuous build or publicly released build should increment it.

I do not change the AssemblyVersion when PATCH is incremented.

All core Narvalo projects use the same version, let's see if things work with NuGet:
- Patch update: X.Y.0.0 -> X.Y.1.0
  * If I publish Narvalo.Core but not Narvalo.Common, binding redirect works
    for Narvalo.Core and Narvalo.Common can reference the newly published assembly.
  * If I publish Narvalo.Common but not Narvalo.Core, even if Narvalo.Common
    references Narvalo.Core X.Y.1.0, obviously unknown outside, it doesn't
    matter for the CLR: the assembly version _did not actually change_,
    it's still X.Y.0.0.
- Major or Minor upgrade: 1.1.0.0 -> 1.2.0.0 (or 1.1.0.0 -> 2.1.0.0)
  * If I publish Narvalo.Core but not Narvalo.Common, binding redirect works.
    Let's cross fingers that I did not make a mistake by not releasing
    Narvalo.Common too.
  * If I publish Narvalo.Common but not Narvalo.Core, we get a runtime error
    since Narvalo.Common references an assembly version unknown outside my
    development environment. The solution is obvious. Narvalo.Core has not
    changed so Narvalo.Common should replace the direct reference and use
    the NuGet package for Narvalo.Core. If necessary we can roll back
    at any time and next time we must publish both packages.

### Strong Name Key

- Create a key pair: `sn -k Narvalo.snk`.
- Extract the public key: `sn -p Narvalo.snk Narvalo.pk`.
- Extract the public key token: `sn -tp Narvalo.pk > Narvalo.txt`.

References:
- [Strong Name Tool](http://msdn.microsoft.com/en-us/library/k5b5tt23.aspx)