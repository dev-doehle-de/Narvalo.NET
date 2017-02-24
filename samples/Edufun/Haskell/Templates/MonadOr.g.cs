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

using global::Narvalo;
using global::Narvalo.Fx;

namespace Edufun.Haskell.Templates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Edufun.Haskell.Templates.Internal;
    using Edufun.Haskell.Templates.Linq;

    // Provides a set of static methods for MonadOr<T>.
    public static partial class MonadOr
    {
        /// <summary>
        /// The unique object of type <c>MonadOr&lt;Unit&gt;</c>.
        /// </summary>
        private static readonly MonadOr<global::Narvalo.Fx.Unit> s_Unit = Of(global::Narvalo.Fx.Unit.Single);

        /// <summary>
        /// Gets the unique object of type <c>MonadOr&lt;Unit&gt;</c>.
        /// </summary>
        public static MonadOr<global::Narvalo.Fx.Unit> Unit => s_Unit;

        /// <summary>
        /// Gets the zero for <see cref="MonadOr{T}.Bind"/>.
        /// </summary>
        public static MonadOr<global::Narvalo.Fx.Unit> None => MonadOr<global::Narvalo.Fx.Unit>.None;

        /// <summary>
        /// Obtains an instance of the <see cref="MonadOr{T}"/> class for the specified value.
        /// </summary>
        /// <typeparam name="T">The underlying type of <paramref name="value"/>.</typeparam>
        /// <param name="value">A value to be wrapped into an object of type <see cref="MonadOr{T}"/>.</param>
        /// <returns>An instance of the <see cref="MonadOr{T}"/> class for the specified value.</returns>
        public static MonadOr<T> Of<T>(T value)
            /* T4: type constraint */
            => MonadOr<T>.η(value);

        /// <summary>
        /// Removes one level of structure, projecting its bound value into the outer level.
        /// </summary>
        public static MonadOr<T> Flatten<T>(MonadOr<MonadOr<T>> square)
            /* T4: type constraint */
            => MonadOr<T>.μ(square);

        public static MonadOr<global::Narvalo.Fx.Unit> Guard(bool predicate) => predicate ? Unit : None;

        /// <summary>
        /// Promotes a function to use and return <see cref="MonadOr{T}" /> values.
        /// </summary>
        public static Func<MonadOr<T>, MonadOr<TResult>> Lift<T, TResult>(
            Func<T, TResult> func)
            /* T4: type constraint */
            => arg =>
            {
                Require.NotNull(arg, nameof(arg));
                return arg.Select(func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="MonadOr{T}" /> values.
        /// </summary>
        public static Func<MonadOr<T1>, MonadOr<T2>, MonadOr<TResult>>
            Lift<T1, T2, TResult>(Func<T1, T2, TResult> func)
            /* T4: type constraint */
            => (arg1, arg2) =>
            {
                Require.NotNull(arg1, nameof(arg1));
                return arg1.Zip(arg2, func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="MonadOr{T}" /> values.
        /// </summary>
        public static Func<MonadOr<T1>, MonadOr<T2>, MonadOr<T3>, MonadOr<TResult>>
            Lift<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> func)
            /* T4: type constraint */
            => (arg1, arg2, arg3) =>
            {
                Require.NotNull(arg1, nameof(arg1));
                return arg1.Zip(arg2, arg3, func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="MonadOr{T}" /> values.
        /// </summary>
        public static Func<MonadOr<T1>, MonadOr<T2>, MonadOr<T3>, MonadOr<T4>, MonadOr<TResult>>
            Lift<T1, T2, T3, T4, TResult>(
            Func<T1, T2, T3, T4, TResult> func)
            /* T4: type constraint */
            => (arg1, arg2, arg3, arg4) =>
            {
                Require.NotNull(arg1, nameof(arg1));
                return arg1.Zip(arg2, arg3, arg4, func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="MonadOr{T}" /> values.
        /// </summary>
        public static Func<MonadOr<T1>, MonadOr<T2>, MonadOr<T3>, MonadOr<T4>, MonadOr<T5>, MonadOr<TResult>>
            Lift<T1, T2, T3, T4, T5, TResult>(
            Func<T1, T2, T3, T4, T5, TResult> func)
            /* T4: type constraint */
            => (arg1, arg2, arg3, arg4, arg5) =>
            {
                Require.NotNull(arg1, nameof(arg1));
                return arg1.Zip(arg2, arg3, arg4, arg5, func);
            };
    } // End of MonadOr - T4: EmitMonadCore().

    // Provides extension methods for MonadOr<T>.
    public static partial class MonadOr
    {
        public static MonadOr<TResult> Select<TSource, TResult>(
            this MonadOr<TSource> @this,
            Func<TSource, TResult> selector)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(selector, nameof(selector));
            return @this.Bind(val => MonadOr.Of(selector(val)));
        }

        public static MonadOr<TResult> Gather<TSource, TResult>(
            this MonadOr<TSource> @this,
            MonadOr<Func<TSource, TResult>> applicative)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(applicative, nameof(applicative));
            return applicative.Bind(func => @this.Select(func));
        }

        public static MonadOr<TResult> Apply<TSource, TResult>(
            this MonadOr<Func<TSource, TResult>> @this,
            MonadOr<TSource> value)
        {
            Require.NotNull(value, nameof(value));
            return value.Gather(@this);
        }

        public static MonadOr<TResult> Replace<TSource, TResult>(
            this MonadOr<TSource> @this,
            TResult value)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            return @this.Select(_ => value);
        }

        public static MonadOr<TResult> ReplaceBy<TSource, TResult>(
            this MonadOr<TSource> @this,
            MonadOr<TResult> other)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            return @this.Bind(_ => other);
        }

        public static MonadOr<TResult> If<TSource, TResult>(
            this MonadOr<TSource> @this,
            Func<TSource, bool> predicate,
            MonadOr<TResult> thenResult)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(predicate, nameof(predicate));
            return @this.Bind(val => predicate(val) ? thenResult : MonadOr<TResult>.None);
        }

        public static MonadOr<TResult> Coalesce<TSource, TResult>(
            this MonadOr<TSource> @this,
            Func<TSource, bool> predicate,
            MonadOr<TResult> thenResult,
            MonadOr<TResult> elseResult)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(predicate, nameof(predicate));
            return @this.Bind(val => predicate(val) ? thenResult : elseResult);
        }

        public static MonadOr<global::Narvalo.Fx.Unit> Skip<TSource>(this MonadOr<TSource> @this)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            return @this.ReplaceBy(Unit);
        }

        public static MonadOr<TSource> Where<TSource>(
            this MonadOr<TSource> @this,
            Func<TSource, bool> predicate)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(predicate, nameof(predicate));
            return @this.Bind(val => predicate(val) ? MonadOr.Of(val) : MonadOr<TSource>.None);
        }

        public static MonadOr<IEnumerable<TSource>> Repeat<TSource>(
            this MonadOr<TSource> @this,
            int count)
        {
            Require.NotNull(@this, nameof(@this));
            Require.Range(count >= 1, nameof(count));
            return @this.Select(val => Enumerable.Repeat(val, count));
        }

        public static MonadOr<TResult> Using<TSource, TResult>(
            this MonadOr<TSource> @this,
            Func<TSource, MonadOr<TResult>> selector)
            where TSource : IDisposable
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(selector, nameof(selector));
            return @this.Bind(val => { using (val) { return selector(val); } });
        }

        public static MonadOr<TResult> Using<TSource, TResult>(
            this MonadOr<TSource> @this,
            Func<TSource, TResult> selector)
            where TSource : IDisposable
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(selector, nameof(selector));
            return @this.Select(val => { using (val) { return selector(val); } });
        }

        #region Zip()

        public static MonadOr<Tuple<TSource, TOther>> Zip<TSource, TOther>(
            this MonadOr<TSource> @this,
            MonadOr<TOther> other)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            return @this.Zip(other, Tuple.Create);
        }

        /// <see cref="Lift{T1, T2, T3}" />
        public static MonadOr<TResult> Zip<TFirst, TSecond, TResult>(
            this MonadOr<TFirst> @this,
            MonadOr<TSecond> second,
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

        /// <see cref="Lift{T1, T2, T3, T4}" />
        public static MonadOr<TResult> Zip<T1, T2, T3, TResult>(
            this MonadOr<T1> @this,
            MonadOr<T2> second,
            MonadOr<T3> third,
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

        /// <see cref="Lift{T1, T2, T3, T4, T5}" />
        public static MonadOr<TResult> Zip<T1, T2, T3, T4, TResult>(
             this MonadOr<T1> @this,
             MonadOr<T2> second,
             MonadOr<T3> third,
             MonadOr<T4> fourth,
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

        /// <see cref="Lift{T1, T2, T3, T4, T5, T6}" />
        public static MonadOr<TResult> Zip<T1, T2, T3, T4, T5, TResult>(
            this MonadOr<T1> @this,
            MonadOr<T2> second,
            MonadOr<T3> third,
            MonadOr<T4> fourth,
            MonadOr<T5> fifth,
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

        /// <remarks>
        /// Kind of generalisation of <see cref="Zip{T1, T2, T3}" />.
        /// </remarks>
        public static MonadOr<TResult> SelectMany<TSource, TMiddle, TResult>(
            this MonadOr<TSource> @this,
            Func<TSource, MonadOr<TMiddle>> valueSelector,
            Func<TSource, TMiddle, TResult> resultSelector)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(valueSelector, nameof(valueSelector));
            Require.NotNull(resultSelector, nameof(resultSelector));

            return @this.Bind(
                arg => valueSelector(arg).Select(
                    middle => resultSelector(arg, middle)));
        }

        public static MonadOr<TResult> Join<TSource, TInner, TKey, TResult>(
            this MonadOr<TSource> @this,
            MonadOr<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, TInner, TResult> resultSelector)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));

            return JoinImpl(
                @this,
                inner,
                outerKeySelector,
                innerKeySelector,
                resultSelector,
                EqualityComparer<TKey>.Default);
        }

        public static MonadOr<TResult> GroupJoin<TSource, TInner, TKey, TResult>(
            this MonadOr<TSource> @this,
            MonadOr<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, MonadOr<TInner>, TResult> resultSelector)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));

            return GroupJoinImpl(
                @this,
                inner,
                outerKeySelector,
                innerKeySelector,
                resultSelector,
                EqualityComparer<TKey>.Default);
        }

        public static MonadOr<TResult> Join<TSource, TInner, TKey, TResult>(
            this MonadOr<TSource> @this,
            MonadOr<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, TInner, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
            /* T4: type constraint */
        {
            return JoinImpl(
                @this,
                inner,
                outerKeySelector,
                innerKeySelector,
                resultSelector,
                comparer ?? EqualityComparer<TKey>.Default);
        }

        public static MonadOr<TResult> GroupJoin<TSource, TInner, TKey, TResult>(
            this MonadOr<TSource> @this,
            MonadOr<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, MonadOr<TInner>, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
            /* T4: type constraint */
        {
            return GroupJoinImpl(
                @this,
                inner,
                outerKeySelector,
                innerKeySelector,
                resultSelector,
                comparer ?? EqualityComparer<TKey>.Default);
        }

        private static MonadOr<TResult> JoinImpl<TSource, TInner, TKey, TResult>(
            MonadOr<TSource> seq,
            MonadOr<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, TInner, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
            /* T4: type constraint */
        {
            Require.NotNull(seq, nameof(seq));
            Require.NotNull(resultSelector, nameof(resultSelector));
            Demand.NotNull(inner);
            Demand.NotNull(outerKeySelector);
            Demand.NotNull(innerKeySelector);
            Demand.NotNull(comparer);

            var keyLookupM = GetKeyLookup(inner, outerKeySelector, innerKeySelector, comparer);

            return from outerValue in seq
                   from innerValue in keyLookupM(outerValue).ReplaceBy(inner)
                   select resultSelector(outerValue, innerValue);
        }

        private static MonadOr<TResult> GroupJoinImpl<TSource, TInner, TKey, TResult>(
            MonadOr<TSource> seq,
            MonadOr<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, MonadOr<TInner>, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
            /* T4: type constraint */
        {
            Require.NotNull(seq, nameof(seq));
            Require.NotNull(resultSelector, nameof(resultSelector));
            Demand.NotNull(inner);
            Demand.NotNull(outerKeySelector);
            Demand.NotNull(innerKeySelector);
            Demand.NotNull(comparer);

            var keyLookupM = GetKeyLookup(inner, outerKeySelector, innerKeySelector, comparer);

            return from outerValue in seq
                   select resultSelector(outerValue, keyLookupM(outerValue).ReplaceBy(inner));
        }

        private static Func<TSource, MonadOr<TKey>> GetKeyLookup<TSource, TInner, TKey>(
            MonadOr<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            IEqualityComparer<TKey> comparer)
            /* T4: type constraint */
        {
            Require.NotNull(inner, nameof(inner));
            Require.NotNull(outerKeySelector, nameof(outerKeySelector));
            Require.NotNull(comparer, nameof(comparer));
            Demand.NotNull(innerKeySelector);

            return arg =>
            {
                TKey outerKey = outerKeySelector(arg);

                return inner.Select(innerKeySelector).Where(key => comparer.Equals(key, outerKey));
            };
        }

        #endregion
    } // End of MonadOr - T4: EmitMonadExtensions().

    // Provides extension methods for Func<T> in the Kleisli category.
    public static partial class Kleisli
    {
        public static MonadOr<IEnumerable<TResult>> ForEach<TSource, TResult>(
            this Func<TSource, MonadOr<TResult>> @this,
            IEnumerable<TSource> seq)
            => seq.SelectWith(@this);

        public static MonadOr<TResult> Invoke<TSource, TResult>(
            this Func<TSource, MonadOr<TResult>> @this,
            MonadOr<TSource> value)
            /* T4: type constraint */
        {
            Require.NotNull(value, nameof(value));
            return value.Bind(@this);
        }

        public static Func<TSource, MonadOr<TResult>> Compose<TSource, TMiddle, TResult>(
            this Func<TSource, MonadOr<TMiddle>> first,
            Func<TMiddle, MonadOr<TResult>> second)
            /* T4: type constraint */
        {
            Require.NotNull(first, nameof(first));
            return arg => first(arg).Bind(second);
        }

        public static Func<TSource, MonadOr<TResult>> ComposeBack<TSource, TMiddle, TResult>(
            this Func<TMiddle, MonadOr<TResult>> first,
            Func<TSource, MonadOr<TMiddle>> second)
            /* T4: type constraint */
        {
            Require.NotNull(second, nameof(second));
            return arg => second(arg).Bind(first);
        }
    } // End of Kleisli - T4: EmitKleisliExtensions().

    // Provides extension methods for IEnumerable<MonadOr<T>>.
    public static partial class MonadOr
    {
        public static MonadOr<IEnumerable<TSource>> Collect<TSource>(
            this IEnumerable<MonadOr<TSource>> @this)
            => @this.CollectImpl();

        public static MonadOr<TSource> Sum<TSource>(
            this IEnumerable<MonadOr<TSource>> @this)
            /* T4: type constraint */
            => @this.SumImpl();
    } // End of Sequence - T4: EmitMonadEnumerableExtensions().
}

namespace Edufun.Haskell.Templates.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Narvalo.Fx.Linq;

    // Provides default implementations for the extension methods for IEnumerable<MonadOr<T>>.
    // You will certainly want to override them to improve performance.
    internal static partial class EnumerableExtensions
    {
        internal static MonadOr<IEnumerable<TSource>> CollectImpl<TSource>(
            this IEnumerable<MonadOr<TSource>> @this)
        {
            Demand.NotNull(@this);

            var seed = MonadOr.Of(Enumerable.Empty<TSource>());
            Func<IEnumerable<TSource>, TSource, IEnumerable<TSource>> append = (seq, item) => seq.Append(item);

            return @this.Aggregate(seed, MonadOr.Lift<IEnumerable<TSource>, TSource, IEnumerable<TSource>>(append));
        }

        internal static MonadOr<TSource> SumImpl<TSource>(
            this IEnumerable<MonadOr<TSource>> @this)
            /* T4: type constraint */
        {
            Demand.NotNull(@this);

            return @this.Aggregate(MonadOr<TSource>.None, (m, n) => m.OrElse(n));
        }
    } // End of EnumerableExtensions - T4: EmitMonadEnumerableInternalExtensions().
}

namespace Edufun.Haskell.Templates.Linq
{
    using System;
    using System.Collections.Generic;

    using Edufun.Haskell.Templates;
    using Edufun.Haskell.Templates.Internal;

    // Provides extension methods for IEnumerable<T>.
    // We do not use the standard LINQ names to avoid a confusing API.
    // - Select    -> SelectWith
    // - Where     -> WhereBy
    // - Zip       -> ZipWith
    // - Aggregate -> Reduce or Fold
    public static partial class Qperators
    {
        public static MonadOr<IEnumerable<TResult>> SelectWith<TSource, TResult>(
            this IEnumerable<TSource> @this,
            Func<TSource, MonadOr<TResult>> selector)
            => @this.SelectWithImpl(selector);

        public static MonadOr<IEnumerable<TSource>> WhereBy<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, MonadOr<bool>> predicate)
            => @this.WhereByImpl(predicate);

        public static MonadOr<Tuple<IEnumerable<TFirst>, IEnumerable<TSecond>>>
            SelectUnzip<TSource, TFirst, TSecond>(
            this IEnumerable<TSource> @this,
            Func<TSource, MonadOr<Tuple<TFirst, TSecond>>> selector)
            => @this.SelectUnzipImpl(selector);

        public static MonadOr<IEnumerable<TResult>> ZipWith<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> @this,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, MonadOr<TResult>> resultSelector)
            => @this.ZipWithImpl(second, resultSelector);

        public static MonadOr<TAccumulate> Fold<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, MonadOr<TAccumulate>> accumulator)
            /* T4: type constraint */
            => @this.FoldImpl(seed, accumulator);

        public static MonadOr<TAccumulate> FoldBack<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, MonadOr<TAccumulate>> accumulator)
            /* T4: type constraint */
            => @this.FoldBackImpl(seed, accumulator);

        public static MonadOr<TSource> Reduce<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, MonadOr<TSource>> accumulator)
            /* T4: type constraint */
            => @this.ReduceImpl(accumulator);

        public static MonadOr<TSource> ReduceBack<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, MonadOr<TSource>> accumulator)
            /* T4: type constraint */
            => @this.ReduceBackImpl(accumulator);

        // Haskell uses a different signature.
        public static MonadOr<TAccumulate> Fold<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, MonadOr<TAccumulate>> accumulator,
            Func<MonadOr<TAccumulate>, bool> predicate)
            /* T4: type constraint */
            => @this.FoldImpl(seed, accumulator, predicate);

        // Haskell uses a different signature.
        public static MonadOr<TSource> Reduce<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, MonadOr<TSource>> accumulator,
            Func<MonadOr<TSource>, bool> predicate)
            /* T4: type constraint */
            => @this.ReduceImpl(accumulator, predicate);
    } // End of Iterable - T4: EmitEnumerableExtensions().
}

namespace Edufun.Haskell.Templates.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Edufun.Haskell.Templates.Linq;
    using Narvalo.Fx.Linq;

    // Provides default implementations for the extension methods for IEnumerable<T>.
    // You will certainly want to override them to improve performance.
    internal static partial class EnumerableExtensions
    {
        internal static MonadOr<IEnumerable<TResult>> SelectWithImpl<TSource, TResult>(
            this IEnumerable<TSource> @this,
            Func<TSource, MonadOr<TResult>> selector)
        {
            Demand.NotNull(@this);
            Demand.NotNull(selector);

            return @this.Select(selector).Collect();
        }

        internal static MonadOr<IEnumerable<TSource>> WhereByImpl<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, MonadOr<bool>> predicate)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(predicate, nameof(predicate));

            Func<TSource, Func<bool, IEnumerable<TSource>, IEnumerable<TSource>>> func
                = item => (flg, seq) => flg ? seq.Append(item) : seq;

            Func<MonadOr<IEnumerable<TSource>>, TSource, MonadOr<IEnumerable<TSource>>> accumulator
                = (mseq, item) => predicate(item).Zip(mseq, func(item));

            return @this.Aggregate(MonadOr.Of(Enumerable.Empty<TSource>()), accumulator);
        }

        internal static MonadOr<Tuple<IEnumerable<TFirst>, IEnumerable<TSecond>>>
            SelectUnzipImpl<TSource, TFirst, TSecond>(
            this IEnumerable<TSource> @this,
            Func<TSource, MonadOr<Tuple<TFirst, TSecond>>> selector)
        {
            Demand.NotNull(@this);
            Demand.NotNull(selector);

            return @this.SelectWith(selector).Select(
                tuples =>
                {
                    var seq1 = tuples.Select(_ => _.Item1);
                    var seq2 = tuples.Select(_ => _.Item2);

                    return new Tuple<IEnumerable<TFirst>, IEnumerable<TSecond>>(seq1, seq2);
                });
        }

        internal static MonadOr<IEnumerable<TResult>> ZipWithImpl<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> @this,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, MonadOr<TResult>> resultSelector)
        {
            Demand.NotNull(resultSelector);
            Demand.NotNull(@this);
            Demand.NotNull(second);

            return @this.Zip(second, resultSelector).Collect();
        }

        internal static MonadOr<TAccumulate> FoldImpl<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, MonadOr<TAccumulate>> accumulator)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(accumulator, nameof(accumulator));

            Func<MonadOr<TAccumulate>, TSource, MonadOr<TAccumulate>> func
                = (arg1, arg2) => arg1.Bind(arg => accumulator(arg, arg2));

            return @this.Aggregate(MonadOr.Of(seed), func);
        }

        internal static MonadOr<TAccumulate> FoldBackImpl<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, MonadOr<TAccumulate>> accumulator)
            /* T4: type constraint */
        {
            Demand.NotNull(@this);
            Demand.NotNull(accumulator);

            return @this.Reverse().Fold(seed, accumulator);
        }

        internal static MonadOr<TSource> ReduceImpl<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, MonadOr<TSource>> accumulator)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(accumulator, nameof(accumulator));

            using (var iter = @this.GetEnumerator())
            {
                if (!iter.MoveNext())
                {
                    throw new InvalidOperationException("Source sequence was empty.");
                }

                MonadOr<TSource> retval = MonadOr.Of(iter.Current);

                while (iter.MoveNext())
                {
                    retval = retval.Bind(_ => accumulator.Invoke(_, iter.Current));
                }

                return retval;
            }
        }

        internal static MonadOr<TSource> ReduceBackImpl<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, MonadOr<TSource>> accumulator)
            /* T4: type constraint */
        {
            Demand.NotNull(@this);
            Demand.NotNull(accumulator);

            return @this.Reverse().Reduce(accumulator);
        }

        internal static MonadOr<TAccumulate> FoldImpl<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, MonadOr<TAccumulate>> accumulator,
            Func<MonadOr<TAccumulate>, bool> predicate)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(accumulator, nameof(accumulator));
            Require.NotNull(predicate, nameof(predicate));

            MonadOr<TAccumulate> retval = MonadOr.Of(seed);

            using (var iter = @this.GetEnumerator())
            {
                while (predicate.Invoke(retval) && iter.MoveNext())
                {
                    retval = retval.Bind(_ => accumulator.Invoke(_, iter.Current));
                }
            }

            return retval;
        }

        internal static MonadOr<TSource> ReduceImpl<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, MonadOr<TSource>> accumulator,
            Func<MonadOr<TSource>, bool> predicate)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(accumulator, nameof(accumulator));
            Require.NotNull(predicate, nameof(predicate));

            using (var iter = @this.GetEnumerator())
            {
                if (!iter.MoveNext())
                {
                    throw new InvalidOperationException("Source sequence was empty.");
                }

                MonadOr<TSource> retval = MonadOr.Of(iter.Current);

                while (predicate.Invoke(retval) && iter.MoveNext())
                {
                    retval = retval.Bind(_ => accumulator.Invoke(_, iter.Current));
                }

                return retval;
            }
        }
    } // End of EnumerableExtensions - T4: EmitEnumerableInternalExtensions().
}

