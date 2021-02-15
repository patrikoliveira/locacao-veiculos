using LocacaoVeiculosApi.Domain.Entities.Enums;

namespace LocacaoVeiculosApi.Presentation.ViewModel
{
    public record UsuarioCompleto
    {
        public string Id {get;set;}
         public string CpfMatricula {get;set;}
        public string Senha {get;set;}
        public string Nome {get;set;}
        public Endereco Endereco {get;set;}
        public TipoUsuario TipoUsuario {get;set;}
    }
}