using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Object
{
    public class OrderItems
    {
        public int Id { get; set; }

        [DisplayName("Tên sản phẩm")]
        public string ProductName { get; set; }

        [DisplayName("Mã sản phẩm")]
        public string ProductCode { get; set; }

        [DisplayName("Hãng")]
        public string BrandName { get; set; }

        [DisplayName("Số lượng")]
        public int Quantity { get; set; }

        [DisplayName("Đơn giá")]
        public double Price { get; set; }

        [DisplayName("Thành tiền")]
        public double TotalPrice { get; set; }
    }
}
