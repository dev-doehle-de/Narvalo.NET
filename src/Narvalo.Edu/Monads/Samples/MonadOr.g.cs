﻿// Copyright (c) 2014, Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by a tool. Changes to this file may cause incorrect
// behavior and will be lost if the code is regenerated.
//
// Creation Time: 03/03/2014 12:38:23
// Runtime Version: 4.0.30319.34011
// </auto-generated>
//------------------------------------------------------------------------------

namespace Narvalo.Edu.Monads.Samples {
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using Narvalo;      // For Require
    using Narvalo.Fx;   // For Unit

    // Monad methods.
    public static partial class MonadOr
    {
        static readonly MonadOr<Unit> Unit_ = Return(Narvalo.Fx.Unit.Single);
        static readonly MonadOr<Unit> None_ = MonadOr<Unit>.None;

        public static MonadOr<Unit> Unit { get { return Unit_; } }

        // [Haskell] mzero
        public static MonadOr<Unit> None { get { return None_; } }

        // [Haskell] return
        public static MonadOr<T> Return<T>(T value)
        {
            return MonadOr<T>.η(value);
        }
        
        #region Generalisations of list functions (Prelude)

        // [Haskell] join
        public static MonadOr<T> Flatten<T>(MonadOr<MonadOr<T>> square)
        {
            return MonadOr<T>.μ(square);
        }

        #endregion

        #region Monadic lifting operators

        public static Func<MonadOr<T>, MonadOr<TResult>> Lift<T, TResult>(Func<T, TResult> fun)
        {
            return m =>
            {
	            Require.NotNull(m, "m");
                return m.Select(fun);
            };
        }

        public static Func<MonadOr<T1>, MonadOr<T2>, MonadOr<TResult>>
            Lift<T1, T2, TResult>(Func<T1, T2, TResult> fun)
        {
            return (m1, m2) => 
            {
	            Require.NotNull(m1, "m1");
                return m1.Zip(m2, fun);
            };
        }

        public static Func<MonadOr<T1>, MonadOr<T2>, MonadOr<T3>, MonadOr<TResult>>
            Lift<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> fun)
        {
            return (m1, m2, m3) =>
            {
	            Require.NotNull(m1, "m1");
                return m1.Zip(m2, m3, fun);
            };
        }

        public static Func<MonadOr<T1>, MonadOr<T2>, MonadOr<T3>, MonadOr<T4>, MonadOr<TResult>>
            Lift<T1, T2, T3, T4, TResult>(
            Func<T1, T2, T3, T4, TResult> fun)
        {
            return (m1, m2, m3, m4) =>
            {
	            Require.NotNull(m1, "m1");
                return m1.Zip(m2, m3, m4, fun);
            };
        }

        public static Func<MonadOr<T1>, MonadOr<T2>, MonadOr<T3>, MonadOr<T4>, MonadOr<T5>, MonadOr<TResult>>
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

    // Extensions for MonadOr<T>.
    public static partial class MonadOr
    {
        #region Basic Monad functions (Prelude)

        // [Haskell] fmap
        public static MonadOr<TResult> Select<TSource, TResult>(this MonadOr<TSource> @this, Func<TSource, TResult> selector)
        {
            Require.Object(@this);
            Require.NotNull(selector, "selector");

            return @this.Bind(_ => MonadOr.Return(selector.Invoke(_)));
        }

        // [Haskell] >>
        public static MonadOr<TResult> Then<TSource, TResult>(this MonadOr<TSource> @this, MonadOr<TResult> other)
        {
            Require.Object(@this);

            return @this.Bind(_ => other);
        }
        
        #endregion

        #region Generalisations of list functions (Prelude)

        // [Haskell] mfilter
        public static MonadOr<TSource> Where<TSource>(this MonadOr<TSource> @this, Func<TSource, bool> predicate)
        {
            Require.Object(@this);
            Require.NotNull(predicate, "predicate");

            return @this.Bind(_ => predicate.Invoke(_) ? @this : MonadOr<TSource>.None);
        }

        // [Haskell] replicateM
        public static MonadOr<IEnumerable<TSource>> Repeat<TSource>(this MonadOr<TSource> @this, int count)
        {
            return @this.Select(_ => Enumerable.Repeat(_, count));
        }
        
        #endregion

        #region Conditional execution of monadic expressions (Prelude)

        // [Haskell] guard
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "this")]
        public static MonadOr<Unit> Guard<TSource>(this MonadOr<TSource> @this, bool predicate)
        {
            return predicate ? MonadOr.Unit : MonadOr.None;
        }

        // [Haskell] when
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "this")]
        public static MonadOr<Unit> When<TSource>(this MonadOr<TSource> @this, bool predicate, Action action)
        {
            Require.NotNull(action, "action");

            if (predicate) {
                action.Invoke();
            }

            return MonadOr.Unit;
        }

        // [Haskell] unless
        public static MonadOr<Unit> Unless<TSource>(this MonadOr<TSource> @this, bool predicate, Action action)
        {
            return @this.When(!predicate, action);
        }

        #endregion

        #region Monadic lifting operators (Prelude)

        // [Haskell] liftM2
        public static MonadOr<TResult> Zip<TFirst, TSecond, TResult>(
            this MonadOr<TFirst> @this,
            MonadOr<TSecond> second,
            Func<TFirst, TSecond, TResult> resultSelector)
        {
            Require.Object(@this);
            Require.NotNull(second, "second");
            Require.NotNull(resultSelector, "resultSelector");

            return @this.Bind(v1 => second.Select(v2 => resultSelector.Invoke(v1, v2)));
        }

        // [Haskell] liftM3
        public static MonadOr<TResult> Zip<T1, T2, T3, TResult>(
            this MonadOr<T1> @this,
            MonadOr<T2> second,
            MonadOr<T3> third,
            Func<T1, T2, T3, TResult> resultSelector)
        {
            Require.Object(@this);
            Require.NotNull(second, "second");
            Require.NotNull(resultSelector, "resultSelector");

            Func<T1, MonadOr<TResult>> g
                = t1 => second.Zip(third, (t2, t3) => resultSelector.Invoke(t1, t2, t3));

            return @this.Bind(g);
        }

        // [Haskell] liftM4
        public static MonadOr<TResult> Zip<T1, T2, T3, T4, TResult>(
             this MonadOr<T1> @this,
             MonadOr<T2> second,
             MonadOr<T3> third,
             MonadOr<T4> fourth,
             Func<T1, T2, T3, T4, TResult> resultSelector)
        {
            Require.Object(@this);
            Require.NotNull(second, "second");
            Require.NotNull(resultSelector, "resultSelector");

            Func<T1, MonadOr<TResult>> g
                = t1 => second.Zip(third, fourth, (t2, t3, t4) => resultSelector.Invoke(t1, t2, t3, t4));

            return @this.Bind(g);
        }

        // [Haskell] liftM5
        public static MonadOr<TResult> Zip<T1, T2, T3, T4, T5, TResult>(
            this MonadOr<T1> @this,
            MonadOr<T2> second,
            MonadOr<T3> third,
            MonadOr<T4> fourth,
            MonadOr<T5> fifth,
            Func<T1, T2, T3, T4, T5, TResult> resultSelector)
        {
            Require.Object(@this);
            Require.NotNull(second, "second");
            Require.NotNull(resultSelector, "resultSelector");

            Func<T1, MonadOr<TResult>> g
                = t1 => second.Zip(third, fourth, fifth, (t2, t3, t4, t5) => resultSelector.Invoke(t1, t2, t3, t4, t5));

            return @this.Bind(g);
        }

        #endregion

        #region Query Expression Pattern


        // Kind of generalisation of Zip (liftM2).
        public static MonadOr<TResult> SelectMany<TSource, TMiddle, TResult>(
            this MonadOr<TSource> @this,
            Func<TSource, MonadOr<TMiddle>> valueSelectorM,
            Func<TSource, TMiddle, TResult> resultSelector)
        {
            Require.Object(@this);
            Require.NotNull(valueSelectorM, "valueSelectorM");
            Require.NotNull(resultSelector, "resultSelector");

            return @this.Bind(_ => valueSelectorM.Invoke(_).Select(middle => resultSelector.Invoke(_, middle)));
        }

        public static MonadOr<TResult> Join<TSource, TInner, TKey, TResult>(
            this MonadOr<TSource> @this,
            MonadOr<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, TInner, TResult> resultSelector)
        {
            return @this.Join(inner, outerKeySelector, innerKeySelector, resultSelector, EqualityComparer<TKey>.Default);
        }

        public static MonadOr<TResult> GroupJoin<TSource, TInner, TKey, TResult>(
            this MonadOr<TSource> @this,
            MonadOr<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, MonadOr<TInner>, TResult> resultSelector)
        {
            return @this.GroupJoin(inner, outerKeySelector, innerKeySelector, resultSelector, EqualityComparer<TKey>.Default);
        }

        #endregion
        
        #region Linq extensions

        public static MonadOr<TResult> Join<TSource, TInner, TKey, TResult>(
            this MonadOr<TSource> @this,
            MonadOr<TInner> inner,
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

        public static MonadOr<TResult> GroupJoin<TSource, TInner, TKey, TResult>(
            this MonadOr<TSource> @this,
            MonadOr<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, MonadOr<TInner>, TResult> resultSelector,
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
        
        static MonadOr<TResult> JoinCore_<TSource, TInner, TKey, TResult>(
            this MonadOr<TSource> @this,
            MonadOr<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, TInner, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
        {
            Require.Object(@this);
            Require.NotNull(inner, "inner");
            Require.NotNull(outerKeySelector, "valueSelector");
            Require.NotNull(innerKeySelector, "innerKeySelector");
            Require.NotNull(resultSelector, "resultSelector");
            
            var keyLookupM = GetKeyLookup_(inner, outerKeySelector, innerKeySelector, comparer);

            return from outerValue in @this
                   from innerValue in keyLookupM.Invoke(outerValue).Then(inner)
                   select resultSelector.Invoke(outerValue, innerValue);
        }
        
        static MonadOr<TResult> GroupJoinCore_<TSource, TInner, TKey, TResult>(
            this MonadOr<TSource> @this,
            MonadOr<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TSource, MonadOr<TInner>, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
        {
            Require.Object(@this);
            Require.NotNull(inner, "inner");
            Require.NotNull(outerKeySelector, "valueSelector");
            Require.NotNull(innerKeySelector, "innerKeySelector");
            Require.NotNull(resultSelector, "resultSelector");

            var keyLookupM = GetKeyLookup_(inner, outerKeySelector, innerKeySelector, comparer);

            return from outerValue in @this
                   select resultSelector.Invoke(outerValue, keyLookupM.Invoke(outerValue).Then(inner));
        }

        static Func<TSource, MonadOr<TKey>> GetKeyLookup_<TSource, TInner, TKey>(
            MonadOr<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            IEqualityComparer<TKey> comparer)
        {
            return source =>
            {
                TKey outerKey = outerKeySelector.Invoke(source);
            
                return inner.Select(innerKeySelector).Where(_ => comparer.Equals(_, outerKey));
            };
        }

        #endregion

        #region Non-standard extensions
        
        public static MonadOr<TResult> Coalesce<TSource, TResult>(
            this MonadOr<TSource> @this,
            Func<TSource, bool> predicate,
            MonadOr<TResult> then,
            MonadOr<TResult> otherwise)
        {
            Require.Object(@this);
            Require.NotNull(predicate, "predicate");

            return @this.Bind(_ => predicate.Invoke(_) ? then : otherwise);
        }

        public static MonadOr<TResult> Then<TSource, TResult>(
            this MonadOr<TSource> @this,
            Func<TSource, bool> predicate,
            MonadOr<TResult> other)
        {
            return @this.Coalesce(predicate, other, MonadOr<TResult>.None);
        }

        public static MonadOr<TResult> Otherwise<TSource, TResult>(
            this MonadOr<TSource> @this,
            Func<TSource, bool> predicate,
            MonadOr<TResult> other)
        {
            return @this.Coalesce(predicate, MonadOr<TResult>.None, other);
        }

        public static MonadOr<TSource> Run<TSource>(this MonadOr<TSource> @this, Action<TSource> action)
        {
            Require.Object(@this);
            Require.NotNull(action, "action");

            return @this.Bind(_ => { action.Invoke(_); return @this; });
        }

        public static MonadOr<TSource> OnNone<TSource>(this MonadOr<TSource> @this, Action action)
        {
            Require.Object(@this);
            Require.NotNull(action, "action");

            return @this.Then(MonadOr.Unit).Run(_ => action.Invoke()).Then(@this);
        }

        #endregion
    }

    // Extensions for Func<T, MonadOr<TResult>>.
    public static partial class FuncExtensions
    {
        #region Basic Monad functions (Prelude)

        // [Haskell] =<<
        public static MonadOr<TResult> Invoke<TSource, TResult>(
            this Func<TSource, MonadOr<TResult>> @this,
            MonadOr<TSource> value)
        {
            return value.Bind(@this);
        }

        // [Haskell] >=>
        public static Func<TSource, MonadOr<TResult>> Compose<TSource, TMiddle, TResult>(
            this Func<TSource, MonadOr<TMiddle>> @this,
            Func<TMiddle, MonadOr<TResult>> funM)
        {
            Require.Object(@this);

            return _ => @this.Invoke(_).Bind(funM);
        }

        // [Haskell] <=<
        public static Func<TSource, MonadOr<TResult>> ComposeBack<TSource, TMiddle, TResult>(
            this Func<TMiddle, MonadOr<TResult>> @this,
            Func<TSource, MonadOr<TMiddle>> funM)
        {
            Require.Object(@this);
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

    // Extensions for IEnumerable<MonadOr<T>>.
    public static partial class EnumerableMonadOrExtensions
    {
        #region Basic Monad functions (Prelude)

        // [Haskell] sequence
        public static MonadOr<IEnumerable<TSource>> Collect<TSource>(this IEnumerable<MonadOr<TSource>> @this)
        {
            Require.Object(@this);

            return @this.CollectCore();
        }
        
        #endregion

        #region Generalisations of list functions (Prelude)

        // [Haskell] msum
        public static MonadOr<TSource> Sum<TSource>(this IEnumerable<MonadOr<TSource>> @this)
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

        // [Haskell] mapM
        public static MonadOr<IEnumerable<TResult>> Map<TSource, TResult>(
            this IEnumerable<TSource> @this,
            Func<TSource, MonadOr<TResult>> funM)
        {
            Require.Object(@this);

            return @this.MapCore(funM);
        }
        
        #endregion

        #region Generalisations of list functions (Prelude)

        // [Haskell] filterM
        // REVIEW: Haskell use a differente signature.
        public static IEnumerable<TSource> Filter<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, MonadOr<bool>> predicateM)
        {
            Require.Object(@this);

            return @this.FilterCore(predicateM);
        }

        // [Haskell] mapAndUnzipM
        public static MonadOr<Tuple<IEnumerable<TFirst>, IEnumerable<TSecond>>> MapAndUnzip<TSource, TFirst, TSecond>(
           this IEnumerable<TSource> @this,
           Func<TSource, MonadOr<Tuple<TFirst, TSecond>>> funM)
        {
            Require.Object(@this);

            return @this.MapAndUnzipCore(funM);
        }

        // [Haskell] zipWithM
        public static MonadOr<IEnumerable<TResult>> Zip<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> @this,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, MonadOr<TResult>> resultSelectorM)
        {
            Require.Object(@this);

            return @this.ZipCore(second, resultSelectorM);
        }

        // [Haskell] foldM
        public static MonadOr<TAccumulate> Fold<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, MonadOr<TAccumulate>> accumulatorM)
        {
            Require.Object(@this);

            return @this.FoldCore(seed, accumulatorM);
        }

        #endregion
        
        #region Aggregate Operators

        public static MonadOr<TAccumulate> FoldBack<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, MonadOr<TAccumulate>> accumulatorM)
        {
             Require.Object(@this);

            return @this.FoldBackCore(seed, accumulatorM);
        }

        public static MonadOr<TSource> Reduce<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, MonadOr<TSource>> accumulatorM)
        {
            Require.Object(@this);
            
            return @this.ReduceCore(accumulatorM);
        }

        public static MonadOr<TSource> ReduceBack<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, MonadOr<TSource>> accumulatorM)
        {
            Require.Object(@this);

            return @this.ReduceBackCore(accumulatorM);
        }

        #endregion

        #region Catamorphisms

        // REVIEW: Signature.
        public static MonadOr<TAccumulate> Fold<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, MonadOr<TAccumulate>> accumulatorM,
            Func<MonadOr<TAccumulate>, bool> predicate)
        {
             Require.Object(@this);

            return @this.FoldCore(seed, accumulatorM, predicate);
        }
        
        // REVIEW: Signature.
        public static MonadOr<TSource> Reduce<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, MonadOr<TSource>> accumulatorM,
            Func<MonadOr<TSource>, bool> predicate)
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

    // Internal extensions for IEnumerable<MonadOr<T>>.
    static partial class EnumerableMonadOrExtensions
    {
        public static MonadOr<IEnumerable<TSource>> CollectCore<TSource>(this IEnumerable<MonadOr<TSource>> @this)
        {
            var seed = MonadOr.Return(Enumerable.Empty<TSource>());
            Func<MonadOr<IEnumerable<TSource>>, MonadOr<TSource>, MonadOr<IEnumerable<TSource>>> fun
                = (m, n) =>
                    m.Bind(list =>
                    {
                        return n.Bind(item => MonadOr.Return(list.Concat(Enumerable.Repeat(item, 1))));
                    });

            return @this.Aggregate(seed, fun);
        }

        public static MonadOr<TSource> SumCore<TSource>(this IEnumerable<MonadOr<TSource>> @this)
        {
            return @this.Aggregate(MonadOr<TSource>.None, (m, n) => m.OrElse(n));
        }
    }

    // Internal extensions for IEnumerable<T>.
    static partial class EnumerableExtensions
    {
        public static MonadOr<IEnumerable<TResult>> MapCore<TSource, TResult>(
            this IEnumerable<TSource> @this,
            Func<TSource, MonadOr<TResult>> funM)
        {
            Require.NotNull(funM, "funM");

            return @this.Select(funM).Collect();
        }

        public static IEnumerable<TSource> FilterCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, MonadOr<bool>> predicateM)
        {
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

        public static MonadOr<Tuple<IEnumerable<TFirst>, IEnumerable<TSecond>>> MapAndUnzipCore<TSource, TFirst, TSecond>(
           this IEnumerable<TSource> @this,
           Func<TSource, MonadOr<Tuple<TFirst, TSecond>>> funM)
        {
            Require.NotNull(funM, "funM");

            return from _ in
                       (from _ in @this select funM.Invoke(_)).Collect()
                   let item1 = from item in _ select item.Item1
                   let item2 = from item in _ select item.Item2
                   select new Tuple<IEnumerable<TFirst>, IEnumerable<TSecond>>(item1, item2);
        }

        public static MonadOr<IEnumerable<TResult>> ZipCore<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> @this,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, MonadOr<TResult>> resultSelectorM)
        {
            Require.NotNull(second, "second");
            Require.NotNull(resultSelectorM, "resultSelectorM");

            Func<TFirst, TSecond, MonadOr<TResult>> resultSelector = (v1, v2) => resultSelectorM.Invoke(v1, v2);

            // WARNING: Do not remove resultSelector, otherwise .NET will make a recursive call
            // instead of using the Zip from Linq.
            return @this.Zip(second, resultSelector: resultSelector).Collect();
        }

        public static MonadOr<TAccumulate> FoldCore<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, MonadOr<TAccumulate>> accumulatorM)
        {
            Require.NotNull(accumulatorM, "accumulatorM");

            MonadOr<TAccumulate> result = MonadOr.Return(seed);

            foreach (TSource item in @this) {
                result = result.Bind(_ => accumulatorM.Invoke(_, item));
            }

            return result;
        }

        public static MonadOr<TAccumulate> FoldBackCore<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, MonadOr<TAccumulate>> accumulatorM)
        {
            return @this.Reverse().Fold(seed, accumulatorM);
        }

        public static MonadOr<TSource> ReduceCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, MonadOr<TSource>> accumulatorM)
        {
            Require.NotNull(accumulatorM, "accumulatorM");

            using (var iter = @this.GetEnumerator()) {
                if (!iter.MoveNext()) {
                    throw new InvalidOperationException("Source sequence was empty.");
                }

                MonadOr<TSource> result = MonadOr.Return(iter.Current);

                while (iter.MoveNext()) {
                    result = result.Bind(_ => accumulatorM.Invoke(_, iter.Current));
                }

                return result;
            }
        }

        public static MonadOr<TSource> ReduceBackCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, MonadOr<TSource>> accumulatorM)
        {
            return @this.Reverse().Reduce(accumulatorM);
        }

        public static MonadOr<TAccumulate> FoldCore<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, MonadOr<TAccumulate>> accumulatorM,
            Func<MonadOr<TAccumulate>, bool> predicate)
        {
            Require.NotNull(accumulatorM, "accumulatorM");
            Require.NotNull(predicate, "predicate");

            MonadOr<TAccumulate> result = MonadOr.Return(seed);

            using (var iter = @this.GetEnumerator()) {
                while (predicate.Invoke(result) && iter.MoveNext()) {
                    result = result.Bind(_ => accumulatorM.Invoke(_, iter.Current));
                }
            }

            return result;
        }

        public static MonadOr<TSource> ReduceCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, MonadOr<TSource>> accumulatorM,
            Func<MonadOr<TSource>, bool> predicate)
        {
            Require.NotNull(accumulatorM, "accumulatorM");
            Require.NotNull(predicate, "predicate");

            using (var iter = @this.GetEnumerator()) {if (!iter.MoveNext()) {
                    throw new InvalidOperationException("Source sequence was empty.");
                }

                MonadOr<TSource> result = MonadOr.Return(iter.Current);

                while (predicate.Invoke(result) && iter.MoveNext()) {
                    result = result.Bind(_ => accumulatorM.Invoke(_, iter.Current));
                }

                return result;
            }
        }
    }
}
