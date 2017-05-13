namespace Model.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_ShopProductInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(50)]
        public string ProductCode { get; set; }

        [StringLength(500)]
        public string ProductName { get; set; }

        public double? NewPrice { get; set; }

        [StringLength(300)]
        public string ProductImages { get; set; }

        public int? ProductStatus { get; set; }

        [StringLength(500)]
        public string BrandName { get; set; }

        public int? ProductOrder { get; set; }
    }
}
