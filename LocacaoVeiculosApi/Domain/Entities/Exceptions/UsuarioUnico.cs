using System;

namespace LocacaoVeiculosApi.Domain.Entities.Exceptions
{
    [Serializable]
    public class UsuarioUnico : Exception
    {
        public UsuarioUnico(string message) : base(message) { }
    
    }
}