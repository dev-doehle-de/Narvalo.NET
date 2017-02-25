﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Fx
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Runtime.ExceptionServices;

    using Narvalo.Fx.Properties;

    /// <summary>
    /// Represents the outcome of a computation which might have thrown an exception.
    /// An instance of the <see cref="ResultOrError{T}"/> class contains either a <c>T</c>
    /// value or the exception state at the point it was thrown.
    /// </summary>
    /// <remarks>
    /// <para>We do not catch exceptions throw by any supplied delegate; there is only one exception
    /// though: <see cref="ResultOrError{T}.Select{TResult}(Func{T, TResult})"/>. A good pratice is that
    /// a function that returns a <see cref="ResultOrError{T}"/> does not normally throw.</para>
    /// <para>This class is not meant to replace the standard exception mechanism.</para>
    /// </remarks>
    /// <typeparam name="T">The underlying type of the value.</typeparam>
    // Friendly version of Either<T, ExceptionDispatchInfo>.
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public abstract partial class ResultOrError<T>
        : Internal.IEither<T, ExceptionDispatchInfo>, Internal.Iterable<T>
    {
#if CONTRACTS_FULL // Custom ctor visibility for the contract class only.
        protected ResultOrError() { }
#else
        private ResultOrError() { }
#endif

        /// <summary>
        /// Gets a value indicating whether the object is the result of a successful computation.
        /// </summary>
        /// <remarks>Most of the time, you don't need to access this property.
        /// You are better off using the rich vocabulary that this class offers.</remarks>
        /// <value>true if the outcome was successful; otherwise false.</value>
        public abstract bool IsSuccess { get; }

        public bool IsError => !IsSuccess;

        /// <summary>
        /// Obtains the enclosed value.
        /// </summary>
        /// <remarks>Any access to this method must be protected by checking before that
        /// <see cref="IsSuccess"/> is true.</remarks>
        internal abstract T Value { get; }

        /// <summary>
        /// Obtains the enclosed exception state.
        /// </summary>
        /// <remarks>Any access to this method must be protected by checking before that
        /// <see cref="IsSuccess"/> is false.</remarks>
        internal abstract ExceptionDispatchInfo ExceptionInfo { get; }

        [ExcludeFromCodeCoverage(Justification = "Debugger-only code.")]
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[Intentionally] Debugger-only code.")]
        private string DebuggerDisplay => IsSuccess ? "Success" : "Error";

        public abstract void ThrowIfError();

        /// <summary>
        /// Obtains the underlying value if any; otherwise the default value of the type T.
        /// </summary>
        /// <returns>The underlying value if any; otherwise the default value of the type T.</returns>
        public abstract T ValueOrDefault();

        /// <summary>
        /// Returns the underlying value if any; otherwise <paramref name="other"/>.
        /// </summary>
        /// <param name="other">A default value to be used if if there is no underlying value.</param>
        /// <returns>The underlying value if any; otherwise <paramref name="other"/>.</returns>
        public abstract T ValueOrElse(T other);

        public abstract T ValueOrElse(Func<T> valueFactory);

        public abstract Maybe<T> ValueOrNone();

        public abstract T ValueOrThrow();

        /// <summary>
        /// Represents the "success" part of the <see cref="ResultOrError{T}"/> type.
        /// </summary>
        [DebuggerTypeProxy(typeof(ResultOrError<>.Success_.DebugView))]
        private sealed partial class Success_ : ResultOrError<T>
        {
            public Success_(T value) { Value = value; }

            public override bool IsSuccess => true;

            internal override T Value { get; }

            internal override ExceptionDispatchInfo ExceptionInfo
            {
                get { throw new InvalidOperationException("XXX"); }
            }

            public override void ThrowIfError() { }

            public override T ValueOrDefault() => Value;

            public override T ValueOrElse(T other) => Value;

            public override T ValueOrElse(Func<T> valueFactory) => Value;

            public override Maybe<T> ValueOrNone() => Maybe.Of(Value);

            public override T ValueOrThrow() => Value;

            public override string ToString()
            {
                Warrant.NotNull<string>();

                return Format.Current("Success({0})", Value);
            }

            /// <summary>
            /// Represents a debugger type proxy for <see cref="ResultOrError{T}.Success_"/>.
            /// </summary>
            [ContractVerification(false)] // Debugger-only code.
            [ExcludeFromCodeCoverage(Justification = "Debugger-only code.")]
            private sealed class DebugView
            {
                private readonly ResultOrError<T> _inner;

                public DebugView(ResultOrError<T> inner)
                {
                    _inner = inner;
                }

                public T Value => _inner.Value;
            }
        }

        /// <summary>
        /// Represents the "failure" part of the <see cref="ResultOrError{T}"/> type.
        /// </summary>
        [DebuggerTypeProxy(typeof(ResultOrError<>.Error_.DebugView))]
        private sealed partial class Error_ : ResultOrError<T>
        {
            private readonly ExceptionDispatchInfo _exceptionInfo;

            public Error_(ExceptionDispatchInfo exceptionInfo)
            {
                Demand.NotNull(exceptionInfo);

                _exceptionInfo = exceptionInfo;
            }

            public override bool IsSuccess => false;

            internal override T Value
            {
                get { throw new InvalidOperationException("XXX"); }
            }

            internal override ExceptionDispatchInfo ExceptionInfo
            {
                get { Warrant.NotNull<ExceptionDispatchInfo>(); return _exceptionInfo; }
            }

            public override void ThrowIfError() => ExceptionInfo.Throw();

            public override T ValueOrDefault() => default(T);

            public override T ValueOrElse(T other) => other;

            public override T ValueOrElse(Func<T> valueFactory)
            {
                Require.NotNull(valueFactory, nameof(valueFactory));

                return valueFactory.Invoke();
            }

            public override Maybe<T> ValueOrNone() => Maybe<T>.None;

            public override T ValueOrThrow()
            {
                ExceptionInfo.Throw();

                return default(T);
            }

            public override string ToString()
            {
                Warrant.NotNull<string>();

                return Format.Current("Error({0})", ExceptionInfo);
            }

            /// <summary>
            /// Represents a debugger type proxy for <see cref="ResultOrError{T}.Error_"/>.
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

                public ExceptionDispatchInfo ExceptionInfo => _inner.ExceptionInfo;
            }
        }
    }

    // Conversions operators.
    public partial class ResultOrError<T>
    {
        public abstract T ToValue();

        public abstract Exception ToException();

        public abstract ExceptionDispatchInfo ToExceptionInfo();

        public abstract Result<T, Exception> ToResult();

        public static explicit operator T(ResultOrError<T> value)
            => value == null ? default(T) : value.ToValue();

        public static explicit operator Exception(ResultOrError<T> value)
            => value?.ToException();

        public static explicit operator ExceptionDispatchInfo(ResultOrError<T> value)
            => value?.ToExceptionInfo();

        public static explicit operator Result<T, Exception>(ResultOrError<T> value)
            => value?.ToResult();

        public static explicit operator ResultOrError<T>(T value)
        {
            Warrant.NotNull<ResultOrError<T>>();

            return ResultOrError.Of(value);
        }

        public static explicit operator ResultOrError<T>(ExceptionDispatchInfo exceptionInfo)
            => exceptionInfo == null ? null : ResultOrError.FromError<T>(exceptionInfo);

        private partial class Success_
        {
            public override T ToValue() => Value;

            public override Exception ToException()
            {
                throw new InvalidCastException("XXX");
            }

            public override ExceptionDispatchInfo ToExceptionInfo()
            {
                throw new InvalidCastException("XXX");
            }

            public override Result<T, Exception> ToResult() => Result.Of<T, Exception>(Value);
        }

        private partial class Error_
        {
            public override T ToValue()
            {
                throw new InvalidCastException(Strings.ResultOrError_CannotCastFailureToValue);
            }

            public override Exception ToException() => ExceptionInfo.SourceException;

            public override ExceptionDispatchInfo ToExceptionInfo() => ExceptionInfo;

            public override Result<T, Exception> ToResult()
                => Result.FromError<T, Exception>(ExceptionInfo.SourceException);
        }
    }

    // Core Monad methods.
    public partial class ResultOrError<T>
    {
        public abstract ResultOrError<TResult> Bind<TResult>(Func<T, ResultOrError<TResult>> selector);

        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ResultOrError<T> η(T value) => new Success_(value);

        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ResultOrError<T> η(ExceptionDispatchInfo exceptionInfo)
        {
            Require.NotNull(exceptionInfo, nameof(exceptionInfo));

            return new Error_(exceptionInfo);
        }

        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ResultOrError<T> μ(ResultOrError<ResultOrError<T>> square)
        {
            Require.NotNull(square, nameof(square));

            return square.IsSuccess ? square.Value : ResultOrError.FromError<T>(square.ExceptionInfo);
        }

        private partial class Success_
        {
            [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "[Intentionally] Raison d'être of ResultOrError.")]
            public override ResultOrError<TResult> Bind<TResult>(Func<T, ResultOrError<TResult>> selector)
            {
                Require.NotNull(selector, nameof(selector));

                // Catching all exceptions is not a good practice, but here it makes sense, since
                // the type is supposed to encode the exception too.
                try
                {
                    return selector.Invoke(Value);
                }
                catch (Exception ex)
                {
                    var edi = ExceptionDispatchInfo.Capture(ex);
                    return ResultOrError.FromError<TResult>(edi);
                }
            }
        }

        private partial class Error_
        {
            public override ResultOrError<TResult> Bind<TResult>(Func<T, ResultOrError<TResult>> selector)
                => ResultOrError.FromError<TResult>(ExceptionInfo);
        }
    }

    // Implements the Internal.IEither<T, ExceptionDispatchInfo> interface.
    public partial class ResultOrError<T>
    {
        [SuppressMessage("Microsoft.Naming", "CA1725:ParameterNamesShouldMatchBaseDeclaration", MessageId = "0#", Justification = "[Intentionally] Internal interface.")]
        [SuppressMessage("Microsoft.Naming", "CA1725:ParameterNamesShouldMatchBaseDeclaration", MessageId = "1#", Justification = "[Intentionally] Internal interface.")]
        public abstract TResult Match<TResult>(
            Func<T, TResult> caseSuccess,
            Func<ExceptionDispatchInfo, TResult> caseError);

        // Alias for WhenSuccess().
        // NB: We keep this one public as it overrides the auto-generated method.
        public void When(Func<T, bool> predicate, Action<T> action)
            => WhenSuccess(predicate, action);

        // Alias for WhenError(). Publicly hidden.
        void Internal.ISecondaryContainer<ExceptionDispatchInfo>.When(
            Func<ExceptionDispatchInfo, bool> predicate,
            Action<ExceptionDispatchInfo> action)
            => WhenError(predicate, action);

        [SuppressMessage("Microsoft.Naming", "CA1725:ParameterNamesShouldMatchBaseDeclaration", MessageId = "0#", Justification = "[Intentionally] Internal interface.")]
        [SuppressMessage("Microsoft.Naming", "CA1725:ParameterNamesShouldMatchBaseDeclaration", MessageId = "1#", Justification = "[Intentionally] Internal interface.")]
        public abstract void Do(Action<T> onSuccess, Action<ExceptionDispatchInfo> onError);

        // Alias for OnSuccess(). Publicly hidden.
        void Internal.IContainer<T>.Do(Action<T> onSuccess) => OnSuccess(onSuccess);

        // Alias for OnError(). Publicly hidden.
        void Internal.ISecondaryContainer<ExceptionDispatchInfo>.Do(Action<ExceptionDispatchInfo> onError)
            => OnError(onError);

        public abstract void WhenSuccess(Func<T, bool> predicate, Action<T> action);

        public abstract void WhenError(
            Func<ExceptionDispatchInfo, bool> predicate,
            Action<ExceptionDispatchInfo> action);

        public abstract void OnSuccess(Action<T> action);

        public abstract void OnError(Action<ExceptionDispatchInfo> action);

        private partial class Success_
        {
            public override TResult Match<TResult>(
                Func<T, TResult> caseSuccess,
                Func<ExceptionDispatchInfo, TResult> caseError)
            {
                Require.NotNull(caseSuccess, nameof(caseSuccess));

                return caseSuccess.Invoke(Value);
            }

            public override void WhenSuccess(Func<T, bool> predicate, Action<T> action)
            {
                Require.NotNull(predicate, nameof(predicate));
                Require.NotNull(action, nameof(action));

                if (predicate.Invoke(Value)) { action.Invoke(Value); }
            }

            public override void WhenError(
                Func<ExceptionDispatchInfo, bool> predicate,
                Action<ExceptionDispatchInfo> action)
            { }

            public override void Do(Action<T> onSuccess, Action<ExceptionDispatchInfo> onError)
            {
                Require.NotNull(onSuccess, nameof(onSuccess));

                onSuccess.Invoke(Value);
            }

            public override void OnSuccess(Action<T> action)
            {
                Require.NotNull(action, nameof(action));

                action.Invoke(Value);
            }

            public override void OnError(Action<ExceptionDispatchInfo> action) { }
        }

        private partial class Error_
        {
            public override TResult Match<TResult>(
                Func<T, TResult> caseSuccess,
                Func<ExceptionDispatchInfo, TResult> caseError)
            {
                Require.NotNull(caseError, nameof(caseError));

                return caseError.Invoke(ExceptionInfo);
            }

            public override void WhenSuccess(Func<T, bool> predicate, Action<T> action) { }

            public override void WhenError(
                Func<ExceptionDispatchInfo, bool> predicate,
                Action<ExceptionDispatchInfo> action)
            {
                Require.NotNull(predicate, nameof(predicate));
                Require.NotNull(action, nameof(action));

                if (predicate.Invoke(ExceptionInfo)) { action.Invoke(ExceptionInfo); }
            }

            public override void Do(Action<T> onSuccess, Action<ExceptionDispatchInfo> OnError)
            {
                Require.NotNull(OnError, nameof(OnError));

                OnError.Invoke(ExceptionInfo);
            }

            public override void OnSuccess(Action<T> action) { }

            public override void OnError(Action<ExceptionDispatchInfo> action)
            {
                Require.NotNull(action, nameof(action));

                action.Invoke(ExceptionInfo);
            }
        }
    }

    // Implements the Internal.Iterable<T> interface.
    public partial class ResultOrError<T>
    {
        public abstract IEnumerable<T> ToEnumerable();

        public IEnumerator<T> GetEnumerator()
        {
            Warrant.NotNull<IEnumerator<T>>();

            return ToEnumerable().GetEnumerator();
        }

        private partial class Success_
        {
            public override IEnumerable<T> ToEnumerable()
            {
                Warrant.NotNull<IEnumerable<T>>();

                return Sequence.Of(Value);
            }
        }

        private partial class Error_
        {
            public override IEnumerable<T> ToEnumerable()
            {
                Warrant.NotNull<IEnumerable<T>>();

                return Enumerable.Empty<T>();
            }
        }
    }
}

#if CONTRACTS_FULL

namespace Narvalo.Fx
{
    using System;
    using System.Diagnostics.Contracts;

    // In real world, only Success_ and Error_ can inherit from ResultOrError.
    // Adding the following object invariants on ResultOrError<T>:
    //  (IsSuccess && this is Success_) || (this is Error_)
    // should make unecessary any call to Contract.Assume but I have not been able to make this work.
    [ContractClass(typeof(ResultOrErrorContract<>))]
    public partial class ResultOrError<T>
    {
        private partial class Success_
        {
            [ContractInvariantMethod]
            private void ObjectInvariant()
            {
                Contract.Invariant(IsSuccess);
            }
        }

        private partial class Error_
        {
            [ContractInvariantMethod]
            private void ObjectInvariant()
            {
                Contract.Invariant(IsError);
                Contract.Invariant(_exceptionInfo != null);
            }
        }
    }

    [ContractClassFor(typeof(ResultOrError<>))]
    internal abstract class ResultOrErrorContract<T> : ResultOrError<T>
    {
        protected ResultOrErrorContract() { }

        public override ResultOrError<TResult> Bind<TResult>(Func<T, ResultOrError<TResult>> selector)
        {
            Contract.Requires(selector != null);

            return default(ResultOrError<TResult>);
        }

        public override ResultOrError<TResult> Select<TResult>(Func<T, TResult> selector)
        {
            Contract.Requires(selector != null);

            return default(ResultOrError<TResult>);
        }
    }
}

#endif