using System.Collections.Generic;
using System.Threading.Tasks;
using LocacaoVeiculosApi.Domain.Entities;

namespace LocacaoVeiculosApi.Domain.Repositories
{
    public interface IEntityRepository<T> where T : class
    {
        Task<IEnumerable<T>> ListAsync();
        Task AddAsync(T entity);
        Task<T> FindByIdAsync(int id);
        void Update(T entity);
        void Remove(T entity);
    }
}

