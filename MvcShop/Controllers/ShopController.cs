using Model.DbModel;
using MvcShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Object;
using MvcShop.Common;

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

            var list_sort_type = new List<Sort_Type>()
            {
                new Sort_Type{Sort_Name = "Mới nhất", Value = (int)CommonConstants.Sort_Type.ID_DESC},
                new Sort_Type{Sort_Name = "Cũ nhất", Value = (int)CommonConstants.Sort_Type.ID_ASC},
                new Sort_Type{Sort_Name = "Giá tăng dần", Value = (int)CommonConstants.Sort_Type.Price_ASC},
                new Sort_Type{Sort_Name = "Giá giảm dần", Value = (int)CommonConstants.Sort_Type.Price_DESC}
            };
            int current_sort = 2; // 2: ID_DESC = mới nhất
            if (Session[CommonConstants.SORT_SESSION] != null)
            {
                current_sort = (int)Session[CommonConstants.SORT_SESSION];
            }
            
            ViewBag.sort_Type = new SelectList(list_sort_type, "Value", "Sort_Name", current_sort);

            return View(models);
        }
        // receive sort from user
        [HttpPost]
        public ActionResult Page_Sort(int sort_Type)
        {
            Session[CommonConstants.SORT_SESSION] = sort_Type;

            return RedirectToAction("Pages", new { page = 1 });
        }

        [HttpPost]
        public ActionResult Brand_Sort(int brandId, int sort_Type)
        {
            Session[CommonConstants.SORT_SESSION] = sort_Type;

            return RedirectToAction("Brands", new { brandId, page = 1 });
        }

        [HttpPost]
        public ActionResult Type_Sort(int typeId, int sort_Type)
        {
            Session[CommonConstants.SORT_SESSION] = sort_Type;

            return RedirectToAction("Types", new { typeId, page = 1 });
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
            ViewBag.Brand = brandId;

            // sort part
            var list_sort_type = new List<Sort_Type>()
            {
                new Sort_Type{Sort_Name = "Mới nhất", Value = (int)CommonConstants.Sort_Type.ID_DESC},
                new Sort_Type{Sort_Name = "Cũ nhất", Value = (int)CommonConstants.Sort_Type.ID_ASC},
                new Sort_Type{Sort_Name = "Giá tăng dần", Value = (int)CommonConstants.Sort_Type.Price_ASC},
                new Sort_Type{Sort_Name = "Giá giảm dần", Value = (int)CommonConstants.Sort_Type.Price_DESC}
            };
            int current_sort = 2; // 2: ID_DESC = mới nhất
            if (Session[CommonConstants.SORT_SESSION] != null)
            {
                current_sort = (int)Session[CommonConstants.SORT_SESSION];
            }

            ViewBag.sort_Type = new SelectList(list_sort_type, "Value", "Sort_Name", current_sort);

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
            ViewBag.Type = typeId;

            // sort part
            var list_sort_type = new List<Sort_Type>()
            {
                new Sort_Type{Sort_Name = "Mới nhất", Value = (int)CommonConstants.Sort_Type.ID_DESC},
                new Sort_Type{Sort_Name = "Cũ nhất", Value = (int)CommonConstants.Sort_Type.ID_ASC},
                new Sort_Type{Sort_Name = "Giá tăng dần", Value = (int)CommonConstants.Sort_Type.Price_ASC},
                new Sort_Type{Sort_Name = "Giá giảm dần", Value = (int)CommonConstants.Sort_Type.Price_DESC}
            };
            int current_sort = 2; // 2: ID_DESC = mới nhất
            if (Session[CommonConstants.SORT_SESSION] != null)
            {
                current_sort = (int)Session[CommonConstants.SORT_SESSION];
            }

            ViewBag.sort_Type = new SelectList(list_sort_type, "Value", "Sort_Name", current_sort);

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