using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace GeoCicleAPI.Models
{
    public partial class Model : DbContext
    {
        public Model()
            : base("name=ModelUsuario")
        {
        }

        public virtual DbSet<tblUsuario> tblUsuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblUsuario>()
                .Property(e => e.nmUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<tblUsuario>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<tblUsuario>()
                .Property(e => e.senha)
                .IsUnicode(false);
        }
    }
}
