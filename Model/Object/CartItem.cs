using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Object
{
    public class CartItem
    {
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public double? Price { get; set; }

        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductImages { get; set; }
    }
}
