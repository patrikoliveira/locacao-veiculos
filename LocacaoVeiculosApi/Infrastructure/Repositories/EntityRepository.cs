using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<IEnumerable<T>> ListAsync(params Expression<Func<T, object>>[] includes)
        {
            var query = _context.Set<T>().AsQueryable();       
            foreach (Expression<Func<T, object>> i in includes)       
            {       
                query = query.Include(i);       
            }
            return await query.ToListAsync();
        }

        public async Task<T> FindByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> Filter(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)       
        {       
            var query = _context.Set<T>().Where(predicate);       
            foreach (Expression<Func<T, object>> i in includes)       
            {       
                query = query.Include(i);       
            }

            return await query.ToListAsync();
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

        public async Task<IEnumerable<T>> Filter(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)       
        {       
            var query = _context.Set<T>().Where(predicate);       
            foreach (Expression<Func<T, object>> i in includes)       
            {       
                query = query.Include(i);       
            }

            return await query.ToListAsync();
        }
    }
}