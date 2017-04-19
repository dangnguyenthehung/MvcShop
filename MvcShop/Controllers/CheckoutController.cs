using Model.Object;
using MvcShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

            var model = new CheckoutModel
            {
                CartItems = cartModel.itemList
            };

            return View(model);
        }
        [HttpPost]
        public ActionResult Index(CheckoutModel model)
        {

            return RedirectToAction("Index","Home");
        }
    }
}