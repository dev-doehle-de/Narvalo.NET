﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Applicative
{
    using System;

    public static partial class Either
    {
        public static Either<TLeft, TRight> FlattenLeft<TLeft, TRight>(Either<Either<TLeft, TRight>, TRight> square)
            => Either<TLeft, TRight>.μ(square);

        public static Either<TLeft, TRight> FlattenRight<TLeft, TRight>(Either<TLeft, Either<TLeft, TRight>> square)
            => Either<TLeft, TRight>.FlattenRight(square);
    }

    // Provides extension methods for Either<TLeft, TRight>.
    public static partial class Either
    {
        public static Either<TResult, TRight> SelectLeft<TLeft, TRight, TResult>(
            this Either<TLeft, TRight> @this,
            Func<TLeft, TResult> selector)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(selector, nameof(selector));

            return @this.BindLeft(val => Either<TResult, TRight>.OfLeft(selector(val)));
        }

        public static Either<TLeft, TResult> SelectRight<TLeft, TRight, TResult>(
            this Either<TLeft, TRight> @this,
            Func<TRight, TResult> selector)
        {
            Require.NotNull(@this, nameof(@this));
            Require.NotNull(selector, nameof(selector));

            return @this.BindRight(val => Either<TLeft, TResult>.OfRight(selector(val)));
        }
    }
}
