using System.Collections.Generic;
using System.Threading.Tasks;
using LocacaoVeiculosApi.Domain.Entities;

namespace LocacaoVeiculosApi.Domain.Services
{
    public interface IVeiculoService<T> where T : class
    {
        Task<IEnumerable<IEntity>> ListAsync();
    }
}