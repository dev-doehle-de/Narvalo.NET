﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by a tool. Changes to this file may cause incorrect
// behavior and will be lost if the code is regenerated.
//
// Runtime Version: 4.0.30319.34209
// </auto-generated>
//------------------------------------------------------------------------------

using global::System.Diagnostics.CodeAnalysis;

// See http://msdn.microsoft.com/en-us/library/ms244717.aspx for an explanation 
// of the effect of the SuppressMessage attribute at module scope.
// This suppresses the corresponding warnings for the code inside the generated file.
// We either favour T4 readibility over StyleCop rules or disable rules that do not make sense 
// for files generated by a Text Template.
[module: SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:ElementsMustBeOrderedByAccess",
    Justification = "[GeneratedCode] Elements are correctly ordered in the T4 source file.")]
[module: SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1210:UsingDirectivesMustBeOrderedAlphabeticallyByNamespace",
    Justification = "[GeneratedCode] Directives are correctly ordered in the T4 source file.")]
[module: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass",
    Justification = "[GeneratedCode] A T4 template may contain multiple classes.")]
[module: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1403:FileMayOnlyContainASingleNamespace",
    Justification = "[GeneratedCode] A T4 template may contain multiple namespaces.")]
[module: SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1505:OpeningCurlyBracketsMustNotBeFollowedByBlankLine",
    Justification = "[GeneratedCode] Newline rules are disabled for T4 templates.")]
[module: SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1507:CodeMustNotContainMultipleBlankLinesInARow",
    Justification = "[GeneratedCode] Newline rules are disabled for T4 templates.")]

namespace Narvalo.Fx
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;

    using global::Narvalo;

    /// <content>
    /// Provides a set of static methods for <see cref="Output{T}" />.
    /// </content>
    /// <remarks>
    /// Sometimes we prefer to use extension methods over static methods to be able to locally override them.
    /// </remarks>
    public static partial class Output
    {
        private static readonly Output<global::Narvalo.Fx.Unit> s_Unit = Success(global::Narvalo.Fx.Unit.Single);

        /// <summary>
        /// Gets the unique object of type <c>Output&lt;Unit&gt;</c>.
        /// </summary>
        /// <value>The unique object of type <c>Output&lt;Unit&gt;</c>.</value>
        public static Output<global::Narvalo.Fx.Unit> Unit { get { return s_Unit; } }


        /// <summary>
        /// Obtains an instance of the <see cref="Output{T}"/> class for the specified value.
        /// </summary>
        /// <remarks>
        /// Named <c>return</c> in Haskell parlance.
        /// </remarks>
        /// <typeparam name="T">The underlying type of <paramref name="value"/>.</typeparam>
        /// <param name="value">A value to be wrapped into a <see cref="Output{T}"/> object.</param>
        /// <returns>An instance of the <see cref="Output{T}"/> class for the specified value.</returns>
        public static Output<T> Success<T>(T value)
        {
            Contract.Ensures(Contract.Result<Output<T>>() != null);

            return Output<T>.η(value);
        }
        
        #region Generalisations of list functions (Prelude)

        /// <summary>
        /// Removes one level of structure, projecting its bound value into the outer level.
        /// </summary>
        /// <remarks>
        /// Named <c>join</c> in Haskell parlance.
        /// </remarks>
        public static Output<T> Flatten<T>(Output<Output<T>> square)
        {
            Contract.Requires(square != null);
            Contract.Ensures(Contract.Result<Output<T>>() != null);

            return Output<T>.μ(square);
        }

        #endregion

        #region Monadic lifting operators (Prelude)

        /// <summary>
        /// Promotes a function to use and return <see cref="Output{T}" /> values.
        /// </summary>
        /// <remarks>
        /// Named <c>liftM</c> in Haskell parlance.
        /// </remarks>
        public static Func<Output<T>, Output<TResult>> Lift<T, TResult>(
            Func<T, TResult> fun)
        {
            Contract.Ensures(Contract.Result<Func<Output<T>, Output<TResult>>>() != null);

            return m =>
            {
                Require.NotNull(m, "m");
                return m.Select(fun);
            };
        }

        /// <summary>
        /// Promotes a function to use and return <see cref="Output{T}" /> values, scanning the 
        /// monadic arguments from left to right.
        /// </summary>
        /// <remarks>
        /// Named <c>liftM2</c> in Haskell parlance.
        /// </remarks>
        public static Func<Output<T1>, Output<T2>, Output<TResult>>
            Lift<T1, T2, TResult>(Func<T1, T2, TResult> fun)
        {
            Contract.Ensures(Contract.Result<Func<Output<T1>, Output<T2>, Output<TResult>>>() != null);

            return (m1, m2) =>
            {
                Require.NotNull(m1, "m1");
                return m1.Zip(m2, fun);
            };
        }

        /// <summary>
        /// Promotes a function to use and return <see cref="Output{T}" /> values, scanning the 
        /// monadic arguments from left to right.
        /// </summary>
        /// <remarks>
        /// Named <c>liftM3</c> in Haskell parlance.
        /// </remarks>
        public static Func<Output<T1>, Output<T2>, Output<T3>, Output<TResult>>
            Lift<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> fun)
        {
            Contract.Ensures(Contract.Result<Func<Output<T1>, Output<T2>, Output<T3>, Output<TResult>>>() != null);

            return (m1, m2, m3) =>
            {
                Require.NotNull(m1, "m1");
                return m1.Zip(m2, m3, fun);
            };
        }

        /// <summary>
        /// Promotes a function to use and return <see cref="Output{T}" /> values, scanning the
        /// monadic arguments from left to right.
        /// </summary>
        /// <remarks>
        /// Named <c>liftM4</c> in Haskell parlance.
        /// </remarks>
        public static Func<Output<T1>, Output<T2>, Output<T3>, Output<T4>, Output<TResult>>
            Lift<T1, T2, T3, T4, TResult>(
            Func<T1, T2, T3, T4, TResult> fun)
        {
            Contract.Ensures(Contract.Result<Func<Output<T1>, Output<T2>, Output<T3>, Output<T4>, Output<TResult>>>() != null);
            
            return (m1, m2, m3, m4) =>
            {
                Require.NotNull(m1, "m1");
                return m1.Zip(m2, m3, m4, fun);
            };
        }

        /// <summary>
        /// Promotes a function to use and return <see cref="Output{T}" /> values, scanning the
        /// monadic arguments from left to right.
        /// </summary>
        /// <remarks>
        /// Named <c>liftM5</c> in Haskell parlance.
        /// </remarks>
        public static Func<Output<T1>, Output<T2>, Output<T3>, Output<T4>, Output<T5>, Output<TResult>>
            Lift<T1, T2, T3, T4, T5, TResult>(
            Func<T1, T2, T3, T4, T5, TResult> fun)
        {
            Contract.Ensures(Contract.Result<Func<Output<T1>, Output<T2>, Output<T3>, Output<T4>, Output<T5>, Output<TResult>>>() != null);
       
            return (m1, m2, m3, m4, m5) =>
            {
                Require.NotNull(m1, "m1");
                return m1.Zip(m2, m3, m4, m5, fun);
            };
        }

        #endregion
    } // End of the class Output.

    /// <content>
    /// Provides the core monadic extension methods for <see cref="Output{T}" />.
    /// </content>
    public static partial class Output
    {
        #region Basic Monad functions (Prelude)

        /// <remarks>
        /// Named <c>fmap</c> in Haskell parlance.
        /// </remarks>
        public static Output<TResult> Select<TSource, TResult>(
            this Output<TSource> @this,
            Func<TSource, TResult> selector)
        {
            Require.Object(@this);
            Require.NotNull(selector, "selector");

            return @this.Bind(_ => Output.Success(selector.Invoke(_)));
        }

        /// <remarks>
        /// Named <c>&gt;&gt;</c> in Haskell parlance.
        /// </remarks>
        public static Output<TResult> Then<TSource, TResult>(
            this Output<TSource> @this,
            Output<TResult> other)
        {
            Require.Object(@this);

            return @this.Bind(_ => other);
        }
        
        #endregion

        #region Generalisations of list functions (Prelude)


        /// <remarks>
        /// Named <c>replicateM</c> in Haskell parlance.
        /// </remarks>
        public static Output<IEnumerable<TSource>> Repeat<TSource>(
            this Output<TSource> @this,
            int count)
        {
            Require.Object(@this);
            Require.GreaterThanOrEqualTo(count, 1, "count");

            return @this.Select(_ => Enumerable.Repeat(_, count));
        }
        
        #endregion

        #region Conditional execution of monadic expressions (Prelude)


        /// <remarks>
        /// <para>Named <c>when</c> in Haskell parlance.</para>
        /// <para>Haskell use a different signature. The method should return a <see cref="Narvalo.Fx.Unit"/>.</para>
        /// </remarks>
        public static Output<TSource> When<TSource>(
            this Output<TSource> @this,
            bool predicate,
            Action action)
        {
            Acknowledge.Object(@this);
            Require.NotNull(action, "action");
            Contract.Ensures(Contract.Result<Output<TSource>>() != null);

            if (predicate)
            {
                action.Invoke();
            }

            return @this;
        }

        /// <remarks>
        /// <para>Named <c>unless</c> in Haskell parlance.</para>
        /// <para>Haskell use a different signature. The method should return a <see cref="Narvalo.Fx.Unit"/>.</para>
        /// </remarks>
        public static Output<TSource> Unless<TSource>(
            this Output<TSource> @this,
            bool predicate,
            Action action)
        {
            Acknowledge.Object(@this);
            Require.NotNull(action, "action");
            Contract.Ensures(Contract.Result<Output<TSource>>() != null);

            if (!predicate)
            {
                action.Invoke();
            }

            return @this;
        }

        #endregion

        #region Monadic lifting operators (Prelude)

        /// <see cref="Lift{T1, T2, T3}" />
        public static Output<TResult> Zip<TFirst, TSecond, TResult>(
            this Output<TFirst> @this,
            Output<TSecond> second,
            Func<TFirst, TSecond, TResult> resultSelector)
        {
            Require.Object(@this);
            Require.NotNull(second, "second");
            Require.NotNull(resultSelector, "resultSelector");

            return @this.Bind(v1 => second.Select(v2 => resultSelector.Invoke(v1, v2)));
        }

        /// <see cref="Lift{T1, T2, T3, T4}" />
        public static Output<TResult> Zip<T1, T2, T3, TResult>(
            this Output<T1> @this,
            Output<T2> second,
            Output<T3> third,
            Func<T1, T2, T3, TResult> resultSelector)
        {
            Require.Object(@this);
            Require.NotNull(second, "second");
            Require.NotNull(resultSelector, "resultSelector");

            Func<T1, Output<TResult>> g
                = t1 => second.Zip(third, (t2, t3) => resultSelector.Invoke(t1, t2, t3));

            return @this.Bind(g);
        }

        /// <see cref="Lift{T1, T2, T3, T4, T5}" />
        public static Output<TResult> Zip<T1, T2, T3, T4, TResult>(
             this Output<T1> @this,
             Output<T2> second,
             Output<T3> third,
             Output<T4> fourth,
             Func<T1, T2, T3, T4, TResult> resultSelector)
        {
            Require.Object(@this);
            Require.NotNull(second, "second");
            Require.NotNull(resultSelector, "resultSelector");

            Func<T1, Output<TResult>> g
                = t1 => second.Zip(
                    third,
                    fourth,
                    (t2, t3, t4) => resultSelector.Invoke(t1, t2, t3, t4));

            return @this.Bind(g);
        }

        /// <see cref="Lift{T1, T2, T3, T4, T5, T6}" />
        public static Output<TResult> Zip<T1, T2, T3, T4, T5, TResult>(
            this Output<T1> @this,
            Output<T2> second,
            Output<T3> third,
            Output<T4> fourth,
            Output<T5> fifth,
            Func<T1, T2, T3, T4, T5, TResult> resultSelector)
        {
            Require.Object(@this);
            Require.NotNull(second, "second");
            Require.NotNull(resultSelector, "resultSelector");

            Func<T1, Output<TResult>> g
                = t1 => second.Zip(
                    third,
                    fourth,
                    fifth,
                    (t2, t3, t4, t5) => resultSelector.Invoke(t1, t2, t3, t4, t5));

            return @this.Bind(g);
        }

        #endregion

        #region Query Expression Pattern


        /// <remarks>
        /// Kind of generalisation of Zip (liftM2).
        /// </remarks>
        public static Output<TResult> SelectMany<TSource, TMiddle, TResult>(
            this Output<TSource> @this,
            Func<TSource, Output<TMiddle>> valueSelectorM,
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
        
        #region LINQ extensions


        #endregion

        #region Non-standard extensions
        
        public static Output<TResult> Coalesce<TSource, TResult>(
            this Output<TSource> @this,
            Func<TSource, bool> predicate,
            Output<TResult> then,
            Output<TResult> otherwise)
        {
            Require.Object(@this);
            Require.NotNull(predicate, "predicate");

            return @this.Bind(_ => predicate.Invoke(_) ? then : otherwise);
        }


        public static void Invoke<TSource>(
            this Output<TSource> @this,
            Action<TSource> action)
        {
            Require.Object(@this);
            Require.NotNull(action, "action");

            @this.Bind(_ => { action.Invoke(_); return @this; });
        }


        #endregion
    } // End of the class Output.

    /// <content>
    /// Provides extension methods for <see cref="Func{T}"/> that depend on the <see cref="Output{T}"/> class.
    /// </content>
    public static partial class FuncExtensions
    {
        #region Basic Monad functions (Prelude)

        /// <remarks>
        /// Named <c>=&lt;&lt;</c> in Haskell parlance.
        /// </remarks>
        public static Output<TResult> Invoke<TSource, TResult>(
            this Func<TSource, Output<TResult>> @this,
            Output<TSource> value)
        {
            Acknowledge.Object(@this);
            Require.NotNull(value, "value");

            return value.Bind(@this);
        }

        /// <remarks>
        /// Named <c>&gt;=&gt;</c> in Haskell parlance.
        /// </remarks>
        public static Func<TSource, Output<TResult>> Compose<TSource, TMiddle, TResult>(
            this Func<TSource, Output<TMiddle>> @this,
            Func<TMiddle, Output<TResult>> funM)
        {
            Require.Object(@this);
            Contract.Requires(funM != null);
            Contract.Ensures(Contract.Result<Func<TSource, Output<TResult>>>() != null);

            return _ => @this.Invoke(_).Bind(funM);
        }

        /// <remarks>
        /// Named <c>&lt;=&lt;</c> in Haskell parlance.
        /// </remarks>
        public static Func<TSource, Output<TResult>> ComposeBack<TSource, TMiddle, TResult>(
            this Func<TMiddle, Output<TResult>> @this,
            Func<TSource, Output<TMiddle>> funM)
        {
            Acknowledge.Object(@this);
            Require.NotNull(funM, "funM");
            Contract.Ensures(Contract.Result<Func<TSource, Output<TResult>>>() != null);

            return _ => funM.Invoke(_).Bind(@this);
        }

        #endregion
    } // End of the class FuncExtensions.
}

namespace Narvalo.Fx
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    using Narvalo.Fx.Internal;

    /// <content>
    /// Provides extension methods for <see cref="IEnumerable{T}"/> that depend on the <see cref="Output{T}"/> class.
    /// </content>
    public static partial class EnumerableExtensions
    {
        #region Basic Monad functions (Prelude)

        /// <remarks>
        /// Named <c>sequence</c> in Haskell parlance.
        /// </remarks>
        public static Output<IEnumerable<TSource>> Collect<TSource>(
            this IEnumerable<Output<TSource>> @this)
        {
            Acknowledge.Object(@this);
            Contract.Ensures(Contract.Result<Output<IEnumerable<TSource>>>() != null);

            return @this.CollectCore();
        }

        #endregion
    } // End of the class EnumerableExtensions.
}

namespace Narvalo.Fx.Advanced
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    using Narvalo.Fx;
    using Narvalo.Fx.Internal;

    /// <content>
    /// Provides extension methods for <see cref="IEnumerable{T}"/>.
    /// </content>
    public static partial class EnumerableExtensions
    {
        #region Basic Monad functions (Prelude)

        /// <remarks>
        /// Named <c>mapM</c> in Haskell parlance.
        /// </remarks>
        public static Output<IEnumerable<TResult>> Map<TSource, TResult>(
            this IEnumerable<TSource> @this,
            Func<TSource, Output<TResult>> funM)
        {
            Acknowledge.Object(@this);
            Contract.Requires(funM != null);
            Contract.Ensures(Contract.Result<Output<IEnumerable<TResult>>>() != null);

            return @this.MapCore(funM);
        }

        #endregion

        #region Generalisations of list functions (Prelude)

        /// <remarks>
        /// <para>Named <c>filterM</c> in Haskell parlance.</para>
        /// <para>Haskell use a different signature.</para>
        /// </remarks>
        public static IEnumerable<TSource> Filter<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, Output<bool>> predicateM)
        {
            Acknowledge.Object(@this);
            Contract.Requires(predicateM != null);
            Contract.Ensures(Contract.Result<IEnumerable<TSource>>() != null);

            return @this.FilterCore(predicateM);
        }

        /// <remarks>
        /// Named <c>mapAndUnzipM</c> in Haskell parlance.
        /// </remarks>
        public static Output<Tuple<IEnumerable<TFirst>, IEnumerable<TSecond>>>
            MapAndUnzip<TSource, TFirst, TSecond>(
            this IEnumerable<TSource> @this,
            Func<TSource, Output<Tuple<TFirst, TSecond>>> funM)
        {
            Acknowledge.Object(@this);
            Contract.Requires(funM != null);

            return @this.MapAndUnzipCore(funM);
        }

        /// <remarks>
        /// Named <c>zipWithM</c> in Haskell parlance.
        /// </remarks>
        public static Output<IEnumerable<TResult>> Zip<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> @this,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, Output<TResult>> resultSelectorM)
        {
            Acknowledge.Object(@this);
            Contract.Requires(second != null);
            Contract.Requires(resultSelectorM != null);
            Contract.Ensures(Contract.Result<Output<IEnumerable<TResult>>>() != null);

            return @this.ZipCore(second, resultSelectorM);
        }

        /// <remarks>
        /// Named <c>foldM</c> in Haskell parlance.
        /// </remarks>
        public static Output<TAccumulate> Fold<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Output<TAccumulate>> accumulatorM)
        {
            Acknowledge.Object(@this);
            Contract.Requires(accumulatorM != null);

            return @this.FoldCore(seed, accumulatorM);
        }

        #endregion

        #region Aggregate Operators
        
        public static Output<TAccumulate> FoldBack<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Output<TAccumulate>> accumulatorM)
        {
            Acknowledge.Object(@this);
            Contract.Requires(accumulatorM != null);

            return @this.FoldBackCore(seed, accumulatorM);
        }
        
        public static Output<TSource> Reduce<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Output<TSource>> accumulatorM)
        {
            Acknowledge.Object(@this);
            Contract.Requires(accumulatorM != null);

            return @this.ReduceCore(accumulatorM);
        }
        
        public static Output<TSource> ReduceBack<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Output<TSource>> accumulatorM)
        {
            Acknowledge.Object(@this);
            Contract.Requires(accumulatorM != null);

            return @this.ReduceBackCore(accumulatorM);
        }

        #endregion

        #region Catamorphisms

        /// <remarks>
        /// <para>Haskell use a different signature.</para>
        /// </remarks>
        public static Output<TAccumulate> Fold<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Output<TAccumulate>> accumulatorM,
            Func<Output<TAccumulate>, bool> predicate)
        {
            Acknowledge.Object(@this);
            Contract.Requires(accumulatorM != null);
            Contract.Requires(predicate != null);

            return @this.FoldCore(seed, accumulatorM, predicate);
        }

        /// <remarks>
        /// <para>Haskell use a different signature.</para>
        /// </remarks>
        public static Output<TSource> Reduce<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Output<TSource>> accumulatorM,
            Func<Output<TSource>, bool> predicate)
        {
            Acknowledge.Object(@this);
            Contract.Requires(accumulatorM != null);
            Contract.Requires(predicate != null);

            return @this.ReduceCore(accumulatorM, predicate);
        }

        #endregion
    } // End of the class EnumerableExtensions.
}

namespace Narvalo.Fx.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;

    using global::Narvalo;
    using Narvalo.Fx; // Necessary for EmptyIfNull().
   
   
    using Narvalo.Fx.Advanced;
   

    /// <content>
    /// Provides the core extension methods for <see cref="IEnumerable{T}"/> that depend on the <see cref="Output{T}"/> class.
    /// </content>
    internal static partial class EnumerableExtensions
    {
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Output<IEnumerable<TSource>> CollectCore<TSource>(
            this IEnumerable<Output<TSource>> @this)
        {
            Acknowledge.Object(@this);
            Contract.Ensures(Contract.Result<Output<IEnumerable<TSource>>>() != null);

            var seed = Output.Success(Enumerable.Empty<TSource>());
            Func<Output<IEnumerable<TSource>>, Output<TSource>, Output<IEnumerable<TSource>>> fun
                = (m, n) => m.Bind(list => CollectCore(n, list));

            var retval = @this.Aggregate(seed, fun);
            Contract.Assume(retval != null);

            return retval;
        }
        
        // NB: We do not inline this method to avoid the creation of an unused private field (CA1823 warning).
        private static Output<IEnumerable<TSource>> CollectCore<TSource>(
            Output<TSource> m,
            IEnumerable<TSource> list)
        {
            Contract.Requires(m != null);

            return m.Bind(item => Output.Success(list.Concat(Enumerable.Repeat(item, 1))));
        }
    } // End of the class EnumerableExtensions.

    /// <content>
    /// Provides the core extension methods for <see cref="IEnumerable{T}"/>.
    /// </content>
    internal static partial class EnumerableExtensions
    {
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Output<IEnumerable<TResult>> MapCore<TSource, TResult>(
            this IEnumerable<TSource> @this,
            Func<TSource, Output<TResult>> funM)
        {
            Acknowledge.Object(@this);
            Contract.Requires(funM != null);
            Contract.Ensures(Contract.Result<Output<IEnumerable<TResult>>>() != null);

            return @this.Select(funM).EmptyIfNull().Collect();
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static IEnumerable<TSource> FilterCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, Output<bool>> predicateM)
        {
            Require.Object(@this);
            Require.NotNull(predicateM, "predicateM");
            Contract.Ensures(Contract.Result<IEnumerable<TSource>>() != null);

            // NB: Haskell uses tail recursion, we don't.
            var list = new List<TSource>();

            foreach (var item in @this)
            {
                var m = predicateM.Invoke(item);

                if (m != null)
                {
                    m.Invoke(
                        _ =>
                        {
                            if (_ == true)
                            {
                                list.Add(item);
                            }
                        });
                }
            }

            return list;
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Output<Tuple<IEnumerable<TFirst>, IEnumerable<TSecond>>>
            MapAndUnzipCore<TSource, TFirst, TSecond>(
            this IEnumerable<TSource> @this,
            Func<TSource, Output<Tuple<TFirst, TSecond>>> funM)
        {
            Acknowledge.Object(@this);
            Contract.Requires(funM != null);

            var m = @this.Select(funM).EmptyIfNull().Collect();

            return m.Select(
                tuples =>
                {
                    IEnumerable<TFirst> list1 = tuples.Select(_ => _.Item1);
                    IEnumerable<TSecond> list2 = tuples.Select(_ => _.Item2);

                    return new Tuple<IEnumerable<TFirst>, IEnumerable<TSecond>>(list1, list2);
                });
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Output<IEnumerable<TResult>> ZipCore<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> @this,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, Output<TResult>> resultSelectorM)
        {
            Require.NotNull(resultSelectorM, "resultSelectorM");

            Acknowledge.Object(@this);
            Contract.Requires(second != null);
            Contract.Ensures(Contract.Result<Output<IEnumerable<TResult>>>() != null);

            Func<TFirst, TSecond, Output<TResult>> resultSelector
                = (v1, v2) => resultSelectorM.Invoke(v1, v2);

            // WARNING: Do not remove "resultSelector", otherwise .NET will make a recursive call
            // instead of using the Zip from LINQ.
            return @this.Zip(second, resultSelector: resultSelector).EmptyIfNull().Collect();
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Output<TAccumulate> FoldCore<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Output<TAccumulate>> accumulatorM)
        {
            Require.Object(@this);
            Require.NotNull(accumulatorM, "accumulatorM");

            Output<TAccumulate> retval = Output.Success(seed);

            foreach (TSource item in @this)
            {
                if (retval == null) 
                {
                    return null;
                }

                retval = retval.Bind(_ => accumulatorM.Invoke(_, item));
            }

            return retval;
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Output<TAccumulate> FoldBackCore<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Output<TAccumulate>> accumulatorM)
        {
            Acknowledge.Object(@this);
            Contract.Requires(accumulatorM != null);

            return @this.Reverse().EmptyIfNull().Fold(seed, accumulatorM);
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Output<TSource> ReduceCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Output<TSource>> accumulatorM)
        {
            Require.Object(@this);
            Require.NotNull(accumulatorM, "accumulatorM");

            using (var iter = @this.GetEnumerator())
            {
                if (!iter.MoveNext())
                {
                    throw new InvalidOperationException("Source sequence was empty.");
                }

                Output<TSource> retval = Output.Success(iter.Current);

                while (iter.MoveNext())
                {
                    if (retval == null) 
                    {
                        return null;
                    }

                    retval = retval.Bind(_ => accumulatorM.Invoke(_, iter.Current));
                }

                return retval;
            }
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Output<TSource> ReduceBackCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Output<TSource>> accumulatorM)
        {
            Acknowledge.Object(@this);
            Contract.Requires(accumulatorM != null);

            return @this.Reverse().EmptyIfNull().Reduce(accumulatorM);
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Output<TAccumulate> FoldCore<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Output<TAccumulate>> accumulatorM,
            Func<Output<TAccumulate>, bool> predicate)
        {
            Require.Object(@this);
            Require.NotNull(accumulatorM, "accumulatorM");
            Require.NotNull(predicate, "predicate");

            Output<TAccumulate> retval = Output.Success(seed);

            using (var iter = @this.GetEnumerator())
            {
                while (predicate.Invoke(retval) && iter.MoveNext())
                {
                    if (retval == null)
                    {
                        return null;
                    }

                    retval = retval.Bind(_ => accumulatorM.Invoke(_, iter.Current));
                }
            }

            return retval;
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Output<TSource> ReduceCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Output<TSource>> accumulatorM,
            Func<Output<TSource>, bool> predicate)
        {
            Require.Object(@this);
            Require.NotNull(accumulatorM, "accumulatorM");
            Require.NotNull(predicate, "predicate");

            using (var iter = @this.GetEnumerator())
            {
                if (!iter.MoveNext())
                {
                    throw new InvalidOperationException("Source sequence was empty.");
                }

                Output<TSource> retval = Output.Success(iter.Current);

                while (predicate.Invoke(retval) && iter.MoveNext())
                {
                    if (retval == null)
                    {
                        return null;
                    }

                    retval = retval.Bind(_ => accumulatorM.Invoke(_, iter.Current));
                }

                return retval;
            }
        }
    } // End of the class EnumerableExtensions.
}
