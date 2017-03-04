namespace Model.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Advertise")]
    public partial class Advertise
    {
        public int Id { get; set; }

        [StringLength(500)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Url { get; set; }

        public int? Width { get; set; }

        public int? Height { get; set; }

        [StringLength(500)]
        public string Link { get; set; }

        [Column("_target")]
        public int? C_target { get; set; }

        public int? Position { get; set; }

        [Column("_Order")]
        public int? C_Order { get; set; }

        [Column("_Status")]
        public int? C_Status { get; set; }
    }
}
