using System;

namespace LocacaoVeiculosApi.Domain.UseCase.UseServices
{
    [Serializable]
    public class UserNotFound : Exception
    {
        public UserNotFound(string message) : base(message) { }
    }
}