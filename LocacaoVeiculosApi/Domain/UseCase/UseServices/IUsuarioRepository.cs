using System.Threading.Tasks;
using LocacaoVeiculosApi.Domain.Entities;

namespace LocacaoVeiculosApi.Domain.UseCase.UseServices
{
    public interface IUsuarioRepository
    {
        Task<Usuario> FindByLoginAndPassword(string login, string password);
    }
}