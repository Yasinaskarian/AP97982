using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace A13
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
    public static class ActionTools
    {
        public static long CallSequential(params Action[] actions)
        {
            
           
            Timer mytime = new Timer();
            using (mytime)
            {
                foreach (var v in actions)
                    v();
            }
            return mytime.Timercount();
        }

        public static long CallParallel(params Action[] actions)
        {
            Timer mytime = new Timer();
            using (mytime)
            {
                List<Task> taskmaneger = new List<Task>() { };
                foreach (var v in actions)
                {
                    Task mytask = new Task(v);
                    mytask.Start();
                    taskmaneger.Add(mytask);
                }
                Task.WaitAll(taskmaneger.ToArray());
            }
            return mytime.Timercount();
        }

        public static long CallParallelThreadSafe(int count, params Action[] actions)
        {
            object sync = new object();
            Timer mytime = new Timer();
            using (mytime)
            {
                List<Task> taskmaneger = new List<Task>() { };
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
                                taskmaneger.Add(mytask);
                                Task.WaitAll(taskmaneger.ToArray());
                            }
                        }
                      
                    }
                    
                }
            }
            return mytime.Timercount();
        }


        public static async Task<long> CallSequentialAsync(params Action[] actions)
        {

            return await Task.Run(() =>
            {
                Timer mytime = new Timer();
                using (mytime)
                {

                    List<Task> taskmaneger = new List<Task>() { };
                    foreach (var v in actions)
                    {
                        v();
                    }

                }
                return mytime.Timercount();
            });
            
        }

        public static async Task<long> CallParallelAsync(params Action[] actions)
        {
            return await Task.Run(() =>
            {
                Timer mytime = new Timer();
                using (mytime)
                {
                    List<Task> taskmaneger = new List<Task>() { };
                    foreach (var v in actions)
                    {
                        Task mytask = new Task(v);
                        mytask.Start();
                        taskmaneger.Add(mytask);
                    }
                    Task.WaitAll(taskmaneger.ToArray());
                }
                return mytime.Timercount();
            });
        }

        public static async Task<long> CallParallelThreadSafeAsync(int count, params Action[] actions)
        {
            return await Task.Run(() =>
            {
                object sync = new object();
                Timer mytime = new Timer();
                using (mytime)
                {
                    List<Task> taskmaneger = new List<Task>() { };
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
                                    taskmaneger.Add(mytask);
                                    Task.WaitAll(taskmaneger.ToArray());
                                }
                            }

                        }

                    }
                }
                return mytime.Timercount();
            });
        }
    }
}