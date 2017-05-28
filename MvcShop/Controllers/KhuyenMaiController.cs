using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcShop.Models;

namespace MvcShop.Controllers
{
    public class KhuyenMaiController : Controller
    {
        // GET: KhuyenMai
        public ActionResult Index()
        {
            var model = new KhuyenMaiModel();
            return View(model);
        }

        [ChildActionOnly]
        public PartialViewResult Slider()
        {
            return PartialView();
        }
    }
}