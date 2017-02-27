﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by a tool. Changes to this file may cause incorrect
// behavior and will be lost if the code is regenerated.
//
// Runtime Version: 4.0.30319.42000
// Microsoft.VisualStudio.TextTemplating: 14.0
// </auto-generated>
//------------------------------------------------------------------------------

namespace Narvalo.Fx
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Narvalo.Fx.Internal;
    using Narvalo.Fx.Linq;

    // Provides a set of static methods for Either<T, TRight>.
    public static partial class Either
    {
        /// <summary>
        /// Obtains an instance of the <see cref="Either{T, TRight}"/> class for the specified value.
        /// </summary>
        /// <typeparam name="T">The underlying type of <paramref name="value"/>.</typeparam>
        /// <typeparam name="TRight"></typeparam>
        /// <param name="value">A value to be wrapped into an object of type <see cref="Either{T, TRight}"/>.</param>
        /// <returns>An instance of the <see cref="Either{T, TRight}"/> class for the specified value.</returns>
        public static Either<T, TRight> Of<T, TRight>(T value)
            /* T4: type constraint */
            => Either<T, TRight>.η(value);

        /// <summary>
        /// Removes one level of structure, projecting its bound value into the outer level.
        /// </summary>
        public static Either<T, TRight> Flatten<T, TRight>(Either<Either<T, TRight>, TRight> square)
            /* T4: type constraint */
            => Either<T, TRight>.μ(square);

        #region Lift()

        /// <summary>
        /// Promotes a function to use and return <see cref="Either{T, TRight}" /> values.
        /// </summary>
        /// <seealso cref="Select{T, TResult, TRight}" />
        public static Func<Either<T, TRight>, Either<TResult, TRight>> Lift<T, TResult, TRight>(
            Func<T, TResult> func)
            /* T4: type constraint */
            => arg =>
            {
                Require.NotNull(arg, nameof(arg));
                return arg.Select(func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="Either{T, TRight}" /> values.
        /// </summary>
        /// <seealso cref="Lift{T1, T2, TResult, TRight}" />
        public static Func<Either<T1, TRight>, Either<T2, TRight>, Either<TResult, TRight>>
            Lift<T1, T2, TResult, TRight>(Func<T1, T2, TResult> func)
            /* T4: type constraint */
            => (arg1, arg2) =>
            {
                Require.NotNull(arg1, nameof(arg1));
                return arg1.Zip(arg2, func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="Either{T, TRight}" /> values.
        /// </summary>
        /// <seealso cref="Lift{T1, T2, T3, TResult, TRight}" />
        public static Func<Either<T1, TRight>, Either<T2, TRight>, Either<T3, TRight>, Either<TResult, TRight>>
            Lift<T1, T2, T3, TResult, TRight>(Func<T1, T2, T3, TResult> func)
            /* T4: type constraint */
            => (arg1, arg2, arg3) =>
            {
                Require.NotNull(arg1, nameof(arg1));
                return arg1.Zip(arg2, arg3, func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="Either{T, TRight}" /> values.
        /// </summary>
        /// <seealso cref="Lift{T1, T2, T3, T4, TResult, TRight}" />
        public static Func<Either<T1, TRight>, Either<T2, TRight>, Either<T3, TRight>, Either<T4, TRight>, Either<TResult, TRight>>
            Lift<T1, T2, T3, T4, TResult, TRight>(
            Func<T1, T2, T3, T4, TResult> func)
            /* T4: type constraint */
            => (arg1, arg2, arg3, arg4) =>
            {
                Require.NotNull(arg1, nameof(arg1));
                return arg1.Zip(arg2, arg3, arg4, func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="Either{T, TRight}" /> values.
        /// </summary>
        /// <seealso cref="Lift{T1, T2, T3, T4, T5, TResult, TRight}" />
        public static Func<Either<T1, TRight>, Either<T2, TRight>, Either<T3, TRight>, Either<T4, TRight>, Either<T5, TRight>, Either<TResult, TRight>>
            Lift<T1, T2, T3, T4, T5, TResult, TRight>(
            Func<T1, T2, T3, T4, T5, TResult> func)
            /* T4: type constraint */
            => (arg1, arg2, arg3, arg4, arg5) =>
            {
                Require.NotNull(arg1, nameof(arg1));
                return arg1.Zip(arg2, arg3, arg4, arg5, func);
            };

        #endregion
    } // End of Either - T4: EmitHelpers().

    // Provides extension methods for Either<T, TRight>.
    public static partial class Either
    {
        /// <seealso cref="Apply{TSource, TResult, TRight}" />
        public static Either<TResult, TRight> Gather<TSource, TResult, TRight>(
            this Either<TSource, TRight> @this,
            Either<Func<TSource, TResult>, TRight> applicative)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(applicative, nameof(applicative));
            return applicative.Bind(func => @this.Select(func));
        }

        /// <seealso cref="Gather{TSource, TResult, TRight}" />
        public static Either<TResult, TRight> Apply<TSource, TResult, TRight>(
            this Either<Func<TSource, TResult>, TRight> @this,
            Either<TSource, TRight> value)
        {
            Require.NotNull(value, nameof(value));
            return value.Gather(@this);
        }

        public static Either<IEnumerable<TSource>, TRight> Repeat<TSource, TRight>(
            this Either<TSource, TRight> @this,
            int count)
        {
            Require.NotNull(@this, nameof(@this));
            Require.Range(count >= 1, nameof(count));
            return @this.Select(val => Enumerable.Repeat(val, count));
        }

        public static Either<TResult, TRight> ReplaceBy<TSource, TResult, TRight>(
            this Either<TSource, TRight> @this,
            TResult value)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            return @this.Select(_ => value);
        }

        public static Either<TResult, TRight> Then<TSource, TResult, TRight>(
            this Either<TSource, TRight> @this,
            Either<TResult, TRight> other)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            return @this.Bind(_ => other);
        }

        public static Either<TSource, TRight> Ignore<TSource, TOther, TRight>(
            this Either<TSource, TRight> @this,
            Either<TOther, TRight> other)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            Func<TSource, TOther, TSource> ignore = (arg, _) => arg;

            return @this.Zip(other, ignore);
        }

        public static Either<global::Narvalo.Fx.Unit, TRight> Skip<TSource, TRight>(this Either<TSource, TRight> @this)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            return @this.ReplaceBy(global::Narvalo.Fx.Unit.Default);
        }

        public static Either<TResult, TRight> Coalesce<TSource, TResult, TRight>(
            this Either<TSource, TRight> @this,
            Func<TSource, bool> predicate,
            Either<TResult, TRight> thenResult,
            Either<TResult, TRight> elseResult)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(predicate, nameof(predicate));
            return @this.Bind(val => predicate(val) ? thenResult : elseResult);
        }

        public static Either<TResult, TRight> Using<TSource, TResult, TRight>(
            this Either<TSource, TRight> @this,
            Func<TSource, Either<TResult, TRight>> selector)
            where TSource : IDisposable
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(selector, nameof(selector));
            return @this.Bind(val => { using (val) { return selector(val); } });
        }

        public static Either<TResult, TRight> Using<TSource, TResult, TRight>(
            this Either<TSource, TRight> @this,
            Func<TSource, TResult> selector)
            where TSource : IDisposable
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(selector, nameof(selector));
            return @this.Select(val => { using (val) { return selector(val); } });
        }

        #region Zip()

        public static Either<Tuple<TSource, TOther>, TRight> Zip<TSource, TOther, TRight>(
            this Either<TSource, TRight> @this,
            Either<TOther, TRight> other)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            return @this.Zip(other, Tuple.Create);
        }

        /// <seealso cref="Lift{TFirst, TSecond, TResult, TRight}" />
        public static Either<TResult, TRight> Zip<TFirst, TSecond, TResult, TRight>(
            this Either<TFirst, TRight> @this,
            Either<TSecond, TRight> second,
            Func<TFirst, TSecond, TResult> zipper)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(second, nameof(second));
            Require.NotNull(zipper, nameof(zipper));

            Func<TFirst, Func<TSecond, TResult>> selector
                = arg1 => arg2 => zipper(arg1, arg2);

            return second.Gather(
                @this.Select(selector));
        }

        /// <seealso cref="Lift{T1, T2, T3, TResult, TRight}" />
        public static Either<TResult, TRight> Zip<T1, T2, T3, TResult, TRight>(
            this Either<T1, TRight> @this,
            Either<T2, TRight> second,
            Either<T3, TRight> third,
            Func<T1, T2, T3, TResult> zipper)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(second, nameof(second));
            Require.NotNull(third, nameof(third));
            Require.NotNull(zipper, nameof(zipper));

            Func<T1, Func<T2, Func<T3, TResult>>> selector
                = arg1 => arg2 => arg3 => zipper(arg1, arg2, arg3);

            return third.Gather(
                second.Gather(
                    @this.Select(selector)));
        }

        /// <seealso cref="Lift{T1, T2, T3, T4, TResult, TRight}" />
        public static Either<TResult, TRight> Zip<T1, T2, T3, T4, TResult, TRight>(
             this Either<T1, TRight> @this,
             Either<T2, TRight> second,
             Either<T3, TRight> third,
             Either<T4, TRight> fourth,
             Func<T1, T2, T3, T4, TResult> zipper)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(second, nameof(second));
            Require.NotNull(third, nameof(third));
            Require.NotNull(fourth, nameof(fourth));
            Require.NotNull(zipper, nameof(zipper));

            Func<T1, Func<T2, Func<T3, Func<T4, TResult>>>> selector
                = arg1 => arg2 => arg3 => arg4 => zipper(arg1, arg2, arg3, arg4);

            return fourth.Gather(
                third.Gather(
                    second.Gather(
                        @this.Select(selector))));
        }

        /// <seealso cref="Lift{T1, T2, T3, T4, T5, TResult, TRight}" />
        public static Either<TResult, TRight> Zip<T1, T2, T3, T4, T5, TResult, TRight>(
            this Either<T1, TRight> @this,
            Either<T2, TRight> second,
            Either<T3, TRight> third,
            Either<T4, TRight> fourth,
            Either<T5, TRight> fifth,
            Func<T1, T2, T3, T4, T5, TResult> zipper)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(second, nameof(second));
            Require.NotNull(third, nameof(third));
            Require.NotNull(fourth, nameof(fourth));
            Require.NotNull(fifth, nameof(fifth));
            Require.NotNull(zipper, nameof(zipper));

            Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, TResult>>>>> selector
                = arg1 => arg2 => arg3 => arg4 => arg5 => zipper(arg1, arg2, arg3, arg4, arg5);

            return fifth.Gather(
                fourth.Gather(
                    third.Gather(
                        second.Gather(
                            @this.Select(selector)))));
        }

        #endregion

        #region LINQ dialect

        public static Either<TResult, TRight> Select<TSource, TResult, TRight>(
            this Either<TSource, TRight> @this,
            Func<TSource, TResult> selector)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(selector, nameof(selector));
            return @this.Bind(val => Either.Of<TResult, TRight>(selector(val)));
        }

        /// <remarks>
        /// Kind of generalisation of <see cref="Zip{T1, T2, T3}" />.
        /// </remarks>
        public static Either<TResult, TRight> SelectMany<TSource, TMiddle, TResult, TRight>(
            this Either<TSource, TRight> @this,
            Func<TSource, Either<TMiddle, TRight>> valueSelector,
            Func<TSource, TMiddle, TResult> resultSelector)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(valueSelector, nameof(valueSelector));
            Require.NotNull(resultSelector, nameof(resultSelector));

            return @this.Bind(
                val => valueSelector(val).Select(
                    middle => resultSelector(val, middle)));
        }

        #endregion
    } // End of Either - T4: EmitExtensions().

    // Provides extension methods for Func<T> in the Kleisli category.
    public static partial class Kleisli
    {
        public static Either<IEnumerable<TResult>, TRight> InvokeWith<TSource, TResult, TRight>(
            this Func<TSource, Either<TResult, TRight>> @this,
            IEnumerable<TSource> seq)
            => seq.Select(@this).Collect();

        public static Either<TResult, TRight> InvokeWith<TSource, TResult, TRight>(
            this Func<TSource, Either<TResult, TRight>> @this,
            Either<TSource, TRight> value)
            /* T4: type constraint */
        {
            Require.NotNull(value, nameof(value));
            return value.Bind(@this);
        }

        public static Func<TSource, Either<TResult, TRight>> Compose<TSource, TMiddle, TResult, TRight>(
            this Func<TSource, Either<TMiddle, TRight>> @this,
            Func<TMiddle, Either<TResult, TRight>> second)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            return arg => @this(arg).Bind(second);
        }

        public static Func<TSource, Either<TResult, TRight>> ComposeBack<TSource, TMiddle, TResult, TRight>(
            this Func<TMiddle, Either<TResult, TRight>> @this,
            Func<TSource, Either<TMiddle, TRight>> second)
            /* T4: type constraint */
        {
            Require.NotNull(second, nameof(second));
            return arg => second(arg).Bind(@this);
        }
    } // End of Kleisli - T4: EmitKleisliExtensions().

    // Provides extension methods for IEnumerable<Either<T, TRight>>.
    public static partial class Either
    {
        public static Either<IEnumerable<TSource>, TRight> Collect<TSource, TRight>(
            this IEnumerable<Either<TSource, TRight>> @this)
            => @this.CollectImpl();

    } // End of Sequence - T4: EmitEnumerableExtensions().
}

namespace Narvalo.Fx.Internal
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    using Narvalo.Fx.Linq;

    // Provides default implementations for the extension methods for IEnumerable<Either<T, TRight>>.
    // You will certainly want to override them to improve performance.
    internal static partial class EnumerableExtensions
    {
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Either<IEnumerable<TSource>, TRight> CollectImpl<TSource, TRight>(
            this IEnumerable<Either<TSource, TRight>> @this)
        {
            Require.NotNull(@this, nameof(@this));

            return Either.Of<IEnumerable<TSource>, TRight>(CollectIterator(@this));
        }

        private static IEnumerable<TSource> CollectIterator<TSource, TRight>(IEnumerable<Either<TSource, TRight>> source)
        {
            Demand.NotNull(source);

            var unit = Either.Of<Unit, TRight>(Unit.Default);
            var item = default(TSource);

            using (var iter = source.GetEnumerator())
            {
                while (iter.MoveNext())
                {
                    var append = false;

                    iter.Current.Bind(
                        val =>
                        {
                            append = true;
                            item = val;

                            return unit;
                        });

                    if (append) { yield return item; }
                }
            }
        }

    } // End of EnumerableExtensions - T4: EmitEnumerableInternal().
}
