﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Internal
{
    using System;

    internal static class MoneyHelpers
    {
        public static void ThrowIfCurrencyMismatch(Money mny, Currency cy)
        {
            if (mny.Currency != cy)
            {
                throw new InvalidOperationException("XXX");
            }
        }

        public static void ThrowIfCurrencyMismatch(Moneypenny pny, Currency cy)
        {
            if (pny.Currency != cy)
            {
                throw new InvalidOperationException("XXX");
            }
        }
    }
}