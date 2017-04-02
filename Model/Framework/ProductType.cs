namespace Model.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductType")]
    public partial class ProductType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductType()
        {
            Product_Details = new HashSet<Product_Details>();
        }

        public int Id { get; set; }

        [StringLength(500)]
        [DisplayName("Loại")]
        public string TypeName { get; set; }

        [Column(TypeName = "ntext")]
        public string TypeContent { get; set; }

        [StringLength(300)]
        public string TypeImages { get; set; }

        public int? TypeOrder { get; set; }

        public int? ParentTypeId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product_Details> Product_Details { get; set; }
    }
}
