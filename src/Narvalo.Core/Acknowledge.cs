﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.Contracts;

    /// <summary>
    /// Provides Code Contracts abbreviators and helpers.
    /// </summary>
    public static class Acknowledge
    {
        /// <summary>
        /// Checks that the specified object parameter is not <see langword="null"/>.
        /// </summary>
        /// <typeparam name="T">The type of <paramref name="this"/>.</typeparam>
        /// <param name="this">The object to check.</param>
        [DebuggerHidden]
        [ContractAbbreviator]
        [Conditional("CONTRACTS_FULL")]
        public static void Object<T>(T @this)
        {
            Contract.Requires(@this != null);
        }

        /// <summary>
        /// Asserts that a point of execution is unreachable.
        /// </summary>
        /// <remarks>Adapted from <seealso cref="!:http://blogs.msdn.com/b/francesco/archive/2014/09/12/how-to-use-cccheck-to-prove-no-case-is-forgotten.aspx"/>.</remarks>
        /// <example>
        /// switch (myEnum)
        /// {
        ///     case MyEnum.DefinedValue:
        ///         return "DefinedValue";
        ///     default:
        ///         throw Acknowledge.Unreachable("Found a missing case in the switch.");
        /// }
        /// </example>
        /// <param name="reason">The error message to use if the point of execution is reached.</param>
        /// <returns>A new instance of the <see cref="NotSupportedException"/> class with the specified error message.</returns>
        [DebuggerHidden]
        [ContractVerification(false)]
        public static NotSupportedException Unreachable(string reason)
        {
            Contract.Requires(false);

            return new NotSupportedException(reason);
        }

        /// <summary>
        /// Asserts that a point of execution is unreachable.
        /// </summary>
        /// <remarks>Adapted from <seealso cref="!:http://blogs.msdn.com/b/francesco/archive/2014/09/12/how-to-use-cccheck-to-prove-no-case-is-forgotten.aspx"/>.</remarks>
        /// <example>
        /// switch (myEnum)
        /// {
        ///     case MyEnum.DefinedValue:
        ///         return "DefinedValue";
        ///     default:
        ///         throw Acknowledge.Unreachable(new MyException("Found a missing case in the switch."));
        /// }
        /// </example>
        /// <typeparam name="TException">The type of <paramref name="exception"/>.</typeparam>
        /// <param name="exception">The exception the caller wish to throw back from here.</param>
        /// <returns>The untouched input <paramref name="exception"/>.</returns>
        [DebuggerHidden]
        [ContractVerification(false)]
        public static TException Unreachable<TException>(TException exception)
            where TException : Exception
        {
            Contract.Requires(false);

            return exception;
        }
    }
}