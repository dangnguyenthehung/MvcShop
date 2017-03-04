namespace Model.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Support")]
    public partial class Support
    {
        public int Id { get; set; }

        [StringLength(500)]
        public string Name { get; set; }

        [StringLength(20)]
        public string Tel { get; set; }

        [Column("_Type")]
        public int? C_Type { get; set; }

        [StringLength(50)]
        public string Nick { get; set; }

        [Column("_Order")]
        public int? C_Order { get; set; }

        [Column("_Status")]
        public int? C_Status { get; set; }
    }
}
