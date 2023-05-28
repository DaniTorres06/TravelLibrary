using Microsoft.EntityFrameworkCore;
using System.IO;


namespace DataAccess.Models
{
    public partial class DbCrudContext : DbContext    
    {
        public DbCrudContext()
        {
        }

        public DbCrudContext(DbContextOptions<DbCrudContext> options) : base(options)
        {
        }

        public virtual DbSet<Autor> Autor { get; set; }
        public virtual DbSet<Editorial> Editorial { get; set; }
        public virtual DbSet<Libro> Libro { get; set; }
        public virtual DbSet<AutorHasLibro> AutorHasLibro { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
