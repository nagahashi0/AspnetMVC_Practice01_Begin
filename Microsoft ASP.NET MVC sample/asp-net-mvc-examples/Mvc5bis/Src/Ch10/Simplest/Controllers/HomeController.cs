using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Simplest.Models.Dto;

namespace Simplest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult News()
        {
            var client = new WebClient();
            //client.Headers.Add("Accept", "text/xml");

            var content = client.DownloadString("http://localhost:25708/api/news");
            var serializer = new JavaScriptSerializer();
            var listOfNews = serializer.Deserialize<IList<News>>(content);
            return View(listOfNews);
        }
    }
}
