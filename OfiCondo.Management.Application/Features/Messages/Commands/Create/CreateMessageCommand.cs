namespace OfiCondo.Management.Application.Features.Messages.Commands.Create
{
    using MediatR;
    using System;
    public class CreateMessageCommand: IRequest<Guid>
    {
        public string Description { get; set; }
        public DateTime RecordDate { get; set; }
        public Guid? CondominiumId { get; set; }
    }
}
