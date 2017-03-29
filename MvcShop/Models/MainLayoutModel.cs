using Model.Object;
using MvcShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcShop.Models
{
    public abstract class MainLayoutModel
    {
        public CartItem Cart { get; set; }
    }
}