using locacao_veiculos_api.Domain.Entities;

namespace locacao_veiculos_api.Domain.Authentication
{
    public interface IToken
    {
        string GerarToken(Usuario user);
    }
}