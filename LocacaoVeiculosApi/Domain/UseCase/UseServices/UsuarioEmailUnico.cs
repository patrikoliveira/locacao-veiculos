using System;

namespace LocacaoVeiculosApi.Domain.UseCase.UseServices
{
    [Serializable]
    public class UsuarioEmailUnico : Exception
    {
        public UsuarioEmailUnico(string message) : base(message) { }
    
    }
}