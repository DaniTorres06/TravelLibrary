using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                /*
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false);
                IConfiguration configuration = builder.Build();
                var _connectionString = configuration.GetSection("ConnectionStrings:").Value;
                optionsBuilder.UseSqlServer(_connectionString.ToString());
                */

                optionsBuilder.UseSqlServer("Server=localhost;Database=BDTravel;Trusted_Connection=True;User=sa;Password=123456");

            }


        }
    }
}
