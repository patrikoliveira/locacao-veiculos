using System.Threading.Tasks;
using locacao_veiculos_api.Domain.Entities;

namespace locacao_veiculos_api.Domain.UseCase.UseServices
{
    public interface IUserRepository
    {
        Task<User> FindByLoginAndPassword(string login, string password);
    }
}