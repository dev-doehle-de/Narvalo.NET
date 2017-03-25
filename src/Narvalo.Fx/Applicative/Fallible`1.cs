﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Applicative
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Runtime.ExceptionServices;

    using Narvalo.Properties;

    /// <summary>
    /// Represents the outcome of a computation which might have thrown an exception.
    /// An instance of the <see cref="Fallible{T}"/> class contains either a <c>T</c>
    /// value or the exception state at the point it was thrown.
    /// </summary>
    /// <remarks>
    /// <para>We do not catch exceptions throw by any supplied delegate; there is only one exception
    /// though: <see cref="Fallible{T}.Select{TResult}(Func{T, TResult})"/>. A good pratice is that
    /// a function that returns a <see cref="Fallible{T}"/> does not normally throw.</para>
    /// <para>This class is not meant to replace the standard exception mechanism.</para>
    /// </remarks>
    /// <typeparam name="T">The underlying type of the value.</typeparam>
    // Friendly version of Result<T, ExceptionDispatchInfo>.
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    [DebuggerTypeProxy(typeof(Fallible<>.DebugView))]
    public partial struct Fallible<T>
        : IEquatable<Fallible<T>>, Internal.IEither<T, ExceptionDispatchInfo>, Internal.Iterable<T>
    {
        private readonly ExceptionDispatchInfo _error;
        private readonly T _value;

        private Fallible(T value)
        {
            _error = default(ExceptionDispatchInfo);
            _value = value;
            IsSuccess = true;
        }

        private Fallible(ExceptionDispatchInfo error)
        {
            Debug.Assert(error != null);

            _error = error;
            _value = default(T);
            IsSuccess = false;
        }

        /// <summary>
        /// Gets a value indicating whether the object is the result of a successful computation.
        /// </summary>
        /// <value>true if the outcome was successful; otherwise false.</value>
        public bool IsSuccess { get; }

        /// <summary>
        /// Gets a value indicating whether the object is the result of an unsuccessful computation.
        /// </summary>
        /// <value>true if the outcome was unsuccessful; otherwise false.</value>
        public bool IsError => !IsSuccess;

        /// <summary>
        /// Obtains the enclosed value if any.
        /// </summary>
        /// <remarks>Any access to this method must be protected by checking before that
        /// <see cref="IsSuccess"/> is true.</remarks>
        internal T Value { get { Debug.Assert(IsSuccess); return _value; } }

        /// <summary>
        /// Obtains the captured exception state.
        /// </summary>
        /// <remarks>Any access to this method must be protected by checking before that
        /// <see cref="IsError"/> is true.</remarks>
        internal ExceptionDispatchInfo Error { get { Debug.Assert(IsError); return _error; } }

        [ExcludeFromCodeCoverage]
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[Intentionally] Debugger-only code.")]
        private string DebuggerDisplay => IsSuccess ? "Success" : "Error";

        public void ThrowIfError()
        {
            if (IsError) { Error.Throw(); }
        }

        /// <summary>
        /// Obtains the enclosed value if any; otherwise the default value of the type T.
        /// </summary>
        public T ValueOrDefault() => _value;

        public Maybe<T> ValueOrNone() => IsSuccess ? Maybe.Of(Value) : Maybe<T>.None;

        /// <summary>
        /// Returns the enclosed value if any; otherwise <paramref name="other"/>.
        /// </summary>
        /// <param name="other">A default value to be used if if there is no underlying value.</param>
        public T ValueOrElse(T other) => IsSuccess ? Value : other;

        public T ValueOrElse(Func<T> valueFactory)
        {
            Require.NotNull(valueFactory, nameof(valueFactory));

            return IsSuccess ? Value : valueFactory();
        }

        public T ValueOrThrow()
        {
            if (IsError) { Error.Throw(); }
            return Value;
        }

        public override string ToString()
            => IsSuccess ? "Success(" + Value?.ToString() + ")" : "Error(" + Error.ToString() + ")";

        /// <summary>
        /// Represents a debugger type proxy for <see cref="Fallible{T}"/>.
        /// </summary>
        /// <remarks>Ensure that <see cref="Fallible{T}.Value"/> and <see cref="Fallible{T}.Error"/>
        /// do not throw in the debugger for DEBUG builds.</remarks>
        [ExcludeFromCodeCoverage]
        private sealed class DebugView
        {
            private readonly Fallible<T> _inner;

            public DebugView(Fallible<T> inner)
            {
                _inner = inner;
            }

            public bool IsSuccess => _inner.IsSuccess;

            public T Value => _inner._value;

            public ExceptionDispatchInfo Error => _inner._error;
        }
    }

    // Conversions operators.
    public partial struct Fallible<T>
    {
        public T ToValue()
        {
            if (IsError) { throw new InvalidCastException(Strings.InvalidConversionToValue); }
            return Value;
        }

        public ExceptionDispatchInfo ToExceptionInfo()
        {
            if (IsSuccess) { throw new InvalidCastException(Strings.InvalidConversionToError); }
            return Error;
        }

        public Maybe<T> ToMaybe() => ValueOrNone();

        public Result<T, ExceptionDispatchInfo> ToResult()
            => IsError
            ? Result<T, ExceptionDispatchInfo>.FromError(Error)
            : Result<T, ExceptionDispatchInfo>.Of(Value);

        public static explicit operator T(Fallible<T> value) => value.ToValue();

        public static explicit operator ExceptionDispatchInfo(Fallible<T> value) => value.ToExceptionInfo();

        public static explicit operator Fallible<T>(T value) => η(value);
    }

    // Core Monad methods.
    public partial struct Fallible<T>
    {
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "[Intentionally] Raison d'être of this method.")]
        public Fallible<TResult> Bind<TResult>(Func<T, Fallible<TResult>> binder)
        {
            Require.NotNull(binder, nameof(binder));

            if (IsError) { return Fallible<TResult>.FromError(Error); }

            try
            {
                return binder(Value);
            }
            catch (Exception ex)
            {
                var edi = ExceptionDispatchInfo.Capture(ex);
                return Fallible<TResult>.FromError(edi);
            }
        }

        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Fallible<T> η(T value) => new Fallible<T>(value);

        // NB: This method is normally internal, but Fallible<T>.FromError() is more readable
        // than Fallible.FromError<T>() - no type inference.
        [SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes", Justification = "[Intentionally] A static method in a static class won't help.")]
        public static Fallible<T> FromError(ExceptionDispatchInfo error)
        {
            Require.NotNull(error, nameof(error));

            return new Fallible<T>(error);
        }

        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Fallible<T> μ(Fallible<Fallible<T>> square)
            => square.IsSuccess ? square.Value : FromError(square.Error);
    }

    // Query Expression Pattern.
    public partial struct Fallible<T>
    {
        // Fallible<T> is not a MonadOr but we can still construct a Where() operator.
        // It is weird that it works (filter is not a predicate) but it does.
        public Fallible<T> Where(Func<T, Fallible> filter)
        {
            Require.NotNull(filter, nameof(filter));

            return Bind(val => filter(val).ReplaceBy(val));
        }
    }

    // Implements the Internal.IEither<T, ExceptionDispatchInfo> interface.
    public partial struct Fallible<T>
    {
        public bool Contains(T value)
        {
            if (IsError) { return false; }
            return EqualityComparer<T>.Default.Equals(Value, value);
        }

        public bool Contains(T value, IEqualityComparer<T> comparer)
        {
            Require.NotNull(comparer, nameof(comparer));

            if (IsError) { return false; }
            return comparer.Equals(Value, value);
        }

        [SuppressMessage("Microsoft.Naming", "CA1725:ParameterNamesShouldMatchBaseDeclaration", MessageId = "0#", Justification = "[Intentionally] Internal interface.")]
        [SuppressMessage("Microsoft.Naming", "CA1725:ParameterNamesShouldMatchBaseDeclaration", MessageId = "1#", Justification = "[Intentionally] Internal interface.")]
        public TResult Match<TResult>(
            Func<T, TResult> caseSuccess,
            Func<ExceptionDispatchInfo, TResult> caseError)
        {
            Require.NotNull(caseSuccess, nameof(caseSuccess));
            Require.NotNull(caseError, nameof(caseError));

            return IsSuccess ? caseSuccess(Value) : caseError(Error);
        }

        [SuppressMessage("Microsoft.Naming", "CA1725:ParameterNamesShouldMatchBaseDeclaration", MessageId = "0#", Justification = "[Intentionally] Internal interface.")]
        [SuppressMessage("Microsoft.Naming", "CA1725:ParameterNamesShouldMatchBaseDeclaration", MessageId = "1#", Justification = "[Intentionally] Internal interface.")]
        public void Do(Action<T> onSuccess, Action<ExceptionDispatchInfo> onError)
        {
            Require.NotNull(onSuccess, nameof(onSuccess));
            Require.NotNull(onError, nameof(onError));

            if (IsSuccess) { onSuccess(Value); } else { onError(Error); }
        }

        public void WhenSuccess(Func<T, bool> predicate, Action<T> action)
        {
            Require.NotNull(predicate, nameof(predicate));
            Require.NotNull(action, nameof(action));

            if (IsSuccess && predicate(Value)) { action(Value); }
        }

        public void WhenError(
            Func<ExceptionDispatchInfo, bool> predicate,
            Action<ExceptionDispatchInfo> action)
        {
            Require.NotNull(predicate, nameof(predicate));
            Require.NotNull(action, nameof(action));

            if (IsError && predicate(Error)) { action(Error); }
        }

        public void OnSuccess(Action<T> action)
        {
            Require.NotNull(action, nameof(action));

            if (IsSuccess) { action(Value); }
        }

        public void OnError(Action<ExceptionDispatchInfo> action)
        {
            Require.NotNull(action, nameof(action));

            if (IsError) { action(Error); }
        }

        #region Publicly hidden methods.

        [ExcludeFromCodeCoverage]
        bool Internal.ISecondaryContainer<ExceptionDispatchInfo>.Contains(ExceptionDispatchInfo value)
        {
            throw new NotSupportedException();
        }

        [ExcludeFromCodeCoverage]
        bool Internal.ISecondaryContainer<ExceptionDispatchInfo>.Contains(
            ExceptionDispatchInfo value,
            IEqualityComparer<ExceptionDispatchInfo> comparer)
        {
            throw new NotSupportedException();
        }

        // Alias for WhenSuccess().
        [ExcludeFromCodeCoverage]
        void Internal.IContainer<T>.When(Func<T, bool> predicate, Action<T> action)
           => WhenSuccess(predicate, action);

        // Alias for WhenError().
        [ExcludeFromCodeCoverage]
        void Internal.ISecondaryContainer<ExceptionDispatchInfo>.When(
            Func<ExceptionDispatchInfo, bool> predicate,
            Action<ExceptionDispatchInfo> action)
            => WhenError(predicate, action);

        // Alias for OnSuccess().
        [ExcludeFromCodeCoverage]
        void Internal.IContainer<T>.Do(Action<T> action) => OnSuccess(action);

        // Alias for OnError().
        [ExcludeFromCodeCoverage]
        void Internal.ISecondaryContainer<ExceptionDispatchInfo>.Do(Action<ExceptionDispatchInfo> action)
            => OnError(action);

        #endregion
    }

    // Implements the Internal.Iterable<T> interface.
    public partial struct Fallible<T>
    {
        public IEnumerable<T> ToEnumerable() => IsSuccess ? Sequence.Of(Value) : Enumerable.Empty<T>();

        public IEnumerator<T> GetEnumerator() => ToEnumerable().GetEnumerator();
    }

    // Implements the IEquatable<Fallible<T>> interface.
    public partial struct Fallible<T>
    {
        public static bool operator ==(Fallible<T> left, Fallible<T> right) => left.Equals(right);

        public static bool operator !=(Fallible<T> left, Fallible<T> right) => !left.Equals(right);

        public bool Equals(Fallible<T> other)
        {
            if (IsSuccess) { return other.IsSuccess && EqualityComparer<T>.Default.Equals(Value, other.Value); }
            return other.IsError && ReferenceEquals(Error, other.Error);
        }

        public bool Equals(Fallible<T> other, IEqualityComparer<T> comparer)
        {
            Require.NotNull(comparer, nameof(comparer));

            if (IsSuccess) { return other.IsSuccess && comparer.Equals(Value, other.Value); }
            return other.IsError && ReferenceEquals(Error, other.Error);
        }

        public override bool Equals(object obj)
            => (obj is Fallible<T>) && Equals((Fallible<T>)obj);

        public bool Equals(object other, IEqualityComparer<T> comparer)
            => (other is Fallible<T>) && Equals((Fallible<T>)other, comparer);

        public override int GetHashCode()
            => HashCodeHelpers.Combine(_value?.GetHashCode() ?? 0, _error?.GetHashCode() ?? 0);

        public int GetHashCode(IEqualityComparer<T> comparer)
        {
            Require.NotNull(comparer, nameof(comparer));

            return HashCodeHelpers.Combine(comparer.GetHashCode(_value), _error?.GetHashCode() ?? 0);
        }
    }
}
