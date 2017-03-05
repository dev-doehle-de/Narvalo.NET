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
using global::Narvalo.Applicative;

namespace Edufun.Haskell.Templates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Edufun.Haskell.Templates.Internal;
    using Edufun.Haskell.Templates.Linq;

    // Provides a set of static methods for MonadOr<T>.
    // T4: EmitHelpers().
    public static partial class MonadOr
    {
        /// <summary>
        /// The unique object of type <c>MonadOr&lt;Unit&gt;</c>.
        /// </summary>
        private static readonly MonadOr<global::Narvalo.Applicative.Unit> s_Unit = Of(global::Narvalo.Applicative.Unit.Default);

        /// <summary>
        /// Gets the unique object of type <c>MonadOr&lt;Unit&gt;</c>.
        /// </summary>
        public static MonadOr<global::Narvalo.Applicative.Unit> Unit => s_Unit;

        /// <summary>
        /// Gets the zero for <see cref="MonadOr{T}.Bind"/>.
        /// </summary>
        public static MonadOr<global::Narvalo.Applicative.Unit> None => MonadOr<global::Narvalo.Applicative.Unit>.None;

        /// <summary>
        /// Obtains an instance of the <see cref="MonadOr{T}"/> class for the specified value.
        /// </summary>
        /// <typeparam name="T">The underlying type of <paramref name="value"/>.</typeparam>
        /// <param name="value">A value to be wrapped into an object of type <see cref="MonadOr{T}"/>.</param>
        /// <returns>An instance of the <see cref="MonadOr{T}"/> class for the specified value.</returns>
        public static MonadOr<T> Of<T>(T value)
            => MonadOr<T>.η(value);

        /// <summary>
        /// Removes one level of structure, projecting its bound value into the outer level.
        /// </summary>
        public static MonadOr<T> Flatten<T>(MonadOr<MonadOr<T>> square)
            => MonadOr<T>.μ(square);

        public static MonadOr<Unit> Guard(bool predicate) => predicate ? Unit : None;

        #region Lift()

        /// <summary>
        /// Promotes a function to use and return <see cref="MonadOr{T}" /> values.
        /// </summary>
        /// <seealso cref="MonadOr.Select{T, TResult}" />
        public static Func<MonadOr<T>, MonadOr<TResult>> Lift<T, TResult>(
            Func<T, TResult> func)
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
            => (arg1, arg2, arg3, arg4, arg5) =>
            {
                Require.NotNull(arg1, nameof(arg1));
                return arg1.Zip(arg2, arg3, arg4, arg5, func);
            };

        #endregion
    }

    // Provides extension methods for MonadOr<T>.
    // T4: EmitExtensions().
    public static partial class MonadOr
    {
        /// <seealso cref="Apply{TSource, TResult}" />
        public static MonadOr<TResult> Gather<TSource, TResult>(
            this MonadOr<TSource> @this,
            MonadOr<Func<TSource, TResult>> applicative)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(applicative, nameof(applicative));
            return applicative.Bind(func => @this.Select(func));
        }

        /// <seealso cref="Gather{TSource, TResult}" />
        public static MonadOr<TResult> Apply<TSource, TResult>(
            this MonadOr<Func<TSource, TResult>> @this,
            MonadOr<TSource> value)
        {
            Require.NotNull(value, nameof(value));
            return value.Gather(@this);
        }

        public static MonadOr<IEnumerable<TSource>> Repeat<TSource>(
            this MonadOr<TSource> @this,
            int count)
        {
            Require.NotNull(@this, nameof(@this));
            Require.Range(count >= 1, nameof(count));
            return @this.Select(val => Enumerable.Repeat(val, count));
        }

        public static MonadOr<TResult> ReplaceBy<TSource, TResult>(
            this MonadOr<TSource> @this,
            TResult value)
        {
            Require.NotNull(@this, nameof(@this));
            return @this.Select(_ => value);
        }

        public static MonadOr<TResult> ContinueWith<TSource, TResult>(
            this MonadOr<TSource> @this,
            MonadOr<TResult> other)
        {
            Require.NotNull(@this, nameof(@this));
            return @this.Bind(_ => other);
        }

        public static MonadOr<TSource> Ignore<TSource, TOther>(
            this MonadOr<TSource> @this,
            MonadOr<TOther> other)
        {
            Require.NotNull(@this, nameof(@this));
            Func<TSource, TOther, TSource> ignore = (arg, _) => arg;

            return @this.Zip(other, ignore);
        }

        public static MonadOr<global::Narvalo.Applicative.Unit> Skip<TSource>(this MonadOr<TSource> @this)
        {
            Require.NotNull(@this, nameof(@this));
            return @this.ContinueWith(MonadOr.Unit);
        }

        public static MonadOr<TResult> If<TSource, TResult>(
            this MonadOr<TSource> @this,
            Func<TSource, bool> predicate,
            MonadOr<TResult> thenResult)
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
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(predicate, nameof(predicate));
            return @this.Bind(val => predicate(val) ? thenResult : elseResult);
        }

        public static MonadOr<TResult> Using<TSource, TResult>(
            this MonadOr<TSource> @this,
            Func<TSource, MonadOr<TResult>> selector)
            where TSource : IDisposable
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(selector, nameof(selector));
            return @this.Bind(val => { using (val) { return selector(val); } });
        }

        public static MonadOr<TResult> Using<TSource, TResult>(
            this MonadOr<TSource> @this,
            Func<TSource, TResult> selector)
            where TSource : IDisposable
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(selector, nameof(selector));
            return @this.Select(val => { using (val) { return selector(val); } });
        }

        #region Zip()

        public static MonadOr<Tuple<TSource, TOther>> Zip<TSource, TOther>(
            this MonadOr<TSource> @this,
            MonadOr<TOther> other)
        {
            Require.NotNull(@this, nameof(@this));
            return @this.Zip(other, Tuple.Create);
        }

        public static MonadOr<TResult> Zip<TFirst, TSecond, TResult>(
            this MonadOr<TFirst> @this,
            MonadOr<TSecond> second,
            Func<TFirst, TSecond, TResult> zipper)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(second, nameof(second));
            Require.NotNull(zipper, nameof(zipper));

            return @this.Bind(
                arg1 => second.Select(
                    arg2 => zipper(arg1, arg2)));
        }

        public static MonadOr<TResult> Zip<T1, T2, T3, TResult>(
            this MonadOr<T1> @this,
            MonadOr<T2> second,
            MonadOr<T3> third,
            Func<T1, T2, T3, TResult> zipper)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(second, nameof(second));
            Require.NotNull(third, nameof(third));
            Require.NotNull(zipper, nameof(zipper));

            return @this.Bind(
                arg1 => second.Bind(
                    arg2 => third.Select(
                        arg3 => zipper(arg1, arg2, arg3))));
        }

        public static MonadOr<TResult> Zip<T1, T2, T3, T4, TResult>(
             this MonadOr<T1> @this,
             MonadOr<T2> second,
             MonadOr<T3> third,
             MonadOr<T4> fourth,
             Func<T1, T2, T3, T4, TResult> zipper)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(second, nameof(second));
            Require.NotNull(third, nameof(third));
            Require.NotNull(fourth, nameof(fourth));
            Require.NotNull(zipper, nameof(zipper));

            return @this.Bind(
                arg1 => second.Bind(
                    arg2 => third.Bind(
                        arg3 => fourth.Select(
                            arg4 => zipper(arg1, arg2, arg3, arg4)))));
        }

        public static MonadOr<TResult> Zip<T1, T2, T3, T4, T5, TResult>(
            this MonadOr<T1> @this,
            MonadOr<T2> second,
            MonadOr<T3> third,
            MonadOr<T4> fourth,
            MonadOr<T5> fifth,
            Func<T1, T2, T3, T4, T5, TResult> zipper)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(second, nameof(second));
            Require.NotNull(third, nameof(third));
            Require.NotNull(fourth, nameof(fourth));
            Require.NotNull(fifth, nameof(fifth));
            Require.NotNull(zipper, nameof(zipper));

            return @this.Bind(
                arg1 => second.Bind(
                    arg2 => third.Bind(
                        arg3 => fourth.Bind(
                            arg4 => fifth.Select(
                                arg5 => zipper(arg1, arg2, arg3, arg4, arg5))))));
        }

        #endregion

        #region Query Expression Pattern.

        public static MonadOr<TResult> Select<TSource, TResult>(
            this MonadOr<TSource> @this,
            Func<TSource, TResult> selector)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(selector, nameof(selector));
            return @this.Bind(val => MonadOr<TResult>.η(selector(val)));
        }

        public static MonadOr<TSource> Where<TSource>(
            this MonadOr<TSource> @this,
            Func<TSource, bool> predicate)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(predicate, nameof(predicate));
            return @this.Bind(val => predicate(val) ? MonadOr<TSource>.η(val) : MonadOr<TSource>.None);
        }

        // Kind of generalisation of Zip{T1, T2, T3}.
        public static MonadOr<TResult> SelectMany<TSource, TMiddle, TResult>(
            this MonadOr<TSource> @this,
            Func<TSource, MonadOr<TMiddle>> valueSelector,
            Func<TSource, TMiddle, TResult> resultSelector)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(valueSelector, nameof(valueSelector));
            Require.NotNull(resultSelector, nameof(resultSelector));

            return @this.Bind(
                val => valueSelector(val).Select(
                    middle => resultSelector(val, middle)));
        }

        public static MonadOr<TResult> Join<TSource, TInner, TKey, TResult>(
            this MonadOr<TSource> @this,
            MonadOr<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, TInner, TResult> resultSelector)
            => JoinImpl(
                @this,
                inner,
                outerKeySelector,
                innerKeySelector,
                resultSelector,
                EqualityComparer<TKey>.Default);

        public static MonadOr<TResult> Join<TSource, TInner, TKey, TResult>(
            this MonadOr<TSource> @this,
            MonadOr<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, TInner, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
            => JoinImpl(
                @this,
                inner,
                outerKeySelector,
                innerKeySelector,
                resultSelector,
                comparer ?? EqualityComparer<TKey>.Default);

        public static MonadOr<TResult> GroupJoin<TSource, TInner, TKey, TResult>(
            this MonadOr<TSource> @this,
            MonadOr<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, MonadOr<TInner>, TResult> resultSelector)
            => GroupJoinImpl(
                @this,
                inner,
                outerKeySelector,
                innerKeySelector,
                resultSelector,
                EqualityComparer<TKey>.Default);

        public static MonadOr<TResult> GroupJoin<TSource, TInner, TKey, TResult>(
            this MonadOr<TSource> @this,
            MonadOr<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, MonadOr<TInner>, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
            => GroupJoinImpl(
                @this,
                inner,
                outerKeySelector,
                innerKeySelector,
                resultSelector,
                comparer ?? EqualityComparer<TKey>.Default);

        private static MonadOr<TResult> JoinImpl<TSource, TInner, TKey, TResult>(
            MonadOr<TSource> outer,
            MonadOr<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, TInner, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
        {
            Require.NotNull(outer, nameof(outer));
            Require.NotNull(inner, nameof(inner));
            Require.NotNull(resultSelector, nameof(resultSelector));
            Require.NotNull(outerKeySelector, nameof(outerKeySelector));
            Require.NotNull(innerKeySelector, nameof(innerKeySelector));
            Require.NotNull(comparer, nameof(comparer));

            var keyLookup = GetKeyLookup(inner, outerKeySelector, innerKeySelector, comparer);

            return outer.SelectMany(val => keyLookup(val).ContinueWith(inner), resultSelector);
        }

        private static MonadOr<TResult> GroupJoinImpl<TSource, TInner, TKey, TResult>(
            MonadOr<TSource> outer,
            MonadOr<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, MonadOr<TInner>, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
        {
            Require.NotNull(outer, nameof(outer));
            Require.NotNull(inner, nameof(inner));
            Require.NotNull(resultSelector, nameof(resultSelector));
            Require.NotNull(outerKeySelector, nameof(outerKeySelector));
            Require.NotNull(innerKeySelector, nameof(innerKeySelector));
            Require.NotNull(comparer, nameof(comparer));

            var keyLookup = GetKeyLookup(inner, outerKeySelector, innerKeySelector, comparer);

            return outer.Select(val => resultSelector(val, keyLookup(val).ContinueWith(inner)));
        }

        private static Func<TSource, MonadOr<TKey>> GetKeyLookup<TSource, TInner, TKey>(
            MonadOr<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            IEqualityComparer<TKey> comparer)
        {
            Demand.NotNull("inner");
            Demand.NotNull(outerKeySelector);
            Demand.NotNull(innerKeySelector);
            Demand.NotNull(comparer);

            return arg => inner.Select(innerKeySelector)
                .Where(key => comparer.Equals(key, outerKeySelector(arg)));
        }

        #endregion
    }

    // Provides extension methods for Func<T> in the Kleisli category.
    // T4: EmitKleisli().
    public static partial class Kleisli
    {
        public static MonadOr<IEnumerable<TResult>> InvokeWith<TSource, TResult>(
            this Func<TSource, MonadOr<TResult>> @this,
            IEnumerable<TSource> seq)
            => seq.SelectWith(@this);

        public static MonadOr<TResult> InvokeWith<TSource, TResult>(
            this Func<TSource, MonadOr<TResult>> @this,
            MonadOr<TSource> value)
        {
            Require.NotNull(value, nameof(value));
            return value.Bind(@this);
        }

        public static Func<TSource, MonadOr<TResult>> Compose<TSource, TMiddle, TResult>(
            this Func<TSource, MonadOr<TMiddle>> @this,
            Func<TMiddle, MonadOr<TResult>> second)
        {
            Require.NotNull(@this, nameof(@this));
            return arg => @this(arg).Bind(second);
        }

        public static Func<TSource, MonadOr<TResult>> ComposeBack<TSource, TMiddle, TResult>(
            this Func<TMiddle, MonadOr<TResult>> @this,
            Func<TSource, MonadOr<TMiddle>> second)
        {
            Require.NotNull(second, nameof(second));
            return arg => second(arg).Bind(@this);
        }
    }

    // Provides extension methods for IEnumerable<MonadOr<T>>.
    // T4: EmitEnumerableExtensions().
    public static partial class MonadOr
    {
        public static MonadOr<IEnumerable<TSource>> Collect<TSource>(
            this IEnumerable<MonadOr<TSource>> @this)
            => @this.CollectImpl();

        public static MonadOr<TSource> Sum<TSource>(this IEnumerable<MonadOr<TSource>> @this)
            => @this.SumImpl();
    }
}

namespace Edufun.Haskell.Templates.Internal
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    using Edufun.Haskell.Templates;
    using Narvalo.Linq;

    // Provides default implementations for the extension methods for IEnumerable<MonadOr<T>>.
    // You will certainly want to override them to improve performance.
    // T4: EmitEnumerableInternal().
    internal static partial class EnumerableExtensions
    {
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static MonadOr<IEnumerable<TSource>> CollectImpl<TSource>(
            this IEnumerable<MonadOr<TSource>> @this)
        {
            Require.NotNull(@this, nameof(@this));

            return MonadOr<IEnumerable<TSource>>.η(CollectIterator(@this));
        }

        private static IEnumerable<TSource> CollectIterator<TSource>(IEnumerable<MonadOr<TSource>> source)
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

                            return MonadOr.Unit;
                        });

                    if (append) { yield return item; }
                }
            }
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static MonadOr<TSource> SumImpl<TSource>(
            this IEnumerable<MonadOr<TSource>> @this)
        {
            Demand.NotNull(@this);

            return @this.Aggregate(MonadOr<TSource>.None, (m, n) => m.OrElse(n));
        }
    }
}

namespace Edufun.Haskell.Templates.Linq
{
    using System;
    using System.Collections.Generic;

    using Edufun.Haskell.Templates;
    using Edufun.Haskell.Templates.Internal;

    // Provides extension methods for IEnumerable<T>.
    // We do not use the standard LINQ names to avoid any confusion.
    // - Select    -> SelectWith
    // - Where     -> WhereBy
    // - Zip       -> ZipWith
    // - Aggregate -> Reduce or Fold
    // T4: EmitLinqCore().
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

        public static MonadOr<IEnumerable<TResult>> ZipWith<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> @this,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, MonadOr<TResult>> resultSelector)
            => @this.ZipWithImpl(second, resultSelector);

        public static MonadOr<TAccumulate> Fold<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, MonadOr<TAccumulate>> accumulator)
            => @this.FoldImpl(seed, accumulator);

        public static MonadOr<TAccumulate> Fold<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, MonadOr<TAccumulate>> accumulator,
            Func<MonadOr<TAccumulate>, bool> predicate)
            => @this.FoldImpl(seed, accumulator, predicate);

        public static MonadOr<TSource> Reduce<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, MonadOr<TSource>> accumulator)
            => @this.ReduceImpl(accumulator);

        public static MonadOr<TSource> Reduce<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, MonadOr<TSource>> accumulator,
            Func<MonadOr<TSource>, bool> predicate)
            => @this.ReduceImpl(accumulator, predicate);
    }
}

namespace Edufun.Haskell.Templates.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    using Edufun.Haskell.Templates;

    // Provides default implementations for the extension methods for IEnumerable<T>.
    // You will certainly want to override them to improve performance.
    // T4: EmitLinqInternal().
    internal static partial class EnumerableExtensions
    {
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static MonadOr<IEnumerable<TResult>> SelectWithImpl<TSource, TResult>(
            this IEnumerable<TSource> @this,
            Func<TSource, MonadOr<TResult>> selector)
        {
            Demand.NotNull(@this);
            Demand.NotNull(selector);

            return @this.Select(selector).Collect();
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static MonadOr<IEnumerable<TSource>> WhereByImpl<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, MonadOr<bool>> predicate)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(predicate, nameof(predicate));

            return MonadOr<IEnumerable<TSource>>.η(WhereByIterator(@this, predicate));
        }

        private static IEnumerable<TSource> WhereByIterator<TSource>(
            IEnumerable<TSource> source,
            Func<TSource, MonadOr<bool>> predicate)
        {
            Demand.NotNull(source);
            Demand.NotNull(predicate);

            using (var iter = source.GetEnumerator())
            {
                while (iter.MoveNext())
                {
                    bool pass = false;
                    TSource item = iter.Current;

                    predicate(item).Bind(val =>
                    {
                        pass = val;

                        return MonadOr.Unit;
                    });

                    if (pass) { yield return item; }
                }
            }
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
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

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static MonadOr<TAccumulate> FoldImpl<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, MonadOr<TAccumulate>> accumulator)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(accumulator, nameof(accumulator));

            MonadOr<TAccumulate> retval = MonadOr<TAccumulate>.η(seed);

            using (var iter = @this.GetEnumerator())
            {
                while (iter.MoveNext())
                {
                    if (retval == null) { continue; }

                    retval = retval.Bind(val => accumulator(val, iter.Current));
                }
            }

            return retval;
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static MonadOr<TAccumulate> FoldImpl<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, MonadOr<TAccumulate>> accumulator,
            Func<MonadOr<TAccumulate>, bool> predicate)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(accumulator, nameof(accumulator));
            Require.NotNull(predicate, nameof(predicate));

            MonadOr<TAccumulate> retval = MonadOr<TAccumulate>.η(seed);

            using (var iter = @this.GetEnumerator())
            {
                while (predicate(retval) && iter.MoveNext())
                {
                    if (retval == null) { continue; }

                    retval = retval.Bind(val => accumulator(val, iter.Current));
                }
            }

            return retval;
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static MonadOr<TSource> ReduceImpl<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, MonadOr<TSource>> accumulator)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(accumulator, nameof(accumulator));

            using (var iter = @this.GetEnumerator())
            {
                if (!iter.MoveNext())
                {
                    throw new InvalidOperationException("Source sequence was empty.");
                }

                MonadOr<TSource> retval = MonadOr<TSource>.η(iter.Current);

                while (iter.MoveNext())
                {
                    if (retval == null) { continue; }

                    retval = retval.Bind(val => accumulator(val, iter.Current));
                }

                return retval;
            }
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static MonadOr<TSource> ReduceImpl<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, MonadOr<TSource>> accumulator,
            Func<MonadOr<TSource>, bool> predicate)
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

                MonadOr<TSource> retval = MonadOr<TSource>.η(iter.Current);

                while (predicate(retval) && iter.MoveNext())
                {
                    if (retval == null) { continue; }

                    retval = retval.Bind(val => accumulator(val, iter.Current));
                }

                return retval;
            }
        }
    }
}

