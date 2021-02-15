using System;

namespace LocacaoVeiculosApi.Domain.Exceptions
{
    [Serializable]
    public class CpfInvalidoException : Exception
    {
        public CpfInvalidoException(string message) : base(message) { }
    }
}