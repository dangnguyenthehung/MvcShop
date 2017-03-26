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
            ViewBag.PageTitle = "Cửa hàng";
            //ShopModel model = new ShopModel(defaultPage);
            return RedirectToAction("Pages", new { page = defaultPage });
        }

        [HttpGet]
        public ActionResult Pages(int page)
        {
            //string action = "page";
            ShopModel models = new ShopModel(page);

            ViewBag.PageTitle = "Trang " + page;
            
            
            return View(models);
        }

        [HttpGet]
        public ActionResult Brands(int brandId, int page)
        {
            string action = "brand";
            ViewBag.Brand = brandId;
            ShopModel models = new ShopModel(action, brandId, page);
            if (models.ListProduct.Count() != 0)
            {
                ViewBag.PageTitle = models.ListProduct[0].BrandName;
            }
            return View(models);
        }

        [HttpGet]
        public ActionResult Types(int typeId, int page)
        {
            string action = "type";
            ViewBag.Type = typeId;
            ShopModel models = new ShopModel(action, typeId, page);
            if (models.ListProduct.Count() != 0)
            {
                ViewBag.PageTitle = models.get_Type(typeId);
            }
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