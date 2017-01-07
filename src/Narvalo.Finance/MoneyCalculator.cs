﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Finance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Narvalo.Finance.Numerics;
    using Narvalo.Finance.Properties;

    // Addition with rounding.
    public static partial class MoneyCalculator
    {
        public static Money Plus(this Money @this, decimal amount)
            => Plus(@this, amount, MoneyRounding.Default);

        public static Money Plus(this Money @this, decimal amount, MoneyRounding rounding)
        {
            if (amount == 0m) { return @this; }
            return new Money(@this.Amount + amount, @this.Currency, rounding);
        }

        public static Money Plus(this Money @this, decimal amount, IDecimalRounding rounding)
        {
            if (amount == 0m) { return @this; }
            return new Money(@this.Amount + amount, @this.Currency, rounding);
        }

        public static Money Plus(this Money @this, Money other)
            => Plus(@this, other, MoneyRounding.Default);

        public static Money Plus(this Money @this, Money other, MoneyRounding rounding)
        {
            ThrowIfCurrencyMismatch(@this, other, nameof(other));

            if (@this.IsNormalized && other.IsNormalized) { rounding = MoneyRounding.Unnecessary; }

            return new Money(@this.Amount + other.Amount, @this.Currency, rounding);
        }

        public static Money Plus(this Money @this, Money other, IDecimalRounding rounding)
        {
            ThrowIfCurrencyMismatch(@this, other, nameof(other));

            return @this.IsNormalized && other.IsNormalized
                ? new Money(@this.Amount + other.Amount, @this.Currency, MoneyRounding.Unnecessary)
                : new Money(@this.Amount + other.Amount, @this.Currency, rounding);
        }
    }

    // Subtraction with rounding.
    public static partial class MoneyCalculator
    {
        public static Money Minus(this Money @this, decimal amount)
            => Plus(@this, -amount, MoneyRounding.Default);

        public static Money Minus(this Money @this, decimal amount, MoneyRounding rounding)
            => Plus(@this, -amount, rounding);

        public static Money Minus(this Money @this, decimal amount, IDecimalRounding rounding)
            => Plus(@this, -amount, rounding);

        public static Money Minus(this Money @this, Money other)
            => Minus(@this, other, MoneyRounding.Default);

        public static Money Minus(this Money @this, Money other, MoneyRounding rounding)
        {
            ThrowIfCurrencyMismatch(@this, other, nameof(other));

            if (@this.IsNormalized && other.IsNormalized) { rounding = MoneyRounding.Unnecessary; }

            return new Money(@this.Amount - other.Amount, @this.Currency, rounding);
        }

        public static Money Minus(this Money @this, Money other, IDecimalRounding rounding)
        {
            ThrowIfCurrencyMismatch(@this, other, nameof(other));

            return @this.IsNormalized && other.IsNormalized
                ? new Money(@this.Amount - other.Amount, @this.Currency, MoneyRounding.Unnecessary)
                : new Money(@this.Amount - other.Amount, @this.Currency, rounding);
        }
    }

    // Multiplication with rounding.
    public static partial class MoneyCalculator
    {
        public static Money MultiplyBy(this Money @this, decimal multiplier)
            => MultiplyBy(@this, multiplier, MoneyRounding.Default);

        public static Money MultiplyBy(this Money @this, decimal multiplier, MoneyRounding rounding)
            => new Money(multiplier * @this.Amount, @this.Currency, rounding);

        public static Money MultiplyBy(this Money @this, decimal multiplier, IDecimalRounding rounding)
            => new Money(multiplier * @this.Amount, @this.Currency, rounding);
    }

    // Division with rounding.
    public static partial class MoneyCalculator
    {
        public static Money DivideBy(this Money @this, decimal divisor)
            => DivideBy(@this, divisor, MoneyRounding.Default);

        public static Money DivideBy(this Money @this, decimal divisor, MoneyRounding rounding)
        {
            if (divisor == 0m) { throw new DivideByZeroException(); }
            return new Money(@this.Amount / divisor, @this.Currency, rounding);
        }

        public static Money DivideBy(this Money @this, decimal divisor, IDecimalRounding rounding)
        {
            if (divisor == 0m) { throw new DivideByZeroException(); }
            return new Money(@this.Amount / divisor, @this.Currency, rounding);
        }
    }

    // Remainder with rounding.
    public static partial class MoneyCalculator
    {
        public static Money Modulo(this Money @this, decimal divisor)
            => Modulo(@this, divisor, MoneyRounding.Default);

        public static Money Modulo(this Money @this, decimal divisor, MoneyRounding rounding)
        {
            if (divisor == 0m) { throw new DivideByZeroException(); }
            return new Money(@this.Amount % divisor, @this.Currency, rounding);
        }

        public static Money Modulo(this Money @this, decimal divisor, IDecimalRounding rounding)
        {
            if (divisor == 0m) { throw new DivideByZeroException(); }
            return new Money(@this.Amount % divisor, @this.Currency, rounding);
        }
    }

    // Allocation / Distribution.
    public static partial class MoneyCalculator
    {
        public static IEnumerable<Money> Distribute(this Money @this, int decimalPlaces, int parts)
            => Distribute(@this, decimalPlaces, parts, MoneyRounding.Default);

        public static IEnumerable<Money> Distribute(
            this Money @this,
            int decimalPlaces,
            int parts,
            MoneyRounding rounding)
        {
            Require.True(rounding != MoneyRounding.Unnecessary, nameof(rounding));

            if (rounding == MoneyRounding.None)
            {
                return from _
                       in DecimalCalculator.Distribute(@this.Amount, parts)
                       select new Money(_, @this.Currency, MoneyRounding.None);
            }
            else
            {
                var mode = rounding.ToRoundingMode();

                return from _
                       in DecimalCalculator.Distribute(@this.Amount, decimalPlaces, parts, mode)
                       select new Money(_, @this.Currency, MoneyRounding.Unnecessary);
            }
        }

        public static IEnumerable<Money> Distribute(
            this Money @this,
            int decimalPlaces,
            int parts,
            IDecimalRounding rounding)
        {
            Require.NotNull(rounding, nameof(rounding));

            return from _
                   in DecimalCalculator.Distribute(@this.Amount, decimalPlaces, parts, rounding)
                   select new Money(_, @this.Currency, MoneyRounding.Unnecessary);
        }

        public static IEnumerable<Money> Allocate(this Money @this, int decimalPlaces, RatioArray ratios)
            => Allocate(@this, decimalPlaces, ratios, MoneyRounding.Default);

        public static IEnumerable<Money> Allocate(
            this Money @this,
            int decimalPlaces,
            RatioArray ratios,
            MoneyRounding rounding)
        {
            Require.True(rounding != MoneyRounding.Unnecessary, nameof(rounding));

            if (rounding == MoneyRounding.None)
            {
                return from _
                       in DecimalCalculator.Allocate(@this.Amount, ratios)
                       select new Money(_, @this.Currency, MoneyRounding.None);
            }
            else
            {
                var mode = rounding.ToRoundingMode();

                return from _
                       in DecimalCalculator.Allocate(@this.Amount, decimalPlaces, ratios, mode)
                       select new Money(_, @this.Currency, MoneyRounding.Unnecessary);
            }
        }

        public static IEnumerable<Money> Allocate(
            this Money @this,
            int decimalPlaces,
            RatioArray ratios,
            IDecimalRounding rounding)
        {
            Require.NotNull(rounding, nameof(rounding));

            return from _
                   in DecimalCalculator.Allocate(@this.Amount, decimalPlaces, ratios, rounding)
                   select new Money(_, @this.Currency, MoneyRounding.Unnecessary);
        }
    }

    // Helpers.
    public static partial class MoneyCalculator
    {
        private static void ThrowIfCurrencyMismatch(Money @this, Money that, string parameterName)
            => Enforce.True(@this.Currency != that.Currency, parameterName, Strings.Argument_CurrencyMismatch);
    }
}
