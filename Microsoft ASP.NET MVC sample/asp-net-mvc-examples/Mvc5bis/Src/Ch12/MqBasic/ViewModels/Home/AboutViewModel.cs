using System;
using MqBasic.ViewModels;

namespace MvcSimply.ViewModels.Home
{
    public class AboutViewModel : ViewModelBase
    {
        public String Headline { get; set; }
        public String FollowMe { get; set; }
        public String TwitterName { get; set; }
    }
}