using System;
using System.Web.Mvc;
using DataAnnotations.ViewModels.Customer;

namespace DataAnnotations.Controllers
{
    public class CustomerController : Controller
    {
        public ActionResult Index()
        {
            var model = new CustomerViewModel
            {
                Id = 12345,
                IsCompany = true,
                Reliable = null,
                Name = "e-tennis.NET",
                Notes = "My company",
                Foundation = new DateTime(2005, 3, 12),
                Website = "http://www.e-tennis.net",
                Title = "Sample customer",
                Contact = new ContactInfo
                {
                    Email = "d@d.com",
                    FullName = "D.E.",
                    PhoneNumber = "000"
                }
            };
            return View(model);
        }

        public ActionResult Edit()
        {
            var model = new CustomerViewModel
            {
                Id = 12345,
                IsCompany = true,
                Reliable = null,
                Name = "e-tennis.NET",
                Notes = "My company",
                Foundation = new DateTime(2005, 3, 12),
                Website = "http://www.e-tennis.net",
                Title = "Sample customer",
                Contact = new ContactInfo
                {
                    Email = "d@d.com",
                    FullName = "D.E.",
                    PhoneNumber = "000"
                }
            };
            return View(model);
        }
    }
}
