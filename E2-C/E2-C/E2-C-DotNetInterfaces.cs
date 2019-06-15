using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace E2
{
    public static class DotNetInterfaces
    {
        public static IEnumerable<long> GetElapsedTimes(int max = 100)
        {
            Stopwatch mystopwatch = new Stopwatch();
            mystopwatch.Start();
            List<long> li = new List<long>() { };
            li.Add(0);
            li.Add(0);
            for (int i = 0; i <= max; i++)
            {
                yield return li[li.Count-1]-li[li.Count-2] ;
                li.Add(mystopwatch.ElapsedMilliseconds);
            }
        }
    }
}