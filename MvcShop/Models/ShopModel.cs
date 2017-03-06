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
            List<ShopProductInfo> contextList = context.getDetails_All();
            ListProduct = contextList;
        }
        public ShopModel(int page)
        {
            Model.DbModel.ProductDetailsModel context = new Model.DbModel.ProductDetailsModel();
            List<ShopProductInfo> contextList = context.getDetails_All();
            List<ShopProductInfo> tempList = new List<ShopProductInfo>();
            int begin = (page - 1) * 12;
            int end = (page) * 12;
            
            for (var i = begin; i < end; i++)
            {
                tempList.Add(contextList[i]);
            }
            ListProduct = tempList;
        }
    }
}