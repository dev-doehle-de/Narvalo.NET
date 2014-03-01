﻿// Copyright (c) 2014, Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by a tool. Changes to this file may cause incorrect
// behavior and will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Narvalo.Edu.Samples {
	using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using Narvalo;      // For Require
	using Narvalo.Fx;   // For Unit

	// Monad methods.
    public static partial class Identity
    {
        static readonly Identity<Unit> Unit_ = Return(Narvalo.Fx.Unit.Single);

        public static Identity<Unit> Unit { get { return Unit_; } }


        // [Haskell] return
        public static Identity<T> Return<T>(T value)
        {
            return Identity<T>.η(value);
        }
		
        #region Generalisations of list functions (Prelude)

        // [Haskell] join
        public static Identity<T> Flatten<T>(Identity<Identity<T>> square)
        {
            return Identity<T>.μ(square);
        }

        #endregion

    }
	// Extensions for Identity<T>.
    public static partial class IdentityExtensions
    {
		#region Basic Monad functions (Prelude)

        // [Haskell] fmap
        public static Identity<TResult> Select<TSource, TResult>(this Identity<TSource> @this, Func<TSource, TResult> selector)
        {
            return @this.Bind(_ => Identity.Return(selector.Invoke(_)));
        }

		// [Haskell] >>
        public static Identity<TResult> Then<TSource, TResult>(this Identity<TSource> @this, Identity<TResult> other)
        
        {
            return @this.Bind(_ => other);
        }
		
        #endregion

        #region Generalisations of list functions (Prelude)


        // [Haskell] replicateM
        public static Identity<IEnumerable<TSource>> Repeat<TSource>(this Identity<TSource> @this, int count)
        {
            return @this.Select(_ => Enumerable.Repeat(_, count));
        }
		
        #endregion


        #region Monadic lifting operators (Prelude)

        // [Haskell] liftM2
        public static Identity<TResult> Zip<TFirst, TSecond, TResult>(
            this Identity<TFirst> @this,
            Identity<TSecond> second,
            Func<TFirst, TSecond, TResult> resultSelector)
        {
            Require.Object(@this);
            Require.NotNull(second, "second");
            Require.NotNull(resultSelector, "resultSelector");

            return @this.Bind(v1 => second.Select(v2 => resultSelector.Invoke(v1, v2)));
        }


        #endregion

        #region Query Expression Pattern


        // Kind of generalisation of Zip (liftM2).
        public static Identity<TResult> SelectMany<TSource, TMiddle, TResult>(
            this Identity<TSource> @this,
            Func<TSource, Identity<TMiddle>> valueSelectorM,
            Func<TSource, TMiddle, TResult> resultSelector)
        {
            Require.Object(@this);
            Require.NotNull(valueSelectorM, "valueSelectorM");
            Require.NotNull(resultSelector, "resultSelector");

            return @this.Bind(_ => valueSelectorM.Invoke(_).Select(middle => resultSelector.Invoke(_, middle)));
        }


        #endregion
        
        #region Linq extensions


        #endregion

        #region Non-standard extensions
        
        public static Identity<TResult> Coalesce<TSource, TResult>(
            this Identity<TSource> @this,
            Func<TSource, bool> predicate,
            Identity<TResult> then,
            Identity<TResult> otherwise)
        {
            Require.Object(@this);
            Require.NotNull(predicate, "predicate");

            return @this.Bind(_ => predicate.Invoke(_) ? then : otherwise);
        }


        public static Identity<TSource> Run<TSource>(this Identity<TSource> @this, Action<TSource> action)
        {
            Require.Object(@this);
            Require.NotNull(action, "action");

            return @this.Bind(_ => { action.Invoke(_); return @this; });
        }


        #endregion
    }
	// Extensions for Func<T, Identity<TResult>>.
	public static partial class FuncExtensions
    {
        #region Basic Monad functions (Prelude)

        // [Haskell] =<<
        public static Identity<TResult> Invoke<TSource, TResult>(
            this Func<TSource, Identity<TResult>> @this,
            Identity<TSource> monad)
        {
            return monad.Bind(@this);
        }

        // [Haskell] >=>
        public static Func<TSource, Identity<TResult>> Compose<TSource, TMiddle, TResult>(
            this Func<TSource, Identity<TMiddle>> @this,
            Func<TMiddle, Identity<TResult>> funM)
        {
            Require.Object(@this);

            return _ => @this.Invoke(_).Bind(funM);
        }


        #endregion
    }
}

namespace Narvalo.Edu.Samples {
	// Comonad methods.
    public static partial class Identity
    {
        // [Haskell] extract
        public static T Extract<T>(Identity<T> monad)
        {
            return Identity<T>.ε(monad);
        }

        // [Haskell] duplicate
        public static Identity<Identity<T>> Duplicate<T>(Identity<T> monad)
        {
            return Identity<T>.δ(monad);
        }
    }
}

namespace Narvalo.Edu.Samples.IdentityEx {
	using System;
    using System.Collections.Generic;
    using System.Linq;
    using Narvalo;      // For Require
	using Narvalo.Fx;   // For Unit
    using Narvalo.Edu.Samples;
	// Extensions for IEnumerable<Identity<T>>.
	public static partial class EnumerableIdentityExtensions
    {
        #region Basic Monad functions (Prelude)

        // [Haskell] sequence
        public static Identity<IEnumerable<TSource>> Collect<TSource>(this IEnumerable<Identity<TSource>> @this)
        {
            Require.Object(@this);

            var seed = Identity.Return(Enumerable.Empty<TSource>());
            Func<Identity<IEnumerable<TSource>>, Identity<TSource>, Identity<IEnumerable<TSource>>> fun
                = (m, n) =>
                    m.Bind(list =>
                    {
                        return n.Bind(item => Identity.Return(list.Concat(Enumerable.Repeat(item, 1))));
                    });

            return @this.Aggregate(seed, fun);
        }
		
        #endregion

	}
	// Extensions for IEnumerable<T>.
    public static partial class EnumerableExtensions
    {
        #region Basic Monad functions (Prelude)

        // [Haskell] mapM
        public static Identity<IEnumerable<TResult>> Map<TSource, TResult>(
            this IEnumerable<TSource> @this,
            Func<TSource, Identity<TResult>> funM)
        {
            Require.Object(@this);
            Require.NotNull(funM, "funM");

            return (from _ in @this select funM.Invoke(_)).Collect();
        }
		
        #endregion

        #region Generalisations of list functions (Prelude)

        // [Haskell] filterM
        public static Identity<IEnumerable<TSource>> Filter<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, Identity<bool>> predicateM)
        {
            Require.Object(@this);
            Require.NotNull(predicateM, "predicateM");

            // NB: Haskell uses tail recursion, we don't.
            var list = new List<TSource>();

            foreach (var item in @this) {
                predicateM.Invoke(item)
                    .Bind(_ =>
                    {
                        if (_ == true) {
                            list.Add(item);
                        }

                        return Identity.Unit;
                    });
            }

            return Identity.Return(list.AsEnumerable());
        }


        // [Haskell] zipWithM
        public static Identity<IEnumerable<TResult>> Zip<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> @this,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, Identity<TResult>> resultSelectorM)
        {
            Require.Object(@this);
            Require.NotNull(second, "second");
            Require.NotNull(resultSelectorM, "resultSelectorM");

            Func<TFirst, TSecond, Identity<TResult>> resultSelector = (v1, v2) => resultSelectorM.Invoke(v1, v2);

			// WARNING: Do not remove resultSelector, otherwise .NET will make a recursive call to Zip 
			// instead of using the Zip from Linq.
            return @this.Zip(second, resultSelector: resultSelector).Collect();
        }

        // [Haskell] foldM
        public static Identity<TAccumulate> Fold<TSource, TAccumulate>(
            this IEnumerable<TSource> @this,
            TAccumulate seed,
            Func<TAccumulate, TSource, Identity<TAccumulate>> accumulatorM)
        {
            Require.Object(@this);
            Require.NotNull(accumulatorM, "accumulatorM");

            Identity<TAccumulate> result = Identity.Return(seed);

            foreach (TSource item in @this) {
                result = result.Bind(_ => accumulatorM.Invoke(_, item));
            }

            return result;
        }

        #endregion
	    
        #region Aggregate Operators


        public static Identity<TSource> Reduce<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, TSource, Identity<TSource>> accumulatorM)
        {
            Require.Object(@this);
            Require.NotNull(accumulatorM, "accumulatorM");

            using (var iter = @this.GetEnumerator()) {
                if (!iter.MoveNext()) {
                    throw new InvalidOperationException("Source sequence was empty.");
                }

                Identity<TSource> result = Identity.Return(iter.Current);

                while (iter.MoveNext()) {
                    result = result.Bind(_ => accumulatorM.Invoke(_, iter.Current));
                }

                return result;
            }
        }


        #endregion
    }
}
