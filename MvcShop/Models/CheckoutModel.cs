using Model.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcShop.Models
{
    public class CheckoutModel
    {
        public List<CartItem> CartItems { get; set; }

        public CheckoutInfo CheckoutInfo { get; set; }

    }
}