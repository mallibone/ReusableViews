using System;
using System.Reactive.Linq;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Subviews.ViewModels
{
    public class MainViewModel : ReactiveObject
    {
        public MainViewModel()
        {
            Observable.Interval(TimeSpan.FromMilliseconds(500), RxApp.MainThreadScheduler) // timer invoked every 500 ms on the main thread
                .Select(_ => DateTimeOffset.Now.ToString("T")) // Ignore timer -> Get the current time 13:37:00
                .ToPropertyEx(this, vm => vm.TheTime); // Set TheTime property to the current value
        }
        
        [Reactive] public string TheText { get; set; } = "Welcome to Xamarin.Forms!";
        public string TheTime { [ObservableAsProperty] get; }
    }
}