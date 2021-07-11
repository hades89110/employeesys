using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace test1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult View888()
        {
            ViewBag.a = "viewbag";
            ViewBag.asd = 456;



            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

      /*  protected override void HandleUnknownAction(string actionName)
        {
            Response.Redirect("http://公司網址");
            base.HandleUnknownAction(actionName);
        }*/
    }
}