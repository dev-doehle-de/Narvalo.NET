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

namespace Narvalo.Edu.Monads.Samples {
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using Narvalo;      // For Require
    using Narvalo.Fx;   // For Unit

    /// <summary>
    /// Provides a set of static methods and extension methods for <see cref="Monad{T}" />.
    /// </summary>
    public static partial class Monad
    {
        static readonly Monad<Unit> Unit_ = Return(Narvalo.Fx.Unit.Single);

        /// <summary>
        /// Returns the unique object of type <c>Monad&lt;Unit&gt;</c>.
        /// </summary>
        public static Monad<Unit> Unit { get { return Unit_; } }


        /*!
         * Named `return` in Haskell parlance.
         */

        /// <summary>
        /// Returns a new instance of <see cref="Monad{T}" />.
        /// </summary>
        public static Monad<T> Return<T>(T value)
        {
            return Monad<T>.η(value);
        }
        
        #region Generalisations of list functions (Prelude)

        /*!
         * Named `join` in Haskell parlance.
         */

        /// <summary>
        /// Removes one level of structure, projecting its bound value into the outer level.
        /// </summary>
        public static Monad<T> Flatten<T>(Monad<Monad<T>> square)
        {
            return Monad<T>.μ(square);
        }

        #endregion

        #region Monadic lifting operators (Prelude)

        /*!
         * Named `liftM` in Haskell parlance.
         */

        /// <summary>
        /// Promotes a function to use and return <see cref="Monad{T}" /> values.
        /// </summary>
        public static Func<Monad<T>, Monad<TResult>> Lift<T, TResult>(
            Func<T, TResult> fun)
        {
            return m =>
            {
                Require.NotNull(m, "m");
                return m.Select(fun);
            };
        }

        /*!
         * Named `liftM2` in Haskell parlance.
         */

        /// <summary>
        /// Promotes a function to use and return <see cref="Monad{T}" /> values, scanning the 
        /// monadic arguments from left to right.
        /// </summary>
        public static Func<Monad<T1>, Monad<T2>, Monad<TResult>>
            Lift<T1, T2, TResult>(Func<T1, T2, TResult> fun)
        {
            return (m1, m2) => 
            {
                Require.NotNull(m1, "m1");
                return m1.Zip(m2, fun);
            };
        }

        /*!
         * Named `liftM3` in Haskell parlance.
         */

        /// <summary>
        /// Promotes a function to use and return <see cref="Monad{T}" /> values, scanning the 
        /// monadic arguments from left to right.
        /// </summary>
        public static Func<Monad<T1>, Monad<T2>, Monad<T3>, Monad<TResult>>
            Lift<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> fun)
        {
            return (m1, m2, m3) =>
            {
                Require.NotNull(m1, "m1");
                return m1.Zip(m2, m3, fun);
            };
        }

        /*!
         * Named `liftM4` in Haskell parlance.
         */

        /// <summary>
        /// Promotes a function to use and return <see cref="Monad{T}" /> values, scanning the
        /// monadic arguments from left to right.
        /// </summary>
        public static Func<Monad<T1>, Monad<T2>, Monad<T3>, Monad<T4>, Monad<TResult>>
            Lift<T1, T2, T3, T4, TResult>(
            Func<T1, T2, T3, T4, TResult> fun)
        {
            return (m1, m2, m3, m4) =>
            {
                Require.NotNull(m1, "m1");
                return m1.Zip(m2, m3, m4, fun);
            };
        }

        /*!
         * Named `liftM5` in Haskell parlance.
         */

        /// <summary>
        /// Promotes a function to use and return <see cref="Monad{T}" /> values, scanning the
        /// monadic arguments from left to right.
        /// </summary>
        public static Func<Monad<T1>, Monad<T2>, Monad<T3>, Monad<T4>, Monad<T5>, Monad<TResult>>
            Lift<T1, T2, T3, T4, T5, TResult>(
            Func<T1, T2, T3, T4, T5, TResult> fun)
        {
            return (m1, m2, m3, m4, m5) =>
            {
                Require.NotNull(m1, "m1");
                return m1.Zip(m2, m3, m4, m5, fun);
            };
        }

        #endregion
    }

    /*!
     * Extensions methods for Monad<T>.
     */
    public static partial class Monad
    {
        #region Basic Monad functions (Prelude)

        /*!
         * Named `fmap` in Haskell parlance.
         */
        public static Monad<TResult> Select<TSource, TResult>(
            this Monad<TSource> @this,
            Func<TSource, TResult> selector)
        {
            Require.Object(@this);
            Require.NotNull(selector, "selector");

            return @this.Bind(_ => Monad.Return(selector.Invoke(_)));
        }

        /*!
         * Named `>>` in Haskell parlance.
         */
        public static Monad<TResult> Then<TSource, TResult>(
            this Monad<TSource> @this,
            Monad<TResult> other)
        {
            Require.Object(@this);

            return @this.Bind(_ => other);
        }
        
        #endregion

        #region Generalisations of list functions (Prelude)


        /*!
         * Named `replicateM` in Haskell parlance.
         */
        public static Monad<IEnumerable<TSource>> Repeat<TSource>(
            this Monad<TSource> @this,
            int count)
        {
            Require.Object(@this);
            Require.GreaterThanOrEqualTo(count, 1, "FIXME: Message.");

            return @this.Select(_ => Enumerable.Repeat(_, count));
        }
        
        #endregion

        #region Conditional execution of monadic expressions (Prelude)


        /*!
         * Named `when` in Haskell parlance.
         */
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "this",
            Justification = "Extension method intended to be used in a fluent way.")]
        public static Monad<Unit> When<TSource>(
            this Monad<TSource> @this, 
            bool predicate, 
            Action action)
        {
            Require.NotNull(action, "action");

            if (predicate) {
                action.Invoke();
            }

            return Monad.Unit;
        }

        /*!
         * Named `unless` in Haskell parlance.
         */
        public static Monad<Unit> Unless<TSource>(
            this Monad<TSource> @this,
            bool predicate,
            Action action)
        {
            Require.Object(@this);

            return @this.When(!predicate, action);
        }

        #endregion

        #region Monadic lifting operators (Prelude)

        /// <see cref="Lift{T1, T2, T3}" />
        public static Monad<TResult> Zip<TFirst, TSecond, TResult>(
            this Monad<TFirst> @this,
            Monad<TSecond> second,
            Func<TFirst, TSecond, TResult> resultSelector)
        {
            Require.Object(@this);
            Require.NotNull(second, "second");
            Require.NotNull(resultSelector, "resultSelector");

            return @this.Bind(v1 => second.Select(v2 => resultSelector.Invoke(v1, v2)));
        }

        /// <see cref="Lift{T1, T2, T3, T4}" />
        public static Monad<TResult> Zip<T1, T2, T3, TResult>(
            this Monad<T1> @this,
            Monad<T2> second,
            Monad<T3> third,
            Func<T1, T2, T3, TResult> resultSelector)
        {
            Require.Object(@this);
            Require.NotNull(second, "second");
            Require.NotNull(resultSelector, "resultSelector");

            Func<T1, Monad<TResult>> g
                = t1 => second.Zip(third, (t2, t3) => resultSelector.Invoke(t1, t2, t3));

            return @this.Bind(g);
        }

        /// <see cref="Lift{T1, T2, T3, T4, T5}" />
        public static Monad<TResult> Zip<T1, T2, T3, T4, TResult>(
             this Monad<T1> @this,
             Monad<T2> second,
             Monad<T3> third,
             Monad<T4> fourth,
             Func<T1, T2, T3, T4, TResult> resultSelector)
        {
            Require.Object(@this);
            Require.NotNull(second, "second");
            Require.NotNull(resultSelector, "resultSelector");

            Func<T1, Monad<TResult>> g
                = t1 => second.Zip(
                    third,
                    fourth, 
                    (t2, t3, t4) => resultSelector.Invoke(t1, t2, t3, t4));

            return @this.Bind(g);
        }

        /// <see cref="Lift{T1, T2, T3, T4, T5, T6}" />
        public static Monad<TResult> Zip<T1, T2, T3, T4, T5, TResult>(
            this Monad<T1> @this,
            Monad<T2> second,
            Monad<T3> third,
            Monad<T4> fourth,
            Monad<T5> fifth,
            Func<T1, T2, T3, T4, T5, TResult> resultSelector)
        {
            Require.Object(@this);
            Require.NotNull(second, "second");
            Require.NotNull(resultSelector, "resultSelector");

            Func<T1, Monad<TResult>> g
                = t1 => second.Zip(
                    third,
                    fourth, 
                    fifth,
                    (t2, t3, t4, t5) => resultSelector.Invoke(t1, t2, t3, t4, t5));

            return @this.Bind(g);
        }

        #endregion

        #region Query Expression Pattern


        /*!
         * Kind of generalisation of Zip (liftM2).
         */
        public static Monad<TResult> SelectMany<TSource, TMiddle, TResult>(
            this Monad<TSource> @this,
            Func<TSource, Monad<TMiddle>> valueSelectorM,
            Func<TSource, TMiddle, TResult> resultSelector)
        {
            Require.Object(@this);
            Require.NotNull(valueSelectorM, "valueSelectorM");
            Require.NotNull(resultSelector, "resultSelector");

            return @this.Bind(
                _ => valueSelectorM.Invoke(_).Select(
                    middle => resultSelector.Invoke(_, middle)));
        }


        #endregion
        
        #region Linq extensions


        #endregion

        #region Non-standard extensions
        
        public static Monad<TResult> Coalesce<TSource, TResult>(
            this Monad<TSource> @this,
            Func<TSource, bool> predicate,
            Monad<TResult> then,
            Monad<TResult> otherwise)
        {
            Require.Object(@this);
            Require.NotNull(predicate, "predicate");

            return @this.Bind(_ => predicate.Invoke(_) ? then : otherwise);
        }


        public static Monad<TSource> Run<TSource>(
            this Monad<TSource> @this,
            Action<TSource> action)
        {
            Require.Object(@this);
            Require.NotNull(action, "action");

            return @this.Bind(_ => { action.Invoke(_); return @this; });
        }


        #endregion
    }

    /*!
     * Extensions methods for Func<TSource, Monad<TResult>>.
     */
    public static partial class FuncExtensions
    {
        #region Basic Monad functions (Prelude)

        /*!
         * Named `=<<` in Haskell parlance.
         */
        public static Monad<TResult> Invoke<TSource, TResult>(
            this Func<TSource, Monad<TResult>> @this,
            Monad<TSource> value)
        {
            Require.NotNull(value, "value");

            return value.Bind(@this);
        }

        /*!
         * Named `>=>` in Haskell parlance.
         */
        public static Func<TSource, Monad<TResult>> Compose<TSource, TMiddle, TResult>(
            this Func<TSource, Monad<TMiddle>> @this,
            Func<TMiddle, Monad<TResult>> funM)
        {
            Require.Object(@this);

            return _ => @this.Invoke(_).Bind(funM);
        }

        /*!
         * Named `<=<` in Haskell parlance.
         */
        public static Func<TSource, Monad<TResult>> ComposeBack<TSource, TMiddle, TResult>(
            this Func<TMiddle, Monad<TResult>> @this,
            Func<TSource, Monad<TMiddle>> funM)
        {
            Require.NotNull(funM, "funM");

            return _ => funM.Invoke(_).Bind(@this);
        }

        #endregion
    }
}

namespace Narvalo.Edu.Monads.Samples {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Narvalo;      // For Require
    using Narvalo.Fx;   // For Unit
    using Narvalo.Edu.Monads.Samples;
    using Narvalo.Edu.Monads.Samples.Internal;

    /*!
     * Extensions for IEnumerable<Monad<T>>.
     */
    public static partial class EnumerableMonadExtensions
    {
        #region Basic Monad functions (Prelude)

        /*!
         * Named `sequence` in Haskell parlance.
         */
        public static Monad<IEnumerable<TSource>> Collect<TSource>(
            this IEnumerable<Monad<TSource>> @this)
        {
            Require.Object(@this);

            return @this.CollectCore();
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
        public static Monad<IEnumerable<TResult>> Map<TSource, TResult>(
            this IEnumerable<TSource> @this,
            Func<TSource, Monad<TResult>> funM)
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
            Func<TSource, Monad<bool>> predicateM)
        {
            Require.Object(@this);

            return @this.FilterCore(predicateM);
        }

        /// <remarks>
        /// Named <c>mapAndUnzipM</c> in Haskell parlance.
        /// </remarks>
        public static Monad<Tuple<IEnumerable<TFirst>, IEnumerable<TSecond>>>
            MapAndUnzip<TSource, TFirst, TSecond>(
            this IEnumerable<TSource> @this,
            Func<TSource, Monad<Tuple<TFirst, TSecond>>> funM)
        {
            Require.Object(@this);

            return @this.MapAndUnzipCore(funM);
        }

        /// <remarks>
        /// Named <c>zipWithM</c> in Haskell parlance.
        /// </remarks>
        public static Monad<IEnumerable<TResult>> Zip<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> @this,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, Monad<TResult>> resultSelectorM)
        {
            Require.Object(@this);

            return @this.ZipCore(second, resultSelectorM);
        }

        /// <remarks>
        /// Named <c>foldM</c> in Haskell parlance.
        /// </remarks>
        public static Monad<TAccumulate> Fold<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Monad<TAccumulate>> accumulatorM)
        {
            Require.Object(@this);

            return @this.FoldCore(seed, accumulatorM);
        }

        #endregion
        
        #region Aggregate Operators

        public static Monad<TAccumulate> FoldBack<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Monad<TAccumulate>> accumulatorM)
        {
             Require.Object(@this);

            return @this.FoldBackCore(seed, accumulatorM);
        }

        public static Monad<TSource> Reduce<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Monad<TSource>> accumulatorM)
        {
            Require.Object(@this);
            
            return @this.ReduceCore(accumulatorM);
        }

        public static Monad<TSource> ReduceBack<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Monad<TSource>> accumulatorM)
        {
            Require.Object(@this);

            return @this.ReduceBackCore(accumulatorM);
        }

        #endregion

        #region Catamorphisms

        public static Monad<TAccumulate> Fold<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Monad<TAccumulate>> accumulatorM,
            Func<Monad<TAccumulate>, bool> predicate)
        {
            Require.Object(@this);

            return @this.FoldCore(seed, accumulatorM, predicate);
        }
        
        public static Monad<TSource> Reduce<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Monad<TSource>> accumulatorM,
            Func<Monad<TSource>, bool> predicate)
        {
            Require.Object(@this);

            return @this.ReduceCore(accumulatorM, predicate);
        }

        #endregion
    }
}

namespace Narvalo.Edu.Monads.Samples.Internal {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Narvalo;      // For Require
    using Narvalo.Fx;   // For Unit
    using Narvalo.Edu.Monads.Samples;

    /*!
     * Internal extensions for IEnumerable<Monad<T>>.
     */
    static partial class EnumerableMonadExtensions
    {
        internal static Monad<IEnumerable<TSource>> CollectCore<TSource>(
            this IEnumerable<Monad<TSource>> @this)
        {
            DebugCheck.NotNull(@this);

            var seed = Monad.Return(Enumerable.Empty<TSource>());
            Func<Monad<IEnumerable<TSource>>, Monad<TSource>, Monad<IEnumerable<TSource>>> fun
                = (m, n) =>
                    m.Bind(list =>
                    {
                        return n.Bind(item => Monad.Return(
                            list.Concat(Enumerable.Repeat(item, 1))));
                    });

            return @this.Aggregate(seed, fun);
        }
    }

    // Internal extensions for IEnumerable<T>.
    static partial class EnumerableExtensions
    {
        internal static Monad<IEnumerable<TResult>> MapCore<TSource, TResult>(
            this IEnumerable<TSource> @this,
            Func<TSource, Monad<TResult>> funM)
        {
            DebugCheck.NotNull(@this);

            return @this.Select(funM).Collect();
        }

        internal static IEnumerable<TSource> FilterCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, Monad<bool>> predicateM)
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

        internal static Monad<Tuple<IEnumerable<TFirst>, IEnumerable<TSecond>>>
            MapAndUnzipCore<TSource, TFirst, TSecond>(
            this IEnumerable<TSource> @this,
            Func<TSource, Monad<Tuple<TFirst, TSecond>>> funM)
        {
            DebugCheck.NotNull(@this);

            return from tuple in @this.Select(funM).Collect()
                   let item1 = tuple.Select(_ => _.Item1)
                   let item2 = tuple.Select(_ => _.Item2)
                   select new Tuple<IEnumerable<TFirst>, IEnumerable<TSecond>>(item1, item2);
        }

        internal static Monad<IEnumerable<TResult>> ZipCore<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> @this,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, Monad<TResult>> resultSelectorM)
        {
            DebugCheck.NotNull(@this);
            Require.NotNull(resultSelectorM, "resultSelectorM");

            Func<TFirst, TSecond, Monad<TResult>> resultSelector
                = (v1, v2) => resultSelectorM.Invoke(v1, v2);

            // WARNING: Do not remove resultSelector, otherwise .NET will make a recursive call
            // instead of using the Zip from Linq.
            return @this.Zip(second, resultSelector: resultSelector).Collect();
        }

        internal static Monad<TAccumulate> FoldCore<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Monad<TAccumulate>> accumulatorM)
        {
            DebugCheck.NotNull(@this);
            Require.NotNull(accumulatorM, "accumulatorM");

            Monad<TAccumulate> result = Monad.Return(seed);

            foreach (TSource item in @this) {
                result = result.Bind(_ => accumulatorM.Invoke(_, item));
            }

            return result;
        }

        internal static Monad<TAccumulate> FoldBackCore<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Monad<TAccumulate>> accumulatorM)
        {
            DebugCheck.NotNull(@this);

            return @this.Reverse().Fold(seed, accumulatorM);
        }

        internal static Monad<TSource> ReduceCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Monad<TSource>> accumulatorM)
        {
            DebugCheck.NotNull(@this);
            Require.NotNull(accumulatorM, "accumulatorM");

            using (var iter = @this.GetEnumerator()) {
                if (!iter.MoveNext()) {
                    throw new InvalidOperationException("Source sequence was empty.");
                }

                Monad<TSource> result = Monad.Return(iter.Current);

                while (iter.MoveNext()) {
                    result = result.Bind(_ => accumulatorM.Invoke(_, iter.Current));
                }

                return result;
            }
        }

        internal static Monad<TSource> ReduceBackCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Monad<TSource>> accumulatorM)
        {
            DebugCheck.NotNull(@this);

            return @this.Reverse().Reduce(accumulatorM);
        }

        internal static Monad<TAccumulate> FoldCore<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Monad<TAccumulate>> accumulatorM,
            Func<Monad<TAccumulate>, bool> predicate)
        {
            DebugCheck.NotNull(@this);
            Require.NotNull(accumulatorM, "accumulatorM");
            Require.NotNull(predicate, "predicate");

            Monad<TAccumulate> result = Monad.Return(seed);

            using (var iter = @this.GetEnumerator()) {
                while (predicate.Invoke(result) && iter.MoveNext()) {
                    result = result.Bind(_ => accumulatorM.Invoke(_, iter.Current));
                }
            }

            return result;
        }

        internal static Monad<TSource> ReduceCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Monad<TSource>> accumulatorM,
            Func<Monad<TSource>, bool> predicate)
        {
            DebugCheck.NotNull(@this);
            Require.NotNull(accumulatorM, "accumulatorM");
            Require.NotNull(predicate, "predicate");

            using (var iter = @this.GetEnumerator()) {
                if (!iter.MoveNext()) {
                    throw new InvalidOperationException("Source sequence was empty.");
                }

                Monad<TSource> result = Monad.Return(iter.Current);

                while (predicate.Invoke(result) && iter.MoveNext()) {
                    result = result.Bind(_ => accumulatorM.Invoke(_, iter.Current));
                }

                return result;
            }
        }
    }
}
