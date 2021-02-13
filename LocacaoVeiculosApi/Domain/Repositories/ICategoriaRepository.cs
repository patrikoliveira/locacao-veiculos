using System.Collections.Generic;
using System.Threading.Tasks;
using LocacaoVeiculosApi.Domain.Entities;

namespace LocacaoVeiculosApi.Domain.Repositories
{
    public interface ICategoriaRepository<T> where T : class
    {
        Task<IEnumerable<IEntity>> ListAsync();
        Task AddAsync(Categoria entity);
        Task<Categoria> FindByIdAsync(int id);
        void Update(Categoria entity);

        void Remove(Categoria entity);
    }
}

