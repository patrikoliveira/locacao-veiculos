using System;

namespace LocacaoVeiculosApi.Domain.UseCase.UseServices
{
     [Serializable]
    public class UsuarioIdVazio : Exception
    {
        public UsuarioIdVazio(string message) : base(message) { }
    }
}