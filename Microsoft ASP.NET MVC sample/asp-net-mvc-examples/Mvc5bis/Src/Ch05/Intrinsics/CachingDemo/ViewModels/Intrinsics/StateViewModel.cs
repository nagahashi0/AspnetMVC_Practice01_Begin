using System;

namespace CachingDemo.ViewModels.Intrinsics
{
    public class StateViewModel : ViewModelBase
    {
        public StateViewModel()
        {
            Title = "Caching demo";
        }
        public String TextColor { get; set; }
        public Boolean Persistent { get; set; }
    }
}