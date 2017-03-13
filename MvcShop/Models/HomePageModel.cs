using Model.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcShop.Models
{
    public class HomePageModel : LayoutViewModel
    {
        public List<ShopProductInfo> ListProduct { get; set; }

        private Model.DbModel.ProductDetailsModel context = new Model.DbModel.ProductDetailsModel();
        private List<ShopProductInfo> tempList = new List<ShopProductInfo>();

        public HomePageModel()
        {
            int page = 1;
            tempList = get_all(page);
            ListProduct = tempList;
        }
        private List<ShopProductInfo> get_all(int page)
        {
            List<ShopProductInfo> contextList = context.getDetails_All();

            return pagination(contextList, page);
        }
        private List<ShopProductInfo> pagination(List<ShopProductInfo> contextList, int page)
        {
            int item_per_page = 6;
            int maxLength = contextList.Count();
            int begin = (page - 1) * item_per_page;
            int end = (page) * item_per_page;

            for (var i = begin; i < end; i++)
            {
                if (i >= maxLength)
                {
                    break;
                }
                tempList.Add(contextList[i]);
            }
            return tempList;
        }
    }
}