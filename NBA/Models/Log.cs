namespace NBA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Log")]
    public partial class Log
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string Jobnumber { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Password { get; set; }
    }
}
