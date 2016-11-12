﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Fx.Advanced
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static System.Diagnostics.Contracts.Contract;

    /// <summary>
    /// Provides extension methods for <see cref="IEnumerable{T}"/>.
    /// </summary>
    public static partial class EnumerableExtensions
    {
        public static IEnumerable<TResult> MapAny<TSource, TResult>(
            this IEnumerable<TSource> @this,
            Func<TSource, Maybe<TResult>> funM)
        {
            Require.Object(@this);
            Require.NotNull(funM, nameof(funM));
            Ensures(Result<IEnumerable<TResult>>() != null);

            return (from _ in @this
                    let m = funM.Invoke(_)
                    where m.IsSome
                    select m.Value).EmptyIfNull();
        }

        public static IEnumerable<TResult> MapAny<TSource, TResult>(
            this IEnumerable<TSource> @this,
            Func<TSource, Outcome<TResult>> funM)
        {
            Require.Object(@this);
            Require.NotNull(funM, nameof(funM));
            Ensures(Result<IEnumerable<TResult>>() != null);

            return (from _ in @this
                    let m = funM.Invoke(_)
                    where m.IsSuccess
                    select m.ToValue()).EmptyIfNull();
        }

        #region Overrides for auto-generated (extension) methods

        internal static IEnumerable<TSource> FilterCore<TSource>(
            this IEnumerable<TSource> @this,
            Func<TSource, Maybe<bool>> predicateM)
        {
            Require.Object(@this);
            Require.NotNull(predicateM, nameof(predicateM));
            Ensures(Result<IEnumerable<TSource>>() != null);

            return @this
                .Where(_ => predicateM.Invoke(_).ValueOrElse(false))
                .EmptyIfNull();
        }

        #endregion
    }
}
