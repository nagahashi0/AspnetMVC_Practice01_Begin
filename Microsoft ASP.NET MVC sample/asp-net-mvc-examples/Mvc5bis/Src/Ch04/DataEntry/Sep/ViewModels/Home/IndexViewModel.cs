using System.Collections.Generic;
using BookSamples.Components.Data;

namespace Sep.ViewModels.Home
{
    public class IndexViewModel : ViewModelBase
    {
        public IndexViewModel()
        {
            Customers = new List<SimpleCustomer>();
        }
        public IEnumerable<SimpleCustomer> Customers { get; set; }
    }
}