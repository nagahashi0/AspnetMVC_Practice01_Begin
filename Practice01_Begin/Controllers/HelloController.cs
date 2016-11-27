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

        public ActionResult Show()
        {
            //ViwDataはControllerの基底クラスであるControllerBaseクラスのプロパティ。
            //名称をキーに値を格納するコレクション。
            ViewData["Message"] = "Hello World";

            //ViewBagはControllerの基底クラスであるControllerBaseクラスのプロパティ
            //dynamic型の値を取得/設定できる。
            ViewBag.Message = "Hello World";

            //ControllerクラスのViewメソッドはActionResult派生クラスであるViewResultクラスを返す。
            //ViewResultクラスはアクションメソッドの結果を対応するビューを表示する。
            return View();
        }

        public ActionResult Greeting()
        {
            Models.GreetingModels grt = new Models.GreetingModels();
            grt.Message = "Hello World";

            return View(grt);

        }
    }
}