using System;
using System.Threading;

namespace A13
{
    public class SingleReminderThreadPool : ISingleReminder
    {
        public SingleReminderThreadPool(string msg,int delay)
        {
            Delay = delay;
            Msg = msg;
        }
        public int Delay { get; set; }

        public string Msg { get; set; }
        public event Action<string> Reminder;

        public void Start()
        {
            foreach (var v in Reminder.GetInvocationList())
            {
                ThreadPool.QueueUserWorkItem((d) => v.DynamicInvoke(Msg));
                Thread.Sleep(Delay);
            }
           
        }
        
    }
}