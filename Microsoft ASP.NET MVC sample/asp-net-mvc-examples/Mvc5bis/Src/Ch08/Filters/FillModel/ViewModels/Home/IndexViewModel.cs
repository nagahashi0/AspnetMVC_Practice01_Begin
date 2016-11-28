using System;
using System.Collections.Generic;

namespace FillModel.ViewModels.Home
{
    public class IndexViewModel : ViewModelBase
    {
        public IndexViewModel()
        {
            Countries = new List<String>();
        }
        public IList<String> Countries { get; set; }
}
}