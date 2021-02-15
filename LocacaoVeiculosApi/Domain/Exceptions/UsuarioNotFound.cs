using System;

namespace LocacaoVeiculosApi.Domain.Exceptions
{
    [Serializable]
    public class UsuarioNotFound : Exception
    {
        public UsuarioNotFound(string message) : base(message) { }
    }
}