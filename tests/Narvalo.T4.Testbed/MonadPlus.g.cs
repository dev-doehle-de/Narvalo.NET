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

namespace Narvalo.T4.Testbed
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    using Narvalo.T4.Testbed.Internal;

    // Provides a set of static methods for MonadPlus<T>.
    // T4: EmitHelpers().
    public static partial class MonadPlus
    {
        /// <summary>
        /// The unique object of type <c>MonadPlus&lt;Unit&gt;</c>.
        /// </summary>
        private static readonly MonadPlus<unit> s_Unit = Of(unit.Default);

        /// <summary>
        /// Gets the unique object of type <c>MonadPlus&lt;Unit&gt;</c>.
        /// </summary>
        public static MonadPlus<unit> Unit => s_Unit;

        /// <summary>
        /// Gets the zero for <see cref="MonadPlus{T}.Bind"/>.
        /// </summary>
        public static MonadPlus<unit> Zero => MonadPlus<unit>.Zero;

        /// <summary>
        /// Obtains an instance of the <see cref="MonadPlus{T}"/> class for the specified value.
        /// </summary>
        /// <typeparam name="T">The underlying type of <paramref name="value"/>.</typeparam>
        /// <param name="value">A value to be wrapped into an object of type <see cref="MonadPlus{T}"/>.</param>
        /// <returns>An instance of the <see cref="MonadPlus{T}"/> class for the specified value.</returns>
        public static MonadPlus<T> Of<T>(T value) => MonadPlus<T>.η(value);

        public static MonadPlus<unit> Guard(bool predicate) => predicate ? Unit : Zero;

        public static MonadPlus<IEnumerable<TSource>> Repeat<TSource>(
            MonadPlus<TSource> source,
            int count)
        {
            Require.NotNull(source, nameof(source));
            Require.Range(count >= 0, nameof(count));
            return source.Select(val => Enumerable.Repeat(val, count));
        }

        #region Lift()

        /// <summary>
        /// Promotes a function to use and return <see cref="MonadPlus{T}" /> values.
        /// </summary>
        /// <seealso cref="MonadPlus.Select{T, TResult}" />
        public static Func<MonadPlus<T>, MonadPlus<TResult>> Lift<T, TResult>(
            Func<T, TResult> func)
            => arg =>
            {
                Require.NotNull(arg, nameof(arg));
                return arg.Select(func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="MonadPlus{T}" /> values.
        /// </summary>
        /// <seealso cref="MonadPlus.Zip{T1, T2, TResult}"/>
        public static Func<MonadPlus<T1>, MonadPlus<T2>, MonadPlus<TResult>>
            Lift<T1, T2, TResult>(Func<T1, T2, TResult> func)
            => (arg1, arg2) =>
            {
                Require.NotNull(arg1, nameof(arg1));
                return arg1.Zip(arg2, func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="MonadPlus{T}" /> values.
        /// </summary>
        /// <seealso cref="MonadPlus.Zip{T1, T2, T3, TResult}"/>
        public static Func<MonadPlus<T1>, MonadPlus<T2>, MonadPlus<T3>, MonadPlus<TResult>>
            Lift<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> func)
            => (arg1, arg2, arg3) =>
            {
                Require.NotNull(arg1, nameof(arg1));
                return arg1.Zip(arg2, arg3, func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="MonadPlus{T}" /> values.
        /// </summary>
        /// <seealso cref="MonadPlus.Zip{T1, T2, T3, T4, TResult}"/>
        public static Func<MonadPlus<T1>, MonadPlus<T2>, MonadPlus<T3>, MonadPlus<T4>, MonadPlus<TResult>>
            Lift<T1, T2, T3, T4, TResult>(
            Func<T1, T2, T3, T4, TResult> func)
            => (arg1, arg2, arg3, arg4) =>
            {
                Require.NotNull(arg1, nameof(arg1));
                return arg1.Zip(arg2, arg3, arg4, func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="MonadPlus{T}" /> values.
        /// </summary>
        /// <seealso cref="MonadPlus.Zip{T1, T2, T3, T4, T5, TResult}"/>
        public static Func<MonadPlus<T1>, MonadPlus<T2>, MonadPlus<T3>, MonadPlus<T4>, MonadPlus<T5>, MonadPlus<TResult>>
            Lift<T1, T2, T3, T4, T5, TResult>(
            Func<T1, T2, T3, T4, T5, TResult> func)
            => (arg1, arg2, arg3, arg4, arg5) =>
            {
                Require.NotNull(arg1, nameof(arg1));
                return arg1.Zip(arg2, arg3, arg4, arg5, func);
            };

        #endregion
    }

    // Provides extension methods for MonadPlus<T>.
    // T4: EmitExtensions().
    public static partial class MonadPlus
    {
        /// <summary>
        /// Removes one level of structure, projecting its bound value into the outer level.
        /// </summary>
        public static MonadPlus<T> Flatten<T>(this MonadPlus<MonadPlus<T>> @this)
            => MonadPlus<T>.μ(@this);

        /// <seealso cref="Ap.Apply{TSource, TResult}(MonadPlus{Func{TSource, TResult}}, MonadPlus{TSource})" />
        public static MonadPlus<TResult> Gather<TSource, TResult>(
            this MonadPlus<TSource> @this,
            MonadPlus<Func<TSource, TResult>> applicative)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(applicative, nameof(applicative));
            return applicative.Bind(func => @this.Select(func));
        }

        public static MonadPlus<TResult> ReplaceBy<TSource, TResult>(
            this MonadPlus<TSource> @this,
            TResult value)
        {
            Require.NotNull(@this, nameof(@this));
            return @this.Select(_ => value);
        }

        public static MonadPlus<TResult> ContinueWith<TSource, TResult>(
            this MonadPlus<TSource> @this,
            MonadPlus<TResult> other)
        {
            Require.NotNull(@this, nameof(@this));
            return @this.Bind(_ => other);
        }

        public static MonadPlus<TSource> PassBy<TSource, TOther>(
            this MonadPlus<TSource> @this,
            MonadPlus<TOther> other)
        {
            Require.NotNull(@this, nameof(@this));
            return @this.Zip(other, (arg, _) => arg);
        }

        public static MonadPlus<unit> Skip<TSource>(this MonadPlus<TSource> @this)
        {
            Require.NotNull(@this, nameof(@this));
            return @this.ContinueWith(MonadPlus.Unit);
        }

        #region Zip()

        /// <seealso cref="MonadPlus.Lift{T1, T2, TResult}"/>
        public static MonadPlus<TResult> Zip<T1, T2, TResult>(
            this MonadPlus<T1> @this,
            MonadPlus<T2> second,
            Func<T1, T2, TResult> zipper)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(second, nameof(second));
            Require.NotNull(zipper, nameof(zipper));

            return @this.Bind(
                arg1 => second.Select(
                    arg2 => zipper(arg1, arg2)));
        }

        /// <seealso cref="MonadPlus.Lift{T1, T2, T3, TResult}"/>
        public static MonadPlus<TResult> Zip<T1, T2, T3, TResult>(
            this MonadPlus<T1> @this,
            MonadPlus<T2> second,
            MonadPlus<T3> third,
            Func<T1, T2, T3, TResult> zipper)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(second, nameof(second));
            Require.NotNull(third, nameof(third));
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

        /// <seealso cref="MonadPlus.Lift{T1, T2, T3, T4, TResult}"/>
        public static MonadPlus<TResult> Zip<T1, T2, T3, T4, TResult>(
             this MonadPlus<T1> @this,
             MonadPlus<T2> second,
             MonadPlus<T3> third,
             MonadPlus<T4> fourth,
             Func<T1, T2, T3, T4, TResult> zipper)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(second, nameof(second));
            Require.NotNull(third, nameof(third));
            Require.NotNull(fourth, nameof(fourth));
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

        /// <seealso cref="MonadPlus.Lift{T1, T2, T3, T4, T5, TResult}"/>
        public static MonadPlus<TResult> Zip<T1, T2, T3, T4, T5, TResult>(
            this MonadPlus<T1> @this,
            MonadPlus<T2> second,
            MonadPlus<T3> third,
            MonadPlus<T4> fourth,
            MonadPlus<T5> fifth,
            Func<T1, T2, T3, T4, T5, TResult> zipper)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(second, nameof(second));
            Require.NotNull(third, nameof(third));
            Require.NotNull(fourth, nameof(fourth));
            Require.NotNull(fifth, nameof(fifth));
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
        public static MonadPlus<TResult> Using<TSource, TResult>(
            this MonadPlus<TSource> @this,
            Func<TSource, MonadPlus<TResult>> binder)
            where TSource : IDisposable
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(binder, nameof(binder));
            return @this.Bind(val => { using (val) { return binder(val); } });
        }

        // Select() with automatic resource management.
        public static MonadPlus<TResult> Using<TSource, TResult>(
            this MonadPlus<TSource> @this,
            Func<TSource, TResult> selector)
            where TSource : IDisposable
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(selector, nameof(selector));
            return @this.Select(val => { using (val) { return selector(val); } });
        }

        #endregion

        #region Query Expression Pattern

        public static MonadPlus<TResult> Select<TSource, TResult>(
            this MonadPlus<TSource> @this,
            Func<TSource, TResult> selector)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(selector, nameof(selector));
            return @this.Bind(val => MonadPlus<TResult>.η(selector(val)));
        }

        public static MonadPlus<TSource> Where<TSource>(
            this MonadPlus<TSource> @this,
            Func<TSource, bool> predicate)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(predicate, nameof(predicate));
            return @this.Bind(val => predicate(val) ? MonadPlus<TSource>.η(val) : MonadPlus<TSource>.Zero);
        }

        // Generalizes both Bind() and Zip<T1, T2, TResult>().
        public static MonadPlus<TResult> SelectMany<TSource, TMiddle, TResult>(
            this MonadPlus<TSource> @this,
            Func<TSource, MonadPlus<TMiddle>> selector,
            Func<TSource, TMiddle, TResult> resultSelector)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(selector, nameof(selector));
            Require.NotNull(resultSelector, nameof(resultSelector));

            return @this.Bind(
                val => selector(val).Select(
                    middle => resultSelector(val, middle)));
        }

        public static MonadPlus<TResult> Join<TSource, TInner, TKey, TResult>(
            this MonadPlus<TSource> @this,
            MonadPlus<TInner> inner,
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

        public static MonadPlus<TResult> Join<TSource, TInner, TKey, TResult>(
            this MonadPlus<TSource> @this,
            MonadPlus<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, TInner, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(inner, nameof(inner));
            Require.NotNull(resultSelector, nameof(resultSelector));
            Require.NotNull(outerKeySelector, nameof(outerKeySelector));
            Require.NotNull(innerKeySelector, nameof(innerKeySelector));
            Require.NotNull(comparer, nameof(comparer));

            var lookup = GetKeyLookup(inner, innerKeySelector, comparer);
            Func<TSource, MonadPlus<TInner>> valueSelector = outer => lookup(outerKeySelector(outer));

            return @this.SelectMany(valueSelector, resultSelector);
        }

        public static MonadPlus<TResult> GroupJoin<TSource, TInner, TKey, TResult>(
            this MonadPlus<TSource> @this,
            MonadPlus<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, MonadPlus<TInner>, TResult> resultSelector)
            => GroupJoin(
                @this,
                inner,
                outerKeySelector,
                innerKeySelector,
                resultSelector,
                EqualityComparer<TKey>.Default);

        public static MonadPlus<TResult> GroupJoin<TSource, TInner, TKey, TResult>(
            this MonadPlus<TSource> @this,
            MonadPlus<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, MonadPlus<TInner>, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(inner, nameof(inner));
            Require.NotNull(resultSelector, nameof(resultSelector));
            Require.NotNull(outerKeySelector, nameof(outerKeySelector));
            Require.NotNull(innerKeySelector, nameof(innerKeySelector));
            Require.NotNull(comparer, nameof(comparer));

            var lookup = GetKeyLookup(inner, innerKeySelector, comparer);
            Func<TSource, MonadPlus<TInner>> selector = outer => lookup(outerKeySelector(outer));

            return @this.Select(outer => resultSelector(outer, selector(outer)));
        }

        private static Func<TKey, MonadPlus<TInner>> GetKeyLookup<TInner, TKey>(
            MonadPlus<TInner> inner,
            Func<TInner, TKey> innerKeySelector,
            IEqualityComparer<TKey> comparer)
        {
            Debug.Assert(inner != null);
            Debug.Assert(innerKeySelector != null);
            Debug.Assert(comparer != null);

            return outerKey =>
                inner.Select(innerKeySelector)
                    .Where(innerKey => comparer.Equals(innerKey, outerKey))
                    .ContinueWith(inner);
        }

        #endregion
    }

    // Provides extension methods for MonadPlus<Func<TSource, TResult>>.
    // T4: EmitApplicative().
    public static partial class Ap
    {
        /// <seealso cref="MonadPlus.Gather{TSource, TResult}" />
        public static MonadPlus<TResult> Apply<TSource, TResult>(
            this MonadPlus<Func<TSource, TResult>> @this,
            MonadPlus<TSource> value)
        {
            Require.NotNull(value, nameof(value));
            return value.Gather(@this);
        }
    }

    // Provides extension methods for functions in the Kleisli category.
    // T4: EmitKleisli().
    public static partial class Kleisli
    {
        public static MonadPlus<IEnumerable<TResult>> InvokeWith<TSource, TResult>(
            this Func<TSource, MonadPlus<TResult>> @this,
            IEnumerable<TSource> seq)
            => seq.Select(@this).Collect();

        public static MonadPlus<TResult> InvokeWith<TSource, TResult>(
            this Func<TSource, MonadPlus<TResult>> @this,
            MonadPlus<TSource> value)
        {
            Require.NotNull(value, nameof(value));
            return value.Bind(@this);
        }

        public static Func<TSource, MonadPlus<TResult>> Compose<TSource, TMiddle, TResult>(
            this Func<TSource, MonadPlus<TMiddle>> @this,
            Func<TMiddle, MonadPlus<TResult>> second)
        {
            Require.NotNull(@this, nameof(@this));
            return arg => @this(arg).Bind(second);
        }

        public static Func<TSource, MonadPlus<TResult>> ComposeBack<TSource, TMiddle, TResult>(
            this Func<TMiddle, MonadPlus<TResult>> @this,
            Func<TSource, MonadPlus<TMiddle>> second)
        {
            Require.NotNull(second, nameof(second));
            return arg => second(arg).Bind(@this);
        }
    }

    // Provides extension methods for IEnumerable<MonadPlus<T>>.
    // T4: EmitEnumerableExtensions().
    public static partial class MonadPlus
    {
        public static IEnumerable<TSource> CollectAny<TSource>(
            this IEnumerable<MonadPlus<TSource>> source)
        {
            Require.NotNull(source, nameof(source));
            return source.CollectAnyImpl();
        }

        // Hidden because this operator is not composable.
        // Do not disable, we use it in Kleisli.InvokeWith().
        internal static MonadPlus<IEnumerable<TSource>> Collect<TSource>(
            this IEnumerable<MonadPlus<TSource>> source)
        {
            Require.NotNull(source, nameof(source));
            return source.CollectImpl();
        }

        public static MonadPlus<TSource> Sum<TSource>(this IEnumerable<MonadPlus<TSource>> source)
            => source.SumImpl();
    }
}

namespace Narvalo.T4.Testbed.Internal
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    using Narvalo.T4.Testbed;

    // Provides default implementations for the extension methods for IEnumerable<MonadPlus<T>>.
    // You will certainly want to shadow them to improve performance.
    // T4: EmitEnumerableInternal().
    internal static partial class EnumerableExtensions
    {
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static IEnumerable<TSource> CollectAnyImpl<TSource>(
            this IEnumerable<MonadPlus<TSource>> source)
        {
            Debug.Assert(source != null);

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

                            return MonadPlus.Unit;
                        });

                    if (append) { yield return item; }
                }
            }
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static MonadPlus<IEnumerable<TSource>> CollectImpl<TSource>(
            this IEnumerable<MonadPlus<TSource>> source)
        {
            Debug.Assert(source != null);
            return MonadPlus<IEnumerable<TSource>>.η(CollectAnyImpl(source));
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static MonadPlus<TSource> SumImpl<TSource>(
            this IEnumerable<MonadPlus<TSource>> source)
        {
            Debug.Assert(source != null);
            return source.Aggregate(MonadPlus<TSource>.Zero, (m, n) => m.Plus(n));
        }
    }
}

namespace Narvalo.T4.Testbed.Linq
{
    using System;
    using System.Collections.Generic;

    using Narvalo.T4.Testbed;
    using Narvalo.T4.Testbed.Internal;

    // Provides extension methods for IEnumerable<T>.
    // T4: EmitLinqCore().
    public static partial class Qperators
    {
        public static IEnumerable<TSource> WhereAny<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, MonadPlus<bool>> predicate)
        {
            Require.NotNull(source, nameof(source));
            Require.NotNull(predicate, nameof(predicate));
            return source.WhereAnyImpl(predicate);
        }

        public static MonadPlus<TAccumulate> Fold<TSource, TAccumulate>(
            this IEnumerable<TSource> source,
            TAccumulate seed,
            Func<TAccumulate, TSource, MonadPlus<TAccumulate>> accumulator)
        {
            Require.NotNull(source, nameof(source));
            Require.NotNull(accumulator, nameof(accumulator));
            return source.FoldImpl(seed, accumulator);
        }

        public static MonadPlus<TAccumulate> Fold<TSource, TAccumulate>(
            this IEnumerable<TSource> source,
            TAccumulate seed,
            Func<TAccumulate, TSource, MonadPlus<TAccumulate>> accumulator,
            Func<MonadPlus<TAccumulate>, bool> predicate)
        {
            Require.NotNull(source, nameof(source));
            Require.NotNull(accumulator, nameof(accumulator));
            Require.NotNull(predicate, nameof(predicate));
            return source.FoldImpl(seed, accumulator, predicate);
        }

        public static MonadPlus<TSource> Reduce<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, TSource, MonadPlus<TSource>> accumulator)
        {
            Require.NotNull(source, nameof(source));
            Require.NotNull(accumulator, nameof(accumulator));
            return source.ReduceImpl(accumulator);
        }

        public static MonadPlus<TSource> Reduce<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, TSource, MonadPlus<TSource>> accumulator,
            Func<MonadPlus<TSource>, bool> predicate)
        {
            Require.NotNull(source, nameof(source));
            Require.NotNull(accumulator, nameof(accumulator));
            Require.NotNull(predicate, nameof(predicate));
            return source.ReduceImpl(accumulator, predicate);
        }
    }
}

namespace Narvalo.T4.Testbed.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;

    using Narvalo.T4.Testbed;

    // Provides default implementations for the extension methods for IEnumerable<T>.
    // You will certainly want to shadow them to improve performance.
    // T4: EmitLinqInternal().
    internal static partial class EnumerableExtensions
    {
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static IEnumerable<TSource> WhereAnyImpl<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, MonadPlus<bool>> predicate)
        {
            Debug.Assert(source != null);
            Debug.Assert(predicate != null);

            using (var iter = source.GetEnumerator())
            {
                while (iter.MoveNext())
                {
                    bool pass = false;
                    TSource item = iter.Current;

                    predicate(item).Bind(val =>
                    {
                        pass = val;

                        return MonadPlus.Unit;
                    });

                    if (pass) { yield return item; }
                }
            }
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static MonadPlus<TAccumulate> FoldImpl<TSource, TAccumulate>(
            this IEnumerable<TSource> source,
            TAccumulate seed,
            Func<TAccumulate, TSource, MonadPlus<TAccumulate>> accumulator)
        {
            Debug.Assert(source != null);
            Debug.Assert(accumulator != null);

            MonadPlus<TAccumulate> retval = MonadPlus<TAccumulate>.η(seed);

            using (var iter = source.GetEnumerator())
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
        internal static MonadPlus<TAccumulate> FoldImpl<TSource, TAccumulate>(
            this IEnumerable<TSource> source,
            TAccumulate seed,
            Func<TAccumulate, TSource, MonadPlus<TAccumulate>> accumulator,
            Func<MonadPlus<TAccumulate>, bool> predicate)
        {
            Debug.Assert(source != null);
            Debug.Assert(accumulator != null);
            Debug.Assert(predicate != null);

            MonadPlus<TAccumulate> retval = MonadPlus<TAccumulate>.η(seed);

            using (var iter = source.GetEnumerator())
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
        internal static MonadPlus<TSource> ReduceImpl<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, TSource, MonadPlus<TSource>> accumulator)
        {
            Debug.Assert(source != null);
            Debug.Assert(accumulator != null);

            using (var iter = source.GetEnumerator())
            {
                if (!iter.MoveNext())
                {
                    throw new InvalidOperationException("Source sequence was empty.");
                }

                MonadPlus<TSource> retval = MonadPlus<TSource>.η(iter.Current);

                while (iter.MoveNext())
                {
                    if (retval == null) { continue; }

                    retval = retval.Bind(val => accumulator(val, iter.Current));
                }

                return retval;
            }
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static MonadPlus<TSource> ReduceImpl<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, TSource, MonadPlus<TSource>> accumulator,
            Func<MonadPlus<TSource>, bool> predicate)
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

                MonadPlus<TSource> retval = MonadPlus<TSource>.η(iter.Current);

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

