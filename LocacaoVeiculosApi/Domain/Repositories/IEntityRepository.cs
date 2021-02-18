using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LocacaoVeiculosApi.Domain.Repositories
{
    public interface IEntityRepository<T> where T : class
    {
        Task<IEnumerable<T>> ListAsync(params Expression<Func<T, object>>[] includes);
        Task AddAsync(T entity);
        Task<T> FindByIdAsync(int id);

        Task<IEnumerable<T>> Filter(Expression<Func<T, bool>> predicate,
            params Expression<Func<T, object>>[] includes);
        void Update(T entity);
        void Remove(T entity);

        Task<IEnumerable<T>> Filter(Expression<Func<T, bool>> predicate,
            params Expression<Func<T, object>>[] includes);
    }
}

