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
using global::Narvalo.Fx;

namespace Monads
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Monads.Linq;

    // Provides a set of static methods for Monad<T>.
    // NB: Sometimes we prefer extension methods over static methods to be able to override them locally.
    public static partial class Monad
    {
        /// <summary>
        /// The unique object of type <c>Monad&lt;Unit&gt;</c>.
        /// </summary>
        private static readonly Monad<global::Narvalo.Fx.Unit> s_Unit = Pure(global::Narvalo.Fx.Unit.Single);

        /// <summary>
        /// Gets the unique object of type <c>Monad&lt;Unit&gt;</c>.
        /// </summary>
        /// <value>The unique object of type <c>Monad&lt;Unit&gt;</c>.</value>
        public static Monad<global::Narvalo.Fx.Unit> Unit
        {
            get
            {
                Warrant.NotNull<Monad<global::Narvalo.Fx.Unit>>();

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
        public static Monad<T> Pure<T>(T value)
            /* T4: C# indent */
        {
            Warrant.NotNull<Monad<T>>();

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
            Expect.NotNull(square);

            return Monad<T>.μ(square);
        }

        #endregion

        #region Conditional execution of monadic expressions (Prelude)


        /// <remarks>
        /// <para>Named <c>when</c> in Haskell parlance.</para>
        /// <para>Haskell uses a different signature.</para>
        /// </remarks>
        public static void When<TSource>(
            this Monad<TSource> @this,
            Func<TSource, bool> predicate,
            Action<TSource> action)
            /* T4: C# indent */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(predicate, nameof(predicate));
            Require.NotNull(action, nameof(action));

            @this.Bind(_ => { if (predicate.Invoke(_)) { action.Invoke(_); } return Monad.Unit; });
        }

        /// <remarks>
        /// <para>Named <c>unless</c> in Haskell parlance.</para>
        /// <para>Haskell uses a different signature.</para>
        /// </remarks>
        public static void Unless<TSource>(
            this Monad<TSource> @this,
            Func<TSource, bool> predicate,
            Action<TSource> action)
            /* T4: C# indent */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(predicate, nameof(predicate));
            Require.NotNull(action, nameof(action));

            @this.Bind(_ => { if (!predicate.Invoke(_)) { action.Invoke(_); } return Monad.Unit; });
        }

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
            Warrant.NotNull<Func<Monad<T>, Monad<TResult>>>();

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
            Warrant.NotNull<Func<Monad<T1>, Monad<T2>, Monad<TResult>>>();

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
            Warrant.NotNull<Func<Monad<T1>, Monad<T2>, Monad<T3>, Monad<TResult>>>();

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
            Warrant.NotNull<Func<Monad<T1>, Monad<T2>, Monad<T3>, Monad<T4>, Monad<TResult>>>();

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
            Warrant.NotNull<Func<Monad<T1>, Monad<T2>, Monad<T3>, Monad<T4>, Monad<T5>, Monad<TResult>>>();

            return (m1, m2, m3, m4, m5) =>
            {
                Require.NotNull(m1, nameof(m1));
                return m1.Zip(m2, m3, m4, m5, fun);
            };
        }

        #endregion
    } // End of Monad - T4: EmitMonadCore().

    // Provides the core monadic extension methods for Monad<T>.
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
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(selector, nameof(selector));

            return @this.Bind(_ => Monad.Pure(selector.Invoke(_)));
        }

        /// <remarks>
        /// Named <c>&gt;&gt;</c> in Haskell parlance.
        /// </remarks>
        public static Monad<TResult> Then<TSource, TResult>(
            this Monad<TSource> @this,
            Monad<TResult> other)
            /* T4: C# indent */
        {
            Require.NotNull(@this, nameof(@this));

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
            Require.NotNull(@this, nameof(@this));

            return @this.Then(@this.Forever(fun));
        }

        /// <remarks>
        /// Named <c>void</c> in Haskell parlance.
        /// </remarks>
        public static Monad<global::Narvalo.Fx.Unit> Ignore<TSource>(this Monad<TSource> @this)
            /* T4: C# indent */
        {
            Require.NotNull(@this, nameof(@this));
            Warrant.NotNull<Monad<global::Narvalo.Fx.Unit>>();

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
            Require.NotNull(@this, nameof(@this));
            Require.Range(count >= 1, nameof(count));

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
            Require.NotNull(@this, nameof(@this));
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
            Require.NotNull(@this, nameof(@this));
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
            Require.NotNull(@this, nameof(@this));
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
            Require.NotNull(@this, nameof(@this));
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
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(valueSelectorM, nameof(valueSelectorM));
            Require.NotNull(resultSelector, nameof(resultSelector));

            return @this.Bind(
                _ => valueSelectorM.Invoke(_).Select(
                    middle => resultSelector.Invoke(_, middle)));
        }


        #endregion

        #region LINQ extensions


        #endregion
    } // End of Monad - T4: EmitMonadExtensions().

    // Provides extension methods for Func<T> in the Kleisli category.
    public static partial class Func
    {
        #region Basic Monad functions (Prelude)


        /// <remarks>
        /// Named <c>forM</c> in Haskell parlance. Same as <c>mapM</c> with its arguments flipped.
        /// </remarks>
        public static Monad<IEnumerable<TResult>> ForEach<TSource, TResult>(
            this Func<TSource, Monad<TResult>> @this,
            IEnumerable<TSource> seq)
        {
            Expect.NotNull(@this);
            Expect.NotNull(seq);
            Warrant.NotNull<Monad<IEnumerable<TResult>>>();

            return seq.Map(@this);
        }


        /// <remarks>
        /// Named <c>=&lt;&lt;</c> in Haskell parlance.
        /// </remarks>
        public static Monad<TResult> Invoke<TSource, TResult>(
            this Func<TSource, Monad<TResult>> @this,
            Monad<TSource> value)
            /* T4: C# indent */
        {
            Expect.NotNull(@this);
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
            Require.NotNull(@this, nameof(@this));
            Expect.NotNull(funM);
            Warrant.NotNull<Func<TSource, Monad<TResult>>>();

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
            Expect.NotNull(@this);
            Require.NotNull(funM, nameof(funM));
            Warrant.NotNull<Func<TSource, Monad<TResult>>>();

            return _ => funM.Invoke(_).Bind(@this);
        }

        #endregion
    } // End of Func - T4: EmitKleisliExtensions().
}

namespace Monads
{
    using System.Collections.Generic;

    using Monads.Internal;

    // Provides extension methods for IEnumerable<T> where T is a Monad<S>.
    public static partial class Sequence
    {
        #region Basic Monad functions (Prelude)


        /// <remarks>
        /// Named <c>sequence</c> in Haskell parlance.
        /// </remarks>
        public static Monad<IEnumerable<TSource>> Collect<TSource>(
            this IEnumerable<Monad<TSource>> @this)
        {
            Expect.NotNull(@this);
            Warrant.NotNull<Monad<IEnumerable<TSource>>>();

            return @this.CollectImpl();
        }


        #endregion

    } // End of Sequence - T4: EmitMonadEnumerableExtensions().
}

namespace Monads.Linq
{
    using System;
    using System.Collections.Generic;

    using Monads;
    using Monads.Internal;

    // Provides extension methods for IEnumerable<T>.
    // We do not use the standard LINQ names to avoid a confusing API (see ZipWithImpl()).
    // - Select    -> Map
    // - Where     -> Filter
    // - Zip       -> ZipWith
    // - Aggregate -> Reduce or Fold
    public static partial class MoreEnumerable
    {
        #region Basic Monad functions (Prelude)


        /// <remarks>Named <c>mapM</c> in Haskell parlance.</remarks>
        public static Monad<IEnumerable<TResult>> Map<TSource, TResult>(
            this IEnumerable<TSource> @this,
            Func<TSource, Monad<TResult>> selectorM)
        {
            Expect.NotNull(@this);
            Expect.NotNull(selectorM);
            Warrant.NotNull<Monad<IEnumerable<TResult>>>();

            return @this.MapImpl(selectorM);
        }


        #endregion

        #region Generalisations of list functions (Prelude)


        /// <remarks>Named <c>filterM</c> in Haskell parlance.</remarks>
        public static Monad<IEnumerable<TSource>> Filter<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, Monad<bool>> predicateM)
            /* T4: C# indent */
        {
            Expect.NotNull(@this);
            Expect.NotNull(predicateM);
            Warrant.NotNull<IEnumerable<TSource>>();

            return @this.FilterImpl(predicateM);
        }

        /// <remarks>
        /// Named <c>mapAndUnzipM</c> in Haskell parlance.
        /// </remarks>
        public static Monad<Tuple<IEnumerable<TFirst>, IEnumerable<TSecond>>>
            MapUnzip<TSource, TFirst, TSecond>(
            this IEnumerable<TSource> @this,
            Func<TSource, Monad<Tuple<TFirst, TSecond>>> funM)
        {
            Expect.NotNull(@this);
            Expect.NotNull(funM);

            return @this.MapUnzipImpl(funM);
        }

        /// <remarks>
        /// Named <c>zipWithM</c> in Haskell parlance.
        /// </remarks>
        public static Monad<IEnumerable<TResult>> ZipWith<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> @this,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, Monad<TResult>> resultSelectorM)
        {
            Expect.NotNull(@this);
            Expect.NotNull(second);
            Expect.NotNull(resultSelectorM);
            Warrant.NotNull<Monad<IEnumerable<TResult>>>();

            return @this.ZipWithImpl(second, resultSelectorM);
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
            Expect.NotNull(@this);
            Expect.NotNull(accumulatorM);

            return @this.FoldImpl(seed, accumulatorM);
        }

        #endregion

        #region Aggregate Operators

        public static Monad<TAccumulate> FoldBack<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Monad<TAccumulate>> accumulatorM)
            /* T4: C# indent */
        {
            Expect.NotNull(@this);
            Expect.NotNull(accumulatorM);

            return @this.FoldBackImpl(seed, accumulatorM);
        }

        public static Monad<TSource> Reduce<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Monad<TSource>> accumulatorM)
            /* T4: C# indent */
        {
            Expect.NotNull(@this);
            Expect.NotNull(accumulatorM);

            return @this.ReduceImpl(accumulatorM);
        }

        public static Monad<TSource> ReduceBack<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Monad<TSource>> accumulatorM)
            /* T4: C# indent */
        {
            Expect.NotNull(@this);
            Expect.NotNull(accumulatorM);

            return @this.ReduceBackImpl(accumulatorM);
        }

        #endregion

        #region Catamorphisms

        /// <remarks>
        /// <para>Haskell uses a different signature.</para>
        /// </remarks>
        public static Monad<TAccumulate> Fold<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Monad<TAccumulate>> accumulatorM,
            Func<Monad<TAccumulate>, bool> predicate)
            /* T4: C# indent */
        {
            Expect.NotNull(@this);
            Expect.NotNull(accumulatorM);
            Expect.NotNull(predicate);

            return @this.FoldImpl(seed, accumulatorM, predicate);
        }

        /// <remarks>
        /// <para>Haskell uses a different signature.</para>
        /// </remarks>
        public static Monad<TSource> Reduce<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Monad<TSource>> accumulatorM,
            Func<Monad<TSource>, bool> predicate)
            /* T4: C# indent */
        {
            Expect.NotNull(@this);
            Expect.NotNull(accumulatorM);
            Expect.NotNull(predicate);

            return @this.ReduceImpl(accumulatorM, predicate);
        }

        #endregion
    } // End of MoreEnumerable - T4: EmitEnumerableExtensions().
}

namespace Monads.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Monads.Linq;

    // Provides the core extension methods for IEnumerable<T> where T is a Monad<S>.
    internal static partial class EnumerableExtensions
    {

        internal static Monad<IEnumerable<TSource>> CollectImpl<TSource>(
            this IEnumerable<Monad<TSource>> @this)
        {
            Demand.NotNull(@this);
            Warrant.NotNull<Monad<IEnumerable<TSource>>>();

            var seed = Monad.Pure(Enumerable.Empty<TSource>());
            // Inlined LINQ Append method:
            Func<IEnumerable<TSource>, TSource, IEnumerable<TSource>> append = (m, item) => m.Append(item);

            // NB: Maybe.Lift(append) is the same as:
            // Func<Monad<IEnumerable<TSource>>, Monad<TSource>, Monad<IEnumerable<TSource>>> liftedAppend
            //     = (m, item) => m.Bind(list => Append(list, item));
            // where Append is defined below.
            var retval = @this.Aggregate(seed, Monad.Lift(append));
            System.Diagnostics.Contracts.Contract.Assume(retval != null);

            return retval;
        }

        // NB: We do not inline this method to avoid the creation of an unused private field (CA1823 warning).
        //private static Monad<IEnumerable<TSource>> Append<TSource>(
        //    IEnumerable<TSource> list,
        //    Monad<TSource> m)
        //{
        //    Demand.NotNull(m);

        //    return m.Bind(item => Monad.Pure(list.Concat(Enumerable.Repeat(item, 1))));
        //}

    } // End of EnumerableExtensions - T4: EmitMonadEnumerableInternalExtensions().

    // Provides the core extension methods for IEnumerable<T>.
    internal static partial class EnumerableExtensions
    {

        internal static Monad<IEnumerable<TResult>> MapImpl<TSource, TResult>(
            this IEnumerable<TSource> @this,
            Func<TSource, Monad<TResult>> selectorM)
        {
            Demand.NotNull(@this);
            Demand.NotNull(selectorM);
            Warrant.NotNull<Monad<IEnumerable<TResult>>>();

            return @this.Select(selectorM).EmptyIfNull().Collect();
        }

        internal static Monad<IEnumerable<TSource>> FilterImpl<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, Monad<bool>> predicateM)
            /* T4: C# indent */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(predicateM, nameof(predicateM));
            Warrant.NotNull<IEnumerable<TSource>>();

            Func<bool, IEnumerable<TSource>, TSource, IEnumerable<TSource>> selector
                = (flg, list, item) => { if (flg) { return list.Prepend(item); } else { return list; } };

            Func<Monad<IEnumerable<TSource>>, TSource, Monad<IEnumerable<TSource>>> accumulatorM
                = (mlist, item) => predicateM.Invoke(item).Zip(mlist, (flg, list) => selector.Invoke(flg, list, item));

            var seed = Monad.Pure(Enumerable.Empty<TSource>());

            // REVIEW: Aggregate?
            return @this.AggregateBack(seed, accumulatorM);
        }

        internal static Monad<Tuple<IEnumerable<TFirst>, IEnumerable<TSecond>>>
            MapUnzipImpl<TSource, TFirst, TSecond>(
            this IEnumerable<TSource> @this,
            Func<TSource, Monad<Tuple<TFirst, TSecond>>> selectorM)
        {
            Demand.NotNull(@this);
            Demand.NotNull(selectorM);

            return @this.Map(selectorM).Select(
                tuples =>
                {
                    IEnumerable<TFirst> list1 = tuples.Select(_ => _.Item1);
                    IEnumerable<TSecond> list2 = tuples.Select(_ => _.Item2);

                    return new Tuple<IEnumerable<TFirst>, IEnumerable<TSecond>>(list1, list2);
                });
        }

        internal static Monad<IEnumerable<TResult>> ZipWithImpl<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> @this,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, Monad<TResult>> resultSelectorM)
        {
            Require.NotNull(resultSelectorM, nameof(resultSelectorM));

            Demand.NotNull(@this);
            Demand.NotNull(second);
            Warrant.NotNull<Monad<IEnumerable<TResult>>>();

            Func<TFirst, TSecond, Monad<TResult>> resultSelector
                = (v1, v2) => resultSelectorM.Invoke(v1, v2);

            // WARNING: Do not remove "resultSelector", otherwise .NET will make a recursive call
            // instead of using the Zip from LINQ. (no longer necessary since we renamed Zip to ZipWith).
            IEnumerable<Monad<TResult>> seq = @this.Zip(second, resultSelector);

            return seq.EmptyIfNull().Collect();
        }

        internal static Monad<TAccumulate> FoldImpl<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Monad<TAccumulate>> accumulatorM)
            /* T4: C# indent */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(accumulatorM, nameof(accumulatorM));

            Monad<TAccumulate> retval = Monad.Pure(seed);

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

        internal static Monad<TAccumulate> FoldBackImpl<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Monad<TAccumulate>> accumulatorM)
            /* T4: C# indent */
        {
            Demand.NotNull(@this);
            Demand.NotNull(accumulatorM);

            return @this.Reverse().EmptyIfNull().Fold(seed, accumulatorM);
        }

        internal static Monad<TSource> ReduceImpl<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Monad<TSource>> accumulatorM)
            /* T4: C# indent */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(accumulatorM, nameof(accumulatorM));

            using (var iter = @this.GetEnumerator())
            {
                if (!iter.MoveNext())
                {
                    throw new InvalidOperationException("Source sequence was empty.");
                }

                Monad<TSource> retval = Monad.Pure(iter.Current);

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

        internal static Monad<TSource> ReduceBackImpl<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Monad<TSource>> accumulatorM)
            /* T4: C# indent */
        {
            Demand.NotNull(@this);
            Demand.NotNull(accumulatorM);

            return @this.Reverse().EmptyIfNull().Reduce(accumulatorM);
        }

        internal static Monad<TAccumulate> FoldImpl<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Monad<TAccumulate>> accumulatorM,
            Func<Monad<TAccumulate>, bool> predicate)
            /* T4: C# indent */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(accumulatorM, nameof(accumulatorM));
            Require.NotNull(predicate, nameof(predicate));

            Monad<TAccumulate> retval = Monad.Pure(seed);

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

        internal static Monad<TSource> ReduceImpl<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Monad<TSource>> accumulatorM,
            Func<Monad<TSource>, bool> predicate)
            /* T4: C# indent */
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(accumulatorM, nameof(accumulatorM));
            Require.NotNull(predicate, nameof(predicate));

            using (var iter = @this.GetEnumerator())
            {
                if (!iter.MoveNext())
                {
                    throw new InvalidOperationException("Source sequence was empty.");
                }

                Monad<TSource> retval = Monad.Pure(iter.Current);

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
    } // End of EnumerableExtensions - T4: EmitEnumerableInternalExtensions().
}

