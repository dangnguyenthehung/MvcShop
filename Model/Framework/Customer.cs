namespace Model.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Customer
    {
        public int Id { get; set; }

        [StringLength(500)]
        public string Name { get; set; }

        public DateTime? Birthday { get; set; }

        [StringLength(300)]
        public string Province { get; set; }

        [Column(TypeName = "ntext")]
        public string CustomersAddress { get; set; }

        [StringLength(20)]
        public string Tel { get; set; }

        [StringLength(300)]
        public string Email { get; set; }
    }
}
