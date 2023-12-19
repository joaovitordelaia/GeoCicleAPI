namespace GeoCicleAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblAmbiente")]
    public partial class tblAmbiente
    {
        [Key]
        public int idLocal { get; set; }

        [Required]
        [StringLength(50)]
        public string nmAmbiente { get; set; }

        public double? latitude { get; set; }

        public double? longitude { get; set; }
    }
}
