namespace Model.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ShopInfo")]
    public partial class ShopInfo
    {
        public int Id { get; set; }

        [StringLength(500)]
        public string Name { get; set; }

        [StringLength(20)]
        public string Tel { get; set; }

        public int? City_Id { get; set; }

        public virtual City City { get; set; }
    }
}
