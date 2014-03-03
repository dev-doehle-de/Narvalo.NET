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
    public static partial class MonadValue
    {
        static readonly MonadValue<Unit> Unit_ = Return(Narvalo.Fx.Unit.Single);
        static readonly MonadValue<Unit> None_ = MonadValue<Unit>.None;

        public static MonadValue<Unit> Unit { get { return Unit_; } }

        // [Haskell] mzero
        public static MonadValue<Unit> None { get { return None_; } }

        // [Haskell] return
        public static MonadValue<T> Return<T>(T value)
            where T : struct
        {
            return MonadValue<T>.η(value);
        }
        
        #region Generalisations of list functions (Prelude)

        // [Haskell] join
        public static MonadValue<T> Flatten<T>(MonadValue<MonadValue<T>> square)
            where T : struct
        {
            return MonadValue<T>.μ(square);
        }

        #endregion

        #region Monadic lifting operators

        public static Func<MonadValue<T>, MonadValue<TResult>> Lift<T, TResult>(Func<T, TResult> fun)
            where T : struct
            where TResult : struct
        {
            return m =>
            {
                return m.Select(fun);
            };
        }

        public static Func<MonadValue<T1>, MonadValue<T2>, MonadValue<TResult>>
            Lift<T1, T2, TResult>(Func<T1, T2, TResult> fun)
            where T1 : struct
            where T2 : struct
            where TResult : struct
        {
            return (m1, m2) => 
            {
                return m1.Zip(m2, fun);
            };
        }

        public static Func<MonadValue<T1>, MonadValue<T2>, MonadValue<T3>, MonadValue<TResult>>
            Lift<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> fun)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where TResult : struct
        {
            return (m1, m2, m3) =>
            {
                return m1.Zip(m2, m3, fun);
            };
        }

        public static Func<MonadValue<T1>, MonadValue<T2>, MonadValue<T3>, MonadValue<T4>, MonadValue<TResult>>
            Lift<T1, T2, T3, T4, TResult>(
            Func<T1, T2, T3, T4, TResult> fun)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where TResult : struct
        {
            return (m1, m2, m3, m4) =>
            {
                return m1.Zip(m2, m3, m4, fun);
            };
        }

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
            return (m1, m2, m3, m4, m5) =>
            {
                return m1.Zip(m2, m3, m4, m5, fun);
            };
        }

        #endregion
    }

    // Extensions for MonadValue<T>.
    public static partial class MonadValue
    {
        #region Basic Monad functions (Prelude)

        // [Haskell] fmap
        public static MonadValue<TResult> Select<TSource, TResult>(this MonadValue<TSource> @this, Func<TSource, TResult> selector)
            where TSource : struct
            where TResult : struct
        {

            return @this.Bind(_ => MonadValue.Return(selector.Invoke(_)));
        }

        // [Haskell] >>
        public static MonadValue<TResult> Then<TSource, TResult>(this MonadValue<TSource> @this, MonadValue<TResult> other)
            where TSource : struct
            where TResult : struct
        {

            return @this.Bind(_ => other);
        }
        
        #endregion

        #region Generalisations of list functions (Prelude)

        // [Haskell] mfilter
        public static MonadValue<TSource> Where<TSource>(this MonadValue<TSource> @this, Func<TSource, bool> predicate)
            where TSource : struct
        {
            Require.NotNull(predicate, "predicate");

            return @this.Bind(_ => predicate.Invoke(_) ? @this : MonadValue<TSource>.None);
        }
        
        #endregion

        #region Conditional execution of monadic expressions (Prelude)

        // [Haskell] guard
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "this")]
        public static MonadValue<Unit> Guard<TSource>(this MonadValue<TSource> @this, bool predicate)
            where TSource : struct
        {
            return predicate ? MonadValue.Unit : MonadValue.None;
        }

        // [Haskell] when
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "this")]
        public static MonadValue<Unit> When<TSource>(this MonadValue<TSource> @this, bool predicate, Action action)
            where TSource : struct
        {
            Require.NotNull(action, "action");

            if (predicate) {
                action.Invoke();
            }

            return MonadValue.Unit;
        }

        // [Haskell] unless
        public static MonadValue<Unit> Unless<TSource>(this MonadValue<TSource> @this, bool predicate, Action action)
            where TSource : struct
        {
            return @this.When(!predicate, action);
        }

        #endregion

        #region Monadic lifting operators (Prelude)

        // [Haskell] liftM2
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

        // [Haskell] liftM3
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

        // [Haskell] liftM4
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
                = t1 => second.Zip(third, fourth, (t2, t3, t4) => resultSelector.Invoke(t1, t2, t3, t4));

            return @this.Bind(g);
        }

        // [Haskell] liftM5
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
                = t1 => second.Zip(third, fourth, fifth, (t2, t3, t4, t5) => resultSelector.Invoke(t1, t2, t3, t4, t5));

            return @this.Bind(g);
        }

        #endregion

        #region Query Expression Pattern


        // Kind of generalisation of Zip (liftM2).
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

            return @this.Bind(_ => valueSelectorM.Invoke(_).Select(middle => resultSelector.Invoke(_, middle)));
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
            return @this.Join(inner, outerKeySelector, innerKeySelector, resultSelector, EqualityComparer<TKey>.Default);
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
            return @this.GroupJoin(inner, outerKeySelector, innerKeySelector, resultSelector, EqualityComparer<TKey>.Default);
        }

        #endregion
        
        #region Linq extensions

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
            return GroupJoinCore_(
                @this,
                inner,
                outerKeySelector,
                innerKeySelector,
                resultSelector,
                comparer ?? EqualityComparer<TKey>.Default);
        }
        
        static MonadValue<TResult> JoinCore_<TSource, TInner, TKey, TResult>(
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
            Require.NotNull(outerKeySelector, "valueSelector");
            Require.NotNull(innerKeySelector, "innerKeySelector");
            Require.NotNull(resultSelector, "resultSelector");
            
            var keyLookupM = GetKeyLookup_(inner, outerKeySelector, innerKeySelector, comparer);

            return from outerValue in @this
                   from innerValue in keyLookupM.Invoke(outerValue).Then(inner)
                   select resultSelector.Invoke(outerValue, innerValue);
        }
        
        static MonadValue<TResult> GroupJoinCore_<TSource, TInner, TKey, TResult>(
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
            Require.NotNull(outerKeySelector, "valueSelector");
            Require.NotNull(innerKeySelector, "innerKeySelector");
            Require.NotNull(resultSelector, "resultSelector");

            var keyLookupM = GetKeyLookup_(inner, outerKeySelector, innerKeySelector, comparer);

            return from outerValue in @this
                   select resultSelector.Invoke(outerValue, keyLookupM.Invoke(outerValue).Then(inner));
        }

        static Func<TSource, MonadValue<TKey>> GetKeyLookup_<TSource, TInner, TKey>(
            MonadValue<TInner> inner,
            Func<TSource, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            IEqualityComparer<TKey> comparer)
            where TSource : struct
            where TInner : struct
            where TKey : struct
        {
            return source =>
            {
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
            return @this.Coalesce(predicate, other, MonadValue<TResult>.None);
        }

        public static MonadValue<TResult> Otherwise<TSource, TResult>(
            this MonadValue<TSource> @this,
            Func<TSource, bool> predicate,
            MonadValue<TResult> other)
            where TSource : struct
            where TResult : struct
        {
            return @this.Coalesce(predicate, MonadValue<TResult>.None, other);
        }

        public static MonadValue<TSource> Run<TSource>(this MonadValue<TSource> @this, Action<TSource> action)
            where TSource : struct
        {
            Require.NotNull(action, "action");

            return @this.Bind(_ => { action.Invoke(_); return @this; });
        }

        public static MonadValue<TSource> OnNone<TSource>(this MonadValue<TSource> @this, Action action)
            where TSource : struct
        {
            Require.NotNull(action, "action");

            return @this.Then(MonadValue.Unit).Run(_ => action.Invoke()).Then(@this);
        }

        #endregion
    }

    // Extensions for Func<T, MonadValue<TResult>>.
    public static partial class FuncExtensions
    {
        #region Basic Monad functions (Prelude)

        // [Haskell] =<<
        public static MonadValue<TResult> Invoke<TSource, TResult>(
            this Func<TSource, MonadValue<TResult>> @this,
            MonadValue<TSource> value)
            where TSource : struct
            where TResult : struct
        {
            return value.Bind(@this);
        }

        // [Haskell] >=>
        public static Func<TSource, MonadValue<TResult>> Compose<TSource, TMiddle, TResult>(
            this Func<TSource, MonadValue<TMiddle>> @this,
            Func<TMiddle, MonadValue<TResult>> funM)
            where TSource : struct
            where TMiddle : struct
            where TResult : struct
        {

            return _ => @this.Invoke(_).Bind(funM);
        }

        // [Haskell] <=<
        public static Func<TSource, MonadValue<TResult>> ComposeBack<TSource, TMiddle, TResult>(
            this Func<TMiddle, MonadValue<TResult>> @this,
            Func<TSource, MonadValue<TMiddle>> funM)
            where TSource : struct
            where TMiddle : struct
            where TResult : struct
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

    // Extensions for IEnumerable<MonadValue<T>>.
    public static partial class EnumerableMonadValueExtensions
    {
        #region Basic Monad functions (Prelude)

        
        #endregion

        #region Generalisations of list functions (Prelude)

        // [Haskell] msum
        public static MonadValue<TSource> Sum<TSource>(this IEnumerable<MonadValue<TSource>> @this)
            where TSource : struct
        {

            return @this.SumCore();
        }

        #endregion
    }

    // Extensions for IEnumerable<T>.
    public static partial class EnumerableExtensions
    {
        #region Basic Monad functions (Prelude)

        
        #endregion

        #region Generalisations of list functions (Prelude)

        // [Haskell] filterM
        // REVIEW: Haskell use a differente signature.
        public static IEnumerable<TSource> Filter<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, MonadValue<bool>> predicateM)
            where TSource : struct
        {

            return @this.FilterCore(predicateM);
        }


        // [Haskell] foldM
        public static MonadValue<TAccumulate> Fold<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, MonadValue<TAccumulate>> accumulatorM)
            where TSource : struct
            where TAccumulate : struct
        {

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
 
            return @this.FoldBackCore(seed, accumulatorM);
        }

        public static MonadValue<TSource> Reduce<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, MonadValue<TSource>> accumulatorM)
            where TSource : struct
        {
            
            return @this.ReduceCore(accumulatorM);
        }

        public static MonadValue<TSource> ReduceBack<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, MonadValue<TSource>> accumulatorM)
            where TSource : struct
        {

            return @this.ReduceBackCore(accumulatorM);
        }

        #endregion

        #region Catamorphisms

        // REVIEW: Signature.
        public static MonadValue<TAccumulate> Fold<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, MonadValue<TAccumulate>> accumulatorM,
            Func<MonadValue<TAccumulate>, bool> predicate)
            where TSource : struct
            where TAccumulate : struct
        {
 
            return @this.FoldCore(seed, accumulatorM, predicate);
        }
        
        // REVIEW: Signature.
        public static MonadValue<TSource> Reduce<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, MonadValue<TSource>> accumulatorM,
            Func<MonadValue<TSource>, bool> predicate)
            where TSource : struct
        {
 
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

    // Internal extensions for IEnumerable<MonadValue<T>>.
    static partial class EnumerableMonadValueExtensions
    {

        public static MonadValue<TSource> SumCore<TSource>(this IEnumerable<MonadValue<TSource>> @this)
            where TSource : struct
        {
            return @this.Aggregate(MonadValue<TSource>.None, (m, n) => m.OrElse(n));
        }
    }

    // Internal extensions for IEnumerable<T>.
    static partial class EnumerableExtensions
    {

        public static IEnumerable<TSource> FilterCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, MonadValue<bool>> predicateM)
            where TSource : struct
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


        public static MonadValue<TAccumulate> FoldCore<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, MonadValue<TAccumulate>> accumulatorM)
            where TSource : struct
            where TAccumulate : struct
        {
            Require.NotNull(accumulatorM, "accumulatorM");

            MonadValue<TAccumulate> result = MonadValue.Return(seed);

            foreach (TSource item in @this) {
                result = result.Bind(_ => accumulatorM.Invoke(_, item));
            }

            return result;
        }

        public static MonadValue<TAccumulate> FoldBackCore<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, MonadValue<TAccumulate>> accumulatorM)
            where TSource : struct
            where TAccumulate : struct
        {
            return @this.Reverse().Fold(seed, accumulatorM);
        }

        public static MonadValue<TSource> ReduceCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, MonadValue<TSource>> accumulatorM)
            where TSource : struct
        {
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

        public static MonadValue<TSource> ReduceBackCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, MonadValue<TSource>> accumulatorM)
            where TSource : struct
        {
            return @this.Reverse().Reduce(accumulatorM);
        }

        public static MonadValue<TAccumulate> FoldCore<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, MonadValue<TAccumulate>> accumulatorM,
            Func<MonadValue<TAccumulate>, bool> predicate)
            where TSource : struct
            where TAccumulate : struct
        {
            Require.NotNull(accumulatorM, "accumulatorM");
            Require.NotNull(predicate, "predicate");

            MonadValue<TAccumulate> result = MonadValue.Return(seed);

            using (var iter = @this.GetEnumerator()) {
                while (predicate.Invoke(result) && iter.MoveNext()) {
                    result = result.Bind(_ => accumulatorM.Invoke(_, iter.Current));
                }
            }

            return result;
        }

        public static MonadValue<TSource> ReduceCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, MonadValue<TSource>> accumulatorM,
            Func<MonadValue<TSource>, bool> predicate)
            where TSource : struct
        {
            Require.NotNull(accumulatorM, "accumulatorM");
            Require.NotNull(predicate, "predicate");

            using (var iter = @this.GetEnumerator()) {if (!iter.MoveNext()) {
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
