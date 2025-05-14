using System;
namespace ApiCliente.Services.Exceptions

{
    public class BadRequestExceptions : Exception
    {
        public BadRequestExceptions(string message):
            base(message)
        {

        }
    }
}
