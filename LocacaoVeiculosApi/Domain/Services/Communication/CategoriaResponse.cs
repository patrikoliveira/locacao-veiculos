using LocacaoVeiculosApi.Domain.Entities;

namespace LocacaoVeiculosApi.Domain.Services.Communication
{
    public class CategoriaResponse : BaseResponse
    {
        private CategoriaResponse(bool success, string message, Categoria categoria) : base(success, message)
        {
            Categoria = categoria;
        }

        public Categoria Categoria { get; set; }
        
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="categoria">Categoria criada.</param>
        /// <returns>Response.</returns>
        public CategoriaResponse(Categoria categoria) : this(true, string.Empty, categoria)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public CategoriaResponse(string message) : this(false, message, null)
        { }
        
    }
}