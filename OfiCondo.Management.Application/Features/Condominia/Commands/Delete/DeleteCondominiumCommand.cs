namespace OfiCondo.Management.Application.Features.Condominia.Commands.Delete
{
    using MediatR;
    using System;
    public class DeleteCondominiumCommand: IRequest
    {
        public Guid CondominiumId { get; set; }
    }
}
