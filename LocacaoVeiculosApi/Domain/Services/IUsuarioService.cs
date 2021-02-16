using System.Threading.Tasks;
using LocacaoVeiculosApi.Domain.Entities;
using LocacaoVeiculosApi.Infra.Authentication;
using LocacaoVeiculosApi.Presentation.ViewModel;

namespace LocacaoVeiculosApi.Domain.Services
{
    public interface IUsuarioService<T> where T : class
    {
        Task<UsuarioJwt> Login(Usuario user, Token token);
        Task<Usuario> RetornaTodosUsuarios();
        Task Save(Usuario user);
        Task Delete(int id);
        Task Update(Usuario user);
    }
}