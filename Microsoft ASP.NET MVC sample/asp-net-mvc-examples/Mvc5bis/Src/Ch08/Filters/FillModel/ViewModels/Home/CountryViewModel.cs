using System;

namespace FillModel.ViewModels.Home
{
    public class CountryViewModel : IndexViewModel
    {
        public CountryViewModel()
        {
            Area = "N/A";
            Capital = "N/A";
            Population = "N/A";
        }

        public String Country { get; set; }
        public String Area { get; set; }
        public String Capital { get; set; }
        public String Population { get; set; }
    }
}