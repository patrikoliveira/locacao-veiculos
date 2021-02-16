using Microsoft.EntityFrameworkCore;
using LocacaoVeiculosApi.Domain.Entities;

namespace LocacaoVeiculosApi.Infrastructure.Database
{
    public class EntityContext : DbContext
    {
        public EntityContext(DbContextOptions<EntityContext> options) : base(options) {}
        
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}