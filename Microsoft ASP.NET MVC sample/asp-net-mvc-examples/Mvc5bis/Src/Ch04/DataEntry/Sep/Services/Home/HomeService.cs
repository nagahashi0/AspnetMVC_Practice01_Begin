using System;
using System.Web.Mvc;
using BookSamples.Components.Data;
using Sep.ViewModels.Home;

namespace Sep.Services.Home
{
    public class HomeService
    {
        public IndexViewModel GetModelForIndex()
        {
            var model = new IndexViewModel {Customers = NorthwindCustomers.GetAll()};
            return model;
        }

        public EditViewModel GetModelForEdit(String id)
        {
            var model = new EditViewModel
                {
                    Customer = NorthwindCustomers.Get(id),
                    Customers = NorthwindCustomers.GetAll()
                };
            return model;
        }

        public EditViewModel TryUpdateCustomer(ModelStateDictionary modelState, SimpleCustomer customer)
        {
            if (Validate(modelState, customer))
                Update(customer);

            return GetModelForEdit(customer.Id);
        }

        private static Boolean Validate(ModelStateDictionary modelState, SimpleCustomer customer)
        {
            // Check also against nullness (the model binder leaves it NULL if not specified)
            var result = true;
            if (String.IsNullOrEmpty(customer.Country) || !customer.Country.Equals("USA"))
            {
                modelState.AddModelError("Country", "Invalid country.");
                result = false;
            }

            return result;
        }

        private static void Update(SimpleCustomer customer)
        {
            // Perform physical update here using the repository services
        }
    }
}