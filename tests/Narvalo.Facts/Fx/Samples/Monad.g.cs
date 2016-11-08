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

namespace Narvalo.Fx.Samples
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Linq;

    using global::Narvalo;
    using Narvalo.Fx.Samples.Internal;

    using static System.Diagnostics.Contracts.Contract;

    /// <content>
    /// Provides a set of static methods for <see cref="Monad{T}" />.
    /// </content>
    /// <remarks>
    /// Sometimes we prefer to use extension methods over static methods to be able to override them locally.
    /// </remarks>
    public static partial class Monad
    {
        /// <summary>
        /// The unique object of type <c>Monad&lt;Unit&gt;</c>.
        /// </summary>
        private static readonly Monad<global::Narvalo.Fx.Unit> s_Unit = Return(global::Narvalo.Fx.Unit.Single);

        /// <summary>
        /// Gets the unique object of type <c>Monad&lt;Unit&gt;</c>.
        /// </summary>
        /// <value>The unique object of type <c>Monad&lt;Unit&gt;</c>.</value>
        public static Monad<global::Narvalo.Fx.Unit> Unit
        {
            get
            {
                Ensures(Result<Monad<global::Narvalo.Fx.Unit>>() != null);

                return s_Unit;
            }
        }


        /// <summary>
        /// Obtains an instance of the <see cref="Monad{T}"/> class for the specified value.
        /// </summary>
        /// <remarks>
        /// Named <c>return</c> in Haskell parlance.
        /// </remarks>
        /// <typeparam name="T">The underlying type of <paramref name="value"/>.</typeparam>
        /// <param name="value">A value to be wrapped into a <see cref="Monad{T}"/> object.</param>
        /// <returns>An instance of the <see cref="Monad{T}"/> class for the specified value.</returns>
        public static Monad<T> Return<T>(T value)
            /* T4: C# indent */
        {
            Ensures(Result<Monad<T>>() != null);

            return Monad<T>.η(value);
        }

        #region Generalisations of list functions (Prelude)

        /// <summary>
        /// Removes one level of structure, projecting its bound value into the outer level.
        /// </summary>
        /// <remarks>
        /// Named <c>join</c> in Haskell parlance.
        /// </remarks>
        public static Monad<T> Flatten<T>(Monad<Monad<T>> square)
            /* T4: C# indent */
        {
            Demand.NotNull(square);

            return Monad<T>.μ(square);
        }

        #endregion

        #region Conditional execution of monadic expressions (Prelude)


        #endregion

        #region Monadic lifting operators (Prelude)

        /// <summary>
        /// Promotes a function to use and return <see cref="Monad{T}" /> values.
        /// </summary>
        /// <remarks>
        /// Named <c>liftM</c> in Haskell parlance.
        /// </remarks>
        public static Func<Monad<T>, Monad<TResult>> Lift<T, TResult>(
            Func<T, TResult> fun)
            /* T4: C# indent */
        {
            Ensures(Result<Func<Monad<T>, Monad<TResult>>>() != null);

            return m =>
            {
                Require.NotNull(m, nameof(m));
                return m.Select(fun);
            };
        }

        /// <summary>
        /// Promotes a function to use and return <see cref="Monad{T}" /> values, scanning the
        /// monadic arguments from left to right.
        /// </summary>
        /// <remarks>
        /// Named <c>liftM2</c> in Haskell parlance.
        /// </remarks>
        public static Func<Monad<T1>, Monad<T2>, Monad<TResult>>
            Lift<T1, T2, TResult>(Func<T1, T2, TResult> fun)
            /* T4: C# indent */
        {
            Ensures(Result<Func<Monad<T1>, Monad<T2>, Monad<TResult>>>() != null);

            return (m1, m2) =>
            {
                Require.NotNull(m1, nameof(m1));
                return m1.Zip(m2, fun);
            };
        }

        /// <summary>
        /// Promotes a function to use and return <see cref="Monad{T}" /> values, scanning the
        /// monadic arguments from left to right.
        /// </summary>
        /// <remarks>
        /// Named <c>liftM3</c> in Haskell parlance.
        /// </remarks>
        public static Func<Monad<T1>, Monad<T2>, Monad<T3>, Monad<TResult>>
            Lift<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> fun)
            /* T4: C# indent */
        {
            Ensures(Result<Func<Monad<T1>, Monad<T2>, Monad<T3>, Monad<TResult>>>() != null);

            return (m1, m2, m3) =>
            {
                Require.NotNull(m1, nameof(m1));
                return m1.Zip(m2, m3, fun);
            };
        }

        /// <summary>
        /// Promotes a function to use and return <see cref="Monad{T}" /> values, scanning the
        /// monadic arguments from left to right.
        /// </summary>
        /// <remarks>
        /// Named <c>liftM4</c> in Haskell parlance.
        /// </remarks>
        public static Func<Monad<T1>, Monad<T2>, Monad<T3>, Monad<T4>, Monad<TResult>>
            Lift<T1, T2, T3, T4, TResult>(
            Func<T1, T2, T3, T4, TResult> fun)
            /* T4: C# indent */
        {
            Ensures(Result<Func<Monad<T1>, Monad<T2>, Monad<T3>, Monad<T4>, Monad<TResult>>>() != null);

            return (m1, m2, m3, m4) =>
            {
                Require.NotNull(m1, nameof(m1));
                return m1.Zip(m2, m3, m4, fun);
            };
        }

        /// <summary>
        /// Promotes a function to use and return <see cref="Monad{T}" /> values, scanning the
        /// monadic arguments from left to right.
        /// </summary>
        /// <remarks>
        /// Named <c>liftM5</c> in Haskell parlance.
        /// </remarks>
        public static Func<Monad<T1>, Monad<T2>, Monad<T3>, Monad<T4>, Monad<T5>, Monad<TResult>>
            Lift<T1, T2, T3, T4, T5, TResult>(
            Func<T1, T2, T3, T4, T5, TResult> fun)
            /* T4: C# indent */
        {
            Ensures(Result<Func<Monad<T1>, Monad<T2>, Monad<T3>, Monad<T4>, Monad<T5>, Monad<TResult>>>() != null);

            return (m1, m2, m3, m4, m5) =>
            {
                Require.NotNull(m1, nameof(m1));
                return m1.Zip(m2, m3, m4, m5, fun);
            };
        }

        #endregion
    } // End of Monad.

    /// <content>
    /// Provides the core monadic extension methods for <see cref="Monad{T}" />.
    /// </content>
    public static partial class Monad
    {
        #region Basic Monad functions (Prelude)

        /// <remarks>
        /// Named <c>fmap</c> in Haskell parlance.
        /// </remarks>
        public static Monad<TResult> Select<TSource, TResult>(
            this Monad<TSource> @this,
            Func<TSource, TResult> selector)
            /* T4: C# indent */
        {
            Require.Object(@this);
            Require.NotNull(selector, nameof(selector));

            return @this.Bind(_ => Monad.Return(selector.Invoke(_)));
        }

        /// <remarks>
        /// Named <c>&gt;&gt;</c> in Haskell parlance.
        /// </remarks>
        public static Monad<TResult> Then<TSource, TResult>(
            this Monad<TSource> @this,
            Monad<TResult> other)
            /* T4: C# indent */
        {
            Require.Object(@this);

            return @this.Bind(_ => other);
        }

        /// <remarks>
        /// Named <c>forever</c> in Haskell parlance.
        /// </remarks>
        public static Monad<TResult> Forever<TSource, TResult>(
            this Monad<TSource> @this,
            Func<Monad<TResult>> fun
            )
            /* T4: C# indent */
        {
            Require.Object(@this);

            // http://stackoverflow.com/questions/24042977/how-does-forever-monad-work

            return @this.Then(@this.Forever(fun));
        }

        /// <remarks>
        /// Named <c>void</c> in Haskell parlance.
        /// </remarks>
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "this",
            Justification = "[Intentionally] This method always returns the same result.")]
        public static Monad<global::Narvalo.Fx.Unit> Forget<TSource>(this Monad<TSource> @this)
            /* T4: C# indent */
        {
            Require.Object(@this);
            Ensures(Result<Monad<global::Narvalo.Fx.Unit>>() != null);

            return Monad.Unit;
        }

        #endregion

        #region Generalisations of list functions (Prelude)


        /// <remarks>
        /// Named <c>replicateM</c> in Haskell parlance.
        /// </remarks>
        public static Monad<IEnumerable<TSource>> Repeat<TSource>(
            this Monad<TSource> @this,
            int count)
        {
            Require.Object(@this);
            Require.GreaterThanOrEqualTo(count, 1, "count");

            return @this.Select(_ => Enumerable.Repeat(_, count));
        }


        #endregion

        #region Monadic lifting operators (Prelude)

        /// <see cref="Lift{T1, T2, T3}" />
        public static Monad<TResult> Zip<TFirst, TSecond, TResult>(
            this Monad<TFirst> @this,
            Monad<TSecond> second,
            Func<TFirst, TSecond, TResult> resultSelector)
            /* T4: C# indent */
        {
            Require.Object(@this);
            Require.NotNull(second, nameof(second));
            Require.NotNull(resultSelector, nameof(resultSelector));

            return @this.Bind(v1 => second.Select(v2 => resultSelector.Invoke(v1, v2)));
        }

        /// <see cref="Lift{T1, T2, T3, T4}" />
        public static Monad<TResult> Zip<T1, T2, T3, TResult>(
            this Monad<T1> @this,
            Monad<T2> second,
            Monad<T3> third,
            Func<T1, T2, T3, TResult> resultSelector)
            /* T4: C# indent */
        {
            Require.Object(@this);
            Require.NotNull(second, nameof(second));
            Require.NotNull(resultSelector, nameof(resultSelector));

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
            /* T4: C# indent */
        {
            Require.Object(@this);
            Require.NotNull(second, nameof(second));
            Require.NotNull(resultSelector, nameof(resultSelector));

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
            /* T4: C# indent */
        {
            Require.Object(@this);
            Require.NotNull(second, nameof(second));
            Require.NotNull(resultSelector, nameof(resultSelector));

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


        /// <remarks>
        /// Kind of generalisation of Zip (liftM2).
        /// </remarks>
        public static Monad<TResult> SelectMany<TSource, TMiddle, TResult>(
            this Monad<TSource> @this,
            Func<TSource, Monad<TMiddle>> valueSelectorM,
            Func<TSource, TMiddle, TResult> resultSelector)
            /* T4: C# indent */
        {
            Require.Object(@this);
            Require.NotNull(valueSelectorM, nameof(valueSelectorM));
            Require.NotNull(resultSelector, nameof(resultSelector));

            return @this.Bind(
                _ => valueSelectorM.Invoke(_).Select(
                    middle => resultSelector.Invoke(_, middle)));
        }


        #endregion

        #region LINQ extensions


        #endregion
    } // End of Monad.

    /// <content>
    /// Provides non-standard extension methods for <see cref="Monad{T}" />.
    /// </content>
    public static partial class Monad
    {
        public static Monad<TResult> Coalesce<TSource, TResult>(
            this Monad<TSource> @this,
            Func<TSource, bool> predicate,
            Monad<TResult> then,
            Monad<TResult> otherwise)
            /* T4: C# indent */
        {
            Require.Object(@this);
            Require.NotNull(predicate, nameof(predicate));

            return @this.Bind(_ => predicate.Invoke(_) ? then : otherwise);
        }


        public static Monad<TSource> When<TSource>(
            this Monad<TSource> @this,
            bool predicate,
            Action action)
            /* T4: C# indent */
        {
            Require.Object(@this);
            Require.NotNull(action, nameof(action));
            Ensures(Result<Monad<TSource>>() != null);

            if (predicate) { action.Invoke(); }

            return @this;
        }

        public static Monad<TSource> Unless<TSource>(
            this Monad<TSource> @this,
            bool predicate,
            Action action)
            /* T4: C# indent */
        {
            Demand.Object(@this);
            Demand.NotNull(action);
            Ensures(Result<Monad<TSource>>() != null);

            return @this.When(!predicate, action);
        }

        public static Monad<TSource> Invoke<TSource>(
            this Monad<TSource> @this,
            Action<TSource> action)
            /* T4: C# indent */
        {
            Require.Object(@this);
            Require.NotNull(action, nameof(action));

            return @this.Bind(_ => { action.Invoke(_); return @this; });
        }

    } // End of Monad.

    /// <content>
    /// Provides extension methods for <see cref="Func{T}"/> in the Kleisli category.
    /// </content>
    public static partial class FuncExtensions
    {
        #region Basic Monad functions (Prelude)


        /// <remarks>
        /// Named <c>mapM</c> in Haskell parlance. Same as <c>forM</c> with its arguments flipped.
        /// </remarks>
        public static Monad<IEnumerable<TResult>> Map<TSource, TResult>(
            this Func<TSource, Monad<TResult>> @this,
            IEnumerable<TSource> seq)
        {
            Demand.Object(@this);
            Demand.NotNull(seq);
            Ensures(Result<Monad<IEnumerable<TResult>>>() != null);

            return seq.ForEachCore(@this);
        }


        /// <remarks>
        /// Named <c>=&lt;&lt;</c> in Haskell parlance.
        /// </remarks>
        public static Monad<TResult> Invoke<TSource, TResult>(
            this Func<TSource, Monad<TResult>> @this,
            Monad<TSource> value)
            /* T4: C# indent */
        {
            Demand.Object(@this);
            Require.NotNull(value, nameof(value));

            return value.Bind(@this);
        }

        /// <remarks>
        /// Named <c>&gt;=&gt;</c> in Haskell parlance.
        /// </remarks>
        public static Func<TSource, Monad<TResult>> Compose<TSource, TMiddle, TResult>(
            this Func<TSource, Monad<TMiddle>> @this,
            Func<TMiddle, Monad<TResult>> funM)
            /* T4: C# indent */
        {
            Require.Object(@this);
            Demand.NotNull(funM);
            Ensures(Result<Func<TSource, Monad<TResult>>>() != null);

            return _ => @this.Invoke(_).Bind(funM);
        }

        /// <remarks>
        /// Named <c>&lt;=&lt;</c> in Haskell parlance.
        /// </remarks>
        public static Func<TSource, Monad<TResult>> ComposeBack<TSource, TMiddle, TResult>(
            this Func<TMiddle, Monad<TResult>> @this,
            Func<TSource, Monad<TMiddle>> funM)
            /* T4: C# indent */
        {
            Demand.Object(@this);
            Require.NotNull(funM, nameof(funM));
            Ensures(Result<Func<TSource, Monad<TResult>>>() != null);

            return _ => funM.Invoke(_).Bind(@this);
        }

        #endregion
    } // End of FuncExtensions.
}

namespace Narvalo.Fx.Samples
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    using Narvalo.Fx.Samples.Internal;

    using static System.Diagnostics.Contracts.Contract;

    /// <content>
    /// Provides extension methods for <see cref="IEnumerable{T}"/> where <c>T</c> is a <see cref="Monad{S}"/>.
    /// </content>
    public static partial class EnumerableExtensions
    {
        #region Basic Monad functions (Prelude)


        /// <remarks>
        /// Named <c>sequence</c> in Haskell parlance.
        /// </remarks>
        public static Monad<IEnumerable<TSource>> Collect<TSource>(
            this IEnumerable<Monad<TSource>> @this)
        {
            Demand.Object(@this);
            Ensures(Result<Monad<IEnumerable<TSource>>>() != null);

            return @this.CollectCore();
        }


        #endregion

    } // End of EnumerableExtensions.
}

namespace Narvalo.Fx.Samples.Advanced
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    using Narvalo.Fx.Samples;
    using Narvalo.Fx.Samples.Internal;

    using static System.Diagnostics.Contracts.Contract;

    /// <content>
    /// Provides extension methods for <see cref="IEnumerable{T}"/>.
    /// </content>
    public static partial class EnumerableExtensions
    {
        #region Basic Monad functions (Prelude)


        /// <remarks>
        /// Named <c>forM</c> in Haskell parlance.
        /// </remarks>
        public static Monad<IEnumerable<TResult>> ForEach<TSource, TResult>(
            this IEnumerable<TSource> @this,
            Func<TSource, Monad<TResult>> funM)
        {
            Demand.Object(@this);
            Demand.NotNull(funM);
            Ensures(Result<Monad<IEnumerable<TResult>>>() != null);

            return @this.ForEachCore(funM);
        }


        #endregion

        #region Generalisations of list functions (Prelude)

        /// <remarks>
        /// <para>Named <c>filterM</c> in Haskell parlance.</para>
        /// <para>Haskell use a different signature.</para>
        /// </remarks>
        public static IEnumerable<TSource> Filter<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, Monad<bool>> predicateM)
            /* T4: C# indent */
        {
            Demand.Object(@this);
            Demand.NotNull(predicateM);
            Ensures(Result<IEnumerable<TSource>>() != null);

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
            Demand.Object(@this);
            Demand.NotNull(funM);

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
            Demand.Object(@this);
            Demand.NotNull(second);
            Demand.NotNull(resultSelectorM);
            Ensures(Result<Monad<IEnumerable<TResult>>>() != null);

            return @this.ZipCore(second, resultSelectorM);
        }


        /// <remarks>
        /// Named <c>foldM</c> in Haskell parlance.
        /// </remarks>
        public static Monad<TAccumulate> Fold<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Monad<TAccumulate>> accumulatorM)
            /* T4: C# indent */
        {
            Demand.Object(@this);
            Demand.NotNull(accumulatorM);

            return @this.FoldCore(seed, accumulatorM);
        }

        #endregion

        #region Aggregate Operators

        public static Monad<TAccumulate> FoldBack<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Monad<TAccumulate>> accumulatorM)
            /* T4: C# indent */
        {
            Demand.Object(@this);
            Demand.NotNull(accumulatorM);

            return @this.FoldBackCore(seed, accumulatorM);
        }

        public static Monad<TSource> Reduce<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Monad<TSource>> accumulatorM)
            /* T4: C# indent */
        {
            Demand.Object(@this);
            Demand.NotNull(accumulatorM);

            return @this.ReduceCore(accumulatorM);
        }

        public static Monad<TSource> ReduceBack<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Monad<TSource>> accumulatorM)
            /* T4: C# indent */
        {
            Demand.Object(@this);
            Demand.NotNull(accumulatorM);

            return @this.ReduceBackCore(accumulatorM);
        }

        #endregion

        #region Catamorphisms

        /// <remarks>
        /// <para>Haskell use a different signature.</para>
        /// </remarks>
        public static Monad<TAccumulate> Fold<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Monad<TAccumulate>> accumulatorM,
            Func<Monad<TAccumulate>, bool> predicate)
            /* T4: C# indent */
        {
            Demand.Object(@this);
            Demand.NotNull(accumulatorM);
            Demand.NotNull(predicate);

            return @this.FoldCore(seed, accumulatorM, predicate);
        }

        /// <remarks>
        /// <para>Haskell use a different signature.</para>
        /// </remarks>
        public static Monad<TSource> Reduce<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Monad<TSource>> accumulatorM,
            Func<Monad<TSource>, bool> predicate)
            /* T4: C# indent */
        {
            Demand.Object(@this);
            Demand.NotNull(accumulatorM);
            Demand.NotNull(predicate);

            return @this.ReduceCore(accumulatorM, predicate);
        }

        #endregion
    } // End of EnumerableExtensions.
}

namespace Narvalo.Fx.Samples.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Linq;

    using global::Narvalo;
    using global::Narvalo.Fx; // Required for EmptyIfNull().
    using Narvalo.Fx.Samples;
    using Narvalo.Fx.Samples.Advanced;

    using static System.Diagnostics.Contracts.Contract;

    /// <content>
    /// Provides the core extension methods for <see cref="IEnumerable{T}"/> where <c>T</c> is a <see cref="Maybe{S}"/>.
    /// </content>
    internal static partial class EnumerableExtensions
    {


        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Monad<IEnumerable<TSource>> CollectCore<TSource>(
            this IEnumerable<Monad<TSource>> @this)
        {
            Demand.Object(@this);
            Ensures(Result<Monad<IEnumerable<TSource>>>() != null);

            var seed = Monad.Return(Enumerable.Empty<TSource>());
            Func<Monad<IEnumerable<TSource>>, Monad<TSource>, Monad<IEnumerable<TSource>>> fun
                = (m, n) => m.Bind(list => CollectCore(n, list));

            var retval = @this.Aggregate(seed, fun);
            Contract.Assume(retval != null);

            return retval;
        }

        // NB: We do not inline this method to avoid the creation of an unused private field (CA1823 warning).
        private static Monad<IEnumerable<TSource>> CollectCore<TSource>(
            Monad<TSource> m,
            IEnumerable<TSource> list)
        {
            Demand.NotNull(m);

            return m.Bind(item => Monad.Return(list.Concat(Enumerable.Repeat(item, 1))));
        }

    } // End of EnumerableExtensions.

    /// <content>
    /// Provides the core extension methods for <see cref="IEnumerable{T}"/>.
    /// </content>
    internal static partial class EnumerableExtensions
    {


        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Monad<IEnumerable<TResult>> ForEachCore<TSource, TResult>(
            this IEnumerable<TSource> @this,
            Func<TSource, Monad<TResult>> funM)
        {
            Demand.Object(@this);
            Demand.NotNull(funM);
            Ensures(Result<Monad<IEnumerable<TResult>>>() != null);

            return @this.Select(funM).EmptyIfNull().Collect();
        }


        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static IEnumerable<TSource> FilterCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, Monad<bool>> predicateM)
            /* T4: C# indent */
        {
            Require.Object(@this);
            Require.NotNull(predicateM, nameof(predicateM));
            Ensures(Result<IEnumerable<TSource>>() != null);

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
        internal static Monad<Tuple<IEnumerable<TFirst>, IEnumerable<TSecond>>>
            MapAndUnzipCore<TSource, TFirst, TSecond>(
            this IEnumerable<TSource> @this,
            Func<TSource, Monad<Tuple<TFirst, TSecond>>> funM)
        {
            Demand.Object(@this);
            Demand.NotNull(funM);

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
        internal static Monad<IEnumerable<TResult>> ZipCore<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> @this,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, Monad<TResult>> resultSelectorM)
        {
            Require.NotNull(resultSelectorM, nameof(resultSelectorM));

            Demand.Object(@this);
            Demand.NotNull(second);
            Ensures(Result<Monad<IEnumerable<TResult>>>() != null);

            Func<TFirst, TSecond, Monad<TResult>> resultSelector
                = (v1, v2) => resultSelectorM.Invoke(v1, v2);

            // WARNING: Do not remove "resultSelector", otherwise .NET will make a recursive call
            // instead of using the Zip from LINQ.
            return @this.Zip(second, resultSelector: resultSelector).EmptyIfNull().Collect();
        }


        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Monad<TAccumulate> FoldCore<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Monad<TAccumulate>> accumulatorM)
            /* T4: C# indent */
        {
            Require.Object(@this);
            Require.NotNull(accumulatorM, nameof(accumulatorM));

            Monad<TAccumulate> retval = Monad.Return(seed);

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
        internal static Monad<TAccumulate> FoldBackCore<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Monad<TAccumulate>> accumulatorM)
            /* T4: C# indent */
        {
            Demand.Object(@this);
            Demand.NotNull(accumulatorM);

            return @this.Reverse().EmptyIfNull().Fold(seed, accumulatorM);
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Monad<TSource> ReduceCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Monad<TSource>> accumulatorM)
            /* T4: C# indent */
        {
            Require.Object(@this);
            Require.NotNull(accumulatorM, nameof(accumulatorM));

            using (var iter = @this.GetEnumerator())
            {
                if (!iter.MoveNext())
                {
                    throw new InvalidOperationException("Source sequence was empty.");
                }

                Monad<TSource> retval = Monad.Return(iter.Current);

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
        internal static Monad<TSource> ReduceBackCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Monad<TSource>> accumulatorM)
            /* T4: C# indent */
        {
            Demand.Object(@this);
            Demand.NotNull(accumulatorM);

            return @this.Reverse().EmptyIfNull().Reduce(accumulatorM);
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Monad<TAccumulate> FoldCore<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Monad<TAccumulate>> accumulatorM,
            Func<Monad<TAccumulate>, bool> predicate)
            /* T4: C# indent */
        {
            Require.Object(@this);
            Require.NotNull(accumulatorM, nameof(accumulatorM));
            Require.NotNull(predicate, nameof(predicate));

            Monad<TAccumulate> retval = Monad.Return(seed);

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
        internal static Monad<TSource> ReduceCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Monad<TSource>> accumulatorM,
            Func<Monad<TSource>, bool> predicate)
            /* T4: C# indent */
        {
            Require.Object(@this);
            Require.NotNull(accumulatorM, nameof(accumulatorM));
            Require.NotNull(predicate, nameof(predicate));

            using (var iter = @this.GetEnumerator())
            {
                if (!iter.MoveNext())
                {
                    throw new InvalidOperationException("Source sequence was empty.");
                }

                Monad<TSource> retval = Monad.Return(iter.Current);

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
    } // End of EnumerableExtensions.
}

