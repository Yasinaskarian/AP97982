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

        private double _HourAngle;
        private double _MinAngle;
        private double _SecAngle;

        
        public double HourAngle
        {
            get { return _HourAngle; }
            set
            {
                _HourAngle = value;
                OnPropertyChanged("HourAngle");
            }
        }


        public double MinAngle
        {
            get { return _MinAngle; }
            set
            {
                _MinAngle = value;
                OnPropertyChanged("MinAngle");
            }
        }

        public double SecAngle
        {
            get { return _SecAngle; }
            set
            {
                _SecAngle = value;
                OnPropertyChanged("SecAngle");
            }
        }
        

       

        public AnalogClock()
        {
            HourParts = new List<ClockPart>();
            for (int x = 1; x <= 12; x++)
            {
                HourParts.Add(new ClockPart()
                {
                    
                    Angle = (x) * (360 / 12)
                });
            }

            SecondParts = new List<ClockPart>();
            for (int x = 1; x <= 60; x++)
            {
                SecondParts.Add(new ClockPart()
                {
                    Angle = x * (360 / 60)
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
            HourAngle = (time.Hour) * (360 / 12);
            MinAngle = (time.Minute) * (360 / 60);
            SecAngle = (time.Second) * (360 / 60);
        }
    }
}
