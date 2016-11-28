using System;
using System.Collections.Generic;
using FatFreeIoC.ViewModels.Shared;

namespace FatFreeIoC.ViewModels.Home
{
    public class IndexViewModel : ViewModelBase
    {
        public String MessageFormat { get; set; }
        public String Today { get; set; }
        public IList<FeaturedDate> FeaturedDates { get; set; }
    }
}