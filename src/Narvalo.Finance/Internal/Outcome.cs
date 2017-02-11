﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Finance.Internal
{
    /// <summary>
    /// Provides extension methods for <see cref="Outcome{T}"/>.
    /// </summary>
    internal static class Outcome
    {
        public static Outcome<T> Success<T>(T value) where T : struct
        {
            Warrant.NotNull<Outcome<T>>();

            return Outcome<T>.Return(value);
        }
    }
}