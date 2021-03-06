﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;

[module: SuppressMessage("Microsoft.Usage", "CA2243:AttributeStringLiteralsShouldParseCorrectly", Justification = "Informational version uses semantic versioning.")]

[assembly: AssemblyProduct("Narvalo.Org Libraries & Tools.")]
[assembly: AssemblyCompany("Narvalo.Org - http://narvalo.org")]
[assembly: AssemblyCopyright("Copyright © 2013-2017 Narvalo.Org")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

[assembly: NeutralResourcesLanguage("en")]

#if !NOT_CLS_COMPLIANT
[assembly: CLSCompliant(true)]
#else
[assembly: CLSCompliant(false)]
#endif
[assembly: ComVisible(false)]

#if DUMMY_GENERATED_VERSION
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyInformationalVersion("1.0.0-DUMMY")]
#elif BUILD_GENERATED_VERSION
// Version attributes are automatically generated and made available in a separate file.
#else
// Inside Visual Studio, assemblies get a fake version.
[assembly: AssemblyConfiguration("Development Build.")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0-DEV")]
#endif

#if !NO_INTERNALS_VISIBLE_TO
namespace Narvalo
{
    /// <summary>
    /// Provides constants used in Assembly's attributes.
    /// </summary>
    internal static partial class AssemblyInfo
    {
        /// <summary>
        /// Gets the public key suffix suitable for use with <c>System.Runtime.CompilerServices.InternalsVisibleTo</c>.
        /// </summary>
#if SIGNED_ASSEMBLY
        public const string PublicKeySuffix =
            ",PublicKey=0024000004800000940000000602000000240000525341310004000001000100fb21e2a499fbcf"
            + "0cb875344dde9e0d1554954d090511cc735db683b9402a28e150bc1c8fcbe40eded55863b1f1b7"
            + "22c194aba08983514bdaaa241192cfc1f53d56e937e8a7f1b58ce3098df0019e6939f8e5097574"
            + "3c9a78b3b54530540c6f52918baf16ee6411cf2b3137597660f3767205ceb0b377c2a1bc343a01"
            + "2f8ab5d1";
#else
        public const string PublicKeySuffix = "";
#endif
    }
}
#endif
