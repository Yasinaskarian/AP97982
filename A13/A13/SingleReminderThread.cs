using System;
using System.Threading;

namespace A13
{
    public class SingleReminderThread : ISingleReminder
    {
        Thread ReiminderThread = null;

        public int Delay => throw new NotImplementedException();

        public string Msg => throw new NotImplementedException();

        public event Action<string> Reminder;

        public void Start()
        {
            throw new NotImplementedException();
        }
    }
}