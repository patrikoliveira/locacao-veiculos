using System;

namespace locacao_veiculos_api.Domain.UseCase.UseServices
{
    public class UserNotFound : Exception
    {
        public UserNotFound(string message) : base(message) { }
    }
}