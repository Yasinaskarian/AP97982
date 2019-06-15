using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace E2
{
        public static class Threading
      {

           public static void MakeItFaster(params Action[] actions)
           {

                List<Task> t = new List<Task>() { };
                foreach (var item in actions)
                {
                    Task mytask = new Task(item);
                    mytask.Start();
                    t.Add(mytask);
                }
                Task.WaitAll(t.ToArray());

           }
         }
}