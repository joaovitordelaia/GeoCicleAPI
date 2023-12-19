using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace GeoCicleAPI.Models
{
    public partial class Model2 : DbContext
    {
        public Model2()
            : base("name=ModelAmbiente")
        {
        }

        public virtual DbSet<tblAmbiente> tblAmbiente { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblAmbiente>()
                .Property(e => e.nmAmbiente)
                .IsUnicode(false);
        }
    }
}
