using Model.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcShop.Models
{
    public class CompareModel : LayoutViewModel
    {
        public View_ProductDetails Item_1 { get; set; }

        public View_ProductDetails Item_2 { get; set; }

        public View_ProductDetails Item_3 { get; set; }

        public CompareModel()
        {
            //
            Item_1 = new View_ProductDetails();
            Item_2 = new View_ProductDetails();
            Item_3 = new View_ProductDetails();
        }

        public CompareModel(int id_item_1, int id_item_2, int id_item_3)
        {
            var dbModel = new Model.DbModel.ProductDetailsModel();

            Item_1 = dbModel.getDetails(id_item_1);
            Item_2 = dbModel.getDetails(id_item_2);

            if (id_item_3 == 0)
            {
                Item_3 = null;
                return;
            }
            else
            {
                Item_3 = dbModel.getDetails(id_item_3);
            }

        }

        public string formattedPrice(double? price)
        {
            if (price == null)
            {
                return "0";
            }
            string str = String.Format("{0:n0}", price);
            str = str.Replace(",", ".");
            return str;
        }
    }
}