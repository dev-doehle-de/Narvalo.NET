Overview
==========

Project Layout
--------------

- `.nuget`
- `docs`
- `etc`
- `packages`, local repository of NuGet packages.
- `samples`
- `src`
- `tests`
- `tools`

Temporary directories:
- `_build`


Solutions
---------

There are six solutions.

### Narvalo.sln

This solution contains all projects. This is not used for daily work but rather
for deep refactoring and installing NuGet packages updates.

### Narvalo (Core).sln

This solution contains **all** libraries built upon Narvalo.Core:
- Narvalo.Core itself, a PCL (Profile259) for .NET 4.5, Windows 8, Windows 
  Phone 8.1 and Windows Phone Silverlight 8.
- Narvalo.Common complements Narvalo.Core with non portable classes.
- Narvalo.Web complements Narvalo.Common with Web centric classes.
- Narvalo.Extras a repository of sample classes depending on external packages.
- Narvalo.Benchmarking
- Narvalo.Facts, the test project.

### Narvalo (Mvp).sln

This solution contains all MVP related libraries. It **does not** depend on any
of the core libraries.
- Narvalo.Mvp
- Narvalo.Mvp.Web
- Narvalo.Mvp.Windows.Forms
- Narvalo.Mvp.Extras
- Narvalo.Mvp.Facts, the test project.

### Narvalo (Miscs).sln

This solution contains anything else. It **does not** depend on any
of the core libraries.
- Narvalo.Build
- Narvalo.Ghostscript
- Narvalo.Reliability
- Narvalo.StyleCop.CSharp

### Narvalo (Playground).sln

A "fourre-tout" of unfinished or broken codes.

### Narvalo (NuGet).sln

