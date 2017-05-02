using Model.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcShop.Common;

namespace MvcShop.Models
{
    public class ShopModel : LayoutViewModel
    {
        public List<ShopProductInfo> ListProduct { get; set; }

        private Model.DbModel.ProductDetailsModel context = new Model.DbModel.ProductDetailsModel();
        private List<ShopProductInfo> tempList = new List<ShopProductInfo>();

        public ShopModel()
        {
            List<ShopProductInfo> contextList = context.getDetails_All();
            ListProduct = contextList;
        }

        public ShopModel(int page)
        {
            tempList = get_all(page);
            ListProduct = tempList;
        }
        public ShopModel(string action, int id, int page)
        {
            switch (action)
            {
                case "brand":
                    tempList = get_list_brand(id, page);
                    break;
                case "type":
                    tempList = get_list_type(id, page);
                    break;
                default:
                    break;
            }

            ListProduct = tempList;
        }
        private List<ShopProductInfo> get_all(int page)
        {
            var contextList = new List<ShopProductInfo>();
            // Kiểm tra sort hiện tại - không có: get mặc định; có: get theo sort
            if (HttpContext.Current.Session[CommonConstants.SORT_SESSION] == null)
            {
                contextList = context.getDetails_All();
            }
            else
            {
                try
                {
                    var sort_Type = (int)HttpContext.Current.Session[CommonConstants.SORT_SESSION];
                    contextList = context.getDetails_All(sort_Type);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }

            // nếu có lọc khoảng giá
            if (HttpContext.Current.Session[CommonConstants.CURRENT_PRICE_RANGE_SORT] != null)
            {
                if ((bool) HttpContext.Current.Session[CommonConstants.CURRENT_PRICE_RANGE_SORT])
                {
                    contextList = Sort_Price_Range(contextList);
                }
            }
            
            return pagination(contextList, page);
        }

        private List<ShopProductInfo> get_list_brand(int brandId, int page)
        {
            var contextList = new List<ShopProductInfo>();
            // Kiểm tra sort hiện tại - không có: get mặc định; có: get theo sort
            if (HttpContext.Current.Session[CommonConstants.SORT_SESSION] == null)
            {
                contextList = context.getDetails_Brand(brandId);
            }
            else
            {
                try
                {
                    var sort_Type = (int)HttpContext.Current.Session[CommonConstants.SORT_SESSION];
                    contextList = context.getDetails_Brand(brandId, sort_Type);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }

            // nếu có lọc khoảng giá
            if (HttpContext.Current.Session[CommonConstants.CURRENT_PRICE_RANGE_SORT] != null)
            {
                if ((bool)HttpContext.Current.Session[CommonConstants.CURRENT_PRICE_RANGE_SORT])
                {
                    contextList = Sort_Price_Range(contextList);
                }
            }

            return pagination(contextList, page);

        }

        private List<ShopProductInfo> get_list_type(int typeId, int page)
        {
            var contextList = new List<ShopProductInfo>();
            // Kiểm tra sort hiện tại - không có: get mặc định; có: get theo sort
            if (HttpContext.Current.Session[CommonConstants.SORT_SESSION] == null)
            {
                contextList = context.getDetails_Type(typeId);
            }
            else
            {
                try
                {
                    var sort_Type = (int)HttpContext.Current.Session[CommonConstants.SORT_SESSION];
                    contextList = context.getDetails_Type(typeId, sort_Type);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }

            // nếu có lọc khoảng giá
            if (HttpContext.Current.Session[CommonConstants.CURRENT_PRICE_RANGE_SORT] != null)
            {
                if ((bool)HttpContext.Current.Session[CommonConstants.CURRENT_PRICE_RANGE_SORT])
                {
                    contextList = Sort_Price_Range(contextList);
                }
            }

            return pagination(contextList, page);
        }

        // lọc khoảng giá 
        private List<ShopProductInfo> Sort_Price_Range(List<ShopProductInfo> source_list)
        {
            if (HttpContext.Current.Session[CommonConstants.PRICE_RANGE_MIN] == null)
            {
                return source_list;
            }

            if (HttpContext.Current.Session[CommonConstants.PRICE_RANGE_MAX] == null)
            {
                return source_list;
            }

            var range_min = (int)HttpContext.Current.Session[CommonConstants.PRICE_RANGE_MIN];
            var range_max = (int)HttpContext.Current.Session[CommonConstants.PRICE_RANGE_MAX];

            var list = source_list.Where(item => (item.NewPrice >= range_min && item.NewPrice <= range_max)).ToList();

            return list;
        }

        // lấy số lượng phần tử cho mỗi trang
        private List<ShopProductInfo> pagination(List<ShopProductInfo> contextList, int page)
        {
            int item_per_page = 21;
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
        public string get_Type(int typeId)
        {
            string type = context.get_type_name(typeId);
            return type;
        }
    }
}