using System.Collections.Generic;
using System.Threading.Tasks;
using LocacaoVeiculosApi.Domain.Entities;
using LocacaoVeiculosApi.Domain.Services.Communication;

namespace LocacaoVeiculosApi.Domain.Services
{
    public interface IEntityService<T> where T : class
    {
        Task<IEnumerable<T>> ListAsync();
        Task<EntityResponse> GetAsync(int id);
        Task<EntityResponse> CreateAsync(T entity);
        Task<EntityResponse> UpdateAsync(int id, T entity);
        Task<EntityResponse> DeleteAsync(int id);
    }
}