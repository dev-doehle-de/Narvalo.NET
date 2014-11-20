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

namespace Narvalo.Fx {
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using Narvalo;      // For Require
    using Narvalo.Fx;   // For Unit

    /// <summary>
    /// Provides a set of static methods and extension methods for <see cref="Output{T}" />.
    /// </summary>
    public static partial class Output
    {
        static readonly Output<Unit> Unit_ = Success(Narvalo.Fx.Unit.Single);

        /// <summary>
        /// Returns the unique object of type <c>Output&lt;Unit&gt;</c>.
        /// </summary>
        public static Output<Unit> Unit { get { return Unit_; } }


        /*!
         * Named `return` in Haskell parlance.
         */

        /// <summary>
        /// Returns a new instance of <see cref="Output{T}" />.
        /// </summary>
        public static Output<T> Success<T>(T value)
        {
            return Output<T>.η(value);
        }
        
        #region Generalisations of list functions (Prelude)

        /*!
         * Named `join` in Haskell parlance.
         */

        /// <summary>
        /// Removes one level of structure, projecting its bound value into the outer level.
        /// </summary>
        public static Output<T> Flatten<T>(Output<Output<T>> square)
        {
            return Output<T>.μ(square);
        }

        #endregion

        #region Monadic lifting operators (Prelude)

        /*!
         * Named `liftM` in Haskell parlance.
         */

        /// <summary>
        /// Promotes a function to use and return <see cref="Output{T}" /> values.
        /// </summary>
        public static Func<Output<T>, Output<TResult>> Lift<T, TResult>(
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
        /// Promotes a function to use and return <see cref="Output{T}" /> values, scanning the 
        /// monadic arguments from left to right.
        /// </summary>
        public static Func<Output<T1>, Output<T2>, Output<TResult>>
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
        /// Promotes a function to use and return <see cref="Output{T}" /> values, scanning the 
        /// monadic arguments from left to right.
        /// </summary>
        public static Func<Output<T1>, Output<T2>, Output<T3>, Output<TResult>>
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
        /// Promotes a function to use and return <see cref="Output{T}" /> values, scanning the
        /// monadic arguments from left to right.
        /// </summary>
        public static Func<Output<T1>, Output<T2>, Output<T3>, Output<T4>, Output<TResult>>
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
        /// Promotes a function to use and return <see cref="Output{T}" /> values, scanning the
        /// monadic arguments from left to right.
        /// </summary>
        public static Func<Output<T1>, Output<T2>, Output<T3>, Output<T4>, Output<T5>, Output<TResult>>
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
     * Extensions methods for Output<T>.
     */
    public static partial class Output
    {
        #region Basic Monad functions (Prelude)

        /*!
         * Named `fmap` in Haskell parlance.
         */
        public static Output<TResult> Select<TSource, TResult>(
            this Output<TSource> @this,
            Func<TSource, TResult> selector)
        {
            Require.Object(@this);
            Require.NotNull(selector, "selector");

            return @this.Bind(_ => Output.Success(selector.Invoke(_)));
        }

        /*!
         * Named `>>` in Haskell parlance.
         */
        public static Output<TResult> Then<TSource, TResult>(
            this Output<TSource> @this,
            Output<TResult> other)
        {
            Require.Object(@this);

            return @this.Bind(_ => other);
        }
        
        #endregion

        #region Generalisations of list functions (Prelude)


        /*!
         * Named `replicateM` in Haskell parlance.
         */
        public static Output<IEnumerable<TSource>> Repeat<TSource>(
            this Output<TSource> @this,
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
        public static Output<Unit> When<TSource>(
            this Output<TSource> @this, 
            bool predicate, 
            Action action)
        {
            Require.NotNull(action, "action");

            if (predicate) {
                action.Invoke();
            }

            return Output.Unit;
        }

        /*!
         * Named `unless` in Haskell parlance.
         */
        public static Output<Unit> Unless<TSource>(
            this Output<TSource> @this,
            bool predicate,
            Action action)
        {
            Require.Object(@this);

            return @this.When(!predicate, action);
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


        /*!
         * Kind of generalisation of Zip (liftM2).
         */
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
        
        #region Linq extensions


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


        public static Output<TSource> Run<TSource>(
            this Output<TSource> @this,
            Action<TSource> action)
        {
            Require.Object(@this);
            Require.NotNull(action, "action");

            return @this.Bind(_ => { action.Invoke(_); return @this; });
        }


        #endregion
    }

    /*!
     * Extensions methods for Func<TSource, Output<TResult>>.
     */
    public static partial class FuncExtensions
    {
        #region Basic Monad functions (Prelude)

        /*!
         * Named `=<<` in Haskell parlance.
         */
        public static Output<TResult> Invoke<TSource, TResult>(
            this Func<TSource, Output<TResult>> @this,
            Output<TSource> value)
        {
            Require.NotNull(value, "value");

            return value.Bind(@this);
        }

        /*!
         * Named `>=>` in Haskell parlance.
         */
        public static Func<TSource, Output<TResult>> Compose<TSource, TMiddle, TResult>(
            this Func<TSource, Output<TMiddle>> @this,
            Func<TMiddle, Output<TResult>> funM)
        {
            Require.Object(@this);

            return _ => @this.Invoke(_).Bind(funM);
        }

        /*!
         * Named `<=<` in Haskell parlance.
         */
        public static Func<TSource, Output<TResult>> ComposeBack<TSource, TMiddle, TResult>(
            this Func<TMiddle, Output<TResult>> @this,
            Func<TSource, Output<TMiddle>> funM)
        {
            Require.NotNull(funM, "funM");

            return _ => funM.Invoke(_).Bind(@this);
        }

        #endregion
    }
}
