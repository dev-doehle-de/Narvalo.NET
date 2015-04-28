﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Fx.Advanced
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Runtime.ExceptionServices;

    /// <summary>
    /// Provides extension methods for <see cref="Func{T}"/>.
    /// </summary>
    public static partial class FuncExtensions
    {
        public static Func<TResult> Bind<TSource, TResult>(
            this Func<TSource> @this,
            Func<TSource, Func<TResult>> selector)
        {
            Require.Object(@this);
            Require.NotNull(selector, "selector");

            return selector.Invoke(@this.Invoke());
        }

        public static Func<TResult> Select<TSource, TResult>(this Func<TSource> @this, Func<TSource, TResult> selector)
        {
            Require.Object(@this);
            Require.NotNull(selector, "selector");
            Contract.Ensures(Contract.Result<Func<TResult>>() != null);

            return () => selector.Invoke(@this.Invoke());
        }
    }

    /// <content>
    /// Provides extension methods for <see cref="Func{T}"/> that depend on the <see cref="Nullable{T}"/> class.
    /// </content>
    public static partial class FuncExtensions
    {
        #region Basic Monad functions (Prelude)

        public static TResult? Invoke<TSource, TResult>(
            this Func<TSource, TResult?> @this,
            TSource? value)
            where TSource : struct
            where TResult : struct
        {
            Acknowledge.Object(@this);

            return value.Bind(@this);
        }

        public static Func<TSource, TResult?> Compose<TSource, TMiddle, TResult>(
            this Func<TSource, TMiddle?> @this,
            Func<TMiddle, TResult?> funM)
            where TSource : struct
            where TMiddle : struct
            where TResult : struct
        {
            Require.Object(@this);
            Contract.Ensures(Contract.Result<Func<TSource, TResult?>>() != null);

            return _ => @this.Invoke(_).Bind(funM);
        }

        public static Func<TSource, TResult?> ComposeBack<TSource, TMiddle, TResult>(
            this Func<TMiddle, TResult?> @this,
            Func<TSource, TMiddle?> funM)
            where TSource : struct
            where TMiddle : struct
            where TResult : struct
        {
            Require.Object(@this);
            Require.NotNull(funM, "funM");
            Contract.Ensures(Contract.Result<Func<TSource, TResult?>>() != null);

            return _ => funM.Invoke(_).Bind(@this);
        }

        #endregion
    }

    /// <content>
    /// Provides extension methods for <see cref="Func{T}"/> that depend on the <see cref="Output{T}"/> class.
    /// </content>
    public static partial class FuncExtensions
    {
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter",
            Justification = "[Intentionally] There is no way we can achieve the same thing with type parameter inference.")]
        public static Output<TSource> Catch<TSource, TException>(this Func<TSource> @this) where TException : Exception
        {
            Require.Object(@this);
            Contract.Ensures(Contract.Result<Output<TSource>>() != null);

            try
            {
                TSource value = @this.Invoke();

                return Output.Success(value);
            }
            catch (TException ex)
            {
                var edi = ExceptionDispatchInfo.Capture(ex);

                return Output.Failure<TSource>(edi);
            }
        }

        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter",
            Justification = "[Intentionally] There is no way we can achieve the same thing with type parameter inference.")]
        [SuppressMessage("Microsoft.Contracts", "Suggestion-23-0",
            Justification = "[Ignore] Unrecognized postcondition by CCCheck.")]
        public static Output<TSource> Catch<TSource, T1Exception, T2Exception>(this Func<TSource> @this)
            where T1Exception : Exception
            where T2Exception : Exception
        {
            Require.Object(@this);
            Contract.Ensures(Contract.Result<Output<TSource>>() != null);

            ExceptionDispatchInfo edi;

            try
            {
                TSource value = @this.Invoke();

                return Output.Success(value);
            }
            catch (T1Exception ex) { edi = ExceptionDispatchInfo.Capture(ex); }
            catch (T2Exception ex) { edi = ExceptionDispatchInfo.Capture(ex); }

            return Output.Failure<TSource>(edi);
        }

        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter",
            Justification = "[Intentionally] There is no way we can achieve the same thing with type parameter inference.")]
        [SuppressMessage("Microsoft.Contracts", "Suggestion-23-0",
            Justification = "[Ignore] Unrecognized postcondition by CCCheck.")]
        public static Output<TSource> Catch<TSource, T1Exception, T2Exception, T3Exception>(this Func<TSource> @this)
            where T1Exception : Exception
            where T2Exception : Exception
            where T3Exception : Exception
        {
            Require.Object(@this);
            Contract.Ensures(Contract.Result<Output<TSource>>() != null);

            ExceptionDispatchInfo edi;

            try
            {
                TSource value = @this.Invoke();

                return Output.Success(value);
            }
            catch (T1Exception ex) { edi = ExceptionDispatchInfo.Capture(ex); }
            catch (T2Exception ex) { edi = ExceptionDispatchInfo.Capture(ex); }
            catch (T3Exception ex) { edi = ExceptionDispatchInfo.Capture(ex); }

            return Output.Failure<TSource>(edi);
        }

        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter",
            Justification = "[Intentionally] There is no way we can achieve the same thing with type parameter inference.")]
        [SuppressMessage("Microsoft.Contracts", "Suggestion-23-0",
            Justification = "[Ignore] Unrecognized postcondition by CCCheck.")]
        public static Output<TSource> Catch<TSource, T1Exception, T2Exception, T3Exception, T4Exception>(
            this Func<TSource> @this)
            where T1Exception : Exception
            where T2Exception : Exception
            where T3Exception : Exception
            where T4Exception : Exception
        {
            Require.Object(@this);
            Contract.Ensures(Contract.Result<Output<TSource>>() != null);

            ExceptionDispatchInfo edi;

            try
            {
                TSource value = @this.Invoke();

                return Output.Success(value);
            }
            catch (T1Exception ex) { edi = ExceptionDispatchInfo.Capture(ex); }
            catch (T2Exception ex) { edi = ExceptionDispatchInfo.Capture(ex); }
            catch (T3Exception ex) { edi = ExceptionDispatchInfo.Capture(ex); }
            catch (T4Exception ex) { edi = ExceptionDispatchInfo.Capture(ex); }

            return Output.Failure<TSource>(edi);
        }
    }
}
