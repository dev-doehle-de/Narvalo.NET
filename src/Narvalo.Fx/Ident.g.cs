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
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    using Narvalo.Fx.Internal;
    using Narvalo.Fx.Linq;

    // Provides a set of static methods for Ident<T>.
    // NB: Sometimes we prefer extension methods over static methods to be able to override them locally.
    public static partial class Ident
    {
        /// <summary>
        /// The unique object of type <c>Ident&lt;Unit&gt;</c>.
        /// </summary>
        private static readonly Ident<global::Narvalo.Fx.Unit> s_Unit = Of(global::Narvalo.Fx.Unit.Single);

        /// <summary>
        /// Gets the unique object of type <c>Ident&lt;Unit&gt;</c>.
        /// </summary>
        /// <value>The unique object of type <c>Ident&lt;Unit&gt;</c>.</value>
        public static Ident<global::Narvalo.Fx.Unit> Unit
        {
            get
            {

                return s_Unit;
            }
        }


        /// <summary>
        /// Obtains an instance of the <see cref="Ident{T}"/> class for the specified value.
        /// </summary>
        /// <typeparam name="T">The underlying type of <paramref name="value"/>.</typeparam>
        /// <param name="value">A value to be wrapped into a <see cref="Ident{T}"/> object.</param>
        /// <returns>An instance of the <see cref="Ident{T}"/> class for the specified value.</returns>
        // Named "return" (Monad) or "pure" (Applicative) in Haskell parlance.
        public static Ident<T> Of<T>(T value)
            /* T4: C# indent */
        {

            return Ident<T>.η(value);
        }

        #region Generalisations of list functions

        /// <summary>
        /// Removes one level of structure, projecting its bound value into the outer level.
        /// </summary>
        // Named "join" in Haskell parlance.
        public static Ident<T> Flatten<T>(Ident<Ident<T>> square)
            /* T4: C# indent */
        {

            return Ident<T>.μ(square);
        }

        #endregion

        #region Conditional execution of monadic expressions


        #endregion

        #region Monadic lifting operators

        /// <summary>
        /// Promotes a function to use and return <see cref="Ident{T}" /> values.
        /// </summary>
        // Named "liftM" in Haskell parlance.
        public static Func<Ident<T>, Ident<TResult>> Lift<T, TResult>(
            Func<T, TResult> thunk)
            /* T4: C# indent */
        {
            Warrant.NotNull<Func<Ident<T>, Ident<TResult>>>();

            return m =>
            {
                /* T4: C# indent */
                return m.Select(thunk);
            };
        }

        /// <summary>
        /// Promotes a function to use and return <see cref="Ident{T}" /> values, scanning the
        /// monadic arguments from left to right.
        /// </summary>
        // Named "liftM2" in Haskell parlance.
        public static Func<Ident<T1>, Ident<T2>, Ident<TResult>>
            Lift<T1, T2, TResult>(Func<T1, T2, TResult> thunk)
            /* T4: C# indent */
        {
            Warrant.NotNull<Func<Ident<T1>, Ident<T2>, Ident<TResult>>>();

            return (m1, m2) =>
            {
                /* T4: C# indent */
                return m1.Zip(m2, thunk);
            };
        }

        /// <summary>
        /// Promotes a function to use and return <see cref="Ident{T}" /> values, scanning the
        /// monadic arguments from left to right.
        /// </summary>
        // Named "liftM3" in Haskell parlance.
        public static Func<Ident<T1>, Ident<T2>, Ident<T3>, Ident<TResult>>
            Lift<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> thunk)
            /* T4: C# indent */
        {
            Warrant.NotNull<Func<Ident<T1>, Ident<T2>, Ident<T3>, Ident<TResult>>>();

            return (m1, m2, m3) =>
            {
                /* T4: C# indent */
                return m1.Zip(m2, m3, thunk);
            };
        }

        /// <summary>
        /// Promotes a function to use and return <see cref="Ident{T}" /> values, scanning the
        /// monadic arguments from left to right.
        /// </summary>
        // Named "liftM4" in Haskell parlance.
        public static Func<Ident<T1>, Ident<T2>, Ident<T3>, Ident<T4>, Ident<TResult>>
            Lift<T1, T2, T3, T4, TResult>(
            Func<T1, T2, T3, T4, TResult> thunk)
            /* T4: C# indent */
        {
            Warrant.NotNull<Func<Ident<T1>, Ident<T2>, Ident<T3>, Ident<T4>, Ident<TResult>>>();

            return (m1, m2, m3, m4) =>
            {
                /* T4: C# indent */
                return m1.Zip(m2, m3, m4, thunk);
            };
        }

        /// <summary>
        /// Promotes a function to use and return <see cref="Ident{T}" /> values, scanning the
        /// monadic arguments from left to right.
        /// </summary>
        // Named "liftM5" in Haskell parlance.
        public static Func<Ident<T1>, Ident<T2>, Ident<T3>, Ident<T4>, Ident<T5>, Ident<TResult>>
            Lift<T1, T2, T3, T4, T5, TResult>(
            Func<T1, T2, T3, T4, T5, TResult> thunk)
            /* T4: C# indent */
        {
            Warrant.NotNull<Func<Ident<T1>, Ident<T2>, Ident<T3>, Ident<T4>, Ident<T5>, Ident<TResult>>>();

            return (m1, m2, m3, m4, m5) =>
            {
                /* T4: C# indent */
                return m1.Zip(m2, m3, m4, m5, thunk);
            };
        }

        #endregion
    } // End of Ident - T4: EmitMonadCore().

    // Provides extension methods for Ident<T>.
    public static partial class Ident
    {
        #region Applicative

        // Named "<$" (Applicative) in Haskell parlance.
        public static Ident<TResult> Replace<TSource, TResult>(
            this Ident<TSource> @this,
            TResult value)
            /* T4: C# indent */
        {
            /* T4: C# indent */

            return @this.Select(_ => value);
        }


        // Named "<*>" in Haskell parlance. Same as Apply (<**>) with its arguments flipped.
        public static Ident<TResult> Gather<TSource, TResult>(
            this Ident<TSource> @this,
            Ident<Func<TSource, TResult>> applicative)
            /* T4: C# indent */
        {
            /* T4: C# indent */

            return applicative.Apply(@this);
        }

        // Named "<**>" in Haskell parlance. Same as Gather (<*>) with its arguments flipped.
        public static Ident<TResult> Apply<TSource, TResult>(
            this Ident<Func<TSource, TResult>> @this,
            Ident<TSource> value)
        {
            /* T4: C# indent */
            /* T4: C# indent */

            return @this.Bind(thunk => value.Select(v => thunk.Invoke(v)));
        }

        public static Ident<Tuple<TSource, TOther>> Zip<TSource, TOther>(
            this Ident<TSource> @this,
            Ident<TOther> other)
            /* T4: C# indent */
        {
            /* T4: C# indent */

            return @this.Zip(other, Tuple.Create);
        }


        #endregion

        #region Basic Monad functions

        // Named "fmap", "liftA" or "<$>" (Applicative) in Haskell parlance.
        public static Ident<TResult> Select<TSource, TResult>(
            this Ident<TSource> @this,
            Func<TSource, TResult> selector)
            /* T4: C# indent */
        {
            /* T4: C# indent */
            Require.NotNull(selector, nameof(selector));

            return @this.Bind(_ => Ident.Of(selector.Invoke(_)));
        }

        // Named ">>" (Monad) or "*>" (Applicative) in Haskell parlance.
        public static Ident<TResult> ReplaceBy<TSource, TResult>(
            this Ident<TSource> @this,
            Ident<TResult> other)
            /* T4: C# indent */
        {
            /* T4: C# indent */

            return @this.Bind(_ => other);
        }

        // Named "void" in Haskell parlance.
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "this", Justification = "[Intentionally] This method always returns the same result.")]
        public static Ident<global::Narvalo.Fx.Unit> Skip<TSource>(this Ident<TSource> @this)
            /* T4: C# indent */
        {
            /* T4: C# indent */

            return Ident.Unit;
        }

        // Named "forever" in Haskell parlance.
        public static Ident<TResult> Forever<TSource, TResult>(
            this Ident<TSource> @this,
            Func<Ident<TResult>> thunk)
            /* T4: C# indent */
        {
            /* T4: C# indent */

            return @this.ReplaceBy(@this.Forever(thunk));
        }

        #endregion

        #region Other extensions

        public static Ident<TResult> Coalesce<TSource, TResult>(
            this Ident<TSource> @this,
            Func<TSource, bool> predicate,
            Ident<TResult> thenResult,
            Ident<TResult> elseResult)
            /* T4: C# indent */
        {
            /* T4: C# indent */
            Require.NotNull(predicate, nameof(predicate));

            return @this.Bind(_ => predicate.Invoke(_) ? thenResult : elseResult);
        }


        public static Ident<TResult> Using<TSource, TResult>(
            this Ident<TSource> @this,
            Func<TSource, Ident<TResult>> selector)
            where TSource : IDisposable
            /* T4: C# indent */
        {
            /* T4: C# indent */
            Require.NotNull(selector, nameof(selector));

            return @this.Bind(_ => { using (_) { return selector.Invoke(_); } });
        }

        public static Ident<TResult> Using<TSource, TResult>(
            this Ident<TSource> @this,
            Func<TSource, TResult> selector)
            where TSource : IDisposable
            /* T4: C# indent */
        {
            /* T4: C# indent */
            Require.NotNull(selector, nameof(selector));

            return @this.Select(_ => { using (_) { return selector.Invoke(_); } });
        }

        #endregion

        #region Generalisations of list functions


        // Named "replicateM" in Haskell parlance.
        public static Ident<IEnumerable<TSource>> Repeat<TSource>(
            this Ident<TSource> @this,
            int count)
        {
            /* T4: C# indent */
            Require.Range(count >= 1, nameof(count));

            return @this.Select(_ => Enumerable.Repeat(_, count));
        }


        #endregion

        #region Conditional execution of monadic expressions

        // Named "when" in Haskell parlance. Haskell uses a different signature.
        public static void When<TSource>(
            this Ident<TSource> @this,
            Func<TSource, bool> predicate,
            Action<TSource> action)
            /* T4: C# indent */
        {
            /* T4: C# indent */
            Require.NotNull(predicate, nameof(predicate));
            Require.NotNull(action, nameof(action));

            @this.Bind(
                _ => {
                    if (predicate.Invoke(_)) { action.Invoke(_); }

                    return Ident.Unit;
                });
        }

        // Named "unless" in Haskell parlance. Haskell uses a different signature.
        public static void Unless<TSource>(
            this Ident<TSource> @this,
            Func<TSource, bool> predicate,
            Action<TSource> action)
            /* T4: C# indent */
        {
            /* T4: C# indent */
            Expect.NotNull(predicate);
            Expect.NotNull(action);

            @this.When(_ => !predicate.Invoke(_), action);
        }

        #endregion

        #region Applicative lifting operators

        /// <see cref="Lift{T1, T2, T3}" />
        // Named "liftA2" (Applicative) in Haskell parlance.
        public static Ident<TResult> Zip<TFirst, TSecond, TResult>(
            this Ident<TFirst> @this,
            Ident<TSecond> second,
            Func<TFirst, TSecond, TResult> resultSelector)
            /* T4: C# indent */
        {
            /* T4: C# indent */
            /* T4: C# indent */
            Require.NotNull(resultSelector, nameof(resultSelector));

            return @this.Bind(v1 => second.Select(v2 => resultSelector.Invoke(v1, v2)));
        }

        /// <see cref="Lift{T1, T2, T3, T4}" />
        // Named "liftA3" (Applicative) in Haskell parlance.
        public static Ident<TResult> Zip<T1, T2, T3, TResult>(
            this Ident<T1> @this,
            Ident<T2> second,
            Ident<T3> third,
            Func<T1, T2, T3, TResult> resultSelector)
            /* T4: C# indent */
        {
            /* T4: C# indent */
            /* T4: C# indent */
            Require.NotNull(resultSelector, nameof(resultSelector));

            Func<T1, Ident<TResult>> g
                = t1 => second.Zip(third, (t2, t3) => resultSelector.Invoke(t1, t2, t3));

            return @this.Bind(g);
        }

        /// <see cref="Lift{T1, T2, T3, T4, T5}" />
        // Named "liftA4" (Applicative) in Haskell parlance.
        public static Ident<TResult> Zip<T1, T2, T3, T4, TResult>(
             this Ident<T1> @this,
             Ident<T2> second,
             Ident<T3> third,
             Ident<T4> fourth,
             Func<T1, T2, T3, T4, TResult> resultSelector)
            /* T4: C# indent */
        {
            /* T4: C# indent */
            /* T4: C# indent */
            Require.NotNull(resultSelector, nameof(resultSelector));

            Func<T1, Ident<TResult>> g
                = t1 => second.Zip(
                    third,
                    fourth,
                    (t2, t3, t4) => resultSelector.Invoke(t1, t2, t3, t4));

            return @this.Bind(g);
        }

        /// <see cref="Lift{T1, T2, T3, T4, T5, T6}" />
        // Named "liftA5" (Applicative) in Haskell parlance.
        public static Ident<TResult> Zip<T1, T2, T3, T4, T5, TResult>(
            this Ident<T1> @this,
            Ident<T2> second,
            Ident<T3> third,
            Ident<T4> fourth,
            Ident<T5> fifth,
            Func<T1, T2, T3, T4, T5, TResult> resultSelector)
            /* T4: C# indent */
        {
            /* T4: C# indent */
            /* T4: C# indent */
            Require.NotNull(resultSelector, nameof(resultSelector));

            Func<T1, Ident<TResult>> g
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
        /// Kind of generalisation of <see cref="Zip{T1, T2, T3}" />.
        /// </remarks>
        public static Ident<TResult> SelectMany<TSource, TMiddle, TResult>(
            this Ident<TSource> @this,
            Func<TSource, Ident<TMiddle>> valueSelector,
            Func<TSource, TMiddle, TResult> resultSelector)
            /* T4: C# indent */
        {
            /* T4: C# indent */
            Require.NotNull(valueSelector, nameof(valueSelector));
            Require.NotNull(resultSelector, nameof(resultSelector));

            return @this.Bind(
                _ => valueSelector.Invoke(_).Select(
                    middle => resultSelector.Invoke(_, middle)));
        }


        #endregion

        #region LINQ extensions


        #endregion
    } // End of Ident - T4: EmitMonadExtensions().

    // Provides extension methods for Func<T> in the Kleisli category.
    public static partial class Kunc
    {
        #region Basic Monad functions


        // Named "forM" in Haskell parlance. Same as SelectWith (mapM) with its arguments flipped.
        public static Ident<IEnumerable<TResult>> ForEach<TSource, TResult>(
            this Func<TSource, Ident<TResult>> @this,
            IEnumerable<TSource> seq)
        {
            Expect.NotNull(@this);
            Expect.NotNull(seq);

            return seq.Select(@this).EmptyIfNull().Collect();
        }


        // Named "=<<" in Haskell parlance. Same as Bind (>>=) with its arguments flipped.
        public static Ident<TResult> Invoke<TSource, TResult>(
            this Func<TSource, Ident<TResult>> @this,
            Ident<TSource> value)
            /* T4: C# indent */
        {
            Expect.NotNull(@this);
            /* T4: C# indent */

            return value.Bind(@this);
        }

        // Named ">=>" in Haskell parlance.
        public static Func<TSource, Ident<TResult>> Compose<TSource, TMiddle, TResult>(
            this Func<TSource, Ident<TMiddle>> @this,
            Func<TMiddle, Ident<TResult>> thunk)
            /* T4: C# indent */
        {
            Require.NotNull(@this, nameof(@this));
            Expect.NotNull(thunk);
            Warrant.NotNull<Func<TSource, Ident<TResult>>>();

            return _ => @this.Invoke(_).Bind(thunk);
        }

        // Named "<=<" in Haskell parlance.
        public static Func<TSource, Ident<TResult>> ComposeBack<TSource, TMiddle, TResult>(
            this Func<TMiddle, Ident<TResult>> @this,
            Func<TSource, Ident<TMiddle>> thunk)
            /* T4: C# indent */
        {
            Expect.NotNull(@this);
            Require.NotNull(thunk, nameof(thunk));
            Warrant.NotNull<Func<TSource, Ident<TResult>>>();

            return _ => thunk.Invoke(_).Bind(@this);
        }

        #endregion
    } // End of Func - T4: EmitKleisliExtensions().

    // Provides extension methods for IEnumerable<Ident<T>>.
    public static partial class Ident
    {
        #region Basic Monad functions


        // Named "sequence" in Haskell parlance.
        public static Ident<IEnumerable<TSource>> Collect<TSource>(
            this IEnumerable<Ident<TSource>> @this)
        {
            Expect.NotNull(@this);

            return @this.CollectImpl();
        }


        #endregion

    } // End of Sequence - T4: EmitMonadEnumerableExtensions().
}

namespace Narvalo.Fx.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    using Narvalo.Fx.Linq;

    // Provides default implementations for the extension methods for IEnumerable<Ident<T>>.
    // You will certainly want to override them to improve performance.
    internal static partial class EnumerableExtensions
    {

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Ident<IEnumerable<TSource>> CollectImpl<TSource>(
            this IEnumerable<Ident<TSource>> @this)
        {
            Demand.NotNull(@this);

            var seed = Ident.Of(Enumerable.Empty<TSource>());
            //var seed = Ident.Of(Enumerable.Empty<TSource>());
            // Inlined LINQ Append method:
            Func<IEnumerable<TSource>, TSource, IEnumerable<TSource>> append = (m, item) => m.Append(item);

            // NB: Maybe.Lift(append) is the same as:
            // Func<Ident<IEnumerable<TSource>>, Ident<TSource>, Ident<IEnumerable<TSource>>> liftedAppend
            //     = (m, item) => m.Bind(list => Append(list, item));
            // where Append is defined below.
            var retval = @this.Aggregate(seed, Ident.Lift<IEnumerable<TSource>, TSource, IEnumerable<TSource>>(append));

            return retval;
        }

        // NB: We do not inline this method to avoid the creation of an unused private field (CA1823 warning).
        //private static Ident<IEnumerable<TSource>> Append<TSource>(
        //    IEnumerable<TSource> list,
        //    Ident<TSource> m)
        //{

        //    return m.Bind(item => Ident.Of(list.Concat(Enumerable.Repeat(item, 1))));
        //}

    } // End of EnumerableExtensions - T4: EmitMonadEnumerableInternalExtensions().
}


namespace Narvalo.Fx
{
    // Implements core Comonad methods.
    public static partial class Ident
    {
        /// <remarks>
        /// Named <c>extract</c> in Haskell parlance.
        /// </remarks>
        public static T Extract<T>(Ident<T> monad)
            /* T4: C# indent */
        {

            return Ident<T>.ε(monad);
        }

        /// <remarks>
        /// Named <c>duplicate</c> in Haskell parlance.
        /// </remarks>
        public static Ident<Ident<T>> Duplicate<T>(Ident<T> monad)
            /* T4: C# indent */
        {

            return Ident<T>.δ(monad);
        }
    } // End of Ident - T4: EmitComonadCore().
}

