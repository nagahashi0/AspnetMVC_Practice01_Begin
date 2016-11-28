using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BindingFun.InputModels;
using BindingFun.ViewModels.Complex;

namespace BindingFun.Controllers
{
    public class ComplexController : Controller
    {
        public ActionResult Repeat(RepeatText inputModel)
        {
            var model = new RepeatViewModel { Title = "Repeating text", Text = inputModel.Text, Number = inputModel.Number };
            return View(model);
        }
        
        [ActionName("Emails")]
        [HttpGet]
        public ActionResult EmailsForGet(IList<String> emails)
        {
            // Input parameters
            var defaultEmails = new[] { "admin@contoso.com", "", "", "", "" };
            if (emails == null)
                emails = defaultEmails;
            if (emails.Count == 0)
                emails = defaultEmails;

            var model = new EmailsViewModel { Emails = emails };
            return View(model);
        }

        [ActionName("Emails")]
        [HttpPost]
        public ActionResult EmailsForPost(IList<String> email)
        {
            // Name of list parameter MUST be "email" to match the ID of the input field in the view.
            // Either to call a single input field "emails" or call the list parameter here "email".
            // MUST use PREFIX to decouple names.

            var defaultEmails = new[] { "admin@contoso.com", "", "", "", "" };
            var model = new EmailsViewModel { Emails = defaultEmails, RegisteredEmails = email };
            return View(model);
        }

        [ActionName("Countries")]
        public ActionResult CountriesForGet()
        {
            // Input parameters
            var defaultCountries = GetDefaultCountries();

            // Render the view
            var model = new CountriesViewModel { CountryList = defaultCountries };
            return View(model);
        }

        [HttpPost]
        [ActionName("Countries")]
        public ActionResult CountriesForPost(IList<Country> country)
        {
            var defaultCountries = GetDefaultCountries();

            var model = new CountriesViewModel
            {
                CountryList = defaultCountries,
                SelectedCountries = country
            };
            return View(model);
        }




        #region Internals
        private static IList<Country> GetDefaultCountries()
        {
            var countries = new List<Country>();
            countries.Add(new Country() { Name = "Italy", Details = new CountryInfo { Capital = "Rome", Continent = "Europe" } });
            countries.Add(new Country() { Name = "Spain", Details = new CountryInfo { Capital = "Madrid", Continent = "Europe" } });
            countries.Add(new Country() { Name = "USA", Details = new CountryInfo { Capital = "Washington", Continent = "NorthAmerica" } });
            return countries;
        }
        #endregion
    }
}
