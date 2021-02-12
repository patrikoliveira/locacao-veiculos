using System;

namespace LocacaoVeiculosApi.Domain.UseCase.UseServices
{
    [Serializable]
    public class UsuarioNotFound : Exception
    {
        public UsuarioNotFound(string message) : base(message) { }
    }
}