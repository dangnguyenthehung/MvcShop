using MvcShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcShop.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Index()
        {
            ShopModel model = new ShopModel();
            return View(model);
        }

        public ActionResult Details(int id)
        {

            return RedirectToAction("Index","ProductDetails", new { id = id } );
        }

        [ChildActionOnly]
        public PartialViewResult Slider()
        {
            return PartialView();
        }
    }
}