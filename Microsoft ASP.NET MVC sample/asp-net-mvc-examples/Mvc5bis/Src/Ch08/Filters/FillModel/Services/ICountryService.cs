using System;
using FillModel.ViewModels.Home;

namespace FillModel.Services
{
    public interface ICountryService
    {
        IndexViewModel GetHomePageViewModel();
        CountryViewModel GetCountryViewModel(String country);
    }
}