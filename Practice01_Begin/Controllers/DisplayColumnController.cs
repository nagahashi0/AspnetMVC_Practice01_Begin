using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practice01_Begin.Controllers
{
    public class DisplayColumnController : Controller
    {
        public ActionResult Index()
        {
            var mdlH = new Models.DisplayColumnHedViewModel();
            mdlH.ID = "A001";
            mdlH.Name = "ヘッダ_A";

            var mdlbList = new List<Models.DispalyColumnBodyViewModel>();
            for (int idx = 0; idx < 3; idx++)
            {
                var mdlB = new Models.DispalyColumnBodyViewModel();
                mdlB.ID = idx + 1;
                mdlB.Name = "ボディ" + idx;
                mdlbList.Add(mdlB);
            }
            mdlH.Bodys= mdlbList;

            return View(mdlH);
        }
    }
}