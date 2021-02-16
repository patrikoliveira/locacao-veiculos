using LocacaoVeiculosApi.Domain.Entities;

namespace LocacaoVeiculosApi.Domain.Services.Communication
{
    public class UsuarioResponse : BaseResponse
    {
        public UsuarioResponse(bool success, string message, Usuario usuario) : base(success, message)
        {
            Usuario = usuario;
        }
        public Usuario usuario {get;set;}
        public Usuario Usuario { get; }

        public UsuarioResponse(Usuario usuario) : this(true, string.Empty, usuario)
        { }
        public UsuarioResponse(string message) : this(false, message, null)
        { }
    }
}