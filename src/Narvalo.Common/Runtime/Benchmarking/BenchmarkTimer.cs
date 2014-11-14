namespace Narvalo.Runtime.Benchmarking
{
    using System.Diagnostics;
    using NodaTime;

    public class BenchmarkTimer : IBenchmarkTimer
    {
        readonly Stopwatch _stopwatch = Stopwatch.StartNew();

        public void Reset()
        {
            _stopwatch.Reset();
            _stopwatch.Start();
        }

        public Duration ElapsedTime
        {
            get { return Duration.FromTicks(_stopwatch.Elapsed.Ticks); }
        }
    }
}