using LocacaoVeiculosApi.Domain.Entities.Enums;

namespace LocacaoVeiculosApi.Domain.Entities
{
    public interface IUsuario
    {
        int Id {get;set;}
        string Nome {get;set;}
        string Senha {get;set;}
        string CpfMatricula {get;set;}
        int TipoUsuario {get;set;}
        TipoUsuario Tipo {get;}
        
    }
}