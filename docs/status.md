Status
======

Library                   | Status      | PCL/Platform     | CA | CC | TC
--------------------------|-------------|------------------|----|----|-----
Narvalo.Build             | 1.1.0       | .NET 4.5         |    |    |
Narvalo.Cerbere           | 1.0.0       | Profile259       |    | OK | 100%
Narvalo.Common            | Preview     | .NET 4.5         |    | OK |
Narvalo.Core              | Preview     | Profile259       |    | OK |
Narvalo.Finance           | Preview     | Profile111       |    | OK |
Narvalo.Fx                | Preview     | Profile259       |    | OK |
Narvalo.Ghostscript       |             | .NET 4.5         |    |    |
Narvalo.Mvp               | 1.0.0-alpha | .NET 4.5         |    |    |
Narvalo.Mvp.Web           | 1.0.0-alpha | .NET 4.5         |    |    |
Narvalo.Mvp.Windows.Forms |             | .NET 4.5         |    |    |
Narvalo.Reliability       |             | .NETStandard 1.2 |    |    |
Narvalo.Web               | Preview     | .NET 4.5         |    | OK |

Explanations:
- CA: Static Analysis with:
  * Analyzers shipped with VS
  * SonarCube analyzers
  * StyleCop analyzers
- CC: Static Analysis with Code Contracts
- TC: Code Coverage.

Security
--------

Library             | Attribute
--------------------|------------
Narvalo.Cerbere     | Transparent
Narvalo.Common      | Transparent
Narvalo.Core        | Transparent
Narvalo.Finance     | Transparent
Narvalo.Fx          | Transparent

Currently, all other assemblies do not specifiy a security attribute, therefore
use the default policy (security critical).

Remark:
All methods in ASP.NET MVC v5 default to security critical, our only choice would
be to mark Narvalo.Web with the APTCA attribute and to apply the correct security
attribute where it is needed, but APTCA and ASP.NET MVC
[do not work together](https://github.com/DotNetOpenAuth/DotNetOpenAuth/issues/307).