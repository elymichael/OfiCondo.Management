namespace OfiCondo.Management.Api.Utility
{
    using System;
    public class FileResultContentTypeAttribute : Attribute
    {
        public FileResultContentTypeAttribute(string contentType)
        {
            ContentType = contentType;
        }
        public string ContentType { get; }
    }
}
