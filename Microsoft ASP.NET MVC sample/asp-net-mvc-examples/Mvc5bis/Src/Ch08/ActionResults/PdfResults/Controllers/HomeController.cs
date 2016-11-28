using System;
using System.Web.Mvc;
using PdfResults.Framework;

namespace PdfResults.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Create your PDF document";
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [HttpGet]
        [ActionName("pdf")]
        public ActionResult PreparePdf(String author)
        {
            ViewBag.Author = "Dino Esposito";
            return View();
        }

        [HttpPost]
        [ActionName("pdf")]
        public ActionResult CreatePdf(String author)
        {
            var documentName = Server.MapPath("/Sample.pdf");
            var templateName = Server.MapPath("/Sample.dotx");

            WordDocument.CreateSampleWordDocument(documentName, templateName, DateTime.Now, author);
            return File(documentName, "application/pdf");
        }
    }
}
