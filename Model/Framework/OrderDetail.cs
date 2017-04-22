namespace Model.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderDetail")]
    public partial class OrderDetail
    {
        public int Id { get; set; }

        public int Order_Id { get; set; }

        public int Product_Id { get; set; }

        public int? Quantity { get; set; }

        public int? Price { get; set; }

        public int? TotalPrice { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product_Details Product_Details { get; set; }
    }
}
