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

[module: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass",
    Justification = "This rule is disabled for files generated by a Text Template.")]
[module: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1403:FileMayOnlyContainASingleNamespace",
    Justification = "This rule is disabled for files generated by a Text Template.")]
    
[module: SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:ElementsMustBeOrderedByAccess",
    Justification = "For files generated by Text Template, we favour T4 readibility over StyleCop rules.")]
[module: SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1505:OpeningCurlyBracketsMustNotBeFollowedByBlankLine",
    Justification = "For files generated by Text Template, we favour T4 readibility over StyleCop rules.")]
[module: SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1507:CodeMustNotContainMultipleBlankLinesInARow",
    Justification = "For files generated by Text Template, we favour T4 readibility over StyleCop rules.")]

[module: SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1210:UsingDirectivesMustBeOrderedAlphabeticallyByNamespace",
    Justification = "The directives are correctly ordered in the T4 source file.")]

namespace Narvalo.Fx {
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using Narvalo;      // For Require
    using Narvalo.Fx;   // For Unit

    /// <summary>
    /// Provides a set of static methods for <see cref="Maybe{T}" />.
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Microsoft.VisualStudio.TextTemplating.12.0", "12.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCode]
    [global::System.Runtime.CompilerServices.CompilerGenerated]
    public static partial class Maybe
    {
        static readonly Maybe<Unit> Unit_ = Create(Narvalo.Fx.Unit.Single);
        static readonly Maybe<Unit> None_ = Maybe<Unit>.None;

        /// <summary>
        /// Returns the unique object of type <c>Maybe&lt;Unit&gt;</c>.
        /// </summary>
        public static Maybe<Unit> Unit { get { return Unit_; } }

        /// <summary>
        /// Returns the zero of type <c>Maybe&lt;Unit&gt;.None</c>.
        /// </summary>
        /// <remarks>
        /// Named <c>mzero</c> in Haskell parlance.
        /// </remarks>
        public static Maybe<Unit> None { get { return None_; } }

        /// <summary>
        /// Returns a new instance of <see cref="Maybe{T}" />.
        /// </summary>
        /// <remarks>
        /// Named <c>return</c> in Haskell parlance.
        /// </remarks>
        public static Maybe<T> Create<T>(T value)
        {
            Contract.Ensures(Contract.Result<Maybe<T>>() != null);

            return Maybe<T>.η(value);
        }
        
        #region Generalisations of list functions (Prelude)

        /// <summary>
        /// Removes one level of structure, projecting its bound value into the outer level.
        /// </summary>
        /// <remarks>
        /// Named <c>join</c> in Haskell parlance.
        /// </remarks>
        public static Maybe<T> Flatten<T>(Maybe<Maybe<T>> square)
        {
            Contract.Requires(square != null);

            return Maybe<T>.μ(square);
        }

        #endregion

        #region Monadic lifting operators (Prelude)

        /// <summary>
        /// Promotes a function to use and return <see cref="Maybe{T}" /> values.
        /// </summary>
        /// <remarks>
        /// Named <c>liftM</c> in Haskell parlance.
        /// </remarks>
        public static Func<Maybe<T>, Maybe<TResult>> Lift<T, TResult>(
            Func<T, TResult> fun)
        {
            return m => {
                Require.NotNull(m, "m"); // Null-reference check: "Select" could have been overriden by a normal method.
                return m.Select(fun);
            };
        }

        /// <summary>
        /// Promotes a function to use and return <see cref="Maybe{T}" /> values, scanning the 
        /// monadic arguments from left to right.
        /// </summary>
        /// <remarks>
        /// Named <c>liftM2</c> in Haskell parlance.
        /// </remarks>
        public static Func<Maybe<T1>, Maybe<T2>, Maybe<TResult>>
            Lift<T1, T2, TResult>(Func<T1, T2, TResult> fun)
        {
            return (m1, m2) => {
                Require.NotNull(m1, "m1"); // Null-reference check: "Zip" could have been overriden by a normal method.
                return m1.Zip(m2, fun);
            };
        }

        /// <summary>
        /// Promotes a function to use and return <see cref="Maybe{T}" /> values, scanning the 
        /// monadic arguments from left to right.
        /// </summary>
        /// <remarks>
        /// Named <c>liftM3</c> in Haskell parlance.
        /// </remarks>
        public static Func<Maybe<T1>, Maybe<T2>, Maybe<T3>, Maybe<TResult>>
            Lift<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> fun)
        {
            return (m1, m2, m3) => {
                Require.NotNull(m1, "m1"); // Null-reference check: "Zip" could have been overriden by a normal method.
                return m1.Zip(m2, m3, fun);
            };
        }

        /// <summary>
        /// Promotes a function to use and return <see cref="Maybe{T}" /> values, scanning the
        /// monadic arguments from left to right.
        /// </summary>
        /// <remarks>
        /// Named <c>liftM4</c> in Haskell parlance.
        /// </remarks>
        public static Func<Maybe<T1>, Maybe<T2>, Maybe<T3>, Maybe<T4>, Maybe<TResult>>
            Lift<T1, T2, T3, T4, TResult>(
            Func<T1, T2, T3, T4, TResult> fun)
        {
            return (m1, m2, m3, m4) => {
                Require.NotNull(m1, "m1"); // Null-reference check: "Zip" could have been overriden by a normal method.
                return m1.Zip(m2, m3, m4, fun);
            };
        }

        /// <summary>
        /// Promotes a function to use and return <see cref="Maybe{T}" /> values, scanning the
        /// monadic arguments from left to right.
        /// </summary>
        /// <remarks>
        /// Named <c>liftM5</c> in Haskell parlance.
        /// </remarks>
        public static Func<Maybe<T1>, Maybe<T2>, Maybe<T3>, Maybe<T4>, Maybe<T5>, Maybe<TResult>>
            Lift<T1, T2, T3, T4, T5, TResult>(
            Func<T1, T2, T3, T4, T5, TResult> fun)
        {
            return (m1, m2, m3, m4, m5) => {
                Require.NotNull(m1, "m1"); // Null-reference check: "Zip" could have been overriden by a normal method.
                return m1.Zip(m2, m3, m4, m5, fun);
            };
        }

        #endregion
    }

    /// <summary>
    /// Provides a set of extension methods for <see cref="Maybe{T}" />.
    /// We use extension methods so that we can override them on a case by case basis.
    /// </summary>
    public static partial class Maybe
    {
        #region Basic Monad functions (Prelude)

        /// <remarks>
        /// Named <c>fmap</c> in Haskell parlance.
        /// </remarks>
        public static Maybe<TResult> Select<TSource, TResult>(
            this Maybe<TSource> @this,
            Func<TSource, TResult> selector)
        {
            Require.Object(@this);
            Require.NotNull(selector, "selector");
            Contract.Ensures(Contract.Result<Maybe<TResult>>() != null);

            return @this.Bind(_ => Maybe.Create(selector.Invoke(_)));
        }

        /// <remarks>
        /// Named <c>&gt;&gt;</c> in Haskell parlance.
        /// </remarks>
        public static Maybe<TResult> Then<TSource, TResult>(
            this Maybe<TSource> @this,
            Maybe<TResult> other)
        {
            Require.Object(@this);
            Contract.Ensures(Contract.Result<Maybe<TResult>>() != null);

            return @this.Bind(_ => other);
        }
        
        #endregion

        #region Generalisations of list functions (Prelude)

        /// <remarks>
        /// Named <c>mfilter</c> in Haskell parlance.
        /// </remarks>
        public static Maybe<TSource> Where<TSource>(
            this Maybe<TSource> @this,
            Func<TSource, bool> predicate)
        {
            Require.Object(@this);
            Require.NotNull(predicate, "predicate");
            Contract.Ensures(Contract.Result<Maybe<TSource>>() != null);

            return @this.Bind(
                _ => predicate.Invoke(_) ? @this : Maybe<TSource>.None);
        }

        /// <remarks>
        /// Named <c>replicateM</c> in Haskell parlance.
        /// </remarks>
        public static Maybe<IEnumerable<TSource>> Repeat<TSource>(
            this Maybe<TSource> @this,
            int count)
        {
            Require.Object(@this); // Null-reference check: "Select" could have been overriden by a normal method.
            Require.GreaterThanOrEqualTo(count, 1, "count");
            Contract.Ensures(Contract.Result<Maybe<IEnumerable<TSource>>>() != null);

            return @this.Select(_ => Enumerable.Repeat(_, count));
        }
        
        #endregion

        #region Conditional execution of monadic expressions (Prelude)

        /// <remarks>
        /// Named <c>guard</c> in Haskell parlance.
        /// </remarks>
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "this",
            Justification = "Extension method intended to be used in a fluent way.")]
        public static Maybe<Unit> Guard<TSource>(
            this Maybe<TSource> @this,
            bool predicate)
        {
            return predicate ? Maybe.Unit : Maybe.None;
        }

        /// <remarks>
        /// Named <c>when</c> in Haskell parlance.
        /// </remarks>
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "this",
            Justification = "Extension method intended to be used in a fluent way.")]
        public static Maybe<Unit> When<TSource>(
            this Maybe<TSource> @this, 
            bool predicate, 
            Action action)
        {
            Require.NotNull(action, "action");

            if (predicate) {
                action.Invoke();
            }

            return Maybe.Unit;
        }

        /// <remarks>
        /// Named <c>unless</c> in Haskell parlance.
        /// </remarks>
        public static Maybe<Unit> Unless<TSource>(
            this Maybe<TSource> @this,
            bool predicate,
            Action action)
        {
            Require.Object(@this);
            Contract.Requires(action != null);

            return @this.When(!predicate, action);
        }

        #endregion

        #region Monadic lifting operators (Prelude)

        /// <see cref="Lift{T1, T2, T3}" />
        public static Maybe<TResult> Zip<TFirst, TSecond, TResult>(
            this Maybe<TFirst> @this,
            Maybe<TSecond> second,
            Func<TFirst, TSecond, TResult> resultSelector)
        {
            Require.Object(@this);
            Require.NotNull(second, "second"); // Null-reference check: "Select" could have been overriden by a normal method.
            Require.NotNull(resultSelector, "resultSelector");

            return @this.Bind(v1 => second.Select(v2 => resultSelector.Invoke(v1, v2)));
        }

        /// <see cref="Lift{T1, T2, T3, T4}" />
        public static Maybe<TResult> Zip<T1, T2, T3, TResult>(
            this Maybe<T1> @this,
            Maybe<T2> second,
            Maybe<T3> third,
            Func<T1, T2, T3, TResult> resultSelector)
        {
            Require.Object(@this);
            Require.NotNull(second, "second"); // Null-reference check: "Zip" could have been overriden by a normal method.
            Require.NotNull(resultSelector, "resultSelector");

            Func<T1, Maybe<TResult>> g
                = t1 => second.Zip(third, (t2, t3) => resultSelector.Invoke(t1, t2, t3));

            return @this.Bind(g);
        }

        /// <see cref="Lift{T1, T2, T3, T4, T5}" />
        public static Maybe<TResult> Zip<T1, T2, T3, T4, TResult>(
             this Maybe<T1> @this,
             Maybe<T2> second,
             Maybe<T3> third,
             Maybe<T4> fourth,
             Func<T1, T2, T3, T4, TResult> resultSelector)
        {
            Require.Object(@this);
            Require.NotNull(second, "second"); // Null-reference check: "Zip" could have been overriden by a normal method.
            Require.NotNull(resultSelector, "resultSelector");

            Func<T1, Maybe<TResult>> g
                = t1 => second.Zip(
                    third,
                    fourth, 
                    (t2, t3, t4) => resultSelector.Invoke(t1, t2, t3, t4));

            return @this.Bind(g);
        }

        /// <see cref="Lift{T1, T2, T3, T4, T5, T6}" />
        public static Maybe<TResult> Zip<T1, T2, T3, T4, T5, TResult>(
            this Maybe<T1> @this,
            Maybe<T2> second,
            Maybe<T3> third,
            Maybe<T4> fourth,
            Maybe<T5> fifth,
            Func<T1, T2, T3, T4, T5, TResult> resultSelector)
        {
            Require.Object(@this);
            Require.NotNull(second, "second"); // Null-reference check: "Zip" could have been overriden by a normal method.
            Require.NotNull(resultSelector, "resultSelector");

            Func<T1, Maybe<TResult>> g
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
        public static Maybe<TResult> SelectMany<TSource, TMiddle, TResult>(
            this Maybe<TSource> @this,
            Func<TSource, Maybe<TMiddle>> valueSelectorM,
            Func<TSource, TMiddle, TResult> resultSelector)
        {
            Require.Object(@this);
            Require.NotNull(valueSelectorM, "valueSelectorM");
            Require.NotNull(resultSelector, "resultSelector");

            return @this.Bind(
                _ => valueSelectorM.Invoke(_).Select(
                    middle => resultSelector.Invoke(_, middle)));
        }

        public static Maybe<TResult> Join<TSource, TInner, TKey, TResult>(
            this Maybe<TSource> @this,
            Maybe<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, TInner, TResult> resultSelector)
        {
            Require.Object(@this); // Null-reference check: "Join" could have been overriden by a normal method.
            Contract.Requires(inner != null);
            Contract.Requires(outerKeySelector != null);
            Contract.Requires(innerKeySelector != null);
            Contract.Requires(resultSelector != null);

            return @this.Join(
                inner,
                outerKeySelector,
                innerKeySelector,
                resultSelector,
                EqualityComparer<TKey>.Default);
        }

        public static Maybe<TResult> GroupJoin<TSource, TInner, TKey, TResult>(
            this Maybe<TSource> @this,
            Maybe<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, Maybe<TInner>, TResult> resultSelector)
        {
            Require.Object(@this); // Null-reference check: "GroupJoin" could have been overriden by a normal method.
            Contract.Requires(inner != null);
            Contract.Requires(outerKeySelector != null);
            Contract.Requires(innerKeySelector != null);
            Contract.Requires(resultSelector != null);

            return @this.GroupJoin(
                inner, 
                outerKeySelector,
                innerKeySelector, 
                resultSelector, 
                EqualityComparer<TKey>.Default);
        }

        #endregion
        
        #region Linq extensions

        public static Maybe<TResult> Join<TSource, TInner, TKey, TResult>(
            this Maybe<TSource> @this,
            Maybe<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, TInner, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
        {
            Contract.Requires(@this != null);
            Contract.Requires(inner != null);
            Contract.Requires(outerKeySelector != null);
            Contract.Requires(innerKeySelector != null);
            Contract.Requires(resultSelector != null);

            return JoinCore_(
                @this,
                inner,
                outerKeySelector,
                innerKeySelector,
                resultSelector,
                comparer ?? EqualityComparer<TKey>.Default);
        }

        public static Maybe<TResult> GroupJoin<TSource, TInner, TKey, TResult>(
            this Maybe<TSource> @this,
            Maybe<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, Maybe<TInner>, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
        {
            Contract.Requires(@this != null);
            Contract.Requires(inner != null);
            Contract.Requires(outerKeySelector != null);
            Contract.Requires(innerKeySelector != null);
            Contract.Requires(resultSelector != null);

            return GroupJoinCore_(
                @this,
                inner,
                outerKeySelector,
                innerKeySelector,
                resultSelector,
                comparer ?? EqualityComparer<TKey>.Default);
        }
        
        static Maybe<TResult> JoinCore_<TSource, TInner, TKey, TResult>(
            Maybe<TSource> seq,
            Maybe<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, TInner, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
        {
            Require.NotNull(seq, "seq");
            Require.NotNull(resultSelector, "resultSelector");
            Contract.Requires(inner != null);
            Contract.Requires(outerKeySelector != null);
            Contract.Requires(innerKeySelector != null);
            Contract.Requires(comparer != null);
            
            var keyLookupM = GetKeyLookup_(inner, outerKeySelector, innerKeySelector, comparer);

            return from outerValue in seq
                   from innerValue in keyLookupM.Invoke(outerValue).Then(inner)
                   select resultSelector.Invoke(outerValue, innerValue);
        }
        
        static Maybe<TResult> GroupJoinCore_<TSource, TInner, TKey, TResult>(
            Maybe<TSource> seq,
            Maybe<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, Maybe<TInner>, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
        {
            Require.NotNull(seq, "seq");
            Require.NotNull(resultSelector, "resultSelector");
            Contract.Requires(inner != null);
            Contract.Requires(outerKeySelector != null);
            Contract.Requires(innerKeySelector != null);
            Contract.Requires(comparer != null);

            var keyLookupM = GetKeyLookup_(inner, outerKeySelector, innerKeySelector, comparer);

            return from outerValue in seq
                   select resultSelector.Invoke(outerValue, keyLookupM.Invoke(outerValue).Then(inner));
        }

        static Func<TSource, Maybe<TKey>> GetKeyLookup_<TSource, TInner, TKey>(
            Maybe<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            IEqualityComparer<TKey> comparer)
        {
            Require.NotNull(inner, "inner"); // Null-reference check: "Select" could have been overriden by a normal method.
            Require.NotNull(outerKeySelector, "outerKeySelector");
            Require.NotNull(comparer, "comparer");
            Contract.Requires(innerKeySelector != null);

            return source => {
                TKey outerKey = outerKeySelector.Invoke(source);
            
                return inner.Select(innerKeySelector).Where(_ => comparer.Equals(_, outerKey));
            };
        }

        #endregion

        #region Non-standard extensions
        
        public static Maybe<TResult> Coalesce<TSource, TResult>(
            this Maybe<TSource> @this,
            Func<TSource, bool> predicate,
            Maybe<TResult> then,
            Maybe<TResult> otherwise)
        {
            Require.Object(@this);
            Require.NotNull(predicate, "predicate");

            return @this.Bind(_ => predicate.Invoke(_) ? then : otherwise);
        }

        public static Maybe<TResult> Then<TSource, TResult>(
            this Maybe<TSource> @this,
            Func<TSource, bool> predicate,
            Maybe<TResult> other)
        {
            Require.Object(@this); // Null-reference check: "Coalesce" could have been overriden by a normal method.
            Contract.Requires(predicate != null);

            return @this.Coalesce(predicate, other, Maybe<TResult>.None);
        }

        public static Maybe<TResult> Otherwise<TSource, TResult>(
            this Maybe<TSource> @this,
            Func<TSource, bool> predicate,
            Maybe<TResult> other)
        {
            Require.Object(@this); // Null-reference check: "Coalesce" could have been overriden by a normal method.
            Contract.Requires(predicate != null);

            return @this.Coalesce(predicate, Maybe<TResult>.None, other);
        }

        public static Maybe<TSource> Run<TSource>(
            this Maybe<TSource> @this,
            Action<TSource> action)
        {
            Require.Object(@this);
            Require.NotNull(action, "action");

            return @this.Bind(_ => { action.Invoke(_); return @this; });
        }

        public static Maybe<TSource> OnNone<TSource>(
            this Maybe<TSource> @this,
            Action action)
        {
            Require.Object(@this); // Null-reference check: "Then" could have been overriden by a normal method.
            Require.NotNull(action, "action");

            return @this.Then(Maybe.Unit).Run(_ => action.Invoke()).Then(@this);
        }

        #endregion
    }

    /// <summary>
    /// Extensions methods for <c>Func&lt;TSource, Maybe&lt;TResult&gt;&gt;</c>.
    /// </summary>
    public static partial class FuncExtensions
    {
        #region Basic Monad functions (Prelude)

        /// <remarks>
        /// Named <c>=&lt;&lt;</c> in Haskell parlance.
        /// </remarks>
        public static Maybe<TResult> Invoke<TSource, TResult>(
            this Func<TSource, Maybe<TResult>> @this,
            Maybe<TSource> value)
        {
            Require.NotNull(value, "value");
            Contract.Requires(@this != null);
            Contract.Ensures(Contract.Result<Maybe<TResult>>() != null);

            return value.Bind(@this);
        }

        /// <remarks>
        /// Named <c>&gt;=&gt;</c> in Haskell parlance.
        /// </remarks>
        public static Func<TSource, Maybe<TResult>> Compose<TSource, TMiddle, TResult>(
            this Func<TSource, Maybe<TMiddle>> @this,
            Func<TMiddle, Maybe<TResult>> funM)
        {
            Require.Object(@this);
            Contract.Requires(funM != null);

            return _ => @this.Invoke(_).Bind(funM);
        }

        /// <remarks>
        /// Named <c>&lt;=&lt;</c> in Haskell parlance.
        /// </remarks>
        public static Func<TSource, Maybe<TResult>> ComposeBack<TSource, TMiddle, TResult>(
            this Func<TMiddle, Maybe<TResult>> @this,
            Func<TSource, Maybe<TMiddle>> funM)
        {
            Require.NotNull(funM, "funM");
            Contract.Requires(@this != null);

            return _ => funM.Invoke(_).Bind(@this);
        }

        #endregion
    }
}
