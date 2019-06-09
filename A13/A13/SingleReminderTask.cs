using System;
using System.Threading;
using System.Threading.Tasks;

namespace A13
{
    public class SingleReminderTask : ISingleReminder
    {
        Task ReiminderTask = null;

        public int Delay => throw new NotImplementedException();

        public string Msg => throw new NotImplementedException();

        public event Action<string> Reminder;

        public void Start()
        {
            throw new NotImplementedException();
        }
    }
}