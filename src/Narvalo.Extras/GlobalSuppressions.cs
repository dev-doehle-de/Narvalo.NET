// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

#if !NO_GLOBAL_SUPPRESSIONS

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "Narvalo",
    Justification = "This assembly is not meant to be used as it.")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "Narvalo.Collections",
    Justification = "This assembly is not meant to be used as it.")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "Narvalo.Fx",
    Justification = "This assembly is not meant to be used as it.")]

[assembly: SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields", Scope = "member", Target = "Narvalo.Collections.Internal.EnumerableIdentityExtensions+<>c__DisplayClass3`1+<>c__DisplayClass5.#CS$<>8__locals4",
    Justification = "[GeneratedCode] This method has been overridden for performance reasons.")]

#endif