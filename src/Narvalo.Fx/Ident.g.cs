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

    // Provides a set of static methods for Ident<T>.
    public static partial class Ident
    {
        /// <summary>
        /// The unique object of type <c>Ident&lt;Unit&gt;</c>.
        /// </summary>
        private static readonly Ident<global::Narvalo.Fx.Unit> s_Unit = Of(global::Narvalo.Fx.Unit.Single);

        /// <summary>
        /// Gets the unique object of type <c>Ident&lt;Unit&gt;</c>.
        /// </summary>
        public static Ident<global::Narvalo.Fx.Unit> Unit => s_Unit;

        /// <summary>
        /// Obtains an instance of the <see cref="Ident{T}"/> class for the specified value.
        /// </summary>
        /// <typeparam name="T">The underlying type of <paramref name="value"/>.</typeparam>
        /// <param name="value">A value to be wrapped into an object of type <see cref="Ident{T}"/>.</param>
        /// <returns>An instance of the <see cref="Ident{T}"/> class for the specified value.</returns>
        public static Ident<T> Of<T>(T value)
            /* T4: type constraint */
            => Ident<T>.η(value);

        /// <summary>
        /// Removes one level of structure, projecting its bound value into the outer level.
        /// </summary>
        public static Ident<T> Flatten<T>(Ident<Ident<T>> square)
            /* T4: type constraint */
            => Ident<T>.μ(square);

        #region Lift()

        /// <summary>
        /// Promotes a function to use and return <see cref="Ident{T}" /> values.
        /// </summary>
        public static Func<Ident<T>, Ident<TResult>> Lift<T, TResult>(
            Func<T, TResult> func)
            /* T4: type constraint */
            => arg =>
            {
                /* T4: NotNull(arg) */
                return arg.Select(func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="Ident{T}" /> values.
        /// </summary>
        public static Func<Ident<T1>, Ident<T2>, Ident<TResult>>
            Lift<T1, T2, TResult>(Func<T1, T2, TResult> func)
            /* T4: type constraint */
            => (arg1, arg2) =>
            {
                /* T4: NotNull(arg1) */
                return arg1.Zip(arg2, func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="Ident{T}" /> values.
        /// </summary>
        public static Func<Ident<T1>, Ident<T2>, Ident<T3>, Ident<TResult>>
            Lift<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> func)
            /* T4: type constraint */
            => (arg1, arg2, arg3) =>
            {
                /* T4: NotNull(arg1) */
                return arg1.Zip(arg2, arg3, func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="Ident{T}" /> values.
        /// </summary>
        public static Func<Ident<T1>, Ident<T2>, Ident<T3>, Ident<T4>, Ident<TResult>>
            Lift<T1, T2, T3, T4, TResult>(
            Func<T1, T2, T3, T4, TResult> func)
            /* T4: type constraint */
            => (arg1, arg2, arg3, arg4) =>
            {
                /* T4: NotNull(arg1) */
                return arg1.Zip(arg2, arg3, arg4, func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="Ident{T}" /> values.
        /// </summary>
        public static Func<Ident<T1>, Ident<T2>, Ident<T3>, Ident<T4>, Ident<T5>, Ident<TResult>>
            Lift<T1, T2, T3, T4, T5, TResult>(
            Func<T1, T2, T3, T4, T5, TResult> func)
            /* T4: type constraint */
            => (arg1, arg2, arg3, arg4, arg5) =>
            {
                /* T4: NotNull(arg1) */
                return arg1.Zip(arg2, arg3, arg4, arg5, func);
            };

        #endregion
    } // End of Ident - T4: EmitMonadCore().

    // Provides extension methods for Ident<T>.
    public static partial class Ident
    {
        public static Ident<TResult> Gather<TSource, TResult>(
            this Ident<TSource> @this,
            Ident<Func<TSource, TResult>> applicative)
        {
            /* T4: NotNull(@this) */
            /* T4: NotNull(applicative) */
            return applicative.Bind(func => @this.Select(func));
        }

        public static Ident<TResult> Apply<TSource, TResult>(
            this Ident<Func<TSource, TResult>> @this,
            Ident<TSource> value)
        {
            /* T4: NotNull(value) */
            return value.Gather(@this);
        }

        public static Ident<IEnumerable<TSource>> Repeat<TSource>(
            this Ident<TSource> @this,
            int count)
        {
            /* T4: NotNull(@this) */
            Require.Range(count >= 1, nameof(count));
            return @this.Select(val => Enumerable.Repeat(val, count));
        }

        public static Ident<TResult> ReplaceBy<TSource, TResult>(
            this Ident<TSource> @this,
            TResult value)
            /* T4: type constraint */
        {
            /* T4: NotNull(@this) */
            return @this.Select(_ => value);
        }

        public static Ident<TResult> Then<TSource, TResult>(
            this Ident<TSource> @this,
            Ident<TResult> other)
            /* T4: type constraint */
        {
            /* T4: NotNull(@this) */
            return @this.Bind(_ => other);
        }

        public static Ident<TSource> Ignore<TSource, TOther>(
            this Ident<TSource> @this,
            Ident<TOther> other)
            /* T4: type constraint */
        {
            /* T4: NotNull(@this) */
            Func<TSource, TOther, TSource> ignore = (arg, _) => arg;

            return @this.Zip(other, ignore);
        }

        public static Ident<global::Narvalo.Fx.Unit> Skip<TSource>(this Ident<TSource> @this)
            /* T4: type constraint */
        {
            /* T4: NotNull(@this) */
            return @this.Then(Unit);
        }

        public static Ident<TResult> Coalesce<TSource, TResult>(
            this Ident<TSource> @this,
            Func<TSource, bool> predicate,
            Ident<TResult> thenResult,
            Ident<TResult> elseResult)
            /* T4: type constraint */
        {
            /* T4: NotNull(@this) */
            Require.NotNull(predicate, nameof(predicate));
            return @this.Bind(val => predicate(val) ? thenResult : elseResult);
        }

        public static Ident<TResult> Using<TSource, TResult>(
            this Ident<TSource> @this,
            Func<TSource, Ident<TResult>> selector)
            where TSource : IDisposable
            /* T4: type constraint */
        {
            /* T4: NotNull(@this) */
            Require.NotNull(selector, nameof(selector));
            return @this.Bind(val => { using (val) { return selector(val); } });
        }

        public static Ident<TResult> Using<TSource, TResult>(
            this Ident<TSource> @this,
            Func<TSource, TResult> selector)
            where TSource : IDisposable
            /* T4: type constraint */
        {
            /* T4: NotNull(@this) */
            Require.NotNull(selector, nameof(selector));
            return @this.Select(val => { using (val) { return selector(val); } });
        }

        #region Zip()

        public static Ident<Tuple<TSource, TOther>> Zip<TSource, TOther>(
            this Ident<TSource> @this,
            Ident<TOther> other)
            /* T4: type constraint */
        {
            /* T4: NotNull(@this) */
            return @this.Zip(other, Tuple.Create);
        }

        /// <see cref="Lift{T1, T2, T3}" />
        public static Ident<TResult> Zip<TFirst, TSecond, TResult>(
            this Ident<TFirst> @this,
            Ident<TSecond> second,
            Func<TFirst, TSecond, TResult> zipper)
            /* T4: type constraint */
        {
            /* T4: NotNull(@this) */
            /* T4: NotNull(second) */
            Require.NotNull(zipper, nameof(zipper));

            Func<TFirst, Func<TSecond, TResult>> selector
                = arg1 => arg2 => zipper(arg1, arg2);

            return second.Gather(
                @this.Select(selector));
        }

        /// <see cref="Lift{T1, T2, T3, T4}" />
        public static Ident<TResult> Zip<T1, T2, T3, TResult>(
            this Ident<T1> @this,
            Ident<T2> second,
            Ident<T3> third,
            Func<T1, T2, T3, TResult> zipper)
            /* T4: type constraint */
        {
            /* T4: NotNull(@this) */
            /* T4: NotNull(second) */
            /* T4: NotNull(third) */
            Require.NotNull(zipper, nameof(zipper));

            Func<T1, Func<T2, Func<T3, TResult>>> selector
                = arg1 => arg2 => arg3 => zipper(arg1, arg2, arg3);

            return third.Gather(
                second.Gather(
                    @this.Select(selector)));
        }

        /// <see cref="Lift{T1, T2, T3, T4, T5}" />
        public static Ident<TResult> Zip<T1, T2, T3, T4, TResult>(
             this Ident<T1> @this,
             Ident<T2> second,
             Ident<T3> third,
             Ident<T4> fourth,
             Func<T1, T2, T3, T4, TResult> zipper)
            /* T4: type constraint */
        {
            /* T4: NotNull(@this) */
            /* T4: NotNull(second) */
            /* T4: NotNull(third) */
            /* T4: NotNull(fourth) */
            Require.NotNull(zipper, nameof(zipper));

            Func<T1, Func<T2, Func<T3, Func<T4, TResult>>>> selector
                = arg1 => arg2 => arg3 => arg4 => zipper(arg1, arg2, arg3, arg4);

            return fourth.Gather(
                third.Gather(
                    second.Gather(
                        @this.Select(selector))));
        }

        /// <see cref="Lift{T1, T2, T3, T4, T5, T6}" />
        public static Ident<TResult> Zip<T1, T2, T3, T4, T5, TResult>(
            this Ident<T1> @this,
            Ident<T2> second,
            Ident<T3> third,
            Ident<T4> fourth,
            Ident<T5> fifth,
            Func<T1, T2, T3, T4, T5, TResult> zipper)
            /* T4: type constraint */
        {
            /* T4: NotNull(@this) */
            /* T4: NotNull(second) */
            /* T4: NotNull(third) */
            /* T4: NotNull(fourth) */
            /* T4: NotNull(fifth) */
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

        public static Ident<TResult> Select<TSource, TResult>(
            this Ident<TSource> @this,
            Func<TSource, TResult> selector)
            /* T4: type constraint */
        {
            /* T4: NotNull(@this) */
            Require.NotNull(selector, nameof(selector));
            return @this.Bind(val => Ident.Of(selector(val)));
        }
        /// <remarks>
        /// Kind of generalisation of <see cref="Zip{T1, T2, T3}" />.
        /// </remarks>
        public static Ident<TResult> SelectMany<TSource, TMiddle, TResult>(
            this Ident<TSource> @this,
            Func<TSource, Ident<TMiddle>> valueSelector,
            Func<TSource, TMiddle, TResult> resultSelector)
            /* T4: type constraint */
        {
            /* T4: NotNull(@this) */
            Require.NotNull(valueSelector, nameof(valueSelector));
            Require.NotNull(resultSelector, nameof(resultSelector));

            return @this.Bind(
                val => valueSelector(val).Select(
                    middle => resultSelector(val, middle)));
        }


        #endregion
    } // End of Ident - T4: EmitMonadExtensions().

    // Provides extension methods for Func<T> in the Kleisli category.
    public static partial class Kleisli
    {
        public static Ident<IEnumerable<TResult>> InvokeWith<TSource, TResult>(
            this Func<TSource, Ident<TResult>> @this,
            IEnumerable<TSource> seq)
            => seq.Select(@this).Collect();

        public static Ident<TResult> InvokeWith<TSource, TResult>(
            this Func<TSource, Ident<TResult>> @this,
            Ident<TSource> value)
            /* T4: type constraint */
        {
            /* T4: NotNull(value) */
            return value.Bind(@this);
        }

        public static Func<TSource, Ident<TResult>> Compose<TSource, TMiddle, TResult>(
            this Func<TSource, Ident<TMiddle>> @this,
            Func<TMiddle, Ident<TResult>> second)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            return arg => @this(arg).Bind(second);
        }

        public static Func<TSource, Ident<TResult>> ComposeBack<TSource, TMiddle, TResult>(
            this Func<TMiddle, Ident<TResult>> @this,
            Func<TSource, Ident<TMiddle>> second)
            /* T4: type constraint */
        {
            Require.NotNull(second, nameof(second));
            return arg => second(arg).Bind(@this);
        }
    } // End of Kleisli - T4: EmitKleisliExtensions().

    // Provides extension methods for IEnumerable<Ident<T>>.
    public static partial class Ident
    {
        public static Ident<IEnumerable<TSource>> Collect<TSource>(
            this IEnumerable<Ident<TSource>> @this)
            => @this.CollectImpl();

    } // End of Sequence - T4: EmitMonadEnumerableExtensions().
}

namespace Narvalo.Fx.Internal
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    using Narvalo.Fx.Linq;

    // Provides default implementations for the extension methods for IEnumerable<Ident<T>>.
    // You will certainly want to override them to improve performance.
    internal static partial class EnumerableExtensions
    {
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Ident<IEnumerable<TSource>> CollectImpl<TSource>(
            this IEnumerable<Ident<TSource>> @this)
        {
            Require.NotNull(@this, nameof(@this));

            return Ident.Of(CollectIterator(@this));
        }

        private static IEnumerable<TSource> CollectIterator<TSource>(IEnumerable<Ident<TSource>> source)
        {
            Demand.NotNull(source);

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

                            return Ident.Unit;
                        });

                    if (append) { yield return item; }
                }
            }
        }

    } // End of EnumerableExtensions - T4: EmitMonadEnumerableInternalExtensions().
}

namespace Narvalo.Fx
{
    // Implements core Comonad methods.
    public static partial class Ident
    {
        /// <remarks>
        /// Named <c>extract</c> in Haskell parlance.
        /// </remarks>
        public static T Extract<T>(Ident<T> value)
            /* T4: type constraint */
        {

            return Ident<T>.ε(value);
        }

        /// <remarks>
        /// Named <c>duplicate</c> in Haskell parlance.
        /// </remarks>
        public static Ident<Ident<T>> Duplicate<T>(Ident<T> value)
            /* T4: type constraint */
        {

            return Ident<T>.δ(value);
        }
    } // End of Ident - T4: EmitComonadCore().
}
