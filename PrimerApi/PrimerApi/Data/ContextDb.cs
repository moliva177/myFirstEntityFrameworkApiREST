using Microsoft.EntityFrameworkCore;
using PrimerApi.Models;

namespace PrimerApi.Data;

public class ContextDb : DbContext
{
    public ContextDb(DbContextOptions<ContextDb> options) : base(options)
    {
        
    }

    public DbSet<Persona> Personas { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<MarcaAvion> MarcasAviones { get; set; }
    public DbSet<Avion> Aviones { get; set; }
}