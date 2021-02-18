using System;

namespace LocacaoVeiculosApi.Domain.Entities.Exceptions
{
     [Serializable]
    public class UsuarioIdVazio : Exception
    {
        public UsuarioIdVazio(string message) : base(message) { }
    }
}