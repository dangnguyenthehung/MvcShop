using Model.DbModel;
using MvcShopAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Object;
using MvcShopAdmin.Helper;

namespace MvcShopAdmin.Controllers
{
    public class NewOrdersController : Controller
    {
        // GET: NewOrders
        public ActionResult Index()
        {
            var dbModel = new Orders_OrderDetailsModel();

            var model = new OrdersModel {
                listOrder = dbModel.Get_New_Orders()
            };
        
            return View(model);
        }

        public ActionResult Details(int Order_Id)
        {
            if (Order_Id != 0)
            {
                return RedirectToAction("Index", "OrderDetails", new { Order_Id = Order_Id });
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        // syncing result - realtime syncing
        [HttpGet]
        public JsonResult SyncResult()
        {
            var dbModel = new Orders_OrderDetailsModel();
            List<NewOrder> data = dbModel.Get_New_Orders();
            string[] text = { " " };
            
            //var i = 0;

            if (data == null || data.Count == 0)
            {
                text[0] = "normal";
            }
            else
            {
                for (var i = 0; i < text.Length; i++)
                {
                    string str = "Có đơn hàng mới";
                    text[i] = str;
                }
            }

            return Json(text, JsonRequestBehavior.AllowGet);
        }
    }
}