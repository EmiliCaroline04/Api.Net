using System;

namespace ApiCliente.Services.Validations
{
    [Serializable]
    internal class BadResquestException : Exception
    {
        public BadResquestException()
        {
        }

        public BadResquestException(string message) : base(message)
        {
        }

        public BadResquestException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}