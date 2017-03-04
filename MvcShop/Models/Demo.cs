using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcShop.Models
{
    public class Demo : Model.Framework.View_ProductDetails
    {
        public string Formatted_price { get; set; }
        public string Formatted_old_price { get; set; }
    }
}