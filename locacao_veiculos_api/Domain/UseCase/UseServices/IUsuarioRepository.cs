using System.Threading.Tasks;
using locacao_veiculos_api.Domain.Entities;

namespace locacao_veiculos_api.Domain.UseCase.UseServices
{
    public interface IUsuarioRepository
    {
        Task<Usuario> FindByLoginAndPassword(string login, string password);
    }
}