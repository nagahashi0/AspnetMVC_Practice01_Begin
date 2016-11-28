using System;
using System.Web.Mvc;

namespace ImageMan.Controllers
{
    public class ImageController : Controller
    {
        public ActionResult Download(String img, String defaultImg = "~/content/images/missing.png")
        {
            var path = GetResolvedImageName(img, defaultImg);
            return File(path, "image");
        }

        #region Internals
        private String GetResolvedImageName(String img, String defaultImg)
        {
            var path = Server.MapPath(img);
            if (!System.IO.File.Exists(path))
            {
                path = Server.MapPath(defaultImg);
            }
            return path;
        }
        #endregion
    }
}
