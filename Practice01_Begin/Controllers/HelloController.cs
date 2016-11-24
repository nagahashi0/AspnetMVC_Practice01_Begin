using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practice01_Begin.Controllers
{
    public class HelloController : Controller
    {
        // GET: Hello
        public ActionResult Index()
        {
            return View();
        }

     
        public ActionResult ShowHelloMessage()
        {
            //ControllerクラスのContentメソッドはActionResult派生クラスであるContentResultクラスを返す。
            //ContentResultクラスは引数に指定した文字列をテキスト形式で出力する。
            return Content("Hello World");
        }
    }
}