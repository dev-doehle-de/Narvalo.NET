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
    /// Provides a set of static methods and extension methods for <see cref="MonadPlus{T}" />.
    /// </summary>
    public static partial class MonadPlus
    {
        static readonly MonadPlus<Unit> Unit_ = Return(Narvalo.Fx.Unit.Single);
        static readonly MonadPlus<Unit> Zero_ = MonadPlus<Unit>.Zero;

        /// <summary>
        /// Returns the unique object of type <c>MonadPlus&lt;Unit&gt;</c>.
        /// </summary>
        public static MonadPlus<Unit> Unit { get { return Unit_; } }

        /*!
         * Named `mzero` in Haskell parlance.
         */

        /// <summary>
        /// Returns the zero of type <c>MonadPlus&lt;Unit&gt;.Zero</c>.
        /// </summary>
        public static MonadPlus<Unit> Zero { get { return Zero_; } }

        /*!
         * Named `return` in Haskell parlance.
         */

        /// <summary>
        /// Returns a new instance of <see cref="MonadPlus{T}" />.
        /// </summary>
        public static MonadPlus<T> Return<T>(T value)
        {
            return MonadPlus<T>.η(value);
        }
        
        #region Generalisations of list functions (Prelude)

        /*!
         * Named `join` in Haskell parlance.
         */

        /// <summary>
        /// Removes one level of structure, projecting its bound value into the outer level.
        /// </summary>
        public static MonadPlus<T> Flatten<T>(MonadPlus<MonadPlus<T>> square)
        {
            return MonadPlus<T>.μ(square);
        }

        #endregion

        #region Monadic lifting operators (Prelude)

        /*!
         * Named `liftM` in Haskell parlance.
         */

        /// <summary>
        /// Promotes a function to use and return <see cref="MonadPlus{T}" /> values.
        /// </summary>
        public static Func<MonadPlus<T>, MonadPlus<TResult>> Lift<T, TResult>(
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
        /// Promotes a function to use and return <see cref="MonadPlus{T}" /> values, scanning the 
        /// monadic arguments from left to right.
        /// </summary>
        public static Func<MonadPlus<T1>, MonadPlus<T2>, MonadPlus<TResult>>
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
        /// Promotes a function to use and return <see cref="MonadPlus{T}" /> values, scanning the 
        /// monadic arguments from left to right.
        /// </summary>
        public static Func<MonadPlus<T1>, MonadPlus<T2>, MonadPlus<T3>, MonadPlus<TResult>>
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
        /// Promotes a function to use and return <see cref="MonadPlus{T}" /> values, scanning the
        /// monadic arguments from left to right.
        /// </summary>
        public static Func<MonadPlus<T1>, MonadPlus<T2>, MonadPlus<T3>, MonadPlus<T4>, MonadPlus<TResult>>
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
        /// Promotes a function to use and return <see cref="MonadPlus{T}" /> values, scanning the
        /// monadic arguments from left to right.
        /// </summary>
        public static Func<MonadPlus<T1>, MonadPlus<T2>, MonadPlus<T3>, MonadPlus<T4>, MonadPlus<T5>, MonadPlus<TResult>>
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
     * Extensions methods for MonadPlus<T>.
     */
    public static partial class MonadPlus
    {
        #region Basic Monad functions (Prelude)

        /*!
         * Named `fmap` in Haskell parlance.
         */
        public static MonadPlus<TResult> Select<TSource, TResult>(
            this MonadPlus<TSource> @this,
            Func<TSource, TResult> selector)
        {
            Require.Object(@this);
            Require.NotNull(selector, "selector");

            return @this.Bind(_ => MonadPlus.Return(selector.Invoke(_)));
        }

        /*!
         * Named `>>` in Haskell parlance.
         */
        public static MonadPlus<TResult> Then<TSource, TResult>(
            this MonadPlus<TSource> @this,
            MonadPlus<TResult> other)
        {
            Require.Object(@this);

            return @this.Bind(_ => other);
        }
        
        #endregion

        #region Generalisations of list functions (Prelude)

        /*!
         * Named `mfilter` in Haskell parlance.
         */
        public static MonadPlus<TSource> Where<TSource>(
            this MonadPlus<TSource> @this,
            Func<TSource, bool> predicate)
        {
            Require.Object(@this);
            Require.NotNull(predicate, "predicate");

            return @this.Bind(
                _ => predicate.Invoke(_) ? @this : MonadPlus<TSource>.Zero);
        }

        /*!
         * Named `replicateM` in Haskell parlance.
         */
        public static MonadPlus<IEnumerable<TSource>> Repeat<TSource>(
            this MonadPlus<TSource> @this,
            int count)
        {
            Require.Object(@this);
            Require.GreaterThanOrEqualTo(count, 1, "FIXME: Message.");

            return @this.Select(_ => Enumerable.Repeat(_, count));
        }
        
        #endregion

        #region Conditional execution of monadic expressions (Prelude)

        /*!
         * Named `guard` in Haskell parlance.
         */
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "this",
            Justification = "Extension method intended to be used in a fluent way.")]
        public static MonadPlus<Unit> Guard<TSource>(
            this MonadPlus<TSource> @this,
            bool predicate)
        {
            return predicate ? MonadPlus.Unit : MonadPlus.Zero;
        }

        /*!
         * Named `when` in Haskell parlance.
         */
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "this",
            Justification = "Extension method intended to be used in a fluent way.")]
        public static MonadPlus<Unit> When<TSource>(
            this MonadPlus<TSource> @this, 
            bool predicate, 
            Action action)
        {
            Require.NotNull(action, "action");

            if (predicate) {
                action.Invoke();
            }

            return MonadPlus.Unit;
        }

        /*!
         * Named `unless` in Haskell parlance.
         */
        public static MonadPlus<Unit> Unless<TSource>(
            this MonadPlus<TSource> @this,
            bool predicate,
            Action action)
        {
            Require.Object(@this);

            return @this.When(!predicate, action);
        }

        #endregion

        #region Monadic lifting operators (Prelude)

        /// <see cref="Lift{T1, T2, T3}" />
        public static MonadPlus<TResult> Zip<TFirst, TSecond, TResult>(
            this MonadPlus<TFirst> @this,
            MonadPlus<TSecond> second,
            Func<TFirst, TSecond, TResult> resultSelector)
        {
            Require.Object(@this);
            Require.NotNull(second, "second");
            Require.NotNull(resultSelector, "resultSelector");

            return @this.Bind(v1 => second.Select(v2 => resultSelector.Invoke(v1, v2)));
        }

        /// <see cref="Lift{T1, T2, T3, T4}" />
        public static MonadPlus<TResult> Zip<T1, T2, T3, TResult>(
            this MonadPlus<T1> @this,
            MonadPlus<T2> second,
            MonadPlus<T3> third,
            Func<T1, T2, T3, TResult> resultSelector)
        {
            Require.Object(@this);
            Require.NotNull(second, "second");
            Require.NotNull(resultSelector, "resultSelector");

            Func<T1, MonadPlus<TResult>> g
                = t1 => second.Zip(third, (t2, t3) => resultSelector.Invoke(t1, t2, t3));

            return @this.Bind(g);
        }

        /// <see cref="Lift{T1, T2, T3, T4, T5}" />
        public static MonadPlus<TResult> Zip<T1, T2, T3, T4, TResult>(
             this MonadPlus<T1> @this,
             MonadPlus<T2> second,
             MonadPlus<T3> third,
             MonadPlus<T4> fourth,
             Func<T1, T2, T3, T4, TResult> resultSelector)
        {
            Require.Object(@this);
            Require.NotNull(second, "second");
            Require.NotNull(resultSelector, "resultSelector");

            Func<T1, MonadPlus<TResult>> g
                = t1 => second.Zip(
                    third,
                    fourth, 
                    (t2, t3, t4) => resultSelector.Invoke(t1, t2, t3, t4));

            return @this.Bind(g);
        }

        /// <see cref="Lift{T1, T2, T3, T4, T5, T6}" />
        public static MonadPlus<TResult> Zip<T1, T2, T3, T4, T5, TResult>(
            this MonadPlus<T1> @this,
            MonadPlus<T2> second,
            MonadPlus<T3> third,
            MonadPlus<T4> fourth,
            MonadPlus<T5> fifth,
            Func<T1, T2, T3, T4, T5, TResult> resultSelector)
        {
            Require.Object(@this);
            Require.NotNull(second, "second");
            Require.NotNull(resultSelector, "resultSelector");

            Func<T1, MonadPlus<TResult>> g
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
        public static MonadPlus<TResult> SelectMany<TSource, TMiddle, TResult>(
            this MonadPlus<TSource> @this,
            Func<TSource, MonadPlus<TMiddle>> valueSelectorM,
            Func<TSource, TMiddle, TResult> resultSelector)
        {
            Require.Object(@this);
            Require.NotNull(valueSelectorM, "valueSelectorM");
            Require.NotNull(resultSelector, "resultSelector");

            return @this.Bind(
                _ => valueSelectorM.Invoke(_).Select(
                    middle => resultSelector.Invoke(_, middle)));
        }

        public static MonadPlus<TResult> Join<TSource, TInner, TKey, TResult>(
            this MonadPlus<TSource> @this,
            MonadPlus<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, TInner, TResult> resultSelector)
        {
            Require.Object(@this);

            return @this.Join(
                inner,
                outerKeySelector,
                innerKeySelector,
                resultSelector,
                EqualityComparer<TKey>.Default);
        }

        public static MonadPlus<TResult> GroupJoin<TSource, TInner, TKey, TResult>(
            this MonadPlus<TSource> @this,
            MonadPlus<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, MonadPlus<TInner>, TResult> resultSelector)
        {
            Require.Object(@this);

            return @this.GroupJoin(
                inner, 
                outerKeySelector,
                innerKeySelector, 
                resultSelector, 
                EqualityComparer<TKey>.Default);
        }

        #endregion
        
        #region Linq extensions

        public static MonadPlus<TResult> Join<TSource, TInner, TKey, TResult>(
            this MonadPlus<TSource> @this,
            MonadPlus<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, TInner, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
        {
            return JoinCore_(
                @this,
                inner,
                outerKeySelector,
                innerKeySelector,
                resultSelector,
                comparer ?? EqualityComparer<TKey>.Default);
        }

        public static MonadPlus<TResult> GroupJoin<TSource, TInner, TKey, TResult>(
            this MonadPlus<TSource> @this,
            MonadPlus<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, MonadPlus<TInner>, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
        {
            return GroupJoinCore_(
                @this,
                inner,
                outerKeySelector,
                innerKeySelector,
                resultSelector,
                comparer ?? EqualityComparer<TKey>.Default);
        }
        
        static MonadPlus<TResult> JoinCore_<TSource, TInner, TKey, TResult>(
            MonadPlus<TSource> seq,
            MonadPlus<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, TInner, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
        {
            Require.NotNull(seq, "seq");
            Require.NotNull(resultSelector, "resultSelector");
            
            var keyLookupM = GetKeyLookup_(inner, outerKeySelector, innerKeySelector, comparer);

            return from outerValue in seq
                   from innerValue in keyLookupM.Invoke(outerValue).Then(inner)
                   select resultSelector.Invoke(outerValue, innerValue);
        }
        
        static MonadPlus<TResult> GroupJoinCore_<TSource, TInner, TKey, TResult>(
            MonadPlus<TSource> seq,
            MonadPlus<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, MonadPlus<TInner>, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
        {
            Require.NotNull(seq, "seq");
            Require.NotNull(resultSelector, "resultSelector");

            var keyLookupM = GetKeyLookup_(inner, outerKeySelector, innerKeySelector, comparer);

            return from outerValue in seq
                   select resultSelector.Invoke(outerValue, keyLookupM.Invoke(outerValue).Then(inner));
        }

        static Func<TSource, MonadPlus<TKey>> GetKeyLookup_<TSource, TInner, TKey>(
            MonadPlus<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            IEqualityComparer<TKey> comparer)
        {
            DebugCheck.NotNull(comparer);
            Require.NotNull(inner, "inner");
            Require.NotNull(outerKeySelector, "outerKeySelector");

            return source =>
            {
                TKey outerKey = outerKeySelector.Invoke(source);
            
                return inner.Select(innerKeySelector).Where(_ => comparer.Equals(_, outerKey));
            };
        }

        #endregion

        #region Non-standard extensions
        
        public static MonadPlus<TResult> Coalesce<TSource, TResult>(
            this MonadPlus<TSource> @this,
            Func<TSource, bool> predicate,
            MonadPlus<TResult> then,
            MonadPlus<TResult> otherwise)
        {
            Require.Object(@this);
            Require.NotNull(predicate, "predicate");

            return @this.Bind(_ => predicate.Invoke(_) ? then : otherwise);
        }

        public static MonadPlus<TResult> Then<TSource, TResult>(
            this MonadPlus<TSource> @this,
            Func<TSource, bool> predicate,
            MonadPlus<TResult> other)
        {
            Require.Object(@this);

            return @this.Coalesce(predicate, other, MonadPlus<TResult>.Zero);
        }

        public static MonadPlus<TResult> Otherwise<TSource, TResult>(
            this MonadPlus<TSource> @this,
            Func<TSource, bool> predicate,
            MonadPlus<TResult> other)
        {
            Require.Object(@this);

            return @this.Coalesce(predicate, MonadPlus<TResult>.Zero, other);
        }

        public static MonadPlus<TSource> Run<TSource>(
            this MonadPlus<TSource> @this,
            Action<TSource> action)
        {
            Require.Object(@this);
            Require.NotNull(action, "action");

            return @this.Bind(_ => { action.Invoke(_); return @this; });
        }

        public static MonadPlus<TSource> OnZero<TSource>(
            this MonadPlus<TSource> @this,
            Action action)
        {
            Require.Object(@this);
            Require.NotNull(action, "action");

            return @this.Then(MonadPlus.Unit).Run(_ => action.Invoke()).Then(@this);
        }

        #endregion
    }

    /*!
     * Extensions methods for Func<TSource, MonadPlus<TResult>>.
     */
    public static partial class FuncExtensions
    {
        #region Basic Monad functions (Prelude)

        /*!
         * Named `=<<` in Haskell parlance.
         */
        public static MonadPlus<TResult> Invoke<TSource, TResult>(
            this Func<TSource, MonadPlus<TResult>> @this,
            MonadPlus<TSource> value)
        {
            Require.NotNull(value, "value");

            return value.Bind(@this);
        }

        /*!
         * Named `>=>` in Haskell parlance.
         */
        public static Func<TSource, MonadPlus<TResult>> Compose<TSource, TMiddle, TResult>(
            this Func<TSource, MonadPlus<TMiddle>> @this,
            Func<TMiddle, MonadPlus<TResult>> funM)
        {
            Require.Object(@this);

            return _ => @this.Invoke(_).Bind(funM);
        }

        /*!
         * Named `<=<` in Haskell parlance.
         */
        public static Func<TSource, MonadPlus<TResult>> ComposeBack<TSource, TMiddle, TResult>(
            this Func<TMiddle, MonadPlus<TResult>> @this,
            Func<TSource, MonadPlus<TMiddle>> funM)
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
     * Extensions for IEnumerable<MonadPlus<T>>.
     */
    public static partial class EnumerableMonadPlusExtensions
    {
        #region Basic Monad functions (Prelude)

        /*!
         * Named `sequence` in Haskell parlance.
         */
        public static MonadPlus<IEnumerable<TSource>> Collect<TSource>(
            this IEnumerable<MonadPlus<TSource>> @this)
        {
            Require.Object(@this);

            return @this.CollectCore();
        }
        
        #endregion

        #region Generalisations of list functions (Prelude)

        /*!
         * Named `msum` in Haskell parlance.
         */
        public static MonadPlus<TSource> Sum<TSource>(
            this IEnumerable<MonadPlus<TSource>> @this)
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
        public static MonadPlus<IEnumerable<TResult>> Map<TSource, TResult>(
            this IEnumerable<TSource> @this,
            Func<TSource, MonadPlus<TResult>> funM)
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
            Func<TSource, MonadPlus<bool>> predicateM)
        {
            Require.Object(@this);

            return @this.FilterCore(predicateM);
        }

        /// <remarks>
        /// Named <c>mapAndUnzipM</c> in Haskell parlance.
        /// </remarks>
        public static MonadPlus<Tuple<IEnumerable<TFirst>, IEnumerable<TSecond>>>
            MapAndUnzip<TSource, TFirst, TSecond>(
            this IEnumerable<TSource> @this,
            Func<TSource, MonadPlus<Tuple<TFirst, TSecond>>> funM)
        {
            Require.Object(@this);

            return @this.MapAndUnzipCore(funM);
        }

        /// <remarks>
        /// Named <c>zipWithM</c> in Haskell parlance.
        /// </remarks>
        public static MonadPlus<IEnumerable<TResult>> Zip<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> @this,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, MonadPlus<TResult>> resultSelectorM)
        {
            Require.Object(@this);

            return @this.ZipCore(second, resultSelectorM);
        }

        /// <remarks>
        /// Named <c>foldM</c> in Haskell parlance.
        /// </remarks>
        public static MonadPlus<TAccumulate> Fold<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, MonadPlus<TAccumulate>> accumulatorM)
        {
            Require.Object(@this);

            return @this.FoldCore(seed, accumulatorM);
        }

        #endregion
        
        #region Aggregate Operators

        public static MonadPlus<TAccumulate> FoldBack<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, MonadPlus<TAccumulate>> accumulatorM)
        {
             Require.Object(@this);

            return @this.FoldBackCore(seed, accumulatorM);
        }

        public static MonadPlus<TSource> Reduce<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, MonadPlus<TSource>> accumulatorM)
        {
            Require.Object(@this);
            
            return @this.ReduceCore(accumulatorM);
        }

        public static MonadPlus<TSource> ReduceBack<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, MonadPlus<TSource>> accumulatorM)
        {
            Require.Object(@this);

            return @this.ReduceBackCore(accumulatorM);
        }

        #endregion

        #region Catamorphisms

        public static MonadPlus<TAccumulate> Fold<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, MonadPlus<TAccumulate>> accumulatorM,
            Func<MonadPlus<TAccumulate>, bool> predicate)
        {
            Require.Object(@this);

            return @this.FoldCore(seed, accumulatorM, predicate);
        }
        
        public static MonadPlus<TSource> Reduce<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, MonadPlus<TSource>> accumulatorM,
            Func<MonadPlus<TSource>, bool> predicate)
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
     * Internal extensions for IEnumerable<MonadPlus<T>>.
     */
    static partial class EnumerableMonadPlusExtensions
    {
        internal static MonadPlus<IEnumerable<TSource>> CollectCore<TSource>(
            this IEnumerable<MonadPlus<TSource>> @this)
        {
            DebugCheck.NotNull(@this);

            var seed = MonadPlus.Return(Enumerable.Empty<TSource>());
            Func<MonadPlus<IEnumerable<TSource>>, MonadPlus<TSource>, MonadPlus<IEnumerable<TSource>>> fun
                = (m, n) =>
                    m.Bind(list =>
                    {
                        return n.Bind(item => MonadPlus.Return(
                            list.Concat(Enumerable.Repeat(item, 1))));
                    });

            return @this.Aggregate(seed, fun);
        }

        internal static MonadPlus<TSource> SumCore<TSource>(
            this IEnumerable<MonadPlus<TSource>> @this)
        {
            DebugCheck.NotNull(@this);

            return @this.Aggregate(MonadPlus<TSource>.Zero, (m, n) => m.Plus(n));
        }
    }

    // Internal extensions for IEnumerable<T>.
    static partial class EnumerableExtensions
    {
        internal static MonadPlus<IEnumerable<TResult>> MapCore<TSource, TResult>(
            this IEnumerable<TSource> @this,
            Func<TSource, MonadPlus<TResult>> funM)
        {
            DebugCheck.NotNull(@this);

            return @this.Select(funM).Collect();
        }

        internal static IEnumerable<TSource> FilterCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, MonadPlus<bool>> predicateM)
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

        internal static MonadPlus<Tuple<IEnumerable<TFirst>, IEnumerable<TSecond>>>
            MapAndUnzipCore<TSource, TFirst, TSecond>(
            this IEnumerable<TSource> @this,
            Func<TSource, MonadPlus<Tuple<TFirst, TSecond>>> funM)
        {
            DebugCheck.NotNull(@this);

            return from tuple in @this.Select(funM).Collect()
                   let item1 = tuple.Select(_ => _.Item1)
                   let item2 = tuple.Select(_ => _.Item2)
                   select new Tuple<IEnumerable<TFirst>, IEnumerable<TSecond>>(item1, item2);
        }

        internal static MonadPlus<IEnumerable<TResult>> ZipCore<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> @this,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, MonadPlus<TResult>> resultSelectorM)
        {
            DebugCheck.NotNull(@this);
            Require.NotNull(resultSelectorM, "resultSelectorM");

            Func<TFirst, TSecond, MonadPlus<TResult>> resultSelector
                = (v1, v2) => resultSelectorM.Invoke(v1, v2);

            // WARNING: Do not remove resultSelector, otherwise .NET will make a recursive call
            // instead of using the Zip from Linq.
            return @this.Zip(second, resultSelector: resultSelector).Collect();
        }

        internal static MonadPlus<TAccumulate> FoldCore<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, MonadPlus<TAccumulate>> accumulatorM)
        {
            DebugCheck.NotNull(@this);
            Require.NotNull(accumulatorM, "accumulatorM");

            MonadPlus<TAccumulate> result = MonadPlus.Return(seed);

            foreach (TSource item in @this) {
                result = result.Bind(_ => accumulatorM.Invoke(_, item));
            }

            return result;
        }

        internal static MonadPlus<TAccumulate> FoldBackCore<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, MonadPlus<TAccumulate>> accumulatorM)
        {
            DebugCheck.NotNull(@this);

            return @this.Reverse().Fold(seed, accumulatorM);
        }

        internal static MonadPlus<TSource> ReduceCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, MonadPlus<TSource>> accumulatorM)
        {
            DebugCheck.NotNull(@this);
            Require.NotNull(accumulatorM, "accumulatorM");

            using (var iter = @this.GetEnumerator()) {
                if (!iter.MoveNext()) {
                    throw new InvalidOperationException("Source sequence was empty.");
                }

                MonadPlus<TSource> result = MonadPlus.Return(iter.Current);

                while (iter.MoveNext()) {
                    result = result.Bind(_ => accumulatorM.Invoke(_, iter.Current));
                }

                return result;
            }
        }

        internal static MonadPlus<TSource> ReduceBackCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, MonadPlus<TSource>> accumulatorM)
        {
            DebugCheck.NotNull(@this);

            return @this.Reverse().Reduce(accumulatorM);
        }

        internal static MonadPlus<TAccumulate> FoldCore<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, MonadPlus<TAccumulate>> accumulatorM,
            Func<MonadPlus<TAccumulate>, bool> predicate)
        {
            DebugCheck.NotNull(@this);
            Require.NotNull(accumulatorM, "accumulatorM");
            Require.NotNull(predicate, "predicate");

            MonadPlus<TAccumulate> result = MonadPlus.Return(seed);

            using (var iter = @this.GetEnumerator()) {
                while (predicate.Invoke(result) && iter.MoveNext()) {
                    result = result.Bind(_ => accumulatorM.Invoke(_, iter.Current));
                }
            }

            return result;
        }

        internal static MonadPlus<TSource> ReduceCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, MonadPlus<TSource>> accumulatorM,
            Func<MonadPlus<TSource>, bool> predicate)
        {
            DebugCheck.NotNull(@this);
            Require.NotNull(accumulatorM, "accumulatorM");
            Require.NotNull(predicate, "predicate");

            using (var iter = @this.GetEnumerator()) {
                if (!iter.MoveNext()) {
                    throw new InvalidOperationException("Source sequence was empty.");
                }

                MonadPlus<TSource> result = MonadPlus.Return(iter.Current);

                while (predicate.Invoke(result) && iter.MoveNext()) {
                    result = result.Bind(_ => accumulatorM.Invoke(_, iter.Current));
                }

                return result;
            }
        }
    }
}
