using LocacaoVeiculosApi.Domain.Entities;

namespace LocacaoVeiculosApi.Domain.Services.Communication
{
    public class UsuarioResponse : BaseResponse
    {
        public UsuarioResponse(bool success, string message, Usuario usuario) : base(success, message)
        {
            Usuario = usuario;
        }
        public Usuario Usuario {get;set;}

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="usuario">Usuario criado.</param>
        /// <returns>Response.</returns>
        public UsuarioResponse(Usuario usuario) : this(true, string.Empty, usuario)
        { }
        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public UsuarioResponse(string message) : this(false, message, null)
        { }

    }
}