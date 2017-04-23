using Model.DbModel;
using MvcShopAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}