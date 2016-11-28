using System;
using System.Collections.Generic;
using FatFree.ViewModels.Shared;

namespace FatFree.ViewModels.Home
{
    public class IndexViewModel : ViewModelBase
    {
        public String MessageFormat { get; set; }
        public String Today { get; set; }
        public IList<FeaturedDate> FeaturedDates { get; set; }
    }
}