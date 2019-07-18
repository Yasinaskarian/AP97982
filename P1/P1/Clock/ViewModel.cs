using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using P1.Clock;

namespace P1.Clock
{
    class AnalogClock : INotifyPropertyChanged
    {
        public List<ClockPart> HourParts { get; set; }
        public List<ClockPart> SecondParts { get; set; }

        private DispatcherTimer Timer { get; set; } = new DispatcherTimer();

        private double angleHour;
        private double angleMin;
        private double angleSec;

        
        public double AngleHour
        {
            get { return angleHour; }
            set
            {
                angleHour = value;
                OnPropertyChanged("AngleHour");
            }
        }


        public double AngleMin
        {
            get { return angleMin; }
            set
            {
                angleMin = value;
                OnPropertyChanged("AngleMin");
            }
        }

        public double AngleSec
        {
            get { return angleSec; }
            set
            {
                angleSec = value;
                OnPropertyChanged("AngleSec");
            }
        }
        

       

        public AnalogClock()
        {
            HourParts = new List<ClockPart>();
            for (int x = 1; x <= 12; x++)
            {
                HourParts.Add(new ClockPart()
                {
                    Number = (x).ToString(),
                    Angle = (x) * (360 / 12),
                });
            }

            SecondParts = new List<ClockPart>();
            for (int x = 1; x <= 60; x++)
            {
                SecondParts.Add(new ClockPart()
                {
                    Number = x.ToString(),
                    Angle = x * (360 / 60),
                });
            }

            Timer.Interval = TimeSpan.FromSeconds(1);
            Timer.Tick += Timer_Tick;
            Timer.Start();
        }
      

     
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = null)
        {
       
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
      

        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            AngleHour = (time.Hour) * (360 / 12);
            AngleMin = (time.Minute) * (360 / 60);
            AngleSec = (time.Second) * (360 / 60);
        }
    }
}
