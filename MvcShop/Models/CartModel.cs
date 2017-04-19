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
        CheckoutModel model = null;
        public List<CartItem> itemList { get; set; }

        public CartModel()
        {
            model = new CheckoutModel();
        }

        public void get_Item_Details(List<CartItem> listItem)
        {
            itemList = model.getItemInfo(listItem);       
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