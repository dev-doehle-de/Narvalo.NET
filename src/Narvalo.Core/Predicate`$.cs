﻿// Copyright (c) 2014, Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo
{
    using System;

    public static class PredicateExtensions
    {
        public static Func<TSource, bool> Negate<TSource>(this Func<TSource, bool> @this)
        {
            Require.Object(@this);

            return _ => !@this.Invoke(_);
        }
    }
}