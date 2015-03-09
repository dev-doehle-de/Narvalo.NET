// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

#if !NO_GLOBAL_SUPPRESSIONS

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "Narvalo.Diagnostics.Benchmarking",
    Justification = "Complements the namespace from Narvalo.Core.")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "Narvalo.Collections",
    Justification = "Complements the namespace from Narvalo.Core.")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "Narvalo.Xml",
    Justification = "Complements the namespace from Narvalo.Core.")]

[assembly: SuppressMessage("Microsoft.Performance", "CA1804:RemoveUnusedLocals", MessageId = "dir", Scope = "member", Target = "Narvalo.IO.FileFinder+<Find>d__0.#System.IDisposable.Dispose()",
    Justification = "[GeneratedCode] False positive?")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1804:RemoveUnusedLocals", MessageId = "dir", Scope = "member", Target = "Narvalo.IO.ConcurrentFileFinder+<Find>d__0.#System.IDisposable.Dispose()",
    Justification = "[GeneratedCode] False positive?")]

#endif