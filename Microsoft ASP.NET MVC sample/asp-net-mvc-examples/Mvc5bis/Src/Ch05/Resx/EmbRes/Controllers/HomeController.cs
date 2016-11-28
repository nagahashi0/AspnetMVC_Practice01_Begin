using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web.Mvc;
using EmbRes.ViewModels;

namespace EmbRes.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new ViewModelBase();
            return View(model);
        }

        public Object Image(String name)
        {
            var bits = (Bitmap) HttpContext.GetGlobalResourceObject("AllResources", name);
            Response.ContentType = "image/jpeg";
            if (bits == null)
                return null;

            bits.Save(Response.OutputStream, ImageFormat.Jpeg);
            return bits;
        }
    }
}
