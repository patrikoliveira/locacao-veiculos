using System;

namespace LocacaoVeiculosApi.Domain.Entities.Exceptions
{
    [Serializable]
    public class UsuarioNotFound : Exception
    {
        public UsuarioNotFound(string message) : base(message) { }
    }
}