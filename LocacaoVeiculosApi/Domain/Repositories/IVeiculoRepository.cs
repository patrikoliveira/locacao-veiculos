using System.Collections.Generic;
using System.Threading.Tasks;
using LocacaoVeiculosApi.Domain.Entities;

namespace LocacaoVeiculosApi.Domain.Repositories
{
    public interface IVeiculoRepository<T> where T : class
    {
        Task<IEnumerable<IEntity>> ListAsync();
    }
}