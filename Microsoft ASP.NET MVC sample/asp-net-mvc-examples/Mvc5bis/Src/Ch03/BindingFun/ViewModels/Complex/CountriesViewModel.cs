using System.Collections.Generic;
using BindingFun.InputModels;

namespace BindingFun.ViewModels.Complex
{
    public class CountriesViewModel : ViewModelBase
    {
        public CountriesViewModel()
        {
            CountryList = new List<Country>();
            SelectedCountries = new List<Country>();
        }
        public IList<Country> CountryList { get; set; }
        public IList<Country> SelectedCountries { get; set; }
    }
}