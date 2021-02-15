using System;

namespace LocacaoVeiculosApi.Domain.Exceptions
{
    [Serializable]
    public class UsuarioUnico : Exception
    {
        public UsuarioUnico(string message) : base(message) { }
    
    }
}