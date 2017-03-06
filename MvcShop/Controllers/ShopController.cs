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
            int defaultPage = 1;
            ShopModel model = new ShopModel(defaultPage);
            return View(model);
        }

        [HttpGet]
        public ActionResult Pages(int page)
        {

            ShopModel models = new ShopModel(page);
            return View(models);
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