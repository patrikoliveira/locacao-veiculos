using System.Threading.Tasks;
using LocacaoVeiculosApi.Infra.Authentication;
using LocacaoVeiculosApi.Presentation.ViewModel;

namespace LocacaoVeiculosApi.Domain.Services
{
    public interface IUsuarioService<T> where T : class
    {
        Task<T> LogarCliente(ClienteLogin userLogin, Token token);
        Task<T> LogarOperador(OperadorLogin userLogin, Token token);
        Task<T> Logar(UsuarioLogin userLogin, Token token);
    }
}