﻿namespace Narvalo.Fx
{
    using System;

    /// <summary>
    /// Fournit des méthodes d'extension pour <see cref="Narvalo.Fx.Maybe{T}"/>.
    /// </summary>
    public static class MaybeExtensions
    {
        public static Maybe<TResult> Cast<T, TResult>(this Maybe<T> @this) where T : TResult
        {
            return @this.Map(_ => (TResult)_);
        }

        public static Maybe<T> ThrowIfNone<T>(this Maybe<T> @this, Exception ex)
        {
            if (@this.IsNone) {
                throw ex;
            }

            return @this;
        }

        public static Maybe<T> ThrowIfNone<T>(this Maybe<T> @this, Func<Exception> exceptionFactory)
        {
            Require.NotNull(exceptionFactory, "exceptionFactory");

            if (@this.IsNone) {
                throw exceptionFactory();
            }
            
            return @this;
        }

        public static TResult Match<TSource, TResult>(
            this Maybe<TSource> @this,
            Func<TSource, TResult> fun,
            TResult defaultValue)
        {
            return @this.Map(fun).ValueOrElse(defaultValue);
        }

        public static TResult Match<TSource, TResult>(
            this Maybe<TSource> option,
            Func<TSource, TResult> fun,
            Func<TResult> defaultValueFactory)
        {
            return option.Map(fun).ValueOrElse(defaultValueFactory);
        }

        public static void Run<T>(this Maybe<T> @this, Action<T> onSome, Action onNone)
        {
            Func<T, Unit> fun = _ => { onSome(_); return Unit.Single; };
            Func<Unit> factory = () => { onNone(); return Unit.Single; };

            @this.Match(fun, factory);
        }

        public static void WhenSome<T>(this Maybe<T> @this, Action<T> action)
        {
            @this.Run(action, () => { });
        }

        public static void WhenNone<T>(this Maybe<T> @this, Action action)
        {
            @this.Run(_ => { }, action);
        }

        public static T? ToNullable<T>(this Maybe<T> @this) where T : struct
        {
            return @this.Match(_ => _, () => (T?)null);
        }

        public static bool TrySet<T>(this Maybe<T> @this, out T value) where T : struct
        {
            T? tmp = @this.ToNullable();

            if (tmp.HasValue) {
                value = tmp.Value;
                return true;
            }
            else {
                value = default(T);
                return false;
            }
        }
    }
}
