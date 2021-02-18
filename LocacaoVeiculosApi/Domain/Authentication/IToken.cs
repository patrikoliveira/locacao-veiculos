using LocacaoVeiculosApi.Domain.Entities;

namespace LocacaoVeiculosApi.Domain.Authentication
{
    public interface IToken
    {
        string GerarToken(Usuario user);
        string GerarToken(IUsuario usuarioLogado);
    }
}