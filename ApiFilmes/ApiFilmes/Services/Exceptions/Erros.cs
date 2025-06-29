using System;

namespace ApiFilmes.Services.Exceptions
{
    public class Erros : Exception
    {

        public Erros() { }

        public Erros(string message) : base(message) { }

        public Erros(string message, Exception inner) : base(message, inner) { }
    }

    // Not found (404)
    public class NotFoundException : Erros
    {
        public NotFoundException(string message) : base(message) { }
    }

    // Bad request (400)
    public class BadRequestException : Erros
    {
        public BadRequestException(string message) : base(message) { }
    }

    // Validation error (400)
    public class ValidationException : Erros
    {
        public ValidationException(string message) : base(message) { }
    }
}