using System.Collections.Generic;
using System.Threading.Tasks;
using LocacaoVeiculosApi.Domain.Entities;
using LocacaoVeiculosApi.Domain.Entities.Enums;
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
        Task<ICollection<T>> RetornaTodosUsuarioPorTipo<T1>(TipoUsuario cliente);
        Task<T> Login(ClienteLogin userLogin, Token token);
        Task<T> Login(OperadorLogin userLogin, Token token);
        Task<ICollection<Usuario>> ListAsync();
    }
}