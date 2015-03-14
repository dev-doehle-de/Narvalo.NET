﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Diagnostics.Benchmarking
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Globalization;

    // FIXME: This struct is a bit too large.
    public partial struct BenchmarkMetric
        : IEquatable<BenchmarkMetric>, IFormattable
    {
        private const long TICKS_PER_SECOND = 10000000L;

        private readonly string _categoryName;
        private readonly TimeSpan _duration;
        private readonly int _iterations;
        private readonly string _name;
        private readonly bool _fixedTime;

        public BenchmarkMetric(string categoryName, string name, TimeSpan duration, int iterations)
            : this(categoryName, name, duration, iterations, true)
        {
            Contract.Requires(categoryName != null && categoryName.Length > 0);
            Contract.Requires(name != null && name.Length > 0);
            Contract.Requires(iterations > 0);
            Contract.Requires(duration.Ticks > 0L);
        }

        public BenchmarkMetric(string categoryName, string name, TimeSpan duration, int iterations, bool fixedTime)
        {
            Require.NotNullOrEmpty(categoryName, "categoryName");
            Require.NotNullOrEmpty(name, "name");
            Require.GreaterThanOrEqualTo(iterations, 1, "iterations");
            Require.Condition(duration.Ticks > 0L, Strings_Core.BenchmarkMetric_DurationIsNegative);

            _categoryName = categoryName;
            _name = name;
            _duration = duration;
            _iterations = iterations;
            _fixedTime = fixedTime;
        }

        public long CallsPerSecond
        {
            get { return TICKS_PER_SECOND * Iterations / Duration.Ticks; }
        }

        public string CategoryName
        {
            get
            {
                Contract.Ensures(Contract.Result<string>() != null);
                Contract.Ensures(Contract.Result<string>().Length != 0);

                return _categoryName;
            }
        }

        public TimeSpan Duration
        {
            get
            {
                Contract.Ensures(Contract.Result<TimeSpan>().Ticks > 0L);

                return _duration;
            }
        }

        public int Iterations
        {
            get
            {
                Contract.Ensures(Contract.Result<int>() > 0);

                return _iterations;
            }
        }

        public bool FixedTime { get { return _fixedTime; } }

        public string Name
        {
            get
            {
                Contract.Ensures(Contract.Result<string>() != null);
                Contract.Ensures(Contract.Result<string>().Length != 0);

                return _name;
            }
        }

        public double TicksPerCall
        {
            get { return (double)Duration.Ticks / Iterations; }
        }

        [ContractInvariantMethod]
        [Conditional("CONTRACTS_FULL")]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic",
            Justification = "[CodeContracts] Object Invariants.")]
        private void ObjectInvariants()
        {
            Contract.Invariant(_categoryName != null && _categoryName.Length != 0);
            Contract.Invariant(_name != null && _name.Length != 0);
            Contract.Invariant(_iterations > 0);
            Contract.Invariant(_duration.Ticks > 0L);
        }
    }

    /// <content>
    /// Implements the <see cref="IFormattable"/> interface.
    /// </content>
    public partial struct BenchmarkMetric
    {
        // https://msdn.microsoft.com/en-us/library/26etazsy.aspx
        public override string ToString()
        {
            Contract.Ensures(Contract.Result<string>() != null);

            return CallsPerSecond.ToString("#,0", CultureInfo.CurrentCulture)
                + " call/s; " + Name;
        }

#if !NO_CONTRACTS_SUPPRESSIONS
        [SuppressMessage("Microsoft.Contracts", "Suggestion-18-0",
            Justification = "[CodeContracts] Unrecognized precondition by CCCheck.")]
#endif
        public string ToString(string format)
        {
            Contract.Ensures(Contract.Result<string>() != null);

            return ToString(format, CultureInfo.CurrentCulture);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            Contract.Ensures(Contract.Result<string>() != null);

            if (formatProvider != null)
            {
                var formatter = formatProvider.GetFormat(GetType()) as ICustomFormatter;
                if (formatter != null)
                {
                    var result = formatter.Format(format, this, formatProvider);

                    Contract.Assume(result != null, "ICustomFormatter.Format() should not have returned a null string.");

                    return result;
                }
            }

            if (formatProvider == null)
            {
                formatProvider = CultureInfo.CurrentCulture;
            }

            switch (format)
            {
                case "n":
                    return Name;
                case "d":
                    return String.Format(
                        formatProvider,
                        Strings_Core.MetricFormat,
                        Name,
                        CallsPerSecond,
                        Iterations,
                        Duration.Ticks,
                        TicksPerCall);
                case "G": // Same as ToString().
                default:  // NB: This includes the "null" case.
                    return ToString();
            }
        }
    }

    /// <content>
    /// Implements the <see cref="IEquatable{BenchmarkMetric}"/> interface.
    /// </content>
    public partial struct BenchmarkMetric
    {
        public static bool operator ==(BenchmarkMetric left, BenchmarkMetric right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(BenchmarkMetric left, BenchmarkMetric right)
        {
            return !left.Equals(right);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is BenchmarkMetric))
            {
                return false;
            }

            return Equals((BenchmarkMetric)obj);
        }

        public bool Equals(BenchmarkMetric other)
        {
            return _iterations == other._iterations
                && _duration == other._duration
                && _fixedTime == other._fixedTime
                && _categoryName == other._categoryName
                && _name == other._name;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;

                hash = (23 * hash) + _iterations;
                hash = (23 * hash) + _duration.GetHashCode();
                hash = (23 * hash) + _categoryName.GetHashCode();
                hash = (23 * hash) + _name.GetHashCode();
                hash = (23 * hash) + _fixedTime.GetHashCode();

                return hash;
            }
        }
    }
}