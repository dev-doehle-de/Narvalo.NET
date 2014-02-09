﻿// Copyright (c) 2014, Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Fx
{
    using System;
    using Narvalo.Linq;

    /// <summary>
    /// Provides extension methods for <see cref="System.Nullable{T}"/>.
    /// </summary>
    public static partial class NullableExtensions
    {
        //// ValueOrThrow

        public static TSource ValueOrThrow<TSource>(this TSource? @this, Exception exception)
            where TSource : struct
        {
            Require.NotNull(exception, "exception");

            return @this.ValueOrThrow(() => exception);
        }

        public static TSource ValueOrThrow<TSource>(this TSource? @this, Func<Exception> exceptionFactory)
            where TSource : struct
        {
            Require.NotNull(exceptionFactory, "exceptionFactory");

            if (!@this.HasValue) {
                throw exceptionFactory.Invoke();
            }

            return @this.Value;
        }

        //// Match

        public static TResult Match<TSource, TResult>(
            this TSource? @this,
            Func<TSource, TResult> selector,
            TResult defaultValue)
            where TSource : struct
            where TResult : struct
        {
            return @this.Map(selector) ?? defaultValue;
        }

        public static TResult Match<TSource, TResult>(
            this TSource? @this,
            Func<TSource, TResult> selector,
            Func<TResult> defaultValueFactory)
            where TSource : struct
            where TResult : struct
        {
            Require.NotNull(defaultValueFactory, "defaultValueFactory");

            return @this.Match(selector, defaultValueFactory.Invoke());
        }

        //// Zip

        public static TResult? Zip<TFirst, TSecond, TResult>(
            this TFirst? @this,
            TSecond? second,
            Func<TFirst, TSecond, TResult> resultSelector)
            where TFirst : struct
            where TSecond : struct
            where TResult : struct
        {
            return @this.HasValue && second.HasValue ? (TResult?)resultSelector.Invoke(@this.Value, second.Value) : null;
        }

        //// Run

        public static TSource? Run<TSource>(this TSource? @this, Action<TSource> action)
            where TSource : struct
        {
            return OnValue(@this, action);
        }

        //// OnValue & OnNothing

        public static TSource? OnValue<TSource>(this TSource? @this, Action<TSource> action)
            where TSource : struct
        {
            Require.NotNull(action, "action");

            if (@this.HasValue) {
                action.Invoke(@this.Value);
            }

            return @this;
        }

        public static TSource? OnNull<TSource>(this TSource? @this, Action action)
            where TSource : struct
        {
            Require.NotNull(action, "action");

            if (!@this.HasValue) {
                action.Invoke();
            }

            return @this;
        }

        //// ToMaybe

        public static Maybe<TSource> ToMaybe<TSource>(this TSource? @this) where TSource : struct
        {
            return Maybe.Create(@this);
        }
    }
}
