﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Fx
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.Contracts;
    using System.Runtime.ExceptionServices;

    using static System.Diagnostics.Contracts.Contract;

    /// <seealso cref="Outcome{T}"/>
    /// <seealso cref="Either{T1, T2}"/>
    /// <seealso cref="Switch{T1, T2}"/>
    /// <seealso cref="VoidOrBreak"/>
    [DebuggerDisplay(@"""Void""")]
    public class VoidOrError
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static readonly VoidOrError s_Void = new VoidOrError();

        private readonly bool _isError;

        private VoidOrError() { }

        private VoidOrError(bool isError)
        {
            _isError = isError;
        }

        public static VoidOrError Void
        {
            get
            {
                Ensures(Result<VoidOrError>() != null);

                return s_Void;
            }
        }

        public bool IsError { get { return _isError; } }

        public static VoidOrError Error(ExceptionDispatchInfo exceptionInfo)
        {
            Require.NotNull(exceptionInfo, nameof(exceptionInfo));
            Ensures(Result<VoidOrError>() != null);

            return new VoidOrError.Error_(exceptionInfo);
        }

        public virtual void ThrowIfError() { }

        public override string ToString()
        {
            Ensures(Result<string>() != null);

            return "Void";
        }

        [DebuggerDisplay(@"""Error""")]
        [DebuggerTypeProxy(typeof(Error_.DebugView))]
        private sealed class Error_ : VoidOrError
        {
            private readonly ExceptionDispatchInfo _exceptionInfo;

            public Error_(ExceptionDispatchInfo exceptionInfo)
                : base(true)
            {
                Demand.NotNull(exceptionInfo);

                _exceptionInfo = exceptionInfo;
            }

            public override void ThrowIfError() => _exceptionInfo.Throw();

            public override string ToString()
            {
                Ensures(Result<string>() != null);

                Exception exception = _exceptionInfo.SourceException;
                Assume(exception != null);

                return Format.Current("Error({0})", exception.Message);
            }

#if CONTRACTS_FULL // Contract Class and Object Invariants.

            [ContractInvariantMethod]
            private void ObjectInvariant()
            {
                Invariant(_exceptionInfo != null);
            }

#endif

            /// <summary>
            /// Represents a debugger type proxy for <see cref="VoidOrError.Error_"/>.
            /// </summary>
            [ContractVerification(false)] // Debugger-only code.
            [ExcludeFromCodeCoverage(Justification = "Debugger-only code.")]
            private sealed class DebugView
            {
                private readonly Error_ _inner;

                public DebugView(Error_ inner)
                {
                    _inner = inner;
                }

                public ExceptionDispatchInfo ExceptionInfo
                {
                    get { return _inner._exceptionInfo; }
                }
            }
        }
    }
}
