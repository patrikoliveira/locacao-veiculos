using System.Threading.Tasks;
using LocacaoVeiculosApi.Domain.Entities;

namespace LocacaoVeiculosApi.Domain.UseCase.UseServices
{
    public interface IUsuarioRepository
    {
        Task Update(User user);
        Task Save(User user);
        Task Delete(User user);
        Task<ICollection<UserView>> All();
        Task<User> FindById(int id);
        Task<Usuario> FindByLoginAndPassword(string login, string password);
    }
}