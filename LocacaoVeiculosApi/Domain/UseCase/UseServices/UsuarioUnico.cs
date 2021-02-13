using System;

namespace LocacaoVeiculosApi.Domain.UseCase.UseServices
{
    [Serializable]
    public class UsuarioUnico : Exception
    {
        public UsuarioUnico(string message) : base(message) { }
    
    }
}