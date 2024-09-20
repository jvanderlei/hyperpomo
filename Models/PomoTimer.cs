using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace hyperpomo.Models
{
    public partial class PomoTimer : ObservableObject
    {
        public int FocusTime { get; set; }
        public int RestTime { get; set; }
        public int BreakTime { get; set; }
        
        public bool AutoStart { get;  set; }

        private string? _timeToString;

        public string? TimeToString
        {
            get => _timeToString;
            set => SetProperty(ref _timeToString, value);
        }

       

        public PomoTimer(int focusTime, int restTime, int breakTime)
        {
            
            FocusTime = focusTime;
            RestTime = restTime;
            BreakTime = breakTime;
            FocusTimeSet();
            UpdateTimerString();
            
        }





        public void FocusTimeSet()
        {
            SecondsCounter = TimeSpan.FromMinutes(FocusTime);
        }

        public void BreakTimeSet()
        {
            SecondsCounter = TimeSpan.FromMinutes(FocusTime);
        }



        public void Reset()
        {
            SecondsCounter = new TimeSpan();
        }
    }
}
