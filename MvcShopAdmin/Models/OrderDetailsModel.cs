using Model.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcShopAdmin.Models
{
    public class OrderDetailsModel
    {
        public NewOrder OrderInfo { get; set; }

        public List<OrderItems> listItem { get; set; }

        public string formatted_TotalMoney()
        {
            string str = String.Format("{0:n0}", OrderInfo.TotalMoney);
            str = str.Replace(",", ".");
            return str;
        }

        public string formatted_item_Price(double price)
        {
            string str = String.Format("{0:n0}", price);
            str = str.Replace(",", ".");
            return str;
        }
    }
}