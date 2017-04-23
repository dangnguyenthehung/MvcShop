using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Object
{
    public class NewOrder
    {
        [DisplayName("Mã đơn hàng")]
        public int Order_Id { get; set; }

        [DisplayName("Tên khách hàng")]
        public string Customer_Name { get; set; }

        [DisplayName("Số điện thoại")]
        public string Customer_Tel { get; set; }

        [DisplayName("Địa chỉ giao")]
        public string Delivery_Address { get; set; }

        [DisplayName("Quận")]
        public string District_Name { get; set; }

        [DisplayName("Tỉnh/Thành phố")]
        public string City_Name { get; set; }

        [DisplayName("Tổng tiền")]
        public double TotalMoney { get; set; }

        [DisplayName("Ngày đặt")]
        public DateTime OrderDate { get; set; }

        [DisplayName("Ghi chú")]
        public string Notes { get; set; }

        [DisplayName("Trạng thái")]
        public int OrderStatus { get; set; }
    }
}
