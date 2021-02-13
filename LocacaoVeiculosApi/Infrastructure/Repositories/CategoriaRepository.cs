using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocacaoVeiculosApi.Domain.Entities;
using LocacaoVeiculosApi.Domain.Repositories;
using LocacaoVeiculosApi.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace LocacaoVeiculosApi.Infrastructure.Repositories
{
    public class CategoriaRepository<T> : BaseRepository, ICategoriaRepository<T> where T : class
    {
        public CategoriaRepository(EntityContext context) : base(context)
        {
        }

        public async Task<IEnumerable<IEntity>> ListAsync()
        {
            // return await _context.Set<Categoria>().ToListAsync();
            return await _context.Categorias.ToListAsync();
        }

        public async Task AddAsync(Categoria categoria)
        {
            await _context.Categorias.AddAsync(categoria);
        }

        public async Task<Categoria> FindByIdAsync(int id)
        {
            return await _context.Categorias.FindAsync(id);
        }

        public void Update(Categoria entity)
        {
            _context.Categorias.Update(entity);
        }

        public void Remove(Categoria entity)
        {
            _context.Categorias.Remove(entity);
        }
    }
}