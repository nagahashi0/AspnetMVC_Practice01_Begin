using System;
using System.Collections.Generic;
using FillModel.ViewModels;
using FillModel.ViewModels.Home;

namespace FillModel.Services
{
    public class CountryService : ICountryService
    {
        public IndexViewModel GetHomePageViewModel()
        {
            var model = new IndexViewModel { Title = ViewModelBase.BaseTitle, Countries = GetListOfCountries() };
            return model;
        }

        public CountryViewModel GetCountryViewModel(String country)
        {
            var model = new CountryViewModel();

            // Add country details
            AddDataForCountry(model, country);

            // Add title (specific to this action)
            model.Title = String.Format("{0} :: {1}", ViewModelBase.BaseTitle, country);

            // Remainder of the view model is left incomplete: will be filled somehow
            return model;
        }   


        #region Static Members
        public static IList<String> GetCountries()
        {
            return GetListOfCountries();
        }
        #endregion

        #region Internals
        private static void AddDataForCountry(CountryViewModel model, String country)
        {
            model.Country = country;

            if (String.Equals(country, "usa", StringComparison.InvariantCultureIgnoreCase))
            {
                model.Area = "North America";
                model.Capital = "Washington";
                model.Population = "310 million";
                return;
            }
            if (String.Equals(country, "uk", StringComparison.InvariantCultureIgnoreCase))
            {
                model.Area = "Europe";
                model.Capital = "London";
                model.Population = "62.2 million";
                return;
            }
            if (String.Equals(country, "spain", StringComparison.InvariantCultureIgnoreCase))
            {
                model.Area = "Europe";
                model.Capital = "Madrid";
                return;
            }
            if (String.Equals(country, "australia", StringComparison.InvariantCultureIgnoreCase))
            {
                model.Area = "Far East";
                model.Capital = "Canberra";
                model.Population = "22.6";
                return;
            }
        }
        private static IList<String> GetListOfCountries()
        {
            var countries = new List<String> { "USA", "UK", "Sweden", "Australia", "Spain", "Poland" };
            return countries;
        }
        #endregion        
    }
}