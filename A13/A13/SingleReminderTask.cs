﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace A13
{
    public class SingleReminderTask : ISingleReminder
    {
        Task ReiminderTask = null;
        public SingleReminderTask(string msg,int delay)
        {
            Msg = msg;
            Delay = delay;
        }
        public int Delay { get; set; }

        public string Msg { get; set; }

        public event Action<string> Reminder;

        public void Start()
        {
            foreach (var v in Reminder.GetInvocationList())
            {
                ReiminderTask = new Task(() => v.DynamicInvoke(Msg)) { };
                Thread.Sleep(Delay);
            }
            ReiminderTask.Start();
            ReiminderTask.Wait();
     
        }
    }
}