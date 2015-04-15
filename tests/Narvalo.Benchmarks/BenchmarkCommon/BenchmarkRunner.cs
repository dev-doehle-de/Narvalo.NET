﻿// Copyright (c) Narvalo.Org. All rights reserved. See LICENSE.txt in the project root for license information.

namespace Narvalo.BenchmarkCommon
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    public sealed class BenchmarkRunner
    {
        private readonly IBenchmarkTimer _timer;

        private TimeSpan _testDuration = TimeSpan.FromSeconds(10);
        private TimeSpan _warmUpDuration = TimeSpan.FromSeconds(1);

        public BenchmarkRunner(IBenchmarkTimer timer)
        {
            Require.NotNull(timer, "timer");
            Contract.Assume(_testDuration.Ticks > 0L, "'_testDuration.Ticks' is negative.");
            Contract.Assume(_warmUpDuration.Ticks > 0L, "'_warmUpDuration.Ticks' is negative.");

            _timer = timer;
        }

        public TimeSpan TestDuration
        {
            get
            {
                Contract.Ensures(Contract.Result<TimeSpan>().Ticks > 0L);
                return _testDuration;
            }

            set
            {
                Require.GreaterThan(value.Ticks, 0L, "TestDuration.Ticks");
                _testDuration = value;
            }
        }

        public TimeSpan WarmUpDuration
        {
            get
            {
                Contract.Ensures(Contract.Result<TimeSpan>().Ticks > 0L);
                return _warmUpDuration;
            }

            set
            {
                Require.GreaterThan(value.Ticks, 0L, "WarmUpDuration.Ticks");
                _warmUpDuration = value;
            }
        }

        // Constant time benchmarking.
        public BenchmarkMetric Run(Benchmark benchmark)
        {
            Require.NotNull(benchmark, "benchmark");
            Contract.Ensures(Contract.Result<BenchmarkMetric>() != null);

            int iterations = WarmUp_(benchmark.Action);
            TimeSpan duration = Time_(benchmark.Action, iterations);

            return new BenchmarkMetric(benchmark.CategoryName, benchmark.Name, duration, iterations);
        }

        // Benchmark for a pre-defined number of iterations.
        public BenchmarkMetric Run(Benchmark benchmark, int iterations)
        {
            Require.NotNull(benchmark, "benchmark");
            Contract.Requires(iterations > 0);
            Contract.Ensures(Contract.Result<BenchmarkMetric>() != null);

            // Warmup.
            benchmark.Action();

            TimeSpan duration = Time_(benchmark.Action, iterations);

            return new BenchmarkMetric(benchmark.CategoryName, benchmark.Name, duration, iterations, fixedTime: false);
        }

        [SuppressMessage("Microsoft.Reliability", "CA2001:AvoidCallingProblematicMethods", MessageId = "System.GC.Collect",
            Justification = "[Intentionally] The call to GC methods is done on purpose to ensure timing happens in a clean room.")]
        private TimeSpan Time_(Action action, int iterations)
        {
            Promise.NotNull(action, "Null guard for a private method call.");
            Contract.Ensures(Contract.Result<TimeSpan>().Ticks > 0L);

            // Make sure we start with a clean room.
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            _timer.Reset();

            for (int i = 0; i < iterations; i++)
            {
                action.Invoke();
            }

            return _timer.ElapsedTime;
        }

        private int WarmUp_(Action action)
        {
            Promise.NotNull(action, "Null guard for a private method call.");
            Contract.Ensures(Contract.Result<int>() > 0);

            double testTicks = (double)TestDuration.Ticks;
            double maxIterations = (double)(Int32.MaxValue - 1);
            int iterations = 100;
            while (iterations < Int32.MaxValue / 2)
            {
                TimeSpan duration = Time_(action, iterations);

                if (duration >= WarmUpDuration)
                {
                    double scale = testTicks / duration.Ticks;
                    double scaledIterations = scale * iterations;
                    iterations = (int)Math.Min(scaledIterations, maxIterations);
                    Contract.Assume(iterations > 0, "'scaledIterations' or 'maxIterations' is negative.");
                    break;
                }

                iterations *= 2;
            }

            return iterations;
        }

#if CONTRACTS_FULL // Contract Class and Object Invariants.

        [ContractInvariantMethod]
        private void ObjectInvariants()
        {
            Contract.Invariant(_timer != null);
            Contract.Invariant(_testDuration.Ticks > 0L);
            Contract.Invariant(_warmUpDuration.Ticks > 0L);
        }

#endif
    }
}