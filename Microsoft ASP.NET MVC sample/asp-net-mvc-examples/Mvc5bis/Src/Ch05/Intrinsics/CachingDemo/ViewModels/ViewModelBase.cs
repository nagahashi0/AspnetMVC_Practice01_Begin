using System;

namespace CachingDemo.ViewModels
{
    public class ViewModelBase
    {
        public ViewModelBase()
        {
            Title = "Programming ASP.NET MVC";
        }
        public String Title { get; set; }
    }
}