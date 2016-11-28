using System;

namespace ClassicAuth.ViewModels
{
    public class ViewModelBase
    {
        public ViewModelBase()
        {
            Title = String.Empty;
        }
        public String Title { get; set; }
    }
}