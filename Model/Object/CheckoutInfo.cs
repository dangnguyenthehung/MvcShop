﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Object
{
    public class CheckoutInfo
    {
        public List<CartItem> CartItems { get; set; }

        public BillingInfo BillingInfo { get; set; }
    }
}
