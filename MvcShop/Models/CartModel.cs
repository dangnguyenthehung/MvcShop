using Model.DbModel;
using Model.Framework;
using Model.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcShop.Models
{
    public class CartModel : LayoutViewModel
    {
        Cart_CheckoutModel model = null;
        public List<CartItem> itemList { get; set; }

        public CartModel()
        {
            model = new Cart_CheckoutModel();
        }

        public void get_Item_Details(List<CartItem> listItem)
        {
            itemList = model.GetItemInfo(listItem);       
        }

        //private List<int> getIdList(List<CartItem> list)
        //{
        //    List<int> listId = new List<int>();
        //    foreach(var item in list)
        //    {
        //        listId.Add(item.ItemId);
        //    }

        //    return listId;
        //}
    }
}