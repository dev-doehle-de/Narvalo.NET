﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Moneta
{
    using System.Diagnostics.Contracts;

    /// <summary>
    /// Represents the "Swiss Franc" currency unit.
    /// </summary>
    public static class SwissFranc
    {
        private static readonly Currency s_Currency = Narvalo.Moneta.Currency.Of("CHF");

        /// <summary>
        /// Gets the "Swiss Franc" currency.
        /// </summary>
        /// <value>The "Swiss Franc" currency.</value>
        public static Currency Currency
        {
            get
            {
                Contract.Ensures(Contract.Result<Currency>() != null);

                return s_Currency;
            }
        }
    }
}