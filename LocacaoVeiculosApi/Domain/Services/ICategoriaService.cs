using System.Collections.Generic;
using System.Threading.Tasks;
using LocacaoVeiculosApi.Domain.Entities;
using LocacaoVeiculosApi.Domain.Services.Communication;

namespace LocacaoVeiculosApi.Domain.Services
{
    public interface ICategoriaService<T> where T : class
    {
        Task<IEnumerable<IEntity>> ListAsync();

        Task<CategoriaResponse> GetAsync(int id);
        Task<CategoriaResponse> CreateAsync(Categoria entity);
        Task<CategoriaResponse> UpdateAsync(int id, Categoria entity);
        Task<CategoriaResponse> DeleteAsync(int id);
    }
}