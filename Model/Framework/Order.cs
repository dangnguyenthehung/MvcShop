namespace Model.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }

        public int? Customer_Id { get; set; }

        public int? Delivery_City_Id { get; set; }

        public int? Delivery_District_Id { get; set; }

        [StringLength(300)]
        public string Delivery_Address { get; set; }

        public double? TotalMoney { get; set; }

        public DateTime? OrderDate { get; set; }

        public int? OrderStatus { get; set; }

        public virtual City City { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual District District { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
