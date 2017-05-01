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
            @ViewBag.PageTitle = "So sánh";
            Check_Null_Session();

            var compare_item_1 = (int)Session[Common.CommonConstants.COMPARE_SESSION_ITEM_1];
            var compare_item_2 = (int)Session[Common.CommonConstants.COMPARE_SESSION_ITEM_2];
            var compare_item_3 = (int)Session[Common.CommonConstants.COMPARE_SESSION_ITEM_3];

            if (compare_item_1 == 0)
            {
                return RedirectToAction("Message");
            }

            if (compare_item_2 == 0)
            {
                return RedirectToAction("Message");
            }
            
            CompareModel model = new CompareModel(compare_item_1, compare_item_2, compare_item_3);

            return View(model);
        }

        [HttpPost]
        public JsonResult AddToCompare(int product_Id)
        {
            var message = "Đã thêm vào so sánh";

            Check_Null_Session();

            int compare_item_1 = (int)Session[Common.CommonConstants.COMPARE_SESSION_ITEM_1];
            int compare_item_2 = (int)Session[Common.CommonConstants.COMPARE_SESSION_ITEM_2];
            int compare_item_3 = (int)Session[Common.CommonConstants.COMPARE_SESSION_ITEM_3];

            if (compare_item_1 == 0)
            {
                Session[Common.CommonConstants.COMPARE_SESSION_ITEM_1] = product_Id;
                return Json(message, JsonRequestBehavior.AllowGet);
            }

            if (compare_item_2 == 0)
            {
                Session[Common.CommonConstants.COMPARE_SESSION_ITEM_2] = product_Id;
                return Json(message, JsonRequestBehavior.AllowGet);
            }

            if (compare_item_3 == 0)
            {
                Session[Common.CommonConstants.COMPARE_SESSION_ITEM_3] = product_Id;
                return Json(message, JsonRequestBehavior.AllowGet);
            }

            // if all 3 slot have item => remove 1st item
            ////// => slot 1: item 2; slot 2: item 3; slot 3: new item
            Session[Common.CommonConstants.COMPARE_SESSION_ITEM_1] = compare_item_2;
            Session[Common.CommonConstants.COMPARE_SESSION_ITEM_2] = compare_item_3;
            Session[Common.CommonConstants.COMPARE_SESSION_ITEM_3] = product_Id;

            return Json(message, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Message()
        {
            ViewBag.Message = "Bạn phải chọn ít nhất 2 sản phẩm để so sánh";
            CompareModel model = new CompareModel();

            return View(model);
        }

        [ChildActionOnly]
        public PartialViewResult Slider()
        {
            return PartialView();
        }

        private void Check_Null_Session()
        {
            if (Session[Common.CommonConstants.COMPARE_SESSION_ITEM_1] == null)
            {
                Session[Common.CommonConstants.COMPARE_SESSION_ITEM_1] = 0;
            }
            if (Session[Common.CommonConstants.COMPARE_SESSION_ITEM_2] == null)
            {
                Session[Common.CommonConstants.COMPARE_SESSION_ITEM_2] = 0;
            }
            if (Session[Common.CommonConstants.COMPARE_SESSION_ITEM_3] == null)
            {
                Session[Common.CommonConstants.COMPARE_SESSION_ITEM_3] = 0;
            }
        }
    }
}