// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "Narvalo.Collections",
    Justification = "[Intentionally] Hopefully more will come.")]

[assembly: SuppressMessage("Microsoft.Performance", "CA1804:RemoveUnusedLocals", MessageId = "dir", Scope = "member", Target = "Narvalo.IO.FileFinder+<Find>d__0.#System.IDisposable.Dispose()", Justification = "[FIXME]")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1804:RemoveUnusedLocals", MessageId = "dir", Scope = "member", Target = "Narvalo.IO.ConcurrentFileFinder+<Find>d__0.#System.IDisposable.Dispose()", Justification = "[FIXME]")]
