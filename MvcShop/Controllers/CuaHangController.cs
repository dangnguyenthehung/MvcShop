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
    public class CuaHangController : Controller
    {
        // GET: Shop
        public ActionResult Index()
        {
            int defaultPage = 1;

            Session[CommonConstants.CURRENT_ROUTE_ID] = 1; // default
            
            ViewBag.PageTitle = "Cửa hàng";
            //ShopModel model = new ShopModel(defaultPage);
            return RedirectToAction("Trang", new { page = defaultPage });
        }

        [HttpGet]
        public ActionResult Trang(int page)
        {
            Session[CommonConstants.CURRENT_ROUTE] = (int)CommonConstants.Shop_Route.Pages;

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

            return RedirectToAction("Trang", new { page = 1 });
        }

        [HttpPost]
        public ActionResult Brand_Sort(int brandId, int sort_Type)
        {
            Session[CommonConstants.SORT_SESSION] = sort_Type;

            return RedirectToAction("Hang", new { brandId, page = 1 });
        }

        [HttpPost]
        public ActionResult Type_Sort(int typeId, int sort_Type)
        {
            Session[CommonConstants.SORT_SESSION] = sort_Type;

            return RedirectToAction("LoaiSP", new { typeId, page = 1 });
        }

        [HttpGet]
        public ActionResult Hang(int brandId, int page)
        {
            Session[CommonConstants.CURRENT_ROUTE] = (int)CommonConstants.Shop_Route.Brands;
            Session[CommonConstants.CURRENT_ROUTE_ID] = brandId;

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
        public ActionResult LoaiSP(int typeId, int page)
        {
            Session[CommonConstants.CURRENT_ROUTE] = (int)CommonConstants.Shop_Route.Types;
            Session[CommonConstants.CURRENT_ROUTE_ID] = typeId;

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

        public ActionResult ChiTiet(int id)
        {

            return RedirectToAction("Index","ThongTinSanPham", new { id = id } );
        }

        [ChildActionOnly]
        public PartialViewResult Slider()
        {
            return PartialView();
        }

        public ActionResult Price_range_filter(string range)
        {
            var split_range = range.Split(':');
            int range_min; // default: 0
            int range_max; // default: 0

            bool result_min = int.TryParse(split_range[0], out range_min);

            bool result_max = int.TryParse(split_range[1], out range_max);

            if (!result_max)
            {
                // error
                range_max = 600000000;
            }

            Session[CommonConstants.CURRENT_PRICE_RANGE_SORT] = true;

            Session[CommonConstants.PRICE_RANGE_MIN] = range_min;
            Session[CommonConstants.PRICE_RANGE_MAX] = range_max;

            if (Session[CommonConstants.CURRENT_ROUTE] == null)
            {
                Session[CommonConstants.CURRENT_ROUTE] = (int)CommonConstants.Shop_Route.Pages;
            }

            int current_route_id;

            if (Session[CommonConstants.CURRENT_ROUTE_ID] != null)
            {
                current_route_id = (int)Session[CommonConstants.CURRENT_ROUTE_ID];
            }
            else
            {
                current_route_id = 1;
            }
            
            // if current page is Shop -> pages
            if ((int)Session[CommonConstants.CURRENT_ROUTE] == (int)CommonConstants.Shop_Route.Pages)
            {
                return RedirectToAction("Trang", new {page = 1});
            }

            // if current page is Shop -> brands
            if ((int)Session[CommonConstants.CURRENT_ROUTE] == (int)CommonConstants.Shop_Route.Brands)
            {
                return RedirectToAction("Hang", new { brandId = current_route_id, page = 1 });
            }

            // if current page is Shop -> Types
            if ((int)Session[CommonConstants.CURRENT_ROUTE] == (int)CommonConstants.Shop_Route.Types)
            {
                return RedirectToAction("LoaiSP", new { typeId = current_route_id ,page = 1 });
            }

            return RedirectToAction("Trang", new { page = 1 });
        }
    }
}