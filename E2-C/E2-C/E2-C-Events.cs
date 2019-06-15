using System;
using System.Collections.Generic;
using System.Timers;

namespace E2
{
    public class DuplicateNumberDetector
    {
        List<int> numers = new List<int>() { };
        public void AddNumber(int n)
        {
            if (numers.Contains(n))
            {
                DuplicateNumberAdded(n);
            }
            else
             numers.Add(n);
        }

        public event Action<int> DuplicateNumberAdded;
    }
}