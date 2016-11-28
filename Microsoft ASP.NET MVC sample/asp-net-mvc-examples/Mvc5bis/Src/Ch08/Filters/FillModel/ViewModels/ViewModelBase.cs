using System;

namespace FillModel.ViewModels
{
    public class ViewModelBase
    {
        public ViewModelBase()
        {
            BaseTitle = "Countries of the world";
        }
        public static String BaseTitle { get; private set; }
        public String Title { get; set; }
    }
}