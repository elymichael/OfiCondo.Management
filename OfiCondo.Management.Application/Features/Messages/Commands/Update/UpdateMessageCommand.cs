namespace OfiCondo.Management.Application.Features.Messages.Commands.Update
{
    using MediatR;
    using System;
    public class UpdateMessageCommand: IRequest
    {
        public Guid MessageId { get; set; }
        public string Description { get; set; }
        public DateTime RecordDate { get; set; }
        public Guid? CondominiumId { get; set; }
    }
}
