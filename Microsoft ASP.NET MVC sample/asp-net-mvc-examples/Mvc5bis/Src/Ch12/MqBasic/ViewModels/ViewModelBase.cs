using System;
using MqBasic.Resources;

namespace MqBasic.ViewModels
{
    public class ViewModelBase
    {
        public ViewModelBase()
        {
            Title = Literals.AppTitle;
        }
        public ViewModelBase(String title)
        {
            Title = title;
        }

        public String Title { get; set; }
    }
}
