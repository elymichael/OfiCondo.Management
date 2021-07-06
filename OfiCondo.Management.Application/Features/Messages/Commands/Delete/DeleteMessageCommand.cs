namespace OfiCondo.Management.Application.Features.Messages.Commands.Delete
{
    using MediatR;
    using System;
    public class DeleteMessageCommand: IRequest
    {
        public Guid MessageId { get; set; }
    }
}
