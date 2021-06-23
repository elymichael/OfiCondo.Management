namespace OfiCondo.Management.Application.Exceptions
{
    using System;
    public class BadRequestException : ApplicationException
    {
        public BadRequestException(string message) : base(message)
        {

        }
    }
}
