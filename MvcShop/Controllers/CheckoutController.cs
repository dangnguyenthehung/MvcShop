using Model.DbModel;
using Model.Object;
using MvcShop.Helper;
using MvcShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MvcShop.Controllers
{
    public class CheckoutController : Controller
    {
        // GET: Checkout
        public ActionResult Index()
        {
            var sesionList = (List<CartItem>)Session["CART_SESSION"];

            CartModel cartModel = new CartModel();

            if (sesionList != null)
            {
                cartModel.get_Item_Details(sesionList);
            }
            else
            {
                List<CartItem> list = new List<CartItem>();
                cartModel.itemList = list;
            }

            var model = new CheckoutModel()
            {
                Info = new CheckoutInfo()
                {
                    CartItems = cartModel.itemList
                }
            };

            var helperModel = new Get_SelectList();

            var listThanhPho = helperModel.Get_ThanhPho();
            var listQuan = helperModel.Get_Quan();

            ViewBag.City_ID = new SelectList(listThanhPho, "Id", "Name");
            ViewBag.District_ID = new SelectList(listQuan, "Id", "Name");

            return View(model);
        }
        [HttpPost]
        public ActionResult Index(CheckoutModel model)
        {
            var helper = new Cart_CheckoutModel();

            helper.Create_Order(model.Info);

            return RedirectToAction("Index","Home");
        }

        [Route("Checkout/Get_Quan")]
        public JsonResult Get_Quan(int ID_ThanhPho)
        {            
            var helperModel = new Get_SelectList();

            var listQuan = helperModel.Get_Quan(ID_ThanhPho);

            return Json(listQuan, JsonRequestBehavior.AllowGet);            
        }
    }
}