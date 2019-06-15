using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace E2
{
    public class Timer : IDisposable
    {
        private Stopwatch mystopwatch;
        public Timer()
        {
            mystopwatch = new Stopwatch();
            mystopwatch.Start();
        }
        public void Dispose()
        {
            mystopwatch.Stop();
        }
        public long Timercount() => mystopwatch.ElapsedMilliseconds;
    }
    public static class DotNetInterfaces
    {
        public static IEnumerable<long> GetElapsedTimes(int max = 100)
        {
            Timer mytime = new Timer();
            Stopwatch mystopwatch = new Stopwatch();
            List<long> list = new List<long>() { };
            for (int i = 0; i < max; i++)
            {
                mystopwatch.Start();
                for (int j = 0; j < 1; j++)
                {
                    mystopwatch.Stop();
                    yield return mystopwatch.ElapsedMilliseconds;
                    yield break;
                }
              
            }

            


        }
    }
}