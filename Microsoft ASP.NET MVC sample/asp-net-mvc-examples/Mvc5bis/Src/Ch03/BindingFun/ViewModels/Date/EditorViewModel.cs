using System;

namespace BindingFun.ViewModels.Date
{
    public class EditorViewModel : ViewModelBase
    {
        public EditorViewModel()
        {
            DefaultDate = null;
            TimeToToday = null;
        }
        public DateTime? DefaultDate { get; set; }
        public TimeSpan? TimeToToday { get; set; }
    }
}
