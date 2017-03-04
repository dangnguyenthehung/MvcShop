using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcShop.Controllers
{
    public class errorController : Controller
    {
        // GET: error
        public ActionResult Index()
        {
            return RedirectToAction("Error404");
        }
        public ActionResult Error404()
        {
            return View();
        }
    }
}