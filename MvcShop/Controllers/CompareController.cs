using MvcShop.Models;
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
            CompareModel model = new CompareModel();
            return View(model);
        }

        [ChildActionOnly]
        public PartialViewResult Slider()
        {
            return PartialView();
        }
    }
}