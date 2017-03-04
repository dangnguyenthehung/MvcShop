using Model.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcShop.Models
{
    public class ShopModel : LayoutViewModel
    {
        public List<ShopProductInfo> ListProduct { get; set; }

        public ShopModel()
        {
            Model.DbModel.ProductDetailsModel context = new Model.DbModel.ProductDetailsModel();
            var contextList = context.getDetails_All();
            ListProduct = contextList;

        }
    }
}