using System.Threading.Tasks;
using LocacaoVeiculosApi.Domain.Entities;

namespace LocacaoVeiculosApi.Domain.UseCase.UseServices
{
    public interface IOperadorRepository
    {
        Task Update(Usuario Usuario);
        Task Save(Usuario Usuario);
        Task Delete(Usuario Usuario);
        Task<Usuario> FindById(int id);
    }
}