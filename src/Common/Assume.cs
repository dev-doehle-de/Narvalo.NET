﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Internal
{
    using System.Diagnostics;
    using System.Diagnostics.Contracts;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Provides helper methods to instruct the code analysis tools
    /// that certain conditions are met.
    /// </summary>
    [DebuggerStepThrough]
    internal static class Assume
    {
        /// <summary>
        /// Instructs code analysis tools to assume that the specified object is not null,
        /// even if it cannot be statically proven to always be not null.
        /// </summary>
        /// <remarks>
        /// When dealing with external dependencies, CCCheck can not infer
        /// that the result of a method is not null. When we know for sure that
        /// the result is not null, this extension method is a useful alias
        /// to inform CCCheck not to worry of <see langword="null"/> values here.
        /// </remarks>
        /// <typeparam name="T">The underlying type of the object.</typeparam>
        /// <param name="this">The input object.</param>
        /// <returns>The untouched input.</returns>
        [DebuggerHidden]
#if !CONTRACTS_FULL
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static T AssumeNotNull<T>(this T @this) where T : class
        {
            Contract.Ensures(Contract.Result<T>() == @this);
            Contract.Ensures(Contract.Result<T>() != null);
            Contract.Assume(@this != null);

            return @this;
        }

        /// <summary>
        /// According to its documentation, CCCheck only assumes and asserts
        /// object invariants for the "this" object. This method allows
        /// to state explicitly the object invariance.
        /// </summary>
        /// <typeparam name="T">The underlying type of the object.</typeparam>
        /// <param name="obj">The invariant object.</param>
        [DebuggerHidden]
        [Conditional("CONTRACTS_FULL")]
        public static void Invariant<T>(T obj) where T : class { }
    }
}
