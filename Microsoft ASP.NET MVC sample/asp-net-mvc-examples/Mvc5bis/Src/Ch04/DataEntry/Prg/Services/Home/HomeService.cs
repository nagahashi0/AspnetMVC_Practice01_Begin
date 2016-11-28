using System;
using System.Web.Mvc;
using BookSamples.Components.Data;
using Sep.ViewModels.Home;

namespace Prg.Services.Home
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

        public EditViewModel TryUpdateCustomer(ModelStateDictionary modelState, TempDataDictionary tempData, SimpleCustomer customer)
        {
            if (Validate(modelState, tempData, customer))
                Update(tempData, customer);

            return GetModelForEdit(customer.Id);
        }

        private static Boolean Validate(ModelStateDictionary modelState, TempDataDictionary tempData, SimpleCustomer customer)
        {
            // Check also against nullness (the model binder leaves it NULL if not specified)
            var result = true;
            if (String.IsNullOrEmpty(customer.Country) || !customer.Country.Equals("USA"))
            {
                modelState.AddModelError("Country", "Invalid country.");

                // Save model-state to TempData
                tempData["ModelState"] = modelState;

                result = false;
            }

            return result;
        }

        private static void Update(TempDataDictionary tempData, SimpleCustomer customer)
        {
            // Perform physical update here using the repository services
            var result = true;

            // Add a message for the user
            var msg = result
                            ? "Successfully updated."
                            : "Update failed. Check your input data!";
            tempData["OutputMessage"] = msg;
        }
    }
}