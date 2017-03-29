using Model.Object;
using MvcShop.Common;
using MvcShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcShop.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            List<CartItem> listItem = SelectedCartItem.ListProduct;
            CartModel model = new CartModel();

            var itemList = model.get_Item_Details(listItem);
            model.itemList = itemList;

            return View(model);
        }

        [HttpPost]
        public JsonResult AddToCart(int ProductId, int Quantity)
        {
            int count = 0;
            if (ProductId > 0)
            {
                //var model = new CartModel();
                CartItem item = new CartItem();
                item.ItemId = ProductId;
                item.Quantity = Quantity;

                SelectedCartItem.ListProduct.Add(item);

                // SelectedCartItem.ListProduct is static, so in Session it will automaticaly update
                // just need to add it into session at the first time
                if (Session["CART_SESSION"] == null)
                {
                    Session.Add(CommonConstants.CART_SESSION, SelectedCartItem.ListProduct);
                    count = 1;
                }
                else
                {
                    List<CartItem> newList = new List<CartItem>();
                    newList = (List<CartItem>)Session["CART_SESSION"];
                    count = newList.Count();
                }
            }
            string text = "Đã thêm vào giỏ hàng. Hiện có " + count + " sản phẩm";

            return Json(text, JsonRequestBehavior.AllowGet); 
        }
    }
}