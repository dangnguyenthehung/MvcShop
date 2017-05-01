using Model.DbModel;
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
            var temp_Model = new LayoutModel();
            var count_product_all = temp_Model.Get_Count_Product_All();


            ShopModel models = new ShopModel(page);

            ViewBag.PageTitle = "Trang " + page;
            ViewBag.Page = page;
            ViewBag.Count = count_product_all;
            
            return View(models);
        }

        [HttpGet]
        public ActionResult Brands(int brandId, int page)
        {
            // count number of product
            var temp_Model = new LayoutModel();
            var count_product_brand = temp_Model.Get_Count_Product_Brand(brandId);

            string action = "brand";
            ViewBag.Brand = brandId;
            ShopModel models = new ShopModel(action, brandId, page);
            if (models.ListProduct.Count() != 0)
            {
                ViewBag.PageTitle = models.ListProduct[0].BrandName;
            }

            ViewBag.Page = page;
            ViewBag.Count = count_product_brand;

            return View(models);
        }

        [HttpGet]
        public ActionResult Types(int typeId, int page)
        {
            // count number of product
            var temp_Model = new LayoutModel();
            var count_product_type = temp_Model.Get_Count_Product_Type(typeId);

            string action = "type";
            ViewBag.Type = typeId;
            ShopModel models = new ShopModel(action, typeId, page);
            if (models.ListProduct.Count() != 0)
            {
                ViewBag.PageTitle = models.get_Type(typeId);
            }

            ViewBag.Page = page;
            ViewBag.Count = count_product_type;

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