namespace MvcHouse.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("House")]
    public partial class House
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Owner { get; set; }

        public int? Type { get; set; }

        public int? Price { get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; }
    }
}
