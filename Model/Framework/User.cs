namespace Model.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        public int Id { get; set; }

        [StringLength(500)]
        public string Name { get; set; }

        [StringLength(500)]
        public string UserName { get; set; }

        [StringLength(500)]
        public string PW { get; set; }

        [Column("_Rule")]
        public int? C_Rule { get; set; }

        [Column("_Status")]
        public int? C_Status { get; set; }
    }
}
