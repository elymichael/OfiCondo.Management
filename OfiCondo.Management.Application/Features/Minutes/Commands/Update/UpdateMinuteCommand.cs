namespace OfiCondo.Management.Application.Features.Minutes.Commands.Update
{
    using MediatR;
    using System;
    public class UpdateMinuteCommand: IRequest
    {
        public Guid MinuteId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime RecordDate { get; set; }
        public Guid? CondominiumId { get; set; }
    }
}
