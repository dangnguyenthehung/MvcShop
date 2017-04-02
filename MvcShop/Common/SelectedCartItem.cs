using Model.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcShop.Common
{
    [Serializable]
    public class SelectedCartItem
    {
        public static List<CartItem> ListProduct = new List<CartItem>();
    }
}