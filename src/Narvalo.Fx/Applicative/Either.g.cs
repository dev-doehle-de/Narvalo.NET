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

namespace Narvalo.Applicative
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Narvalo.Internal;
    using Narvalo.Linq;

    // Provides a set of static methods for Either<T, TRight>.
    // T4: EmitHelpers().
    public static partial class Either
    {
        /// <summary>
        /// Removes one level of structure, projecting its bound value into the outer level.
        /// </summary>
        public static Either<T, TRight> Flatten<T, TRight>(Either<Either<T, TRight>, TRight> square)
            => Either<T, TRight>.μ(square);

        #region Lift()

        /// <summary>
        /// Promotes a function to use and return <see cref="Either{T, TRight}" /> values.
        /// </summary>
        /// <seealso cref="Either.Select{T, TResult, TRight}" />
        public static Func<Either<T, TRight>, Either<TResult, TRight>> Lift<T, TResult, TRight>(
            Func<T, TResult> func)
            => arg =>
            {
                Require.NotNull(arg, nameof(arg));
                return arg.Select(func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="Either{T, TRight}" /> values.
        /// </summary>
        public static Func<Either<T1, TRight>, Either<T2, TRight>, Either<TResult, TRight>>
            Lift<T1, T2, TResult, TRight>(Func<T1, T2, TResult> func)
            => (arg1, arg2) =>
            {
                Require.NotNull(arg1, nameof(arg1));
                return arg1.Zip(arg2, func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="Either{T, TRight}" /> values.
        /// </summary>
        public static Func<Either<T1, TRight>, Either<T2, TRight>, Either<T3, TRight>, Either<TResult, TRight>>
            Lift<T1, T2, T3, TResult, TRight>(Func<T1, T2, T3, TResult> func)
            => (arg1, arg2, arg3) =>
            {
                Require.NotNull(arg1, nameof(arg1));
                return arg1.Zip(arg2, arg3, func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="Either{T, TRight}" /> values.
        /// </summary>
        public static Func<Either<T1, TRight>, Either<T2, TRight>, Either<T3, TRight>, Either<T4, TRight>, Either<TResult, TRight>>
            Lift<T1, T2, T3, T4, TResult, TRight>(
            Func<T1, T2, T3, T4, TResult> func)
            => (arg1, arg2, arg3, arg4) =>
            {
                Require.NotNull(arg1, nameof(arg1));
                return arg1.Zip(arg2, arg3, arg4, func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="Either{T, TRight}" /> values.
        /// </summary>
        public static Func<Either<T1, TRight>, Either<T2, TRight>, Either<T3, TRight>, Either<T4, TRight>, Either<T5, TRight>, Either<TResult, TRight>>
            Lift<T1, T2, T3, T4, T5, TResult, TRight>(
            Func<T1, T2, T3, T4, T5, TResult> func)
            => (arg1, arg2, arg3, arg4, arg5) =>
            {
                Require.NotNull(arg1, nameof(arg1));
                return arg1.Zip(arg2, arg3, arg4, arg5, func);
            };

        #endregion
    }

    // Provides extension methods for Either<T, TRight>.
    // T4: EmitExtensions().
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
        {
            Require.NotNull(@this, nameof(@this));
            return @this.Select(_ => value);
        }

        public static Either<TResult, TRight> Then<TSource, TResult, TRight>(
            this Either<TSource, TRight> @this,
            Either<TResult, TRight> other)
        {
            Require.NotNull(@this, nameof(@this));
            return @this.Bind(_ => other);
        }

        public static Either<TSource, TRight> Ignore<TSource, TOther, TRight>(
            this Either<TSource, TRight> @this,
            Either<TOther, TRight> other)
        {
            Require.NotNull(@this, nameof(@this));
            Func<TSource, TOther, TSource> ignore = (arg, _) => arg;

            return @this.Zip(other, ignore);
        }

        public static Either<global::Narvalo.Applicative.Unit, TRight> Skip<TSource, TRight>(this Either<TSource, TRight> @this)
        {
            Require.NotNull(@this, nameof(@this));
            return @this.ReplaceBy(global::Narvalo.Applicative.Unit.Default);
        }

        public static Either<TResult, TRight> Coalesce<TSource, TResult, TRight>(
            this Either<TSource, TRight> @this,
            Func<TSource, bool> predicate,
            Either<TResult, TRight> thenResult,
            Either<TResult, TRight> elseResult)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(predicate, nameof(predicate));
            return @this.Bind(val => predicate(val) ? thenResult : elseResult);
        }

        public static Either<TResult, TRight> Using<TSource, TResult, TRight>(
            this Either<TSource, TRight> @this,
            Func<TSource, Either<TResult, TRight>> selector)
            where TSource : IDisposable
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(selector, nameof(selector));
            return @this.Bind(val => { using (val) { return selector(val); } });
        }

        public static Either<TResult, TRight> Using<TSource, TResult, TRight>(
            this Either<TSource, TRight> @this,
            Func<TSource, TResult> selector)
            where TSource : IDisposable
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(selector, nameof(selector));
            return @this.Select(val => { using (val) { return selector(val); } });
        }

        #region Zip()

        public static Either<Tuple<TSource, TOther>, TRight> Zip<TSource, TOther, TRight>(
            this Either<TSource, TRight> @this,
            Either<TOther, TRight> other)
        {
            Require.NotNull(@this, nameof(@this));
            return @this.Zip(other, Tuple.Create);
        }

        public static Either<TResult, TRight> Zip<TFirst, TSecond, TResult, TRight>(
            this Either<TFirst, TRight> @this,
            Either<TSecond, TRight> second,
            Func<TFirst, TSecond, TResult> zipper)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(second, nameof(second));
            Require.NotNull(zipper, nameof(zipper));

            return @this.Bind(
                arg1 => second.Select(
                    arg2 => zipper(arg1, arg2)));
        }

        public static Either<TResult, TRight> Zip<T1, T2, T3, TResult, TRight>(
            this Either<T1, TRight> @this,
            Either<T2, TRight> second,
            Either<T3, TRight> third,
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

        public static Either<TResult, TRight> Zip<T1, T2, T3, T4, TResult, TRight>(
             this Either<T1, TRight> @this,
             Either<T2, TRight> second,
             Either<T3, TRight> third,
             Either<T4, TRight> fourth,
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

        public static Either<TResult, TRight> Zip<T1, T2, T3, T4, T5, TResult, TRight>(
            this Either<T1, TRight> @this,
            Either<T2, TRight> second,
            Either<T3, TRight> third,
            Either<T4, TRight> fourth,
            Either<T5, TRight> fifth,
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

        #region LINQ dialect

        public static Either<TResult, TRight> Select<TSource, TResult, TRight>(
            this Either<TSource, TRight> @this,
            Func<TSource, TResult> selector)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(selector, nameof(selector));
            return @this.Bind(val => Either<TResult, TRight>.OfLeft(selector(val)));
        }

        // Kind of generalisation of Zip{T1, T2, T3}.
        public static Either<TResult, TRight> SelectMany<TSource, TMiddle, TResult, TRight>(
            this Either<TSource, TRight> @this,
            Func<TSource, Either<TMiddle, TRight>> valueSelector,
            Func<TSource, TMiddle, TResult> resultSelector)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(valueSelector, nameof(valueSelector));
            Require.NotNull(resultSelector, nameof(resultSelector));

            return @this.Bind(
                val => valueSelector(val).Select(
                    middle => resultSelector(val, middle)));
        }

        #endregion
    }

    // Provides extension methods for Func<T> in the Kleisli category.
    // T4: EmitKleisli().
    public static partial class Kleisli
    {
        public static Either<IEnumerable<TResult>, TRight> InvokeWith<TSource, TResult, TRight>(
            this Func<TSource, Either<TResult, TRight>> @this,
            IEnumerable<TSource> seq)
            => seq.SelectWith(@this);

        public static Either<TResult, TRight> InvokeWith<TSource, TResult, TRight>(
            this Func<TSource, Either<TResult, TRight>> @this,
            Either<TSource, TRight> value)
        {
            Require.NotNull(value, nameof(value));
            return value.Bind(@this);
        }

        public static Func<TSource, Either<TResult, TRight>> Compose<TSource, TMiddle, TResult, TRight>(
            this Func<TSource, Either<TMiddle, TRight>> @this,
            Func<TMiddle, Either<TResult, TRight>> second)
        {
            Require.NotNull(@this, nameof(@this));
            return arg => @this(arg).Bind(second);
        }

        public static Func<TSource, Either<TResult, TRight>> ComposeBack<TSource, TMiddle, TResult, TRight>(
            this Func<TMiddle, Either<TResult, TRight>> @this,
            Func<TSource, Either<TMiddle, TRight>> second)
        {
            Require.NotNull(second, nameof(second));
            return arg => second(arg).Bind(@this);
        }
    }

    // Provides extension methods for IEnumerable<Either<T, TRight>>.
    // T4: EmitEnumerableExtensions().
    public static partial class Either
    {
        public static Either<IEnumerable<TSource>, TRight> Collect<TSource, TRight>(
            this IEnumerable<Either<TSource, TRight>> @this)
            => @this.CollectImpl();
    }
}

namespace Narvalo.Internal
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    using Narvalo.Applicative;
    using Narvalo.Linq;

    // Provides default implementations for the extension methods for IEnumerable<Either<T, TRight>>.
    // You will certainly want to override them to improve performance.
    // T4: EmitEnumerableInternal().
    internal static partial class EnumerableExtensions
    {
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Either<IEnumerable<TSource>, TRight> CollectImpl<TSource, TRight>(
            this IEnumerable<Either<TSource, TRight>> @this)
        {
            Require.NotNull(@this, nameof(@this));

            return Either<IEnumerable<TSource>, TRight>.OfLeft(CollectIterator(@this));
        }

        private static IEnumerable<TSource> CollectIterator<TSource, TRight>(IEnumerable<Either<TSource, TRight>> source)
        {
            Demand.NotNull(source);

            var unit = Either<Unit, TRight>.OfLeft(Unit.Default);
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
    }
}

namespace Narvalo.Linq
{
    using System;
    using System.Collections.Generic;

    using Narvalo.Applicative;
    using Narvalo.Internal;

    // Provides extension methods for IEnumerable<T>.
    // We do not use the standard LINQ names to avoid any confusion.
    // - Select    -> SelectWith
    // - Where     -> WhereBy
    // - Zip       -> ZipWith
    // - Aggregate -> Reduce or Fold
    // T4: EmitLinqCore().
    public static partial class Qperators
    {
        public static Either<IEnumerable<TResult>, TRight> SelectWith<TSource, TResult, TRight>(
            this IEnumerable<TSource> @this,
            Func<TSource, Either<TResult, TRight>> selector)
            => @this.SelectWithImpl(selector);

        public static Either<IEnumerable<TSource>, TRight> WhereBy<TSource, TRight>(
            this IEnumerable<TSource> @this,
            Func<TSource, Either<bool, TRight>> predicate)
            => @this.WhereByImpl(predicate);

        public static Either<IEnumerable<TResult>, TRight> ZipWith<TFirst, TSecond, TResult, TRight>(
            this IEnumerable<TFirst> @this,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, Either<TResult, TRight>> resultSelector)
            => @this.ZipWithImpl(second, resultSelector);

        public static Either<TAccumulate, TRight> Fold<TSource, TAccumulate, TRight>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Either<TAccumulate, TRight>> accumulator)
            => @this.FoldImpl(seed, accumulator);

        public static Either<TAccumulate, TRight> Fold<TSource, TAccumulate, TRight>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Either<TAccumulate, TRight>> accumulator,
            Func<Either<TAccumulate, TRight>, bool> predicate)
            => @this.FoldImpl(seed, accumulator, predicate);

        public static Either<TSource, TRight> Reduce<TSource, TRight>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Either<TSource, TRight>> accumulator)
            => @this.ReduceImpl(accumulator);

        public static Either<TSource, TRight> Reduce<TSource, TRight>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Either<TSource, TRight>> accumulator,
            Func<Either<TSource, TRight>, bool> predicate)
            => @this.ReduceImpl(accumulator, predicate);
    }
}

namespace Narvalo.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    using Narvalo.Applicative;

    // Provides default implementations for the extension methods for IEnumerable<T>.
    // You will certainly want to override them to improve performance.
    // T4: EmitLinqInternal().
    internal static partial class EnumerableExtensions
    {
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Either<IEnumerable<TResult>, TRight> SelectWithImpl<TSource, TResult, TRight>(
            this IEnumerable<TSource> @this,
            Func<TSource, Either<TResult, TRight>> selector)
        {
            Demand.NotNull(@this);
            Demand.NotNull(selector);

            return @this.Select(selector).Collect();
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Either<IEnumerable<TSource>, TRight> WhereByImpl<TSource, TRight>(
            this IEnumerable<TSource> @this,
            Func<TSource, Either<bool, TRight>> predicate)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(predicate, nameof(predicate));

            return Either<IEnumerable<TSource>, TRight>.OfLeft(WhereByIterator(@this, predicate));
        }

        private static IEnumerable<TSource> WhereByIterator<TSource, TRight>(
            IEnumerable<TSource> source,
            Func<TSource, Either<bool, TRight>> predicate)
        {
            Demand.NotNull(source);
            Demand.NotNull(predicate);

            var unit = Either<Unit, TRight>.OfLeft(Unit.Default);

            using (var iter = source.GetEnumerator())
            {
                while (iter.MoveNext())
                {
                    bool pass = false;
                    TSource item = iter.Current;

                    predicate(item).Bind(val =>
                    {
                        pass = val;

                        return unit;
                    });

                    if (pass) { yield return item; }
                }
            }
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Either<IEnumerable<TResult>, TRight> ZipWithImpl<TFirst, TSecond, TResult, TRight>(
            this IEnumerable<TFirst> @this,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, Either<TResult, TRight>> resultSelector)
        {
            Demand.NotNull(resultSelector);
            Demand.NotNull(@this);
            Demand.NotNull(second);

            return @this.Zip(second, resultSelector).Collect();
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Either<TAccumulate, TRight> FoldImpl<TSource, TAccumulate, TRight>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Either<TAccumulate, TRight>> accumulator)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(accumulator, nameof(accumulator));

            Either<TAccumulate, TRight> retval = Either<TAccumulate, TRight>.OfLeft(seed);

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
        internal static Either<TAccumulate, TRight> FoldImpl<TSource, TAccumulate, TRight>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Either<TAccumulate, TRight>> accumulator,
            Func<Either<TAccumulate, TRight>, bool> predicate)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(accumulator, nameof(accumulator));
            Require.NotNull(predicate, nameof(predicate));

            Either<TAccumulate, TRight> retval = Either<TAccumulate, TRight>.OfLeft(seed);

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
        internal static Either<TSource, TRight> ReduceImpl<TSource, TRight>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Either<TSource, TRight>> accumulator)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(accumulator, nameof(accumulator));

            using (var iter = @this.GetEnumerator())
            {
                if (!iter.MoveNext())
                {
                    throw new InvalidOperationException("Source sequence was empty.");
                }

                Either<TSource, TRight> retval = Either<TSource, TRight>.OfLeft(iter.Current);

                while (iter.MoveNext())
                {
                    if (retval == null) { continue; }

                    retval = retval.Bind(val => accumulator(val, iter.Current));
                }

                return retval;
            }
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Either<TSource, TRight> ReduceImpl<TSource, TRight>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Either<TSource, TRight>> accumulator,
            Func<Either<TSource, TRight>, bool> predicate)
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

                Either<TSource, TRight> retval = Either<TSource, TRight>.OfLeft(iter.Current);

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
