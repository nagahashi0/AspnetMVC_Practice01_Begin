using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Practice01_Begin.Controllers
{
    public class TemplateHelperController : Controller
    {
        public ActionResult Index()
        {
            var mdl = new Models.TemplateHelperViewModel();
            return View(mdl);
        }

        public ActionResult DisplayForAction()
        {
            var mdl = new Models.DisplayForViewModel();
            mdl.StringValue = "<font color='red'>赤字</font>";
            mdl.IntValue = 123456789;
            mdl.LongValue = 123456789012345;
            mdl.DecimalValue = 12345.99999m;
            mdl.DateTimeValue = new DateTime(2017,01,01,11,26,30);
            mdl.BoolValue = true;
            mdl.NullableBoolValue = true;
            mdl.EnumValue = Models.WeweathereType.rainy;
            
            return View(mdl);
        }

        public ActionResult AttributeAction()
        {
            var mdl = new Models.AttributeModel();
            mdl.IntValue = 123456789;
            //mdl.HtmlValue = "<font color='red'>赤字</font>";
            //mdl.MultilineTextValue = "1行目\r\n2行目";
            //mdl.EmailAddressValue = "aaa@gmail.com";
            //mdl.UrlValue = "https://www.google.co.jp";
            //mdl.PasswordValue = "ABCD123";
            //mdl.PhoneNumberValue  = "09012345678";
            //mdl.PostalCodeValue = "1234567";
            //mdl.CreditCardValue  = "1234123412341234";
            //mdl.DateTimeValue = DateTime.Now;
            //mdl.DateValue = DateTime.Now;
            //mdl.TimeValue = DateTime.Now;
            mdl.CurrencyValue = 12345678.5678m;
            mdl.DurationValue =12;

            return View(mdl);
        }

        public ActionResult HelperAction()
        {
            var mdl = new Models.HelperViewModel();
            mdl.MyClassValue = new Models.MyClass() { Name = "MyClassName", Age = 36 };
            mdl.StringList = new List<string>() { "AAA", "BBB", "CCC" };
            return View(mdl);
        }
    }
}