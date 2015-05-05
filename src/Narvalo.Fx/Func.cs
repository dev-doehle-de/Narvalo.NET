﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Fx
{
    using System;
    using System.Diagnostics.Contracts;

    public static class Func
    {
        public static Func<T> Return<T>(T value)
        {
            Contract.Ensures(Contract.Result<Func<T>>() != null);

            return () => value;
        }

        public static Func<T> Flatten<T>(Func<Func<T>> square)
        {
            Require.NotNull(square, "square");

            return square.Invoke();
        }
    }
}
