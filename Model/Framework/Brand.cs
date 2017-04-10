namespace Model.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Brand")]
    public partial class Brand
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Brand()
        {
            Product_Details = new HashSet<Product_Details>();
        }

        public int Id { get; set; }

        [StringLength(500)]
        public string BrandName { get; set; }

        [Column(TypeName = "ntext")]
        public string BrandContent { get; set; }

        [StringLength(300)]
        public string BrandImages { get; set; }

        public int? BrandOrder { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product_Details> Product_Details { get; set; }
    }
}
