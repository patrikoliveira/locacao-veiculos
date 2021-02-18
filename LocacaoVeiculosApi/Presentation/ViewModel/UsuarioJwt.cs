using LocacaoVeiculosApi.Domain.Entities;

namespace LocacaoVeiculosApi.Presentation.ViewModel
{
    public class UsuarioJwt : IEntity
    {
        public int id { get; set; }
        public string login { get; set; }
        public string nome {get;set;}
        public string tipoUsuario { get; set; }
        public string Token { get; set; }
    }
}