using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcShopAdmin.Models;
using Model.DbModel;

namespace MvcShopAdmin.Controllers
{
    public class CompleteOrdersController : AdminBaseController
    {
        // GET: CompleteOrders
        public ActionResult Index()
        {
            var dbModel = new Orders_OrderDetailsModel();

            var model = new OrdersModel
            {
                listOrder = dbModel.Get_Completed_Orders()
            };

            return View(model);
        }
    }
}