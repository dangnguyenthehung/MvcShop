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
    public class GioHangController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            //List<CartItem> listItem = new SelectedCartItem().ListProduct;
            var sesionList = (List<CartItem>)Session["CART_SESSION"];

            CartModel model = new CartModel();

            if (sesionList != null)
            {
                model.get_Item_Details(sesionList);
            }
            else
            {
                List<CartItem> list = new List<CartItem>();
                model.itemList = list;
            }
            

            return View(model);
        }

        [HttpPost]
        public JsonResult AddToCart(int ProductId, int Quantity)
        {
            int count = 0;
            string text = "";
            List<CartItem> listItem = new List<CartItem>();
            
            if (ProductId > 0)
            {
                CartItem item = new CartItem
                {
                    ItemId = ProductId,
                    Quantity = Quantity
                };

                var sesionList = new List<CartItem>();
                
                if (Session["CART_SESSION"] == null)
                {
                    listItem.Add(item);
                    Session.Add(CommonConstants.CART_SESSION, listItem);
                    count = 1;
                    text = "Đã thêm vào giỏ hàng. Hiện có " + count + " sản phẩm";
                }
                else
                {
                    sesionList = (List<CartItem>)Session["CART_SESSION"];

                    var isAdded = sesionList.Find(i => i.ItemId == ProductId);
                    if (isAdded != null)
                    {
                        text = "Sản phẩm đã có trong giỏ hàng!";
                        return Json(text, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        sesionList.Add(item);
                    }

                    count = sesionList.Count();

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
            var sesionList = (List<CartItem>)Session["CART_SESSION"];

            if (ProductId > 0)
            {
                //var model = new CartModel();
                
                var itemToRemove = sesionList.SingleOrDefault(r => r.ItemId == ProductId);

                if (itemToRemove != null )
                {
                    sesionList.Remove(itemToRemove);
                }
                else
                {
                    text = "Sản phẩm không có trong giỏ hàng!";
                    return Json(text, JsonRequestBehavior.AllowGet);
                }
                
                if (Session["CART_SESSION"] == null)
                {
                    text = "Giỏ hàng đang trống";
                    
                    return Json(text, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    count = sesionList.Count();
                }
            }
            text = "Đã xóa khỏi giỏ hàng. Hiện có " + count + " sản phẩm";

            return Json(text, JsonRequestBehavior.AllowGet);
            
        }
    }
}