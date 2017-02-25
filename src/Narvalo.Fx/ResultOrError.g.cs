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

    // Provides a set of static methods for ResultOrError<T>.
    public static partial class ResultOrError
    {
        /// <summary>
        /// The unique object of type <c>ResultOrError&lt;Unit&gt;</c>.
        /// </summary>
        private static readonly ResultOrError<global::Narvalo.Fx.Unit> s_Unit = Of(global::Narvalo.Fx.Unit.Single);

        /// <summary>
        /// Gets the unique object of type <c>ResultOrError&lt;Unit&gt;</c>.
        /// </summary>
        public static ResultOrError<global::Narvalo.Fx.Unit> Unit => s_Unit;

        /// <summary>
        /// Obtains an instance of the <see cref="ResultOrError{T}"/> class for the specified value.
        /// </summary>
        /// <typeparam name="T">The underlying type of <paramref name="value"/>.</typeparam>
        /// <param name="value">A value to be wrapped into an object of type <see cref="ResultOrError{T}"/>.</param>
        /// <returns>An instance of the <see cref="ResultOrError{T}"/> class for the specified value.</returns>
        public static ResultOrError<T> Of<T>(T value)
            /* T4: type constraint */
            => ResultOrError<T>.η(value);

        /// <summary>
        /// Removes one level of structure, projecting its bound value into the outer level.
        /// </summary>
        public static ResultOrError<T> Flatten<T>(ResultOrError<ResultOrError<T>> square)
            /* T4: type constraint */
            => ResultOrError<T>.μ(square);

        #region Lift()

        /// <summary>
        /// Promotes a function to use and return <see cref="ResultOrError{T}" /> values.
        /// </summary>
        public static Func<ResultOrError<T>, ResultOrError<TResult>> Lift<T, TResult>(
            Func<T, TResult> func)
            /* T4: type constraint */
            => arg =>
            {
                Require.NotNull(arg, nameof(arg));
                return arg.Select(func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="ResultOrError{T}" /> values.
        /// </summary>
        public static Func<ResultOrError<T1>, ResultOrError<T2>, ResultOrError<TResult>>
            Lift<T1, T2, TResult>(Func<T1, T2, TResult> func)
            /* T4: type constraint */
            => (arg1, arg2) =>
            {
                Require.NotNull(arg1, nameof(arg1));
                return arg1.Zip(arg2, func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="ResultOrError{T}" /> values.
        /// </summary>
        public static Func<ResultOrError<T1>, ResultOrError<T2>, ResultOrError<T3>, ResultOrError<TResult>>
            Lift<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> func)
            /* T4: type constraint */
            => (arg1, arg2, arg3) =>
            {
                Require.NotNull(arg1, nameof(arg1));
                return arg1.Zip(arg2, arg3, func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="ResultOrError{T}" /> values.
        /// </summary>
        public static Func<ResultOrError<T1>, ResultOrError<T2>, ResultOrError<T3>, ResultOrError<T4>, ResultOrError<TResult>>
            Lift<T1, T2, T3, T4, TResult>(
            Func<T1, T2, T3, T4, TResult> func)
            /* T4: type constraint */
            => (arg1, arg2, arg3, arg4) =>
            {
                Require.NotNull(arg1, nameof(arg1));
                return arg1.Zip(arg2, arg3, arg4, func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="ResultOrError{T}" /> values.
        /// </summary>
        public static Func<ResultOrError<T1>, ResultOrError<T2>, ResultOrError<T3>, ResultOrError<T4>, ResultOrError<T5>, ResultOrError<TResult>>
            Lift<T1, T2, T3, T4, T5, TResult>(
            Func<T1, T2, T3, T4, T5, TResult> func)
            /* T4: type constraint */
            => (arg1, arg2, arg3, arg4, arg5) =>
            {
                Require.NotNull(arg1, nameof(arg1));
                return arg1.Zip(arg2, arg3, arg4, arg5, func);
            };

        #endregion
    } // End of ResultOrError - T4: EmitMonadCore().

    // Provides extension methods for ResultOrError<T>.
    public static partial class ResultOrError
    {
        public static ResultOrError<TResult> Select<TSource, TResult>(
            this ResultOrError<TSource> @this,
            Func<TSource, TResult> selector)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(selector, nameof(selector));
            return @this.Bind(val => ResultOrError.Of(selector(val)));
        }

        public static ResultOrError<TResult> Gather<TSource, TResult>(
            this ResultOrError<TSource> @this,
            ResultOrError<Func<TSource, TResult>> applicative)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(applicative, nameof(applicative));
            return applicative.Bind(func => @this.Select(func));
        }

        public static ResultOrError<TResult> Apply<TSource, TResult>(
            this ResultOrError<Func<TSource, TResult>> @this,
            ResultOrError<TSource> value)
        {
            Require.NotNull(value, nameof(value));
            return value.Gather(@this);
        }

        public static ResultOrError<TResult> ReplaceBy<TSource, TResult>(
            this ResultOrError<TSource> @this,
            TResult value)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            return @this.Select(_ => value);
        }

        public static ResultOrError<TResult> ReplaceBy<TSource, TResult>(
            this ResultOrError<TSource> @this,
            ResultOrError<TResult> other)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            return @this.Bind(_ => other);
        }

        public static ResultOrError<TResult> Coalesce<TSource, TResult>(
            this ResultOrError<TSource> @this,
            Func<TSource, bool> predicate,
            ResultOrError<TResult> thenResult,
            ResultOrError<TResult> elseResult)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(predicate, nameof(predicate));
            return @this.Bind(val => predicate(val) ? thenResult : elseResult);
        }

        public static ResultOrError<TSource> Ignore<TSource, TOther>(
            this ResultOrError<TSource> @this,
            ResultOrError<TOther> other)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            Func<TSource, TOther, TSource> ignorearg2 = (arg1, _) => arg1;

            return @this.Zip(other, ignorearg2);
        }

        public static ResultOrError<global::Narvalo.Fx.Unit> Skip<TSource>(this ResultOrError<TSource> @this)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            return @this.ReplaceBy(Unit);
        }

        public static ResultOrError<IEnumerable<TSource>> Repeat<TSource>(
            this ResultOrError<TSource> @this,
            int count)
        {
            Require.NotNull(@this, nameof(@this));
            Require.Range(count >= 1, nameof(count));
            return @this.Select(val => Enumerable.Repeat(val, count));
        }

        public static ResultOrError<TResult> Using<TSource, TResult>(
            this ResultOrError<TSource> @this,
            Func<TSource, ResultOrError<TResult>> selector)
            where TSource : IDisposable
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(selector, nameof(selector));
            return @this.Bind(val => { using (val) { return selector(val); } });
        }

        public static ResultOrError<TResult> Using<TSource, TResult>(
            this ResultOrError<TSource> @this,
            Func<TSource, TResult> selector)
            where TSource : IDisposable
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(selector, nameof(selector));
            return @this.Select(val => { using (val) { return selector(val); } });
        }

        #region Zip()

        public static ResultOrError<Tuple<TSource, TOther>> Zip<TSource, TOther>(
            this ResultOrError<TSource> @this,
            ResultOrError<TOther> other)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            return @this.Zip(other, Tuple.Create);
        }

        /// <see cref="Lift{T1, T2, T3}" />
        public static ResultOrError<TResult> Zip<TFirst, TSecond, TResult>(
            this ResultOrError<TFirst> @this,
            ResultOrError<TSecond> second,
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
        public static ResultOrError<TResult> Zip<T1, T2, T3, TResult>(
            this ResultOrError<T1> @this,
            ResultOrError<T2> second,
            ResultOrError<T3> third,
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
        public static ResultOrError<TResult> Zip<T1, T2, T3, T4, TResult>(
             this ResultOrError<T1> @this,
             ResultOrError<T2> second,
             ResultOrError<T3> third,
             ResultOrError<T4> fourth,
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
        public static ResultOrError<TResult> Zip<T1, T2, T3, T4, T5, TResult>(
            this ResultOrError<T1> @this,
            ResultOrError<T2> second,
            ResultOrError<T3> third,
            ResultOrError<T4> fourth,
            ResultOrError<T5> fifth,
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
        public static ResultOrError<TResult> SelectMany<TSource, TMiddle, TResult>(
            this ResultOrError<TSource> @this,
            Func<TSource, ResultOrError<TMiddle>> valueSelector,
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
    } // End of ResultOrError - T4: EmitMonadExtensions().

    // Provides extension methods for Func<T> in the Kleisli category.
    public static partial class Kleisli
    {
        public static ResultOrError<IEnumerable<TResult>> InvokeForEach<TSource, TResult>(
            this Func<TSource, ResultOrError<TResult>> @this,
            IEnumerable<TSource> seq)
            => seq.SelectWith(@this);

        public static ResultOrError<TResult> InvokeWith<TSource, TResult>(
            this Func<TSource, ResultOrError<TResult>> @this,
            ResultOrError<TSource> value)
            /* T4: type constraint */
        {
            Require.NotNull(value, nameof(value));
            return value.Bind(@this);
        }

        public static Func<TSource, ResultOrError<TResult>> Compose<TSource, TMiddle, TResult>(
            this Func<TSource, ResultOrError<TMiddle>> first,
            Func<TMiddle, ResultOrError<TResult>> second)
            /* T4: type constraint */
        {
            Require.NotNull(first, nameof(first));
            return arg => first(arg).Bind(second);
        }

        public static Func<TSource, ResultOrError<TResult>> ComposeBack<TSource, TMiddle, TResult>(
            this Func<TMiddle, ResultOrError<TResult>> first,
            Func<TSource, ResultOrError<TMiddle>> second)
            /* T4: type constraint */
        {
            Require.NotNull(second, nameof(second));
            return arg => second(arg).Bind(first);
        }
    } // End of Kleisli - T4: EmitKleisliExtensions().

    // Provides extension methods for IEnumerable<ResultOrError<T>>.
    public static partial class ResultOrError
    {
        public static ResultOrError<IEnumerable<TSource>> Collect<TSource>(
            this IEnumerable<ResultOrError<TSource>> @this)
            => @this.CollectImpl();

    } // End of Sequence - T4: EmitMonadEnumerableExtensions().
}

namespace Narvalo.Fx.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    using Narvalo.Fx.Linq;

    // Provides default implementations for the extension methods for IEnumerable<ResultOrError<T>>.
    // You will certainly want to override them to improve performance.
    internal static partial class EnumerableExtensions
    {
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static ResultOrError<IEnumerable<TSource>> CollectImpl<TSource>(
            this IEnumerable<ResultOrError<TSource>> @this)
        {
            Demand.NotNull(@this);

            var seed = ResultOrError.Of(Enumerable.Empty<TSource>());
            Func<IEnumerable<TSource>, TSource, IEnumerable<TSource>> append = (seq, item) => seq.Append(item);

            return @this.Aggregate(seed, ResultOrError.Lift<IEnumerable<TSource>, TSource, IEnumerable<TSource>>(append));
        }

    } // End of EnumerableExtensions - T4: EmitMonadEnumerableInternalExtensions().
}

namespace Narvalo.Fx.Linq
{
    using System;
    using System.Collections.Generic;

    using Narvalo.Fx;
    using Narvalo.Fx.Internal;

    // Provides extension methods for IEnumerable<T>.
    // We do not use the standard LINQ names to avoid a confusing API.
    // - Select    -> SelectWith
    // - Where     -> WhereBy
    // - Zip       -> ZipWith
    // - Aggregate -> Reduce or Fold
    public static partial class Qperators
    {
        public static ResultOrError<IEnumerable<TResult>> SelectWith<TSource, TResult>(
            this IEnumerable<TSource> @this,
            Func<TSource, ResultOrError<TResult>> selector)
            => @this.SelectWithImpl(selector);

        public static ResultOrError<IEnumerable<TSource>> WhereBy<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, ResultOrError<bool>> predicate)
            => @this.WhereByImpl(predicate);

        public static ResultOrError<Tuple<IEnumerable<TFirst>, IEnumerable<TSecond>>>
            SelectUnzip<TSource, TFirst, TSecond>(
            this IEnumerable<TSource> @this,
            Func<TSource, ResultOrError<Tuple<TFirst, TSecond>>> selector)
            => @this.SelectUnzipImpl(selector);

        public static ResultOrError<IEnumerable<TResult>> ZipWith<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> @this,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, ResultOrError<TResult>> resultSelector)
            => @this.ZipWithImpl(second, resultSelector);

        public static ResultOrError<TAccumulate> Fold<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, ResultOrError<TAccumulate>> accumulator)
            /* T4: type constraint */
            => @this.FoldImpl(seed, accumulator);

        public static ResultOrError<TAccumulate> Fold<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, ResultOrError<TAccumulate>> accumulator,
            Func<ResultOrError<TAccumulate>, bool> predicate)
            /* T4: type constraint */
            => @this.FoldImpl(seed, accumulator, predicate);

        public static ResultOrError<TSource> Reduce<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, ResultOrError<TSource>> accumulator)
            /* T4: type constraint */
            => @this.ReduceImpl(accumulator);

        public static ResultOrError<TSource> Reduce<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, ResultOrError<TSource>> accumulator,
            Func<ResultOrError<TSource>, bool> predicate)
            /* T4: type constraint */
            => @this.ReduceImpl(accumulator, predicate);
    } // End of Iterable - T4: EmitEnumerableExtensions().
}

namespace Narvalo.Fx.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    using Narvalo.Fx.Linq;

    // Provides default implementations for the extension methods for IEnumerable<T>.
    // You will certainly want to override them to improve performance.
    internal static partial class EnumerableExtensions
    {
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static ResultOrError<IEnumerable<TResult>> SelectWithImpl<TSource, TResult>(
            this IEnumerable<TSource> @this,
            Func<TSource, ResultOrError<TResult>> selector)
        {
            Demand.NotNull(@this);
            Demand.NotNull(selector);

            return @this.Select(selector).Collect();
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static ResultOrError<IEnumerable<TSource>> WhereByImpl<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, ResultOrError<bool>> predicate)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(predicate, nameof(predicate));

            Func<TSource, Func<bool, IEnumerable<TSource>, IEnumerable<TSource>>> func
                = item => (flg, seq) => flg ? seq.Append(item) : seq;

            Func<ResultOrError<IEnumerable<TSource>>, TSource, ResultOrError<IEnumerable<TSource>>> accumulator
                = (mseq, item) => predicate(item).Zip(mseq, func(item));

            return @this.Aggregate(ResultOrError.Of(Enumerable.Empty<TSource>()), accumulator);
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static ResultOrError<Tuple<IEnumerable<TFirst>, IEnumerable<TSecond>>>
            SelectUnzipImpl<TSource, TFirst, TSecond>(
            this IEnumerable<TSource> @this,
            Func<TSource, ResultOrError<Tuple<TFirst, TSecond>>> selector)
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

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static ResultOrError<IEnumerable<TResult>> ZipWithImpl<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> @this,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, ResultOrError<TResult>> resultSelector)
        {
            Demand.NotNull(resultSelector);
            Demand.NotNull(@this);
            Demand.NotNull(second);

            return @this.Zip(second, resultSelector).Collect();
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static ResultOrError<TAccumulate> FoldImpl<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, ResultOrError<TAccumulate>> accumulator)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(accumulator, nameof(accumulator));

            ResultOrError<TAccumulate> retval = ResultOrError.Of(seed);

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
        internal static ResultOrError<TAccumulate> FoldImpl<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, ResultOrError<TAccumulate>> accumulator,
            Func<ResultOrError<TAccumulate>, bool> predicate)
            /* T4: type constraint */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(accumulator, nameof(accumulator));
            Require.NotNull(predicate, nameof(predicate));

            ResultOrError<TAccumulate> retval = ResultOrError.Of(seed);

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
        internal static ResultOrError<TSource> ReduceImpl<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, ResultOrError<TSource>> accumulator)
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

                ResultOrError<TSource> retval = ResultOrError.Of(iter.Current);

                while (iter.MoveNext())
                {
                    if (retval == null) { continue; }

                    retval = retval.Bind(val => accumulator(val, iter.Current));
                }

                return retval;
            }
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static ResultOrError<TSource> ReduceImpl<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, ResultOrError<TSource>> accumulator,
            Func<ResultOrError<TSource>, bool> predicate)
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

                ResultOrError<TSource> retval = ResultOrError.Of(iter.Current);

                while (predicate(retval) && iter.MoveNext())
                {
                    if (retval == null) { continue; }

                    retval = retval.Bind(val => accumulator(val, iter.Current));
                }

                return retval;
            }
        }
    } // End of EnumerableExtensions - T4: EmitEnumerableInternalExtensions().
}
