﻿namespace Playground.Benchmarks.Internal
{
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Narvalo.Benchmarking;

    class BenchMetricConsoleFormatter : BenchmarkMetricFormatter
    {
        public BenchMetricConsoleFormatter() : base() { }

        public override string Format(CultureInfo cultureInfo, BenchmarkMetricCollection metrics)
        {
            var sb = new StringBuilder(metrics.Name);

            int maxKeyLength = 3 + (from m in metrics select m.Name.Length).Max();
            string format = "{0}. {1,-" + maxKeyLength + "} | {2,-10}";

            int pos = 0;

            foreach (var r in metrics.OrderBy(m => m.Duration)) {
                sb.AppendLine();
                sb.AppendFormat(
                    cultureInfo,
                    format,
                    ++pos,
                    r.Name,
                    r.Duration.ToString());
            }

            return sb.ToString();
        }
    }
}
