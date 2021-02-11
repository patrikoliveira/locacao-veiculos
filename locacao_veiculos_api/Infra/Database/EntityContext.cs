using Microsoft.EntityFrameworkCore;
using locacao_veiculos_api.Domain.Entities;
using Newtonsoft.Json.Linq;
using System.IO;
using System;

namespace locacao_veiculos_api.Infra.Database
{
    public class EntityContext : DbContext
    {
        public EntityContext(DbContextOptions<EntityContext> options): base(options){}
        public EntityContext(){ }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            JToken jAppSettings = JToken.Parse(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "appsettings.json")));
            optionsBuilder.UseNpgsql(jAppSettings["ConnectionString"].ToString());
        }
        
        public DbSet<Usuario> Users { get; set; }
    }
}