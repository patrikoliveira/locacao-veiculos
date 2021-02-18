using System;

namespace LocacaoVeiculosApi.Domain.Entities.Exceptions
{
    [Serializable]
    public class CpfInvalidoException : Exception
    {
        public CpfInvalidoException(string message) : base(message) { }
    }
}