Narvalo.NET
===========

- [Documentation](https://github.com/chtoucas/Narvalo.NET/tree/master/docs)
- [License](https://github.com/chtoucas/Narvalo.NET/tree/master/LICENSE.txt)
- [License for WebFormsMvp](https://github.com/chtoucas/Narvalo.NET/tree/master/LICENSE-WebFormsMvp.txt)
  on which depend all MVP-related packages.

## General Purpose Libraries
- **Narvalo.Cerbere**
  [![NuGet](https://img.shields.io/nuget/v/Narvalo.Cerbere.svg)](https://www.nuget.org/packages/Narvalo.Cerbere/),
  Code Contracts helpers.
- **Narvalo.Core**
  [![NuGet](https://img.shields.io/nuget/v/Narvalo.Core.svg)](https://www.nuget.org/packages/Narvalo.Core/),
  contains helpers on which depend the other packages.
- **Narvalo.Fx**
  [![NuGet](https://img.shields.io/nuget/v/Narvalo.Fx.svg)](https://www.nuget.org/packages/Narvalo.Fx/),
  features implementations of some of the usual suspects from functional
  programming: option type (`Maybe<T>`), return types (`Result<T, TError>`,
  `Fallible<>` and `Outcome<>`), simple disjoint union
  (`Either<T1, T2>`), generators and delegate extensions.
- **Narvalo.Money**, Currency (ISO 4217) & Money types.
- **Narvalo.Finance**
  [![NuGet](https://img.shields.io/nuget/v/Narvalo.Finance.svg)](https://www.nuget.org/packages/Narvalo.Finance/),
  BIC (ISO 9362) & IBAN types.
- **Narvalo.Common**
  [![NuGet](https://img.shields.io/nuget/v/Narvalo.Common.svg)](https://www.nuget.org/packages/Narvalo.Common/),
  utilities and extension methods:
  Int64 encoders, extension methods for Collections, XDom and SQL client.
- **Narvalo.Web**
  [![NuGet](https://img.shields.io/nuget/v/Narvalo.Web.svg)](https://www.nuget.org/packages/Narvalo.Web/),
  provides types that might prove useful for Web development: generic HttpHandler
  type, asset providers, Razor and WebForms compile-time optimizers.

## MVP Framework
- **Narvalo.Mvp**
  [![NuGet](https://img.shields.io/nuget/v/Narvalo.Mvp.svg)](https://www.nuget.org/packages/Narvalo.Mvp/),
  a simple MVP framework largely inspired by [WebFormsMvp](https://github.com/webformsmvp/webformsmvp).
  Contrary to WebFormsMvp, it is not restricted to the WebForms platform; nevertheless, featurewise,
  it should be on par with WebFormsMvp. Includes support for command-line applications.
- **Narvalo.Mvp.Web**
  [![NuGet](https://img.shields.io/nuget/v/Narvalo.Mvp.Web.svg)](https://www.nuget.org/packages/Narvalo.Mvp.Web/),
  enhances Narvalo.Mvp to provide support for ASP.NET WebForms similar to WebFormsMvp.
- Samples:
  * [Command-Line MVP sample](https://github.com/chtoucas/Narvalo.NET/tree/master/samples/MvpCommandLine)
  * [WebForms MVP sample](https://github.com/chtoucas/Narvalo.NET/tree/master/samples/MvpWebForms)

## Developer Tools
- **Narvalo.Build**
  [![NuGet](https://img.shields.io/nuget/v/Narvalo.Build.svg)](https://www.nuget.org/packages/Narvalo.Build/),
  custom MSBuild tasks.
