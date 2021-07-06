namespace OfiCondo.Management.Application.Features.Minutes.Commands.Delete
{
    using MediatR;
    using System;
    public class DeleteMinuteCommand: IRequest
    {
        public Guid MinuteId { get; set; }
    }
}
