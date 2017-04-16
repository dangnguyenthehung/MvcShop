using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Object
{
    public class CheckoutInfo
    {
        public string Customer_Name { get; set; }
        public string Customer_Phone { get; set; }
        public string Customer_Email { get; set; }
        public string Notes { get; set; }

        public int City_ID { get; set; }
        public int District_ID { get; set; }
        public string Delivery_Address { get; set; }
    }
}
