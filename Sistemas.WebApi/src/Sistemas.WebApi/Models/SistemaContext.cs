using Microsoft.Data.Entity;
using Sistemas.WebModel.Models;

namespace Sistemas.WebApi.Models
{
    public class SistemaContext : DbContext
    {
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Unidad> Unidades { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    // Visual Studio 2015 | Use the LocalDb 12 instance created by Visual Studio
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectsV12;Database=Sistema;Trusted_Connection=True;");

        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Producto>().Key(a => a.Id);
            modelBuilder.Entity<Unidad>().Key(a => a.Id);
        
            modelBuilder.Entity<Producto>().Property(g => g.Id).ForSqlServer(b => b.UseSequence());
            modelBuilder.Entity<Unidad>().Property(a => a.Id).ForSqlServer(b => b.UseSequence());
            
            modelBuilder.Entity<Producto>()
                .Property(p => p.Precio)
                .ColumnType("Money");

            modelBuilder.Entity<Producto>()
                .Property(p => p.Nombre)
                .MaxLength(80)
                .ColumnType("varchar");

                
            modelBuilder.Entity<Unidad>()
                .Property(p => p.Descripcion)
                .MaxLength(80)
                .ColumnType("varchar");


            modelBuilder.Entity<Unidad>()
                .Property(p => p.Nemonico)
                .MaxLength(3)
                .ColumnType("varchar");
    
            modelBuilder.Entity<Producto>()
                .Property(p => p.Precio)
                .ColumnType("Money");
        }
    }
}
