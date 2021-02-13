using System;

namespace LocacaoVeiculosApi.Domain.UseCase.UseServices
{
    [Serializable]
    public class CpfInvalidoException : Exception
    {
        public CpfInvalidoException(string message) : base(message) { }
    }
}