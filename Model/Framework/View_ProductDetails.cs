namespace Model.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_ProductDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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

        public int? ProductOrder { get; set; }

        public int? ProductStatus { get; set; }

        [StringLength(500)]
        public string TypeName { get; set; }

        [StringLength(500)]
        public string BrandName { get; set; }
    }
}
