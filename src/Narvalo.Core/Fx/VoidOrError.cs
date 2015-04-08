﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Fx
{
    using System.Diagnostics.Contracts;
    using System.Runtime.ExceptionServices;

    /// <seealso cref="Output{T}"/>
    /// <seealso cref="Either{T1, T2}"/>
    /// <seealso cref="Switch{T1, T2}"/>
    /// <seealso cref="VoidOrBreak"/>
    public class VoidOrError
    {
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
                Contract.Ensures(Contract.Result<VoidOrError>() != null);

                return s_Void;
            }
        }

        public bool IsError { get { return _isError; } }

        public static VoidOrError Error(ExceptionDispatchInfo exceptionInfo)
        {
            Require.NotNull(exceptionInfo, "exceptionInfo");
            Contract.Ensures(Contract.Result<VoidOrError>() != null);

            return new VoidOrError.Error_(exceptionInfo);
        }

        public virtual void ThrowIfError() { }

        public override string ToString()
        {
            Contract.Ensures(Contract.Result<string>() != null);

            return "Void";
        }

        private sealed class Error_ : VoidOrError
        {
            private readonly ExceptionDispatchInfo _exceptionInfo;

            public Error_(ExceptionDispatchInfo exceptionInfo)
                : base(true)
            {
                Contract.Requires(exceptionInfo != null);

                _exceptionInfo = exceptionInfo;
            }

            public override void ThrowIfError()
            {
                _exceptionInfo.Throw();
            }

            public override string ToString()
            {
                Contract.Ensures(Contract.Result<string>() != null);

                return Format.CurrentCulture("Error({0})", _exceptionInfo.SourceException.Message);
            }

#if CONTRACTS_FULL // Contract Class and Object Invariants.

            [ContractInvariantMethod]
            private void ObjectInvariants()
            {
                Contract.Invariant(_exceptionInfo != null);
            }

#endif
        }
    }
}
