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

namespace Playground.Edu.Monads.Samples 
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using Narvalo;      // For Require
    using Narvalo.Fx;   // For Unit

    /// <summary>
    /// Provides a set of static and extension methods for <see cref="MonadValue{T}" />.
    /// </summary>
    /// <remarks>
    /// Sometimes we prefer extension to static methods to be able to locally override them.
    /// </remarks>
    [global::System.CodeDom.Compiler.GeneratedCode("Microsoft.VisualStudio.TextTemplating.12.0", "12.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCode]
    [global::System.Runtime.CompilerServices.CompilerGenerated]
    public static partial class MonadValue
    {
        private static readonly MonadValue<Unit> s_Unit = Return(Narvalo.Fx.Unit.Single);
        private static readonly MonadValue<Unit> s_None = MonadValue<Unit>.None;

        /// <summary>
        /// Gets the unique object of type <c>MonadValue&lt;Unit&gt;</c>.
        /// </summary>
        /// <value>The unique object of type <c>MonadValue&lt;Unit&gt;</c>.</value>
        public static MonadValue<Unit> Unit { get { return s_Unit; } }

        /// <summary>
        /// Gets the zero for <see cref="MonadValue{T}"/>.
        /// </summary>
        /// <remarks>
        /// Named <c>mzero</c> in Haskell parlance.
        /// </remarks>
        /// <value>The zero for <see cref="MonadValue{T}"/>.</value>
        public static MonadValue<Unit> None { get { return s_None; } }

        /// <summary>
        /// Obtains an instance of the <see cref="MonadValue{T}"/> class for the specified value.
        /// </summary>
        /// <remarks>
        /// Named <c>return</c> in Haskell parlance.
        /// </remarks>
        /// <typeparam name="T">The underlying type of the <paramref name="value"/>.</typeparam>
        /// <param name="value">A value to be wrapped into a <see cref="MonadValue{T}"/> object.</param>
        /// <returns>An instance of the <see cref="MonadValue{T}"/> class for the specified value.</returns>
        public static MonadValue<T> Return<T>(T value)
            where T : struct
        {

            return MonadValue<T>.η(value);
        }
        
        #region Generalisations of list functions (Prelude)

        /// <summary>
        /// Removes one level of structure, projecting its bound value into the outer level.
        /// </summary>
        /// <remarks>
        /// Named <c>join</c> in Haskell parlance.
        /// </remarks>
        public static MonadValue<T> Flatten<T>(MonadValue<MonadValue<T>> square)
            where T : struct
        {

            return MonadValue<T>.μ(square);
        }

        #endregion

        #region Monadic lifting operators (Prelude)

        /// <summary>
        /// Promotes a function to use and return <see cref="MonadValue{T}" /> values.
        /// </summary>
        /// <remarks>
        /// Named <c>liftM</c> in Haskell parlance.
        /// </remarks>
        public static Func<MonadValue<T>, MonadValue<TResult>> Lift<T, TResult>(
            Func<T, TResult> fun)
            where T : struct
            where TResult : struct
        {
            Contract.Ensures(Contract.Result<Func<MonadValue<T>, MonadValue<TResult>>>() != null);

            return m => {
                return m.Select(fun);
            };
        }

        /// <summary>
        /// Promotes a function to use and return <see cref="MonadValue{T}" /> values, scanning the 
        /// monadic arguments from left to right.
        /// </summary>
        /// <remarks>
        /// Named <c>liftM2</c> in Haskell parlance.
        /// </remarks>
        public static Func<MonadValue<T1>, MonadValue<T2>, MonadValue<TResult>>
            Lift<T1, T2, TResult>(Func<T1, T2, TResult> fun)
            where T1 : struct
            where T2 : struct
            where TResult : struct
        {
            Contract.Ensures(Contract.Result<Func<MonadValue<T1>, MonadValue<T2>, MonadValue<TResult>>>() != null);

            return (m1, m2) => {
                return m1.Zip(m2, fun);
            };
        }

        /// <summary>
        /// Promotes a function to use and return <see cref="MonadValue{T}" /> values, scanning the 
        /// monadic arguments from left to right.
        /// </summary>
        /// <remarks>
        /// Named <c>liftM3</c> in Haskell parlance.
        /// </remarks>
        public static Func<MonadValue<T1>, MonadValue<T2>, MonadValue<T3>, MonadValue<TResult>>
            Lift<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> fun)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where TResult : struct
        {
            Contract.Ensures(Contract.Result<Func<MonadValue<T1>, MonadValue<T2>, MonadValue<T3>, MonadValue<TResult>>>() != null);

            return (m1, m2, m3) => {
                return m1.Zip(m2, m3, fun);
            };
        }

        /// <summary>
        /// Promotes a function to use and return <see cref="MonadValue{T}" /> values, scanning the
        /// monadic arguments from left to right.
        /// </summary>
        /// <remarks>
        /// Named <c>liftM4</c> in Haskell parlance.
        /// </remarks>
        public static Func<MonadValue<T1>, MonadValue<T2>, MonadValue<T3>, MonadValue<T4>, MonadValue<TResult>>
            Lift<T1, T2, T3, T4, TResult>(
            Func<T1, T2, T3, T4, TResult> fun)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where TResult : struct
        {
            Contract.Ensures(Contract.Result<Func<MonadValue<T1>, MonadValue<T2>, MonadValue<T3>, MonadValue<T4>, MonadValue<TResult>>>() != null);
            
            return (m1, m2, m3, m4) => {
                return m1.Zip(m2, m3, m4, fun);
            };
        }

        /// <summary>
        /// Promotes a function to use and return <see cref="MonadValue{T}" /> values, scanning the
        /// monadic arguments from left to right.
        /// </summary>
        /// <remarks>
        /// Named <c>liftM5</c> in Haskell parlance.
        /// </remarks>
        public static Func<MonadValue<T1>, MonadValue<T2>, MonadValue<T3>, MonadValue<T4>, MonadValue<T5>, MonadValue<TResult>>
            Lift<T1, T2, T3, T4, T5, TResult>(
            Func<T1, T2, T3, T4, T5, TResult> fun)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where TResult : struct
        {
            Contract.Ensures(Contract.Result<Func<MonadValue<T1>, MonadValue<T2>, MonadValue<T3>, MonadValue<T4>, MonadValue<T5>, MonadValue<TResult>>>() != null);
       
            return (m1, m2, m3, m4, m5) => {
                return m1.Zip(m2, m3, m4, m5, fun);
            };
        }

        #endregion
    }

    // Implements core Monad extension methods.
    public static partial class MonadValue
    {
        #region Basic Monad functions (Prelude)

        /// <remarks>
        /// Named <c>fmap</c> in Haskell parlance.
        /// </remarks>
        public static MonadValue<TResult> Select<TSource, TResult>(
            this MonadValue<TSource> @this,
            Func<TSource, TResult> selector)
            where TSource : struct
            where TResult : struct
        {
            Require.NotNull(selector, "selector");

            return @this.Bind(_ => MonadValue.Return(selector.Invoke(_)));
        }

        /// <remarks>
        /// Named <c>&gt;&gt;</c> in Haskell parlance.
        /// </remarks>
        public static MonadValue<TResult> Then<TSource, TResult>(
            this MonadValue<TSource> @this,
            MonadValue<TResult> other)
            where TSource : struct
            where TResult : struct
        {

            return @this.Bind(_ => other);
        }
        
        #endregion

        #region Generalisations of list functions (Prelude)

        /// <remarks>
        /// Named <c>mfilter</c> in Haskell parlance.
        /// </remarks>
        public static MonadValue<TSource> Where<TSource>(
            this MonadValue<TSource> @this,
            Func<TSource, bool> predicate)
            where TSource : struct
        {
            Require.NotNull(predicate, "predicate");

            return @this.Bind(
                _ => predicate.Invoke(_) ? @this : MonadValue<TSource>.None);
        }
        
        #endregion

        #region Conditional execution of monadic expressions (Prelude)

        /// <remarks>
        /// Named <c>guard</c> in Haskell parlance.
        /// </remarks>
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "this",
            Justification = "Extension method intended to be used in a fluent way.")]
        public static MonadValue<Unit> Guard<TSource>(
            this MonadValue<TSource> @this,
            bool predicate)
            where TSource : struct
        {

            return predicate ? MonadValue.Unit : MonadValue.None;
        }

        /// <remarks>
        /// Named <c>when</c> in Haskell parlance.
        /// </remarks>
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "this",
            Justification = "Extension method intended to be used in a fluent way.")]
        public static MonadValue<Unit> When<TSource>(
            this MonadValue<TSource> @this, 
            bool predicate, 
            Action action)
            where TSource : struct
        {
            Require.NotNull(action, "action");

            if (predicate) {
                action.Invoke();
            }

            return MonadValue.Unit;
        }

        /// <remarks>
        /// Named <c>unless</c> in Haskell parlance.
        /// </remarks>
        public static MonadValue<Unit> Unless<TSource>(
            this MonadValue<TSource> @this,
            bool predicate,
            Action action)
            where TSource : struct
        {
            Contract.Requires(action != null);

            return @this.When(!predicate, action);
        }

        #endregion

        #region Monadic lifting operators (Prelude)

        /// <see cref="Lift{T1, T2, T3}" />
        public static MonadValue<TResult> Zip<TFirst, TSecond, TResult>(
            this MonadValue<TFirst> @this,
            MonadValue<TSecond> second,
            Func<TFirst, TSecond, TResult> resultSelector)
            where TFirst : struct
            where TSecond : struct
            where TResult : struct
        {
            Require.NotNull(resultSelector, "resultSelector");

            return @this.Bind(v1 => second.Select(v2 => resultSelector.Invoke(v1, v2)));
        }

        /// <see cref="Lift{T1, T2, T3, T4}" />
        public static MonadValue<TResult> Zip<T1, T2, T3, TResult>(
            this MonadValue<T1> @this,
            MonadValue<T2> second,
            MonadValue<T3> third,
            Func<T1, T2, T3, TResult> resultSelector)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where TResult : struct
        {
            Require.NotNull(resultSelector, "resultSelector");

            Func<T1, MonadValue<TResult>> g
                = t1 => second.Zip(third, (t2, t3) => resultSelector.Invoke(t1, t2, t3));

            return @this.Bind(g);
        }

        /// <see cref="Lift{T1, T2, T3, T4, T5}" />
        public static MonadValue<TResult> Zip<T1, T2, T3, T4, TResult>(
             this MonadValue<T1> @this,
             MonadValue<T2> second,
             MonadValue<T3> third,
             MonadValue<T4> fourth,
             Func<T1, T2, T3, T4, TResult> resultSelector)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where TResult : struct
        {
            Require.NotNull(resultSelector, "resultSelector");

            Func<T1, MonadValue<TResult>> g
                = t1 => second.Zip(
                    third,
                    fourth, 
                    (t2, t3, t4) => resultSelector.Invoke(t1, t2, t3, t4));

            return @this.Bind(g);
        }

        /// <see cref="Lift{T1, T2, T3, T4, T5, T6}" />
        public static MonadValue<TResult> Zip<T1, T2, T3, T4, T5, TResult>(
            this MonadValue<T1> @this,
            MonadValue<T2> second,
            MonadValue<T3> third,
            MonadValue<T4> fourth,
            MonadValue<T5> fifth,
            Func<T1, T2, T3, T4, T5, TResult> resultSelector)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where TResult : struct
        {
            Require.NotNull(resultSelector, "resultSelector");

            Func<T1, MonadValue<TResult>> g
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
        public static MonadValue<TResult> SelectMany<TSource, TMiddle, TResult>(
            this MonadValue<TSource> @this,
            Func<TSource, MonadValue<TMiddle>> valueSelectorM,
            Func<TSource, TMiddle, TResult> resultSelector)
            where TSource : struct
            where TMiddle : struct
            where TResult : struct
        {
            Require.NotNull(valueSelectorM, "valueSelectorM");
            Require.NotNull(resultSelector, "resultSelector");

            return @this.Bind(
                _ => valueSelectorM.Invoke(_).Select(
                    middle => resultSelector.Invoke(_, middle)));
        }

        public static MonadValue<TResult> Join<TSource, TInner, TKey, TResult>(
            this MonadValue<TSource> @this,
            MonadValue<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, TInner, TResult> resultSelector)
            where TSource : struct
            where TInner : struct
            where TKey : struct
            where TResult : struct
        {
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

        public static MonadValue<TResult> GroupJoin<TSource, TInner, TKey, TResult>(
            this MonadValue<TSource> @this,
            MonadValue<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, MonadValue<TInner>, TResult> resultSelector)
            where TSource : struct
            where TInner : struct
            where TKey : struct
            where TResult : struct
        {
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
        
        #region LINQ extensions

        public static MonadValue<TResult> Join<TSource, TInner, TKey, TResult>(
            this MonadValue<TSource> @this,
            MonadValue<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, TInner, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
            where TSource : struct
            where TInner : struct
            where TKey : struct
            where TResult : struct
        {
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

        public static MonadValue<TResult> GroupJoin<TSource, TInner, TKey, TResult>(
            this MonadValue<TSource> @this,
            MonadValue<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, MonadValue<TInner>, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
            where TSource : struct
            where TInner : struct
            where TKey : struct
            where TResult : struct
        {
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
        
        private static MonadValue<TResult> JoinCore_<TSource, TInner, TKey, TResult>(
            MonadValue<TSource> seq,
            MonadValue<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, TInner, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
            where TSource : struct
            where TInner : struct
            where TKey : struct
            where TResult : struct
        {
            Require.NotNull(resultSelector, "resultSelector");
            Contract.Requires(outerKeySelector != null);
            Contract.Requires(innerKeySelector != null);
            Contract.Requires(comparer != null);
            
            var keyLookupM = GetKeyLookup_(inner, outerKeySelector, innerKeySelector, comparer);

            return from outerValue in seq
                   from innerValue in keyLookupM.Invoke(outerValue).Then(inner)
                   select resultSelector.Invoke(outerValue, innerValue);
        }
        
        private static MonadValue<TResult> GroupJoinCore_<TSource, TInner, TKey, TResult>(
            MonadValue<TSource> seq,
            MonadValue<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, MonadValue<TInner>, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
            where TSource : struct
            where TInner : struct
            where TKey : struct
            where TResult : struct
        {
            Require.NotNull(resultSelector, "resultSelector");
            Contract.Requires(outerKeySelector != null);
            Contract.Requires(innerKeySelector != null);
            Contract.Requires(comparer != null);

            var keyLookupM = GetKeyLookup_(inner, outerKeySelector, innerKeySelector, comparer);

            return from outerValue in seq
                   select resultSelector.Invoke(outerValue, keyLookupM.Invoke(outerValue).Then(inner));
        }

        private static Func<TSource, MonadValue<TKey>> GetKeyLookup_<TSource, TInner, TKey>(
            MonadValue<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            IEqualityComparer<TKey> comparer)
            where TSource : struct
            where TInner : struct
            where TKey : struct
        {
            Require.NotNull(outerKeySelector, "outerKeySelector");
            Require.NotNull(comparer, "comparer");
            Contract.Requires(innerKeySelector != null);
            Contract.Ensures(Contract.Result<Func<TSource, MonadValue<TKey>>>() != null);

            return source => {
                TKey outerKey = outerKeySelector.Invoke(source);
            
                return inner.Select(innerKeySelector).Where(_ => comparer.Equals(_, outerKey));
            };
        }

        #endregion

        #region Non-standard extensions
        
        public static MonadValue<TResult> Coalesce<TSource, TResult>(
            this MonadValue<TSource> @this,
            Func<TSource, bool> predicate,
            MonadValue<TResult> then,
            MonadValue<TResult> otherwise)
            where TSource : struct
            where TResult : struct
        {
            Require.NotNull(predicate, "predicate");

            return @this.Bind(_ => predicate.Invoke(_) ? then : otherwise);
        }

        public static MonadValue<TResult> Then<TSource, TResult>(
            this MonadValue<TSource> @this,
            Func<TSource, bool> predicate,
            MonadValue<TResult> other)
            where TSource : struct
            where TResult : struct
        {
            Contract.Requires(predicate != null);

            return @this.Coalesce(predicate, other, MonadValue<TResult>.None);
        }

        public static MonadValue<TResult> Otherwise<TSource, TResult>(
            this MonadValue<TSource> @this,
            Func<TSource, bool> predicate,
            MonadValue<TResult> other)
            where TSource : struct
            where TResult : struct
        {
            Contract.Requires(predicate != null);

            return @this.Coalesce(predicate, MonadValue<TResult>.None, other);
        }

        public static MonadValue<TSource> Run<TSource>(
            this MonadValue<TSource> @this,
            Action<TSource> action)
            where TSource : struct
        {
            Require.NotNull(action, "action");

            return @this.Bind(_ => { action.Invoke(_); return @this; });
        }

        public static MonadValue<TSource> OnNone<TSource>(
            this MonadValue<TSource> @this,
            Action action)
            where TSource : struct
        {
            Require.NotNull(action, "action");

            return @this.Then(MonadValue.Unit).Run(_ => action.Invoke()).Then(@this);
        }

        #endregion
    }

    /// <summary>
    /// Provides extension methods for <c>Func&lt;TSource, MonadValue&lt;TResult&gt;&gt;</c>.
    /// </summary>
    public static partial class FuncExtensions
    {
        #region Basic Monad functions (Prelude)

        /// <remarks>
        /// Named <c>=&lt;&lt;</c> in Haskell parlance.
        /// </remarks>
        public static MonadValue<TResult> Invoke<TSource, TResult>(
            this Func<TSource, MonadValue<TResult>> @this,
            MonadValue<TSource> value)
            where TSource : struct
            where TResult : struct
        {
            Contract.Requires(@this != null);

            return value.Bind(@this);
        }

        /// <remarks>
        /// Named <c>&gt;=&gt;</c> in Haskell parlance.
        /// </remarks>
        public static Func<TSource, MonadValue<TResult>> Compose<TSource, TMiddle, TResult>(
            this Func<TSource, MonadValue<TMiddle>> @this,
            Func<TMiddle, MonadValue<TResult>> funM)
            where TSource : struct
            where TMiddle : struct
            where TResult : struct
        {
            Require.Object(@this);
            Contract.Requires(funM != null);
            Contract.Ensures(Contract.Result<Func<TSource, MonadValue<TResult>>>() != null);

            return _ => @this.Invoke(_).Bind(funM);
        }

        /// <remarks>
        /// Named <c>&lt;=&lt;</c> in Haskell parlance.
        /// </remarks>
        public static Func<TSource, MonadValue<TResult>> ComposeBack<TSource, TMiddle, TResult>(
            this Func<TMiddle, MonadValue<TResult>> @this,
            Func<TSource, MonadValue<TMiddle>> funM)
            where TSource : struct
            where TMiddle : struct
            where TResult : struct
        {
            Require.NotNull(funM, "funM");
            Contract.Requires(@this != null);
            Contract.Ensures(Contract.Result<Func<TSource, MonadValue<TResult>>>() != null);

            return _ => funM.Invoke(_).Bind(@this);
        }

        #endregion
    }
}

namespace Playground.Edu.Monads.Samples 
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using Narvalo;      // For Require
    using Narvalo.Fx;   // For Unit
    using Playground.Edu.Monads.Samples;
    using Playground.Edu.Monads.Samples.Internal;

    /// <summary>
    /// Provides extension methods for <c>IEnumerable&lt;MonadValue&lt;T&gt;&gt;</c>.
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Microsoft.VisualStudio.TextTemplating.12.0", "12.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCode]
    [global::System.Runtime.CompilerServices.CompilerGenerated]
    public static partial class EnumerableMonadValueExtensions
    {
        #region Basic Monad functions (Prelude)

        
        #endregion

        #region Generalisations of list functions (Prelude)

        /// <remarks>
        /// Named <c>msum</c> in Haskell parlance.
        /// </remarks>
        public static MonadValue<TSource> Sum<TSource>(
            this IEnumerable<MonadValue<TSource>> @this)
            where TSource : struct
        {
            // No need to check for null-reference, "SumCore" is an extension method.
            Contract.Requires(@this != null);

            return @this.SumCore();
        }

        #endregion
    }

    /// <summary>
    /// Provides extension methods for <see cref="IEnumerable{T}"/>.
    /// </summary>
    public static partial class EnumerableExtensions
    {
        #region Basic Monad functions (Prelude)

        
        #endregion

        #region Generalisations of list functions (Prelude)

        /// <remarks>
        /// Named <c>filterM</c> in Haskell parlance.
        /// </remarks>
        public static IEnumerable<TSource> Filter<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, MonadValue<bool>> predicateM)
            where TSource : struct
        {
            // No need to check for null-reference, "FilterCore" is an extension method. 
            Contract.Requires(@this != null);
            Contract.Requires(predicateM != null);
            Contract.Ensures(Contract.Result<IEnumerable<TSource>>() != null);

            return @this.FilterCore(predicateM);
        }


        /// <remarks>
        /// Named <c>foldM</c> in Haskell parlance.
        /// </remarks>
        public static MonadValue<TAccumulate> Fold<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, MonadValue<TAccumulate>> accumulatorM)
            where TSource : struct
            where TAccumulate : struct
        {
            // No need to check for null-reference, "FoldCore" is an extension method. 
            Contract.Requires(@this != null);
            Contract.Requires(accumulatorM != null);

            return @this.FoldCore(seed, accumulatorM);
        }

        #endregion
        
        #region Aggregate Operators

        public static MonadValue<TAccumulate> FoldBack<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, MonadValue<TAccumulate>> accumulatorM)
            where TSource : struct
            where TAccumulate : struct
        {
            // No need to check for null-reference, "FoldBackCore" is an extension method. 
            Contract.Requires(@this != null);
            Contract.Requires(accumulatorM != null);

            return @this.FoldBackCore(seed, accumulatorM);
        }

        public static MonadValue<TSource> Reduce<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, MonadValue<TSource>> accumulatorM)
            where TSource : struct
        {
            // No need to check for null-reference, "ReduceCore" is an extension method. 
            Contract.Requires(@this != null);
            Contract.Requires(accumulatorM != null);
            
            return @this.ReduceCore(accumulatorM);
        }

        public static MonadValue<TSource> ReduceBack<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, MonadValue<TSource>> accumulatorM)
            where TSource : struct
        {
            // No need to check for null-reference, "ReduceBackCore" is an extension method. 
            Contract.Requires(@this != null);
            Contract.Requires(accumulatorM != null);

            return @this.ReduceBackCore(accumulatorM);
        }

        #endregion

        #region Catamorphisms

        public static MonadValue<TAccumulate> Fold<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, MonadValue<TAccumulate>> accumulatorM,
            Func<MonadValue<TAccumulate>, bool> predicate)
            where TSource : struct
            where TAccumulate : struct
        {
            // No need to check for null-reference, "FoldCore" is an extension method. 
            Contract.Requires(@this != null);
            Contract.Requires(accumulatorM != null);
            Contract.Requires(predicate != null);

            return @this.FoldCore(seed, accumulatorM, predicate);
        }
        
        public static MonadValue<TSource> Reduce<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, MonadValue<TSource>> accumulatorM,
            Func<MonadValue<TSource>, bool> predicate)
            where TSource : struct
        {
            // No need to check for null-reference, "ReduceCore" is an extension method. 
            Contract.Requires(@this != null);
            Contract.Requires(accumulatorM != null);
            Contract.Requires(predicate != null);

            return @this.ReduceCore(accumulatorM, predicate);
        }

        #endregion
    }
}

namespace Playground.Edu.Monads.Samples.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using Narvalo;      // For Require
    using Narvalo.Fx;   // For Unit
    using Playground.Edu.Monads.Samples;

    /// <summary>
    /// Provides extension methods for <c>IEnumerable&lt;MonadValue&lt;T&gt;&gt;</c>.
    /// </summary>
    internal static partial class EnumerableMonadValueExtensions
    {

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "This method has been localy overriden.")]
        internal static MonadValue<TSource> SumCore<TSource>(
            this IEnumerable<MonadValue<TSource>> @this)
            where TSource : struct
        {
            // No need to check for null-reference, "Enumerable.Aggregate" is an extension method. 
            Contract.Requires(@this != null);

            return @this.Aggregate(MonadValue<TSource>.None, (m, n) => m.OrElse(n));
        }
    }

    /// <summary>
    /// Provides extension methods for <see cref="IEnumerable{T}"/>.
    /// </summary>
    internal static partial class EnumerableExtensions
    {

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "This method has been localy overriden.")]
        internal static IEnumerable<TSource> FilterCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, MonadValue<bool>> predicateM)
            where TSource : struct
        {
            Require.Object(@this);
            Contract.Ensures(Contract.Result<IEnumerable<TSource>>() != null);

            // NB: Haskell uses tail recursion, we don't.
            var list = new List<TSource>();

            foreach (var item in @this) {
                var m = predicateM.Invoke(item);

                if (m != null) {
                    m.Run(_ => {
                        if (_ == true) {
                            list.Add(item);
                        }
                    });
                }
            }

            return list;
        }


        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "This method has been localy overriden.")]
        internal static MonadValue<TAccumulate> FoldCore<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, MonadValue<TAccumulate>> accumulatorM)
            where TSource : struct
            where TAccumulate : struct
        {
            Require.Object(@this);

            MonadValue<TAccumulate> result = MonadValue.Return(seed);

            foreach (TSource item in @this) {
                result = result.Bind(_ => accumulatorM.Invoke(_, item));
            }

            return result;
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "This method has been localy overriden.")]
        internal static MonadValue<TAccumulate> FoldBackCore<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, MonadValue<TAccumulate>> accumulatorM)
            where TSource : struct
            where TAccumulate : struct
        {
            // No need to check for null-reference, "Enumerable.Reverse" is an extension method. 
            Contract.Requires(@this != null);
            Contract.Requires(accumulatorM != null);

            return @this.Reverse().AssumeNotNull().Fold(seed, accumulatorM);
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "This method has been localy overriden.")]
        internal static MonadValue<TSource> ReduceCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, MonadValue<TSource>> accumulatorM)
            where TSource : struct
        {
            Require.Object(@this);
            Require.NotNull(accumulatorM, "accumulatorM");

            using (var iter = @this.GetEnumerator()) {
                if (!iter.MoveNext()) {
                    throw new InvalidOperationException("Source sequence was empty.");
                }

                MonadValue<TSource> result = MonadValue.Return(iter.Current);

                while (iter.MoveNext()) {
                    result = result.Bind(_ => accumulatorM.Invoke(_, iter.Current));
                }

                return result;
            }
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "This method has been localy overriden.")]
        internal static MonadValue<TSource> ReduceBackCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, MonadValue<TSource>> accumulatorM)
            where TSource : struct
        {
            // No need to check for null-reference, "Enumerable.Reverse" is an extension method. 
            Contract.Requires(@this != null);
            Contract.Requires(accumulatorM != null);

            return @this.Reverse().AssumeNotNull().Reduce(accumulatorM);
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "This method has been localy overriden.")]
        internal static MonadValue<TAccumulate> FoldCore<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, MonadValue<TAccumulate>> accumulatorM,
            Func<MonadValue<TAccumulate>, bool> predicate)
            where TSource : struct
            where TAccumulate : struct
        {
            Require.Object(@this);

            MonadValue<TAccumulate> result = MonadValue.Return(seed);

            using (var iter = @this.GetEnumerator()) {
                while (predicate.Invoke(result) && iter.MoveNext()) {
                    result = result.Bind(_ => accumulatorM.Invoke(_, iter.Current));
                }
            }

            return result;
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "This method has been localy overriden.")]
        internal static MonadValue<TSource> ReduceCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, MonadValue<TSource>> accumulatorM,
            Func<MonadValue<TSource>, bool> predicate)
            where TSource : struct
        {
            Require.Object(@this);

            using (var iter = @this.GetEnumerator()) {
                if (!iter.MoveNext()) {
                    throw new InvalidOperationException("Source sequence was empty.");
                }

                MonadValue<TSource> result = MonadValue.Return(iter.Current);

                while (predicate.Invoke(result) && iter.MoveNext()) {
                    result = result.Bind(_ => accumulatorM.Invoke(_, iter.Current));
                }

                return result;
            }
        }
    }
}
