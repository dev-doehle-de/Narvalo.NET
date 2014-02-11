﻿// Copyright (c) 2014, Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Fx
{
    using System;

    /// <summary>
    /// Provides extension methods for <see cref="Narvalo.Fx.Maybe{T}"/>.
    /// </summary>
    public static partial class MaybeExtensions
    {
        #region Monad extensions

        public static Maybe<TResult> Zip<TFirst, TSecond, TResult>(
            this Maybe<TFirst> @this,
            Maybe<TSecond> second,
            Func<TFirst, TSecond, TResult> resultSelector)
        {
            return @this.IsSome && second.IsSome
                ? Maybe.Create(resultSelector.Invoke(@this.Value, second.Value))
                : Maybe<TResult>.None;
        }

        public static Maybe<TSource> Run<TSource>(this Maybe<TSource> @this, Action<TSource> action)
        {
            return OnSome(@this, action);
        }

        #endregion

        #region Additive monad extensions

        public static Maybe<TResult> Then<TSource, TResult>(this Maybe<TSource> @this, Maybe<TResult> other)
        {
            Require.Object(@this);

            return @this.IsNone ? Maybe<TResult>.None : other;
        }

        public static Maybe<TResult> Otherwise<TSource, TResult>(this Maybe<TSource> @this, Maybe<TResult> other)
        {
            Require.Object(@this);

            return @this.IsNone ? other : Maybe<TResult>.None;
        }

        public static Maybe<TResult> Coalesce<TSource, TResult>(
            this Maybe<TSource> @this,
            Maybe<TResult> whenSome,
            Maybe<TResult> whenNone)
        {
            Require.Object(@this);

            return @this.IsSome ? whenSome : whenNone;
        }

        public static Maybe<TSource> OnZero<TSource>(this Maybe<TSource> @this, Action action)
        {
            return OnNone(@this, action);
        }

        #endregion

        //// OnSome & OnNone

        public static Maybe<TSource> OnSome<TSource>(this Maybe<TSource> @this, Action<TSource> action)
        {
            Require.Object(@this);
            Require.NotNull(action, "action");

            if (@this.IsSome) {
                action.Invoke(@this.Value);
            }

            return @this;
        }

        public static Maybe<TSource> OnNone<TSource>(this Maybe<TSource> @this, Action action)
        {
            Require.Object(@this);
            Require.NotNull(action, "action");

            if (@this.IsNone) {
                action.Invoke();
            }

            return @this;
        }

        //// ToNullable

        public static T? ToNullable<T>(this Maybe<T?> @this) where T : struct
        {
            Require.Object(@this);

            return @this.ValueOrDefault();
        }

        public static T? ToNullable<T>(this Maybe<T> @this) where T : struct
        {
            Require.Object(@this);

            return @this.IsSome ? (T?)@this.Value : null;
        }

        //// UnpackOr...

        public static T UnpackOrDefault<T>(this Maybe<T?> @this) where T : struct
        {
            return UnpackOrElse(@this, default(T));
        }

        public static T UnpackOrElse<T>(this Maybe<T?> @this, T defaultValue) where T : struct
        {
            return UnpackOrElse(@this, () => defaultValue);
        }

        public static T UnpackOrElse<T>(this Maybe<T?> @this, Func<T> defaultValueFactory) where T : struct
        {
            Require.Object(@this);

            return @this.ValueOrDefault() ?? defaultValueFactory.Invoke();
        }

        public static T UnpackOrThrow<T>(this Maybe<T?> @this, Exception exception) where T : struct
        {
            return UnpackOrThrow(@this, () => exception);
        }

        public static T UnpackOrThrow<T>(this Maybe<T?> @this, Func<Exception> exceptionFactory) where T : struct
        {
            return ToNullable(@this).OnNull(() => { exceptionFactory.Invoke(); }).Value;
        }
    }
}
