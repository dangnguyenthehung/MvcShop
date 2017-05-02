using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcShop.Common
{
    public static class CommonConstants
    {
        public static string USER_SESSION = "USER_SESSION";
        public static string CART_SESSION = "CART_SESSION";
        public static string SORT_SESSION = "SORT_SESSION";

        public static string CURRENT_ROUTE = "CURRENT_ROUTE";
        public static string CURRENT_ROUTE_ID = "CURRENT_ROUTE_ID";
        public static string CURRENT_PRICE_RANGE_SORT = "CURRENT_PRICE_RANGE_SORT";
        public static string PRICE_RANGE_MIN = "PRICE_RANGE_MIN";
        public static string PRICE_RANGE_MAX = "PRICE_RANGE_MAX";

        public static string COMPARE_SESSION_ITEM_1 = "COMPARE_SESSION_ITEM_1";
        public static string COMPARE_SESSION_ITEM_2 = "COMPARE_SESSION_ITEM_2";
        public static string COMPARE_SESSION_ITEM_3 = "COMPARE_SESSION_ITEM_3";

        public enum Sort_Type
        {
            ID_ASC = 1,
            ID_DESC = 2,
            Price_ASC = 3,
            Price_DESC = 4,
        };

        public enum Shop_Route
        {
            Pages = 1,
            Brands = 2,
            Types = 3
        };

    }
}