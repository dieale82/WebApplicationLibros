using Microsoft.EntityFrameworkCore;
using Models;

namespace DatabaseContext
{
    public class LibrosInventoryContext : DbContext
    {
        public DbSet<Editorial> Editoriales { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }

        public LibrosInventoryContext(DbContextOptions<LibrosInventoryContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define relationships between entities

            modelBuilder.Entity<Libro>()
                .HasOne(l => l.Editorial)
                .WithMany(e => e.Libros)
                .HasForeignKey(l => l.EditorialId);

            modelBuilder.Entity<Libro>()
                .HasMany(l => l.Autores)
                .WithMany(a => a.Libros)
                .UsingEntity(j => j.ToTable("autores_has_libros"));
        }
    }
}
