namespace OfiCondo.Management.Application.Exceptions
{
    using System;
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, object key) : base($"{name} ({key}) is not found")
        {

        }
    }
}
