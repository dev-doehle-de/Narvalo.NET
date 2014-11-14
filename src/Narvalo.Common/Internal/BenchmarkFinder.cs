﻿namespace Narvalo.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Narvalo.Collections;
    using Narvalo.Runtime.Benchmarking;

    class BenchmarkFinder
    {
        const BindingFlags DefaultBindings
           = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static;

        readonly BindingFlags _bindings;

        public BenchmarkFinder() : this(DefaultBindings) { }

        public BenchmarkFinder(BindingFlags bindings)
        {
            _bindings = bindings;
        }

        public IEnumerable<Benchmark> FindBenchmarks(Assembly assembly)
        {
            Require.NotNull(assembly, "assembly");

            return from type in assembly.GetExportedTypes()
                   from benchmark in FindBenchmarks(type)
                   select benchmark;
        }

        public IEnumerable<Benchmark> FindBenchmarks(Type type)
        {
            Require.NotNull(type, "type");

            return type.GetMethods(_bindings).MapAny(BenchmarkFactory.MayCreate);
        }
    }
}