﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by a tool. Changes to this file may cause incorrect
// behavior and will be lost if the code is regenerated.
//
// Runtime Version: 4.0.30319.42000
// Microsoft.VisualStudio.TextTemplating: 15.0
// </auto-generated>
//------------------------------------------------------------------------------

using unit = global::Narvalo.Applicative.Unit;

namespace Narvalo.Applicative
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    using Narvalo.Internal;

    /// <summary>
    /// Provides a set of static methods involving <see cref="Maybe{T}"/>.
    /// </summary>
    // T4: EmitHelpers().
    public static partial class Maybe
    {
        /// <summary>
        /// The unique object of type <c>Maybe&lt;Unit&gt;</c>.
        /// </summary>
        private static readonly Maybe<unit> s_Unit = Of(unit.Default);

        /// <summary>
        /// Gets the unique object of type <c>Maybe&lt;Unit&gt;</c>.
        /// </summary>
        public static Maybe<unit> Unit => s_Unit;

        /// <summary>
        /// Gets the zero for <see cref="Maybe{T}.Bind"/>.
        /// </summary>
        public static Maybe<unit> None => Maybe<unit>.None;

        /// <summary>
        /// Obtains an instance of the <see cref="Maybe{T}"/> class for the specified value.
        /// </summary>
        /// <typeparam name="T">The underlying type of <paramref name="value"/>.</typeparam>
        /// <param name="value">A value to be wrapped into an object of type <see cref="Maybe{T}"/>.</param>
        /// <returns>An instance of the <see cref="Maybe{T}"/> class for the specified value.</returns>
        public static Maybe<T> Of<T>(T value) => Maybe<T>.η(value);

        public static Maybe<unit> Guard(bool predicate) => predicate ? Unit : None;

        public static Maybe<IEnumerable<TSource>> Repeat<TSource>(
            Maybe<TSource> source,
            int count)
        {
            /* T4: NotNull(source) */
            Require.Range(count >= 0, nameof(count));
            return source.Select(val => Enumerable.Repeat(val, count));
        }

        public static Maybe<IEnumerable<T>> Collect<T>(
            IEnumerable<Maybe<T>> source)
        {
            Require.NotNull(source, nameof(source));
            return source.CollectImpl();
        }

        public static Maybe<IEnumerable<T>> Filter<T>(
            IEnumerable<T> source,
            Func<T, Maybe<bool>> predicate)
        {
            Require.NotNull(source, nameof(source));
            Require.NotNull(predicate, nameof(predicate));
            return source.WhereImpl(predicate);
        }

        public static Maybe<IEnumerable<TResult>> Map<T, TResult>(
            IEnumerable<T> source,
            Func<T, Maybe<TResult>> selector)
            => Maybe.Collect(source.Select(selector));

        public static Maybe<IEnumerable<TResult>> Zip<T1, T2, TResult>(
            IEnumerable<T1> first,
            IEnumerable<T2> second,
            Func<T1, T2, Maybe<TResult>> resultSelector)
            => Maybe.Collect(first.Zip(second, resultSelector));

        #region Lift()

        /// <summary>
        /// Promotes a function to use and return <see cref="Maybe{T}" /> values.
        /// </summary>
        /// <seealso cref="MaybeExtensions.Select{T, TResult}" />
        public static Func<Maybe<T>, Maybe<TResult>> Lift<T, TResult>(
            Func<T, TResult> func)
            => arg =>
            {
                /* T4: NotNull(arg) */
                return arg.Select(func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="Maybe{T}" /> values.
        /// </summary>
        /// <seealso cref="MaybeExtensions.Zip{T1, T2, TResult}"/>
        public static Func<Maybe<T1>, Maybe<T2>, Maybe<TResult>>
            Lift<T1, T2, TResult>(Func<T1, T2, TResult> func)
            => (arg1, arg2) =>
            {
                /* T4: NotNull(arg1) */
                return arg1.Zip(arg2, func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="Maybe{T}" /> values.
        /// </summary>
        /// <seealso cref="MaybeExtensions.Zip{T1, T2, T3, TResult}"/>
        public static Func<Maybe<T1>, Maybe<T2>, Maybe<T3>, Maybe<TResult>>
            Lift<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> func)
            => (arg1, arg2, arg3) =>
            {
                /* T4: NotNull(arg1) */
                return arg1.Zip(arg2, arg3, func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="Maybe{T}" /> values.
        /// </summary>
        /// <seealso cref="MaybeExtensions.Zip{T1, T2, T3, T4, TResult}"/>
        public static Func<Maybe<T1>, Maybe<T2>, Maybe<T3>, Maybe<T4>, Maybe<TResult>>
            Lift<T1, T2, T3, T4, TResult>(
            Func<T1, T2, T3, T4, TResult> func)
            => (arg1, arg2, arg3, arg4) =>
            {
                /* T4: NotNull(arg1) */
                return arg1.Zip(arg2, arg3, arg4, func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="Maybe{T}" /> values.
        /// </summary>
        /// <seealso cref="MaybeExtensions.Zip{T1, T2, T3, T4, T5, TResult}"/>
        public static Func<Maybe<T1>, Maybe<T2>, Maybe<T3>, Maybe<T4>, Maybe<T5>, Maybe<TResult>>
            Lift<T1, T2, T3, T4, T5, TResult>(
            Func<T1, T2, T3, T4, T5, TResult> func)
            => (arg1, arg2, arg3, arg4, arg5) =>
            {
                /* T4: NotNull(arg1) */
                return arg1.Zip(arg2, arg3, arg4, arg5, func);
            };

        #endregion
    }

    /// <summary>
    /// Provides extension methods for <see cref="Maybe{T}"/>.
    /// </summary>
    // T4: EmitExtensions().
    public static partial class MaybeExtensions
    {
        /// <summary>
        /// Removes one level of structure, projecting its bound value into the outer level.
        /// </summary>
        public static Maybe<T> Flatten<T>(this Maybe<Maybe<T>> @this)
            => Maybe<T>.μ(@this);

        /// <seealso cref="Ap.Apply{TSource, TResult}(Maybe{Func{TSource, TResult}}, Maybe{TSource})" />
        public static Maybe<TResult> Gather<TSource, TResult>(
            this Maybe<TSource> @this,
            Maybe<Func<TSource, TResult>> applicative)
        {
            /* T4: NotNull(@this) */
            /* T4: NotNull(applicative) */
            return applicative.Bind(func => @this.Select(func));
        }

        public static Maybe<TResult> ReplaceBy<TSource, TResult>(
            this Maybe<TSource> @this,
            TResult value)
        {
            /* T4: NotNull(@this) */
            return @this.Select(_ => value);
        }

        public static Maybe<TResult> ContinueWith<TSource, TResult>(
            this Maybe<TSource> @this,
            Maybe<TResult> other)
        {
            /* T4: NotNull(@this) */
            return @this.Bind(_ => other);
        }

        public static Maybe<TSource> PassBy<TSource, TOther>(
            this Maybe<TSource> @this,
            Maybe<TOther> other)
        {
            /* T4: NotNull(@this) */
            return @this.Zip(other, (arg, _) => arg);
        }

        public static Maybe<unit> Skip<TSource>(this Maybe<TSource> @this)
        {
            /* T4: NotNull(@this) */
            return @this.ContinueWith(Maybe.Unit);
        }

        #region Zip()

        /// <seealso cref="Maybe.Lift{T1, T2, TResult}"/>
        public static Maybe<TResult> Zip<T1, T2, TResult>(
            this Maybe<T1> @this,
            Maybe<T2> second,
            Func<T1, T2, TResult> zipper)
        {
            /* T4: NotNull(@this) */
            /* T4: NotNull(second) */
            Require.NotNull(zipper, nameof(zipper));

            return @this.Bind(
                arg1 => second.Select(
                    arg2 => zipper(arg1, arg2)));
        }

        /// <seealso cref="Maybe.Lift{T1, T2, T3, TResult}"/>
        public static Maybe<TResult> Zip<T1, T2, T3, TResult>(
            this Maybe<T1> @this,
            Maybe<T2> second,
            Maybe<T3> third,
            Func<T1, T2, T3, TResult> zipper)
        {
            /* T4: NotNull(@this) */
            /* T4: NotNull(second) */
            /* T4: NotNull(third) */
            Require.NotNull(zipper, nameof(zipper));

            // This is the same as:
            // > return @this.Bind(
            // >     arg1 => second.Bind(
            // >        arg2 => third.Select(
            // >            arg3 => zipper(arg1, arg2, arg3))));
            // but faster if Zip is locally shadowed.
            return @this.Bind(
                arg1 => second.Zip(
                    third, (arg2, arg3) => zipper(arg1, arg2, arg3)));
        }

        /// <seealso cref="Maybe.Lift{T1, T2, T3, T4, TResult}"/>
        public static Maybe<TResult> Zip<T1, T2, T3, T4, TResult>(
             this Maybe<T1> @this,
             Maybe<T2> second,
             Maybe<T3> third,
             Maybe<T4> fourth,
             Func<T1, T2, T3, T4, TResult> zipper)
        {
            /* T4: NotNull(@this) */
            /* T4: NotNull(second) */
            /* T4: NotNull(third) */
            /* T4: NotNull(fourth) */
            Require.NotNull(zipper, nameof(zipper));

            // > return @this.Bind(
            // >     arg1 => second.Bind(
            // >         arg2 => third.Bind(
            // >             arg3 => fourth.Select(
            // >                 arg4 => zipper(arg1, arg2, arg3, arg4)))));
            return @this.Bind(
                arg1 => second.Zip(
                    third,
                    fourth,
                    (arg2, arg3, arg4) => zipper(arg1, arg2, arg3, arg4)));
        }

        /// <seealso cref="Maybe.Lift{T1, T2, T3, T4, T5, TResult}"/>
        public static Maybe<TResult> Zip<T1, T2, T3, T4, T5, TResult>(
            this Maybe<T1> @this,
            Maybe<T2> second,
            Maybe<T3> third,
            Maybe<T4> fourth,
            Maybe<T5> fifth,
            Func<T1, T2, T3, T4, T5, TResult> zipper)
        {
            /* T4: NotNull(@this) */
            /* T4: NotNull(second) */
            /* T4: NotNull(third) */
            /* T4: NotNull(fourth) */
            /* T4: NotNull(fifth) */
            Require.NotNull(zipper, nameof(zipper));

            // > return @this.Bind(
            // >     arg1 => second.Bind(
            // >         arg2 => third.Bind(
            // >             arg3 => fourth.Bind(
            // >                 arg4 => fifth.Select(
            // >                     arg5 => zipper(arg1, arg2, arg3, arg4, arg5))))));
            return @this.Bind(
                arg1 => second.Zip(
                    third,
                    fourth,
                    fifth,
                    (arg2, arg3, arg4, arg5) => zipper(arg1, arg2, arg3, arg4, arg5)));
        }

        #endregion

        #region Resource management

        // Bind() with automatic resource management.
        public static Maybe<TResult> Using<TSource, TResult>(
            this Maybe<TSource> @this,
            Func<TSource, Maybe<TResult>> binder)
            where TSource : IDisposable
        {
            /* T4: NotNull(@this) */
            Require.NotNull(binder, nameof(binder));
            return @this.Bind(val => { using (val) { return binder(val); } });
        }

        // Select() with automatic resource management.
        public static Maybe<TResult> Using<TSource, TResult>(
            this Maybe<TSource> @this,
            Func<TSource, TResult> selector)
            where TSource : IDisposable
        {
            /* T4: NotNull(@this) */
            Require.NotNull(selector, nameof(selector));
            return @this.Select(val => { using (val) { return selector(val); } });
        }

        #endregion

        #region Query Expression Pattern

        public static Maybe<TResult> Select<TSource, TResult>(
            this Maybe<TSource> @this,
            Func<TSource, TResult> selector)
        {
            /* T4: NotNull(@this) */
            Require.NotNull(selector, nameof(selector));
            return @this.Bind(val => Maybe<TResult>.η(selector(val)));
        }

        public static Maybe<TSource> Where<TSource>(
            this Maybe<TSource> @this,
            Func<TSource, bool> predicate)
        {
            /* T4: NotNull(@this) */
            Require.NotNull(predicate, nameof(predicate));
            return @this.Bind(val => predicate(val) ? Maybe<TSource>.η(val) : Maybe<TSource>.None);
        }

        // Generalizes both Bind() and Zip<T1, T2, TResult>().
        public static Maybe<TResult> SelectMany<TSource, TMiddle, TResult>(
            this Maybe<TSource> @this,
            Func<TSource, Maybe<TMiddle>> selector,
            Func<TSource, TMiddle, TResult> resultSelector)
        {
            /* T4: NotNull(@this) */
            Require.NotNull(selector, nameof(selector));
            Require.NotNull(resultSelector, nameof(resultSelector));

            return @this.Bind(
                val => selector(val).Select(
                    middle => resultSelector(val, middle)));
        }

        public static Maybe<TResult> Join<TSource, TInner, TKey, TResult>(
            this Maybe<TSource> @this,
            Maybe<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, TInner, TResult> resultSelector)
            => Join(
                @this,
                inner,
                outerKeySelector,
                innerKeySelector,
                resultSelector,
                EqualityComparer<TKey>.Default);

        public static Maybe<TResult> Join<TSource, TInner, TKey, TResult>(
            this Maybe<TSource> @this,
            Maybe<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, TInner, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
        {
            /* T4: NotNull(@this) */
            /* T4: NotNull(inner) */
            Require.NotNull(resultSelector, nameof(resultSelector));
            Require.NotNull(outerKeySelector, nameof(outerKeySelector));
            Require.NotNull(innerKeySelector, nameof(innerKeySelector));
            Require.NotNull(comparer, nameof(comparer));

            var lookup = GetKeyLookup(inner, innerKeySelector, comparer);
            Func<TSource, Maybe<TInner>> valueSelector = outer => lookup(outerKeySelector(outer));

            return @this.SelectMany(valueSelector, resultSelector);
        }

        public static Maybe<TResult> GroupJoin<TSource, TInner, TKey, TResult>(
            this Maybe<TSource> @this,
            Maybe<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, Maybe<TInner>, TResult> resultSelector)
            => GroupJoin(
                @this,
                inner,
                outerKeySelector,
                innerKeySelector,
                resultSelector,
                EqualityComparer<TKey>.Default);

        public static Maybe<TResult> GroupJoin<TSource, TInner, TKey, TResult>(
            this Maybe<TSource> @this,
            Maybe<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, Maybe<TInner>, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
        {
            /* T4: NotNull(@this) */
            /* T4: NotNull(inner) */
            Require.NotNull(resultSelector, nameof(resultSelector));
            Require.NotNull(outerKeySelector, nameof(outerKeySelector));
            Require.NotNull(innerKeySelector, nameof(innerKeySelector));
            Require.NotNull(comparer, nameof(comparer));

            var lookup = GetKeyLookup(inner, innerKeySelector, comparer);
            Func<TSource, Maybe<TInner>> selector = outer => lookup(outerKeySelector(outer));

            return @this.Select(outer => resultSelector(outer, selector(outer)));
        }

        private static Func<TKey, Maybe<TInner>> GetKeyLookup<TInner, TKey>(
            Maybe<TInner> inner,
            Func<TInner, TKey> innerKeySelector,
            IEqualityComparer<TKey> comparer)
        {
            Debug.Assert(innerKeySelector != null);
            Debug.Assert(comparer != null);

            return outerKey =>
                inner.Select(innerKeySelector)
                    .Where(innerKey => comparer.Equals(innerKey, outerKey))
                    .ContinueWith(inner);
        }

        #endregion
    }

    /// <summary>
    /// Provides extension methods for <see cref="Maybe{T}"/>
    /// where T is of type <see cref="Func{TSource, TResult}"/>.
    /// </summary>
    // T4: EmitApplicative().
    public static partial class Ap
    {
        /// <seealso cref="MaybeExtensions.Gather{TSource, TResult}" />
        public static Maybe<TResult> Apply<TSource, TResult>(
            this Maybe<Func<TSource, TResult>> @this,
            Maybe<TSource> value)
        {
            /* T4: NotNull(value) */
            return value.Gather(@this);
        }
    }

    /// <summary>
    /// Provides extension methods for functions in the Kleisli category:
    /// <see cref="Func{TSource, TResult}"/> where TResult is of type <see cref="Maybe{T}"/>.
    /// </summary>
    // T4: EmitKleisli().
    public static partial class Kleisli
    {
        public static Maybe<IEnumerable<TResult>> InvokeWith<TSource, TResult>(
            this Func<TSource, Maybe<TResult>> @this,
            IEnumerable<TSource> seq)
            => Maybe.Map(seq, @this);

        public static Maybe<TResult> InvokeWith<TSource, TResult>(
            this Func<TSource, Maybe<TResult>> @this,
            Maybe<TSource> value)
        {
            /* T4: NotNull(value) */
            return value.Bind(@this);
        }

        public static Func<TSource, Maybe<TResult>> Compose<TSource, TMiddle, TResult>(
            this Func<TSource, Maybe<TMiddle>> @this,
            Func<TMiddle, Maybe<TResult>> second)
        {
            Require.NotNull(@this, nameof(@this));
            return arg => @this(arg).Bind(second);
        }

        public static Func<TSource, Maybe<TResult>> ComposeBack<TSource, TMiddle, TResult>(
            this Func<TMiddle, Maybe<TResult>> @this,
            Func<TSource, Maybe<TMiddle>> second)
        {
            Require.NotNull(second, nameof(second));
            return arg => second(arg).Bind(@this);
        }
    }
}

namespace Narvalo.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    using Narvalo.Linq;
    using Narvalo.Applicative;

    // Provides default implementations for extension methods on IEnumerable<Maybe<T>>.
    // You will certainly want to shadow them to improve performance.
    // T4: EmitEnumerableInternal().
    internal static partial class EnumerableExtensions
    {
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Maybe<IEnumerable<TSource>> CollectImpl<TSource>(
            this IEnumerable<Maybe<TSource>> source)
        {
            Debug.Assert(source != null);

            var seed = Maybe<IEnumerable<TSource>>.η(Enumerable.Empty<TSource>());
            Func<IEnumerable<TSource>, TSource, IEnumerable<TSource>> append
                = (seq, item) => seq.Append(item);

            var accumulator = Maybe.Lift<IEnumerable<TSource>, TSource, IEnumerable<TSource>>(append);

            return source.Aggregate(seed, accumulator);
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Maybe<IEnumerable<TSource>> WhereImpl<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, Maybe<bool>> predicate)
        {
            Debug.Assert(source != null);
            Debug.Assert(predicate != null);

            var seed = Maybe<IEnumerable<TSource>>.η(Enumerable.Empty<TSource>());

            Func<TSource, Func<bool, IEnumerable<TSource>, IEnumerable<TSource>>> func
                = item => (b, seq) => b ? seq.Append(item) : seq;

            Func<Maybe<IEnumerable<TSource>>, TSource, Maybe<IEnumerable<TSource>>> accumulator
                = (mseq, item) => predicate(item).Zip(mseq, func(item));

            return source.Aggregate(seed, accumulator);
        }
    }
}

namespace Narvalo.Linq.Applicative
{
    using System;
    using System.Collections.Generic;

    using Narvalo.Applicative;
    using Narvalo.Internal;

    // Provides extension methods for IEnumerable<T> and IEnumerable<Maybe<T>>.
    // T4: EmitLinqCore().
    public static partial class Aperators
    {
        public static IEnumerable<TSource> CollectAny<TSource>(
            this IEnumerable<Maybe<TSource>> source)
        {
            Require.NotNull(source, nameof(source));
            return source.CollectAnyImpl();
        }

        public static Maybe<TSource> Sum<TSource>(this IEnumerable<Maybe<TSource>> source)
            => source.SumImpl();

        public static IEnumerable<TResult> SelectAny<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, Maybe<TResult>> selector)
        {
            Require.NotNull(source, nameof(source));
            Require.NotNull(selector, nameof(selector));
            return source.SelectAnyImpl(selector);
        }

        public static IEnumerable<TSource> WhereAny<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, Maybe<bool>> predicate)
        {
            Require.NotNull(source, nameof(source));
            Require.NotNull(predicate, nameof(predicate));
            return source.WhereAnyImpl(predicate);
        }

        public static Maybe<TAccumulate> Fold<TSource, TAccumulate>(
            this IEnumerable<TSource> source,
            TAccumulate seed,
            Func<TAccumulate, TSource, Maybe<TAccumulate>> accumulator)
        {
            Require.NotNull(source, nameof(source));
            Require.NotNull(accumulator, nameof(accumulator));
            return source.FoldImpl(seed, accumulator);
        }

        public static Maybe<TAccumulate> Fold<TSource, TAccumulate>(
            this IEnumerable<TSource> source,
            TAccumulate seed,
            Func<TAccumulate, TSource, Maybe<TAccumulate>> accumulator,
            Func<Maybe<TAccumulate>, bool> predicate)
        {
            Require.NotNull(source, nameof(source));
            Require.NotNull(accumulator, nameof(accumulator));
            Require.NotNull(predicate, nameof(predicate));
            return source.FoldImpl(seed, accumulator, predicate);
        }

        public static Maybe<TSource> Reduce<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, TSource, Maybe<TSource>> accumulator)
        {
            Require.NotNull(source, nameof(source));
            Require.NotNull(accumulator, nameof(accumulator));
            return source.ReduceImpl(accumulator);
        }

        public static Maybe<TSource> Reduce<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, TSource, Maybe<TSource>> accumulator,
            Func<Maybe<TSource>, bool> predicate)
        {
            Require.NotNull(source, nameof(source));
            Require.NotNull(accumulator, nameof(accumulator));
            Require.NotNull(predicate, nameof(predicate));
            return source.ReduceImpl(accumulator, predicate);
        }
    }
}

namespace Narvalo.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    using Narvalo.Applicative;

    // Provides default implementations for extension methods on IEnumerable<T>
    // and IEnumerable<Maybe<T>>.
    // You will certainly want to shadow them to improve performance.
    // T4: EmitLinqInternal().
    internal static partial class EnumerableExtensions
    {
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static IEnumerable<TSource> CollectAnyImpl<TSource>(
            this IEnumerable<Maybe<TSource>> source)
        {
            Debug.Assert(source != null);

            var item = default(TSource);

            using (var iter = source.GetEnumerator())
            {
                while (iter.MoveNext())
                {
                    bool append = false;
                    var current = iter.Current;

                    current.Bind(val =>
                    {
                        append = true;
                        item = val;

                        return Maybe.Unit;
                    });

                    if (append) { yield return item; }
                }
            }
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Maybe<TSource> SumImpl<TSource>(
            this IEnumerable<Maybe<TSource>> source)
        {
            Debug.Assert(source != null);
            return source.Aggregate(Maybe<TSource>.None, (m, n) => m.OrElse(n));
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static IEnumerable<TResult> SelectAnyImpl<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, Maybe<TResult>> selector)
        {
            Debug.Assert(source != null);
            Debug.Assert(selector != null);

            var result = default(TResult);

            using (var iter = source.GetEnumerator())
            {
                while (iter.MoveNext())
                {
                    bool append = false;

                    var item = selector(iter.Current);

                    item.Bind(val =>
                    {
                        append = true;
                        result = val;

                        return Maybe.Unit;
                    });

                    if (append) { yield return result; }
                }
            }
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static IEnumerable<TSource> WhereAnyImpl<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, Maybe<bool>> predicate)
        {
            Debug.Assert(source != null);
            Debug.Assert(predicate != null);

            using (var iter = source.GetEnumerator())
            {
                while (iter.MoveNext())
                {
                    bool pass = false;
                    TSource current = iter.Current;

                    var item = predicate(current);

                    item.Bind(val =>
                    {
                        pass = val;

                        return Maybe.Unit;
                    });

                    if (pass) { yield return current; }
                }
            }
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Maybe<TAccumulate> FoldImpl<TSource, TAccumulate>(
            this IEnumerable<TSource> source,
            TAccumulate seed,
            Func<TAccumulate, TSource, Maybe<TAccumulate>> accumulator)
        {
            Debug.Assert(source != null);
            Debug.Assert(accumulator != null);

            Maybe<TAccumulate> retval = Maybe<TAccumulate>.η(seed);

            using (var iter = source.GetEnumerator())
            {
                while (iter.MoveNext())
                {
                    retval = retval.Bind(val => accumulator(val, iter.Current));
                }
            }

            return retval;
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Maybe<TAccumulate> FoldImpl<TSource, TAccumulate>(
            this IEnumerable<TSource> source,
            TAccumulate seed,
            Func<TAccumulate, TSource, Maybe<TAccumulate>> accumulator,
            Func<Maybe<TAccumulate>, bool> predicate)
        {
            Debug.Assert(source != null);
            Debug.Assert(accumulator != null);
            Debug.Assert(predicate != null);

            Maybe<TAccumulate> retval = Maybe<TAccumulate>.η(seed);

            using (var iter = source.GetEnumerator())
            {
                while (predicate(retval) && iter.MoveNext())
                {
                    retval = retval.Bind(val => accumulator(val, iter.Current));
                }
            }

            return retval;
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Maybe<TSource> ReduceImpl<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, TSource, Maybe<TSource>> accumulator)
        {
            Debug.Assert(source != null);
            Debug.Assert(accumulator != null);

            using (var iter = source.GetEnumerator())
            {
                if (!iter.MoveNext())
                {
                    throw new InvalidOperationException("Source sequence was empty.");
                }

                Maybe<TSource> retval = Maybe<TSource>.η(iter.Current);

                while (iter.MoveNext())
                {
                    retval = retval.Bind(val => accumulator(val, iter.Current));
                }

                return retval;
            }
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Maybe<TSource> ReduceImpl<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, TSource, Maybe<TSource>> accumulator,
            Func<Maybe<TSource>, bool> predicate)
        {
            Debug.Assert(source != null);
            Debug.Assert(accumulator != null);
            Debug.Assert(predicate != null);

            using (var iter = source.GetEnumerator())
            {
                if (!iter.MoveNext())
                {
                    throw new InvalidOperationException("Source sequence was empty.");
                }

                Maybe<TSource> retval = Maybe<TSource>.η(iter.Current);

                while (predicate(retval) && iter.MoveNext())
                {
                    retval = retval.Bind(val => accumulator(val, iter.Current));
                }

                return retval;
            }
        }
    }
}
