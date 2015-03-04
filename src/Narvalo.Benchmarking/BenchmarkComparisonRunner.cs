﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.Benchmarking
{
    using System.Diagnostics.Contracts;
    using System.Linq;

    using Narvalo;
    using Narvalo.Benchmarking.Internal;

    public sealed class BenchmarkComparisonRunner
    {
        private readonly BenchmarkComparator _comparator;

        private BenchmarkComparisonRunner(BenchmarkComparator comparator)
        {
            Require.NotNull(comparator, "comparator");

            _comparator = comparator;
        }

        public static BenchmarkComparisonRunner Create()
        {
            return Create(new BenchmarkTimer());
        }

        public static BenchmarkComparisonRunner Create(IBenchmarkTimer timer)
        {
            Contract.Requires(timer != null);

            return new BenchmarkComparisonRunner(new BenchmarkComparator(new Benchmarker(timer)));
        }

        public BenchmarkMetricCollection Run(BenchmarkComparison comparison)
        {
            Require.NotNull(comparison, "comparison");

            var metrics = _comparator.Compare(comparison);

            return new BenchmarkMetricCollection(comparison.Name, metrics.ToList());
        }
    }
}
