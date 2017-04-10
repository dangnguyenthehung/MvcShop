namespace Model.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product_Details
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product_Details()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string ProductCode { get; set; }

        [StringLength(500)]
        public string ProductName { get; set; }

        [Column(TypeName = "ntext")]
        public string ProductDetail { get; set; }

        public double? OldPrice { get; set; }

        public double? NewPrice { get; set; }

        [StringLength(300)]
        public string ProductImages { get; set; }

        public int? HeatType { get; set; }

        public double? ProductWeight { get; set; }

        [StringLength(20)]
        public string ProductDimension { get; set; }

        public DateTime? InsertDate { get; set; }

        public int? ProductOrder { get; set; }

        public int? ProductStatus { get; set; }

        public int? ProductType_Id { get; set; }

        public int? Brand_Id { get; set; }

        public virtual Brand Brand { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual ProductType ProductType { get; set; }
    }
}
