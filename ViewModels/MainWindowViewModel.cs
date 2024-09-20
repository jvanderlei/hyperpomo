using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using hyperpomo.Models;
using System;

namespace hyperpomo.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private bool isRunning = false;

        [ObservableProperty]
        private string _timerButtonLabel = "Start Timer";
        [ObservableProperty]
        private string _resetButtonLabel = "Reset Timer";
        [ObservableProperty]
        private PomoTimer _localPomoTimer = new(25, 5, 15);

        [RelayCommand]
        private void TimerButton()
        {
            (isRunning ? (Action)StopTimer : (Action)StartTimer)();
        }

        [RelayCommand]
        private void ResetTimer()
        {
            LocalPomoTimer.Reset();
        }

        private void StartTimer()
        {
            LocalPomoTimer.Start();
            TimerButtonLabel = "Stop Timer";
            isRunning = true;
        }

        private void StopTimer()
        {
            LocalPomoTimer.Stop();
            TimerButtonLabel = "Start Timer";
            isRunning = false;
        }
    }
}
