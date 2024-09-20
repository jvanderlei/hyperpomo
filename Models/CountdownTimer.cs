using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hyperpomo.Models
{
    public partial class CountdownTimer : ObservableObject
    {
        public TimeSpan SecondsCounter { get; private set; }
        public double TimeValue { get; private set; }

        private readonly DispatcherTimer _timer = new() { Interval = new TimeSpan(0, 0, 0, 1, 0) };

        public CountdownTimer()
        {
            SecondsCounter = new TimeSpan();
            _timer.Tick += new EventHandler(DoTick);
            TimeSet();

        }

        private void DoTick(object sender, EventArgs e)
        {
            if (SecondsCounter.Equals(TimeSpan.Zero))
            {
                TimeToString = "Finalizou";
                Stop();
            }
            else
            {
                SecondsCounter = SecondsCounter.Subtract(TimeSpan.FromSeconds(1));
                UpdateTimerString();
            }
        }

        public void Start()
        {
            _timer.IsEnabled = true;
        }

        public void Stop()
        {
            _timer.IsEnabled = false;
        }

        private void UpdateTimerString()
        {
            TimeToString = SecondsCounter.ToString(@"mm\:ss");
        }

        public void TimeSet()
        {
            SecondsCounter = TimeSpan.FromMinutes(TimeValue);
        }
    }
}
