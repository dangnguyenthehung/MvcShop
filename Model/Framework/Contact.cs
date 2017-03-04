namespace Model.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Contact")]
    public partial class Contact
    {
        public int Id { get; set; }

        [StringLength(500)]
        public string ContactName { get; set; }

        [StringLength(500)]
        public string Company { get; set; }

        [Column(TypeName = "ntext")]
        public string ContactAddress { get; set; }

        [StringLength(20)]
        public string Tel { get; set; }

        [StringLength(300)]
        public string Mail { get; set; }

        [Column(TypeName = "ntext")]
        public string ContactDetail { get; set; }
    }
}
