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
        public List<View_ProductDetails> itemList = new List<View_ProductDetails>();

        public CartModel()
        {
            model = new CheckoutModel();
        }

        public List<View_ProductDetails> get_Item_Details(List<CartItem> listItem)
        {
            var listID = getIdList(listItem);
            List<View_ProductDetails> itemList = model.getItemInfo(listID);

            return itemList;
        }

        private List<int> getIdList(List<CartItem> list)
        {
            List<int> listId = new List<int>();
            foreach(var item in list)
            {
                listId.Add(item.ItemId);
            }

            return listId;
        }
    }
}