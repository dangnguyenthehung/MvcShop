using Model.DbModel;
using Model.Object;
using MvcShopAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model.Framework;

namespace MvcShopAdmin.Controllers
{
    public class OrderDetailsController : AdminBaseController
    {
        // GET: OrderDetails
        public ActionResult Index(int Order_Id)
        {
            var dbModel = new Orders_OrderDetailsModel();

            var model = new OrderDetailsModel
            {
                OrderInfo = dbModel.Get_Order_By_Id(Order_Id),
                listItem = dbModel.Get_Order_Details(Order_Id)
            };

            return View(model);
        }

        public ActionResult Edit(int OrderItem_Id)
        {
            var dbModel = new Orders_OrderDetailsModel();

            OrderItems model = dbModel.Get_OrderItem_By_Id(OrderItem_Id);
            

            return View(model);
        }

        public JsonResult UpdateQuantity(int OrderItem_Id, int Quantity)
        {
            var dbModel = new Orders_OrderDetailsModel();

            int result = dbModel.Update_OrderItem_By_Id(OrderItem_Id, Quantity);

            return Json("Update successfully", JsonRequestBehavior.AllowGet);
        }

        public ActionResult VerifyOrder(OrderDetailsModel info)
        {
            var model = info.OrderInfo;

            var dbModel = new Orders_OrderDetailsModel();

            dbModel.Verify_Order_By_Id(model);

            return RedirectToAction("Index","NewOrders");
        }
        //public ActionResult DeleteOrder (int id)
        //{
        //    var dbModel = new Orders_OrderDetailsModel();

        //    dbModel.Delete_Order_By_Id(id);

        //    return RedirectToAction("Index", "NewOrders");
        //}
        // GET: Product_Details/Delete/5
        public ActionResult DeleteOrder(int id)
        {
            
            var dbModel = new Orders_OrderDetailsModel();

            var model = new OrderDetailsModel
            {
                OrderInfo = dbModel.Get_Order_By_Id(id),
                listItem = dbModel.Get_Order_Details(id)
            };
            return View(model);
        }

        // POST: Product_Details/Delete/5
        [HttpPost, ActionName("DeleteOrder")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var dbModel = new Orders_OrderDetailsModel();

            dbModel.Delete_Order_By_Id(id);

            return RedirectToAction("Index", "NewOrders");
        }


    }
}