using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace A13
{
    public class Watcher : IDisposable
    {
        private Stopwatch Mystopwatch;
        public Watcher()
        {
            Mystopwatch = new Stopwatch();
            Mystopwatch.Start();
        }
        public void Dispose()
        {
            Mystopwatch.Stop();
        }
        public long Timercount() => Mystopwatch.ElapsedMilliseconds;
    }
    public static class ActionTools
    {
        public static long CallSequential(params Action[] actions)
        {
            Watcher myTime = new Watcher();
            using (myTime)
            {
                foreach (var v in actions)
                    v();
            }
            return myTime.Timercount();
        }

        public static long CallParallel(params Action[] actions)
        {
            Watcher myTime = new Watcher();
            using (myTime)
            {
                List<Task> taskManager = new List<Task>() { };
                foreach (var v in actions)
                {
                    Task mytask = new Task(v);
                    mytask.Start();
                    taskManager.Add(mytask);
                }
                Task.WaitAll(taskManager.ToArray());
            }
            return myTime.Timercount();
        }

        public static long CallParallelThreadSafe(int count, params Action[] actions)
        {
            object sync = new object();
            Watcher myTime = new Watcher();
            using (myTime)
            {
                List<Task> taskManager = new List<Task>() { };
                for (int i = 0; i < count; i++)
                {
                    lock (sync)
                    {
                        foreach (var v in actions)
                        {
                            lock (sync)
                            {
                                Task mytask = new Task(v);
                                mytask.Start();
                                taskManager.Add(mytask);
                                Task.WaitAll(taskManager.ToArray());
                            }
                        }
                      
                    }
                    
                }
            }
            return myTime.Timercount();
        }


        public static async Task<long> CallSequentialAsync(params Action[] actions)
        {
            return await Task.Run(() =>
            {
                Watcher myTime = new Watcher();
                using (myTime)
                {

                    List<Task> taskManager = new List<Task>() { };
                    foreach (var v in actions)
                    {
                        v();
                    }

                }
                return myTime.Timercount();
            });
            
        }

        public static async Task<long> CallParallelAsync(params Action[] actions)
        {
            return await Task.Run(() =>
            {
                Watcher myTime = new Watcher();
                using (myTime)
                {
                    List<Task> taskManager = new List<Task>() { };
                    foreach (var v in actions)
                    {
                        Task mytask = new Task(v);
                        mytask.Start();
                        taskManager.Add(mytask);
                    }
                    Task.WaitAll(taskManager.ToArray());
                }
                return myTime.Timercount();
            });
        }

        public static async Task<long> CallParallelThreadSafeAsync(int count, params Action[] actions)
        {
            return await Task.Run(() =>
            {
                object sync = new object();
                Watcher myTime = new Watcher();
                using (myTime)
                {
                    List<Task> taskManager = new List<Task>() { };
                    for (int i = 0; i < count; i++)
                    {
                        lock (sync)
                        {
                            foreach (var v in actions)
                            {
                                lock (sync)
                                {
                                    Task mytask = new Task(v);
                                    mytask.Start();
                                    taskManager.Add(mytask);
                                    Task.WaitAll(taskManager.ToArray());
                                }
                            }

                        }

                    }
                }
                return myTime.Timercount();
            });
        }
    }
}