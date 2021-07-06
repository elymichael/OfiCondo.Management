namespace OfiCondo.Management.Application.Features.Minutes.Commands.Create
{
    using MediatR;
    using System;
    public class CreateMinuteCommand: IRequest<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime RecordDate { get; set; }
        public Guid? CondominiumId { get; set; }
    }
}
