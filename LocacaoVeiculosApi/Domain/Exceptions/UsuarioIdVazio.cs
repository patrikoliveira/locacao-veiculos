using System;

namespace LocacaoVeiculosApi.Domain.Exceptions
{
     [Serializable]
    public class UsuarioIdVazio : Exception
    {
        public UsuarioIdVazio(string message) : base(message) { }
    }
}