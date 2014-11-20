﻿// Copyright (c) 2014, Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by a tool. Changes to this file may cause incorrect
// behavior and will be lost if the code is regenerated.
//
// Runtime Version: 4.0.30319.34209
// </auto-generated>
//------------------------------------------------------------------------------

using global::System.Diagnostics.CodeAnalysis;

[module: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass",
    Justification = "This is disabled for files generated by a Text Template.")]
[module: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1403:FileMayOnlyContainASingleNamespace",
    Justification = "This is disabled for files generated by a Text Template.")]
    
[module: SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:ElementsMustBeOrderedByAccess",
    Justification = "For files generated by Text Template, we favour T4 readibility over StyleCop rules.")]
[module: SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1505:OpeningCurlyBracketsMustNotBeFollowedByBlankLine",
    Justification = "For files generated by Text Template, we favour T4 readibility over StyleCop rules.")]
[module: SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1507:CodeMustNotContainMultipleBlankLinesInARow",
    Justification = "For files generated by Text Template, we favour T4 readibility over StyleCop rules.")]

[module: SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1210:UsingDirectivesMustBeOrderedAlphabeticallyByNamespace",
    Justification = "Actual namespaces are not known in advance.")]

namespace Narvalo.Collections {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Narvalo;      // For Require
    using Narvalo.Fx;   // For Unit
    using Narvalo.Collections.Internal;

    /*!
     * Extensions for IEnumerable<Maybe<T>>.
     */
    public static partial class EnumerableMaybeExtensions
    {
        #region Basic Monad functions (Prelude)

        /*!
         * Named `sequence` in Haskell parlance.
         */
        public static Maybe<IEnumerable<TSource>> Collect<TSource>(
            this IEnumerable<Maybe<TSource>> @this)
        {
            Require.Object(@this);

            return @this.CollectCore();
        }
        
        #endregion

        #region Generalisations of list functions (Prelude)

        /*!
         * Named `msum` in Haskell parlance.
         */
        public static Maybe<TSource> Sum<TSource>(
            this IEnumerable<Maybe<TSource>> @this)
        {
            Require.Object(@this);

            return @this.SumCore();
        }

        #endregion
    }

    // Extensions for IEnumerable<T>.
    public static partial class EnumerableExtensions
    {
        #region Basic Monad functions (Prelude)

        /// <remarks>
        /// Named <c>mapM</c> in Haskell parlance.
        /// </remarks>
        public static Maybe<IEnumerable<TResult>> Map<TSource, TResult>(
            this IEnumerable<TSource> @this,
            Func<TSource, Maybe<TResult>> funM)
        {
            Require.Object(@this);

            return @this.MapCore(funM);
        }
        
        #endregion

        #region Generalisations of list functions (Prelude)

        /// <remarks>
        /// Named <c>filterM</c> in Haskell parlance.
        /// </remarks>
        public static IEnumerable<TSource> Filter<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, Maybe<bool>> predicateM)
        {
            Require.Object(@this);

            return @this.FilterCore(predicateM);
        }

        /// <remarks>
        /// Named <c>mapAndUnzipM</c> in Haskell parlance.
        /// </remarks>
        public static Maybe<Tuple<IEnumerable<TFirst>, IEnumerable<TSecond>>>
            MapAndUnzip<TSource, TFirst, TSecond>(
            this IEnumerable<TSource> @this,
            Func<TSource, Maybe<Tuple<TFirst, TSecond>>> funM)
        {
            Require.Object(@this);

            return @this.MapAndUnzipCore(funM);
        }

        /// <remarks>
        /// Named <c>zipWithM</c> in Haskell parlance.
        /// </remarks>
        public static Maybe<IEnumerable<TResult>> Zip<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> @this,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, Maybe<TResult>> resultSelectorM)
        {
            Require.Object(@this);

            return @this.ZipCore(second, resultSelectorM);
        }

        /// <remarks>
        /// Named <c>foldM</c> in Haskell parlance.
        /// </remarks>
        public static Maybe<TAccumulate> Fold<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Maybe<TAccumulate>> accumulatorM)
        {
            Require.Object(@this);

            return @this.FoldCore(seed, accumulatorM);
        }

        #endregion
        
        #region Aggregate Operators

        public static Maybe<TAccumulate> FoldBack<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Maybe<TAccumulate>> accumulatorM)
        {
             Require.Object(@this);

            return @this.FoldBackCore(seed, accumulatorM);
        }

        public static Maybe<TSource> Reduce<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Maybe<TSource>> accumulatorM)
        {
            Require.Object(@this);
            
            return @this.ReduceCore(accumulatorM);
        }

        public static Maybe<TSource> ReduceBack<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Maybe<TSource>> accumulatorM)
        {
            Require.Object(@this);

            return @this.ReduceBackCore(accumulatorM);
        }

        #endregion

        #region Catamorphisms

        public static Maybe<TAccumulate> Fold<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Maybe<TAccumulate>> accumulatorM,
            Func<Maybe<TAccumulate>, bool> predicate)
        {
            Require.Object(@this);

            return @this.FoldCore(seed, accumulatorM, predicate);
        }
        
        public static Maybe<TSource> Reduce<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Maybe<TSource>> accumulatorM,
            Func<Maybe<TSource>, bool> predicate)
        {
            Require.Object(@this);

            return @this.ReduceCore(accumulatorM, predicate);
        }

        #endregion
    }
}

namespace Narvalo.Collections.Internal {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Narvalo;      // For Require
    using Narvalo.Fx;   // For Unit

    /*!
     * Internal extensions for IEnumerable<Maybe<T>>.
     */
    static partial class EnumerableMaybeExtensions
    {
        internal static Maybe<IEnumerable<TSource>> CollectCore<TSource>(
            this IEnumerable<Maybe<TSource>> @this)
        {
            DebugCheck.NotNull(@this);

            var seed = Maybe.Create(Enumerable.Empty<TSource>());
            Func<Maybe<IEnumerable<TSource>>, Maybe<TSource>, Maybe<IEnumerable<TSource>>> fun
                = (m, n) =>
                    m.Bind(list =>
                    {
                        return n.Bind(item => Maybe.Create(
                            list.Concat(Enumerable.Repeat(item, 1))));
                    });

            return @this.Aggregate(seed, fun);
        }

        internal static Maybe<TSource> SumCore<TSource>(
            this IEnumerable<Maybe<TSource>> @this)
        {
            DebugCheck.NotNull(@this);

            return @this.Aggregate(Maybe<TSource>.None, (m, n) => m.OrElse(n));
        }
    }

    // Internal extensions for IEnumerable<T>.
    static partial class EnumerableExtensions
    {
        internal static Maybe<IEnumerable<TResult>> MapCore<TSource, TResult>(
            this IEnumerable<TSource> @this,
            Func<TSource, Maybe<TResult>> funM)
        {
            DebugCheck.NotNull(@this);

            return @this.Select(funM).Collect();
        }

        internal static IEnumerable<TSource> FilterCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, Maybe<bool>> predicateM)
        {
            DebugCheck.NotNull(@this);
            Require.NotNull(predicateM, "predicateM");

            // NB: Haskell uses tail recursion, we don't.
            var list = new List<TSource>();

            foreach (var item in @this) {
                predicateM.Invoke(item)
                    .Run(_ =>
                    {
                        if (_ == true) {
                            list.Add(item);
                        }
                    });
            }

            return list;
        }

        internal static Maybe<Tuple<IEnumerable<TFirst>, IEnumerable<TSecond>>>
            MapAndUnzipCore<TSource, TFirst, TSecond>(
            this IEnumerable<TSource> @this,
            Func<TSource, Maybe<Tuple<TFirst, TSecond>>> funM)
        {
            DebugCheck.NotNull(@this);

            return from tuple in @this.Select(funM).Collect()
                   let item1 = tuple.Select(_ => _.Item1)
                   let item2 = tuple.Select(_ => _.Item2)
                   select new Tuple<IEnumerable<TFirst>, IEnumerable<TSecond>>(item1, item2);
        }

        internal static Maybe<IEnumerable<TResult>> ZipCore<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> @this,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, Maybe<TResult>> resultSelectorM)
        {
            DebugCheck.NotNull(@this);
            Require.NotNull(resultSelectorM, "resultSelectorM");

            Func<TFirst, TSecond, Maybe<TResult>> resultSelector
                = (v1, v2) => resultSelectorM.Invoke(v1, v2);

            // WARNING: Do not remove resultSelector, otherwise .NET will make a recursive call
            // instead of using the Zip from Linq.
            return @this.Zip(second, resultSelector: resultSelector).Collect();
        }

        internal static Maybe<TAccumulate> FoldCore<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Maybe<TAccumulate>> accumulatorM)
        {
            DebugCheck.NotNull(@this);
            Require.NotNull(accumulatorM, "accumulatorM");

            Maybe<TAccumulate> result = Maybe.Create(seed);

            foreach (TSource item in @this) {
                result = result.Bind(_ => accumulatorM.Invoke(_, item));
            }

            return result;
        }

        internal static Maybe<TAccumulate> FoldBackCore<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Maybe<TAccumulate>> accumulatorM)
        {
            DebugCheck.NotNull(@this);

            return @this.Reverse().Fold(seed, accumulatorM);
        }

        internal static Maybe<TSource> ReduceCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Maybe<TSource>> accumulatorM)
        {
            DebugCheck.NotNull(@this);
            Require.NotNull(accumulatorM, "accumulatorM");

            using (var iter = @this.GetEnumerator()) {
                if (!iter.MoveNext()) {
                    throw new InvalidOperationException("Source sequence was empty.");
                }

                Maybe<TSource> result = Maybe.Create(iter.Current);

                while (iter.MoveNext()) {
                    result = result.Bind(_ => accumulatorM.Invoke(_, iter.Current));
                }

                return result;
            }
        }

        internal static Maybe<TSource> ReduceBackCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Maybe<TSource>> accumulatorM)
        {
            DebugCheck.NotNull(@this);

            return @this.Reverse().Reduce(accumulatorM);
        }

        internal static Maybe<TAccumulate> FoldCore<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Maybe<TAccumulate>> accumulatorM,
            Func<Maybe<TAccumulate>, bool> predicate)
        {
            DebugCheck.NotNull(@this);
            Require.NotNull(accumulatorM, "accumulatorM");
            Require.NotNull(predicate, "predicate");

            Maybe<TAccumulate> result = Maybe.Create(seed);

            using (var iter = @this.GetEnumerator()) {
                while (predicate.Invoke(result) && iter.MoveNext()) {
                    result = result.Bind(_ => accumulatorM.Invoke(_, iter.Current));
                }
            }

            return result;
        }

        internal static Maybe<TSource> ReduceCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Maybe<TSource>> accumulatorM,
            Func<Maybe<TSource>, bool> predicate)
        {
            DebugCheck.NotNull(@this);
            Require.NotNull(accumulatorM, "accumulatorM");
            Require.NotNull(predicate, "predicate");

            using (var iter = @this.GetEnumerator()) {
                if (!iter.MoveNext()) {
                    throw new InvalidOperationException("Source sequence was empty.");
                }

                Maybe<TSource> result = Maybe.Create(iter.Current);

                while (predicate.Invoke(result) && iter.MoveNext()) {
                    result = result.Bind(_ => accumulatorM.Invoke(_, iter.Current));
                }

                return result;
            }
        }
    }
}
