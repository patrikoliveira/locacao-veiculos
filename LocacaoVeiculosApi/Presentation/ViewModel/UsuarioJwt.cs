using LocacaoVeiculosApi.Domain.Entities;

namespace LocacaoVeiculosApi.Presentation.ViewModel
{
    public class UsuarioJwt : IEntity
    {
        public int id { get; set; }
        public string CpfMatricula { get; set; }
        public string Nome {get;set;}
        public string TipoUsuario { get; set; }
        public string Token { get; set; }
    }
}