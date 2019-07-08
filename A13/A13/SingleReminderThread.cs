using System;
using System.Threading;

namespace A13
{
    public class SingleReminderThread : ISingleReminder
    {
        Thread ReiminderThread = null;
        public SingleReminderThread(string msg, int delay)
        {
            Delay = delay;
            Msg = msg;
        }
        public int Delay { get; set; }

        public string Msg { get; set; }

        public event Action<string> Reminder;
      

        
        public void Start()
        {

            ReiminderThread = new Thread(() => Reminder.DynamicInvoke(Msg)) { };
            Thread.Sleep(Delay);
            ReiminderThread.Start();
            ReiminderThread.Join();

        }
    }
}