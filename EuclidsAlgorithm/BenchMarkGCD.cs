using System;
using System.Diagnostics;

namespace EuclidsAlgorithm
{
    public static class BenchMarkGCD
    {
        public delegate int Calculate(int a, int b);
        static private Calculate _calc;
        public const int Factor = 32; 
        static public void CalculateGCDExecTime(out double milliseconds, Calculate calculateGCD)
        {
            Random rand = new Random(Environment.TickCount);
            int randomNum1, randomNum2;
            _calc = calculateGCD;

            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            for (int i = 0; i < 1000; i++)
            {
                randomNum1 = rand.Next(1, 100000) * Factor;
                randomNum2 = rand.Next(1, 100000) * Factor;
                _calc(randomNum1, randomNum2);
            }
            stopWatch.Stop();

            TimeSpan ts = stopWatch.Elapsed;

            milliseconds = ts.TotalMilliseconds;
        }
    }
}
