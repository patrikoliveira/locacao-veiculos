using System.Collections.Generic;
using System.Threading.Tasks;
using LocacaoVeiculosApi.Domain.Repositories;
using LocacaoVeiculosApi.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace LocacaoVeiculosApi.Infrastructure.Repositories
{
    public class EntityRepository<T> : BaseRepository, IEntityRepository<T> where T : class
    {
        public EntityRepository(EntityContext context) : base(context)
        {
        }

        public async Task<IEnumerable<T>> ListAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> FindByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}