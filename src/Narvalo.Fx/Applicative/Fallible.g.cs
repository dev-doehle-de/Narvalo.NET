﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by a tool. Changes to this file may cause incorrect
// behavior and will be lost if the code is regenerated.
//
// Runtime Version: 4.0.30319.42000
// Microsoft.VisualStudio.TextTemplating: 15.0
// </auto-generated>
//------------------------------------------------------------------------------

using unit = global::Narvalo.Applicative.Unit;

namespace Narvalo.Applicative
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    using Narvalo.Internal;
    using Narvalo.Linq;

    // Provides a set of static methods for Fallible<T>.
    // T4: EmitHelpers().
    public partial struct Fallible
    {
        /// <summary>
        /// The unique object of type <c>Fallible&lt;Unit&gt;</c>.
        /// </summary>
        private static readonly Fallible<unit> s_Unit = Of(unit.Default);

        /// <summary>
        /// Gets the unique object of type <c>Fallible&lt;Unit&gt;</c>.
        /// </summary>
        public static Fallible<unit> Unit => s_Unit;

        /// <summary>
        /// Obtains an instance of the <see cref="Fallible{T}"/> class for the specified value.
        /// </summary>
        /// <typeparam name="T">The underlying type of <paramref name="value"/>.</typeparam>
        /// <param name="value">A value to be wrapped into an object of type <see cref="Fallible{T}"/>.</param>
        /// <returns>An instance of the <see cref="Fallible{T}"/> class for the specified value.</returns>
        public static Fallible<T> Of<T>(T value) => Fallible<T>.η(value);

        public static Fallible<IEnumerable<TSource>> Repeat<TSource>(
            Fallible<TSource> source,
            int count)
        {
            /* T4: NotNull(source) */
            Require.Range(count >= 0, nameof(count));
            return source.Select(val => Enumerable.Repeat(val, count));
        }

        #region Lift()

        /// <summary>
        /// Promotes a function to use and return <see cref="Fallible{T}" /> values.
        /// </summary>
        /// <seealso cref="FallibleExtensions.Select{T, TResult}" />
        public static Func<Fallible<T>, Fallible<TResult>> Lift<T, TResult>(
            Func<T, TResult> func)
            => arg =>
            {
                /* T4: NotNull(arg) */
                return arg.Select(func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="Fallible{T}" /> values.
        /// </summary>
        /// <seealso cref="FallibleExtensions.Zip{T1, T2, TResult}"/>
        public static Func<Fallible<T1>, Fallible<T2>, Fallible<TResult>>
            Lift<T1, T2, TResult>(Func<T1, T2, TResult> func)
            => (arg1, arg2) =>
            {
                /* T4: NotNull(arg1) */
                return arg1.Zip(arg2, func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="Fallible{T}" /> values.
        /// </summary>
        /// <seealso cref="FallibleExtensions.Zip{T1, T2, T3, TResult}"/>
        public static Func<Fallible<T1>, Fallible<T2>, Fallible<T3>, Fallible<TResult>>
            Lift<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> func)
            => (arg1, arg2, arg3) =>
            {
                /* T4: NotNull(arg1) */
                return arg1.Zip(arg2, arg3, func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="Fallible{T}" /> values.
        /// </summary>
        /// <seealso cref="FallibleExtensions.Zip{T1, T2, T3, T4, TResult}"/>
        public static Func<Fallible<T1>, Fallible<T2>, Fallible<T3>, Fallible<T4>, Fallible<TResult>>
            Lift<T1, T2, T3, T4, TResult>(
            Func<T1, T2, T3, T4, TResult> func)
            => (arg1, arg2, arg3, arg4) =>
            {
                /* T4: NotNull(arg1) */
                return arg1.Zip(arg2, arg3, arg4, func);
            };

        /// <summary>
        /// Promotes a function to use and return <see cref="Fallible{T}" /> values.
        /// </summary>
        /// <seealso cref="FallibleExtensions.Zip{T1, T2, T3, T4, T5, TResult}"/>
        public static Func<Fallible<T1>, Fallible<T2>, Fallible<T3>, Fallible<T4>, Fallible<T5>, Fallible<TResult>>
            Lift<T1, T2, T3, T4, T5, TResult>(
            Func<T1, T2, T3, T4, T5, TResult> func)
            => (arg1, arg2, arg3, arg4, arg5) =>
            {
                /* T4: NotNull(arg1) */
                return arg1.Zip(arg2, arg3, arg4, arg5, func);
            };

        #endregion
    }

    // Provides extension methods for Fallible<T>.
    // T4: EmitExtensions().
    public static partial class FallibleExtensions
    {
        /// <summary>
        /// Removes one level of structure, projecting its bound value into the outer level.
        /// </summary>
        public static Fallible<T> Flatten<T>(this Fallible<Fallible<T>> @this)
            => Fallible<T>.μ(@this);

        /// <seealso cref="Ap.Apply{TSource, TResult}(Fallible{Func{TSource, TResult}}, Fallible{TSource})" />
        public static Fallible<TResult> Gather<TSource, TResult>(
            this Fallible<TSource> @this,
            Fallible<Func<TSource, TResult>> applicative)
        {
            /* T4: NotNull(@this) */
            /* T4: NotNull(applicative) */
            return applicative.Bind(func => @this.Select(func));
        }

        public static Fallible<TResult> ReplaceBy<TSource, TResult>(
            this Fallible<TSource> @this,
            TResult value)
        {
            /* T4: NotNull(@this) */
            return @this.Select(_ => value);
        }

        public static Fallible<TResult> ContinueWith<TSource, TResult>(
            this Fallible<TSource> @this,
            Fallible<TResult> other)
        {
            /* T4: NotNull(@this) */
            return @this.Bind(_ => other);
        }

        public static Fallible<TSource> PassBy<TSource, TOther>(
            this Fallible<TSource> @this,
            Fallible<TOther> other)
        {
            /* T4: NotNull(@this) */
            return @this.Zip(other, (arg, _) => arg);
        }

        public static Fallible<unit> Skip<TSource>(this Fallible<TSource> @this)
        {
            /* T4: NotNull(@this) */
            return @this.ContinueWith(Fallible.Unit);
        }

        #region Zip()

        /// <seealso cref="Fallible.Lift{T1, T2, TResult}"/>
        public static Fallible<TResult> Zip<T1, T2, TResult>(
            this Fallible<T1> @this,
            Fallible<T2> second,
            Func<T1, T2, TResult> zipper)
        {
            /* T4: NotNull(@this) */
            /* T4: NotNull(second) */
            Require.NotNull(zipper, nameof(zipper));

            return @this.Bind(
                arg1 => second.Select(
                    arg2 => zipper(arg1, arg2)));
        }

        /// <seealso cref="Fallible.Lift{T1, T2, T3, TResult}"/>
        public static Fallible<TResult> Zip<T1, T2, T3, TResult>(
            this Fallible<T1> @this,
            Fallible<T2> second,
            Fallible<T3> third,
            Func<T1, T2, T3, TResult> zipper)
        {
            /* T4: NotNull(@this) */
            /* T4: NotNull(second) */
            /* T4: NotNull(third) */
            Require.NotNull(zipper, nameof(zipper));

            // This is the same as:
            // > return @this.Bind(
            // >     arg1 => second.Bind(
            // >        arg2 => third.Select(
            // >            arg3 => zipper(arg1, arg2, arg3))));
            // but faster if Zip is locally shadowed.
            return @this.Bind(
                arg1 => second.Zip(
                    third, (arg2, arg3) => zipper(arg1, arg2, arg3)));
        }

        /// <seealso cref="Fallible.Lift{T1, T2, T3, T4, TResult}"/>
        public static Fallible<TResult> Zip<T1, T2, T3, T4, TResult>(
             this Fallible<T1> @this,
             Fallible<T2> second,
             Fallible<T3> third,
             Fallible<T4> fourth,
             Func<T1, T2, T3, T4, TResult> zipper)
        {
            /* T4: NotNull(@this) */
            /* T4: NotNull(second) */
            /* T4: NotNull(third) */
            /* T4: NotNull(fourth) */
            Require.NotNull(zipper, nameof(zipper));

            // > return @this.Bind(
            // >     arg1 => second.Bind(
            // >         arg2 => third.Bind(
            // >             arg3 => fourth.Select(
            // >                 arg4 => zipper(arg1, arg2, arg3, arg4)))));
            return @this.Bind(
                arg1 => second.Zip(
                    third,
                    fourth,
                    (arg2, arg3, arg4) => zipper(arg1, arg2, arg3, arg4)));
        }

        /// <seealso cref="Fallible.Lift{T1, T2, T3, T4, T5, TResult}"/>
        public static Fallible<TResult> Zip<T1, T2, T3, T4, T5, TResult>(
            this Fallible<T1> @this,
            Fallible<T2> second,
            Fallible<T3> third,
            Fallible<T4> fourth,
            Fallible<T5> fifth,
            Func<T1, T2, T3, T4, T5, TResult> zipper)
        {
            /* T4: NotNull(@this) */
            /* T4: NotNull(second) */
            /* T4: NotNull(third) */
            /* T4: NotNull(fourth) */
            /* T4: NotNull(fifth) */
            Require.NotNull(zipper, nameof(zipper));

            // > return @this.Bind(
            // >     arg1 => second.Bind(
            // >         arg2 => third.Bind(
            // >             arg3 => fourth.Bind(
            // >                 arg4 => fifth.Select(
            // >                     arg5 => zipper(arg1, arg2, arg3, arg4, arg5))))));
            return @this.Bind(
                arg1 => second.Zip(
                    third,
                    fourth,
                    fifth,
                    (arg2, arg3, arg4, arg5) => zipper(arg1, arg2, arg3, arg4, arg5)));
        }

        #endregion

        #region Resource management

        // Bind() with automatic resource management.
        public static Fallible<TResult> Using<TSource, TResult>(
            this Fallible<TSource> @this,
            Func<TSource, Fallible<TResult>> binder)
            where TSource : IDisposable
        {
            /* T4: NotNull(@this) */
            Require.NotNull(binder, nameof(binder));
            return @this.Bind(val => { using (val) { return binder(val); } });
        }

        // Select() with automatic resource management.
        public static Fallible<TResult> Using<TSource, TResult>(
            this Fallible<TSource> @this,
            Func<TSource, TResult> selector)
            where TSource : IDisposable
        {
            /* T4: NotNull(@this) */
            Require.NotNull(selector, nameof(selector));
            return @this.Select(val => { using (val) { return selector(val); } });
        }

        #endregion

        #region Query Expression Pattern

        public static Fallible<TResult> Select<TSource, TResult>(
            this Fallible<TSource> @this,
            Func<TSource, TResult> selector)
        {
            /* T4: NotNull(@this) */
            Require.NotNull(selector, nameof(selector));
            return @this.Bind(val => Fallible<TResult>.η(selector(val)));
        }

        // Generalizes both Bind() and Zip<T1, T2, TResult>().
        public static Fallible<TResult> SelectMany<TSource, TMiddle, TResult>(
            this Fallible<TSource> @this,
            Func<TSource, Fallible<TMiddle>> selector,
            Func<TSource, TMiddle, TResult> resultSelector)
        {
            /* T4: NotNull(@this) */
            Require.NotNull(selector, nameof(selector));
            Require.NotNull(resultSelector, nameof(resultSelector));

            return @this.Bind(
                val => selector(val).Select(
                    middle => resultSelector(val, middle)));
        }

        #endregion
    }

    // Provides extension methods for Fallible<Func<TSource, TResult>>.
    // T4: EmitApplicative().
    public static partial class Ap
    {
        /// <seealso cref="FallibleExtensions.Gather{TSource, TResult}" />
        public static Fallible<TResult> Apply<TSource, TResult>(
            this Fallible<Func<TSource, TResult>> @this,
            Fallible<TSource> value)
        {
            /* T4: NotNull(value) */
            return value.Gather(@this);
        }
    }

    // Provides extension methods for functions in the Kleisli category.
    // T4: EmitKleisli().
    public static partial class Kleisli
    {
        public static Fallible<IEnumerable<TResult>> InvokeWith<TSource, TResult>(
            this Func<TSource, Fallible<TResult>> @this,
            IEnumerable<TSource> seq)
            => seq.SelectWith(@this);

        public static Fallible<TResult> InvokeWith<TSource, TResult>(
            this Func<TSource, Fallible<TResult>> @this,
            Fallible<TSource> value)
        {
            /* T4: NotNull(value) */
            return value.Bind(@this);
        }

        public static Func<TSource, Fallible<TResult>> Compose<TSource, TMiddle, TResult>(
            this Func<TSource, Fallible<TMiddle>> @this,
            Func<TMiddle, Fallible<TResult>> second)
        {
            Require.NotNull(@this, nameof(@this));
            return arg => @this(arg).Bind(second);
        }

        public static Func<TSource, Fallible<TResult>> ComposeBack<TSource, TMiddle, TResult>(
            this Func<TMiddle, Fallible<TResult>> @this,
            Func<TSource, Fallible<TMiddle>> second)
        {
            Require.NotNull(second, nameof(second));
            return arg => second(arg).Bind(@this);
        }
    }

    // Provides extension methods for IEnumerable<Fallible<T>>.
    // T4: EmitEnumerableExtensions().
    public static partial class FallibleExtensions
    {
        public static Fallible<IEnumerable<TSource>> Collect<TSource>(
            this IEnumerable<Fallible<TSource>> source)
            => source.CollectImpl();
    }
}

namespace Narvalo.Internal
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;

    using Narvalo.Applicative;

    // Provides default implementations for the extension methods for IEnumerable<Fallible<T>>.
    // You will certainly want to override them to improve performance.
    // T4: EmitEnumerableInternal().
    internal static partial class EnumerableExtensions
    {
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Fallible<IEnumerable<TSource>> CollectImpl<TSource>(
            this IEnumerable<Fallible<TSource>> source)
        {
            Require.NotNull(source, nameof(source));
            return Fallible<IEnumerable<TSource>>.η(CollectIterator(source));
        }

        private static IEnumerable<TSource> CollectIterator<TSource>(IEnumerable<Fallible<TSource>> source)
        {
            Debug.Assert(source != null);

            var item = default(TSource);

            using (var iter = source.GetEnumerator())
            {
                while (iter.MoveNext())
                {
                    var append = false;

                    iter.Current.Bind(
                        val =>
                        {
                            append = true;
                            item = val;

                            return Fallible.Unit;
                        });

                    if (append) { yield return item; }
                }
            }
        }
    }
}

namespace Narvalo.Linq
{
    using System;
    using System.Collections.Generic;

    using Narvalo.Applicative;
    using Narvalo.Internal;

    // Provides extension methods for IEnumerable<T>.
    // We do not use the standard LINQ names to avoid any confusion.
    // - Select    -> SelectWith
    // - Where     -> WhereBy
    // - Zip       -> ZipWith
    // - Aggregate -> Reduce or Fold
    // T4: EmitLinqCore().
    public static partial class Sequence
    {
        public static Fallible<IEnumerable<TResult>> SelectWith<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, Fallible<TResult>> selector)
            => source.SelectWithImpl(selector);

        public static Fallible<IEnumerable<TSource>> WhereBy<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, Fallible<bool>> predicate)
            => source.WhereByImpl(predicate);

        public static Fallible<IEnumerable<TResult>> ZipWith<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> source,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, Fallible<TResult>> resultSelector)
            => source.ZipWithImpl(second, resultSelector);

        public static Fallible<TAccumulate> Fold<TSource, TAccumulate>(
            this IEnumerable<TSource> source,
            TAccumulate seed,
            Func<TAccumulate, TSource, Fallible<TAccumulate>> accumulator)
            => source.FoldImpl(seed, accumulator);

        public static Fallible<TAccumulate> Fold<TSource, TAccumulate>(
            this IEnumerable<TSource> source,
            TAccumulate seed,
            Func<TAccumulate, TSource, Fallible<TAccumulate>> accumulator,
            Func<Fallible<TAccumulate>, bool> predicate)
            => source.FoldImpl(seed, accumulator, predicate);

        public static Fallible<TSource> Reduce<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, TSource, Fallible<TSource>> accumulator)
            => source.ReduceImpl(accumulator);

        public static Fallible<TSource> Reduce<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, TSource, Fallible<TSource>> accumulator,
            Func<Fallible<TSource>, bool> predicate)
            => source.ReduceImpl(accumulator, predicate);
    }
}

namespace Narvalo.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    using Narvalo.Applicative;

    // Provides default implementations for the extension methods for IEnumerable<T>.
    // You will certainly want to override them to improve performance.
    // T4: EmitLinqInternal().
    internal static partial class EnumerableExtensions
    {
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Fallible<IEnumerable<TResult>> SelectWithImpl<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, Fallible<TResult>> selector)
        {
            Debug.Assert(source != null);
            Debug.Assert(selector != null);

            return source.Select(selector).Collect();
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Fallible<IEnumerable<TSource>> WhereByImpl<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, Fallible<bool>> predicate)
        {
            Require.NotNull(source, nameof(source));
            Require.NotNull(predicate, nameof(predicate));

            return Fallible<IEnumerable<TSource>>.η(WhereByIterator(source, predicate));
        }

        private static IEnumerable<TSource> WhereByIterator<TSource>(
            IEnumerable<TSource> source,
            Func<TSource, Fallible<bool>> predicate)
        {
            Debug.Assert(source != null);
            Debug.Assert(predicate != null);

            using (var iter = source.GetEnumerator())
            {
                while (iter.MoveNext())
                {
                    bool pass = false;
                    TSource item = iter.Current;

                    predicate(item).Bind(val =>
                    {
                        pass = val;

                        return Fallible.Unit;
                    });

                    if (pass) { yield return item; }
                }
            }
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Fallible<IEnumerable<TResult>> ZipWithImpl<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> source,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, Fallible<TResult>> resultSelector)
        {
            Debug.Assert(resultSelector != null);
            Debug.Assert(source != null);
            Debug.Assert(second != null);

            return source.Zip(second, resultSelector).Collect();
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Fallible<TAccumulate> FoldImpl<TSource, TAccumulate>(
            this IEnumerable<TSource> source,
            TAccumulate seed,
            Func<TAccumulate, TSource, Fallible<TAccumulate>> accumulator)
        {
            Require.NotNull(source, nameof(source));
            Require.NotNull(accumulator, nameof(accumulator));

            Fallible<TAccumulate> retval = Fallible<TAccumulate>.η(seed);

            using (var iter = source.GetEnumerator())
            {
                while (iter.MoveNext())
                {
                    retval = retval.Bind(val => accumulator(val, iter.Current));
                }
            }

            return retval;
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Fallible<TAccumulate> FoldImpl<TSource, TAccumulate>(
            this IEnumerable<TSource> source,
            TAccumulate seed,
            Func<TAccumulate, TSource, Fallible<TAccumulate>> accumulator,
            Func<Fallible<TAccumulate>, bool> predicate)
        {
            Require.NotNull(source, nameof(source));
            Require.NotNull(accumulator, nameof(accumulator));
            Require.NotNull(predicate, nameof(predicate));

            Fallible<TAccumulate> retval = Fallible<TAccumulate>.η(seed);

            using (var iter = source.GetEnumerator())
            {
                while (predicate(retval) && iter.MoveNext())
                {
                    retval = retval.Bind(val => accumulator(val, iter.Current));
                }
            }

            return retval;
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Fallible<TSource> ReduceImpl<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, TSource, Fallible<TSource>> accumulator)
        {
            Require.NotNull(source, nameof(source));
            Require.NotNull(accumulator, nameof(accumulator));

            using (var iter = source.GetEnumerator())
            {
                if (!iter.MoveNext())
                {
                    throw new InvalidOperationException("Source sequence was empty.");
                }

                Fallible<TSource> retval = Fallible<TSource>.η(iter.Current);

                while (iter.MoveNext())
                {
                    retval = retval.Bind(val => accumulator(val, iter.Current));
                }

                return retval;
            }
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "[GeneratedCode] This method has been overridden locally.")]
        internal static Fallible<TSource> ReduceImpl<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, TSource, Fallible<TSource>> accumulator,
            Func<Fallible<TSource>, bool> predicate)
        {
            Require.NotNull(source, nameof(source));
            Require.NotNull(accumulator, nameof(accumulator));
            Require.NotNull(predicate, nameof(predicate));

            using (var iter = source.GetEnumerator())
            {
                if (!iter.MoveNext())
                {
                    throw new InvalidOperationException("Source sequence was empty.");
                }

                Fallible<TSource> retval = Fallible<TSource>.η(iter.Current);

                while (predicate(retval) && iter.MoveNext())
                {
                    retval = retval.Bind(val => accumulator(val, iter.Current));
                }

                return retval;
            }
        }
    }
}
