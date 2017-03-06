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
            //ShopModel model = new ShopModel(defaultPage);
            return RedirectToAction("Pages", new { page = defaultPage });
        }

        [HttpGet]
        public ActionResult Pages(int page)
        {
            string action = "page";
            ShopModel models = new ShopModel(page);
            return View(models);
        }

        [HttpGet]
        public ActionResult Brands(int brandId, int page)
        {
            string action = "brand";
            ViewBag.Brand = brandId;
            ShopModel models = new ShopModel(action, brandId, page);
            return View(models);
        }

        [HttpGet]
        public ActionResult Types(int typeId, int page)
        {
            string action = "type";
            ViewBag.Type = typeId;
            ShopModel models = new ShopModel(action, typeId, page);
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