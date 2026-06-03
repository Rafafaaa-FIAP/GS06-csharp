using Microsoft.EntityFrameworkCore;
using ProjetoGS.ApiService.Models;

namespace ProjetoGS.ApiService.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Tecnologia> Tecnologias { get; set; }

    public DbSet<CategoriaImpacto> CategoriasImpacto { get; set; }

    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Usuario>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<CategoriaImpacto>()
            .HasMany(c => c.Tecnologias)
            .WithOne(t => t.CategoriaImpacto)
            .HasForeignKey(t => t.CategoriaImpactoId);
    }
}