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

            model.get_Item_Details(listItem);           

            return View(model);
        }

        [HttpPost]
        public JsonResult AddToCart(int ProductId, int Quantity)
        {
            int count = 0;
            string text = "";
            if (ProductId > 0)
            {
                //var model = new CartModel();
                CartItem item = new CartItem
                {
                    ItemId = ProductId,
                    Quantity = Quantity
                };

                var isAdded = SelectedCartItem.ListProduct.Find(i => i.ItemId == ProductId);
                if (isAdded != null)
                {
                    text = "Sản phẩm đã có trong giỏ hàng!";
                    return Json(text, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    SelectedCartItem.ListProduct.Add(item);
                }
                
                // SelectedCartItem.ListProduct is static, so in Session it will automaticaly update
                // just need to add it into session at the first time
                if (Session["CART_SESSION"] == null)
                {
                    Session.Add(CommonConstants.CART_SESSION, SelectedCartItem.ListProduct);
                    count = 1;
                    text = "Đã thêm vào giỏ hàng. Hiện có " + count + " sản phẩm";
                }
                else
                {
                    List<CartItem> newList = new List<CartItem>();
                    newList = (List<CartItem>)Session["CART_SESSION"];
                    count = newList.Count();

                    text = "Đã thêm vào giỏ hàng. Hiện có " + count + " sản phẩm";
                }
            }
            

            return Json(text, JsonRequestBehavior.AllowGet); 
        }

        [HttpPost]
        public void UpdateCartQuantity(int ProductId, int Quantity)
        {
            var cartList = (List<CartItem>)Session["CART_SESSION"];
            var item = cartList.Find(i => i.ItemId == ProductId);
            item.Quantity = Quantity;
        }

        [HttpPost]
        public JsonResult RemoveFromCart(int ProductId)
        {
            int count = 0;
            string text = "";
            if (ProductId > 0)
            {
                //var model = new CartModel();
                
                var itemToRemove = SelectedCartItem.ListProduct.SingleOrDefault(r => r.ItemId == ProductId);

                if (itemToRemove != null )
                {
                    SelectedCartItem.ListProduct.Remove(itemToRemove);
                }
                else
                {
                    text = "Có lỗi xảy ra! Vui lòng thử lại sau.";
                    return Json(text, JsonRequestBehavior.AllowGet);
                }

                // SelectedCartItem.ListProduct is static, so in Session it will automaticaly update
                // just need to add it into session at the first time
                if (Session["CART_SESSION"] == null)
                {
                    text = "Giỏ hàng đang trống";
                    
                    return Json(text, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    List<CartItem> newList = new List<CartItem>();
                    newList = (List<CartItem>)Session["CART_SESSION"];
                    count = newList.Count();
                }
            }
            text = "Đã xóa khỏi giỏ hàng. Hiện có " + count + " sản phẩm";

            return Json(text, JsonRequestBehavior.AllowGet);

           
        }
    }
}