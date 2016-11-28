using BookSamples.Components.Data;

namespace Sep.ViewModels.Home
{
    public class EditViewModel : IndexViewModel
    {
        public EditViewModel()
        {
            Customer = new SimpleCustomer();
        }
        public SimpleCustomer Customer { get; set; }
    }
}