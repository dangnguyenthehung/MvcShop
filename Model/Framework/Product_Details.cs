namespace Model.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
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
        [DisplayName("Mã SP")]
        public string ProductCode { get; set; }

        [StringLength(500)]
        [DisplayName("Tên SP")]
        public string ProductName { get; set; }

        [Column(TypeName = "ntext")]
        [DisplayName("Chi tiết")]
        public string ProductDetail { get; set; }

        [DisplayName("Giá hãng")]
        public double? OldPrice { get; set; }

        [DisplayName("Giá bán")]
        public double? NewPrice { get; set; }

        [StringLength(300)]
        [DisplayName("Hình")]
        public string ProductImages { get; set; }

        [DisplayName("Nóng/lạnh")]
        public int? HeatType { get; set; }

        [DisplayName("Trọng lượng")]
        public double? ProductWeight { get; set; }

        [StringLength(20)]
        [DisplayName("Kích thước")]
        public string ProductDimension { get; set; }

        [DisplayName("Ngày thêm")]
        public DateTime? InsertDate { get; set; }

        [DisplayName("Ưu tiên")]
        public int? ProductOrder { get; set; }

        [DisplayName("Trạng thái")]
        public int? ProductStatus { get; set; }

        [DisplayName("Loại")]
        public int? ProductType_Id { get; set; }

        [DisplayName("Hãng")]
        public int? Brand_Id { get; set; }

        public virtual Brand Brand { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual ProductType ProductType { get; set; }
    }
}
