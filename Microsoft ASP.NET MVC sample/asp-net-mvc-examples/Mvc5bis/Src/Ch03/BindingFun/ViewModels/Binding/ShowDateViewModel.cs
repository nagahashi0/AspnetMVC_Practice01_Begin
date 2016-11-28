using System;

namespace BindingFun.ViewModels.Binding
{
    public class ShowDateViewModel : ViewModelBase
    {
        public DateTime Today { get; set; }
        public Boolean ShouldShowTime { get; set; }
    }
}