using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcShop.Controllers
{
    public class CompareController : Controller
    {
        // GET: Compare
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult Slider()
        {
            return PartialView();
        }
    }
}