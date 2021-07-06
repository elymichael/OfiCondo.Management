namespace OfiCondo.Management.Application.Features.Minutes.Queries.Detail
{
    using MediatR;
    using System;

    public class GetMinuteDetailQuery : IRequest<MinuteDetailVm>
    {
        public Guid MinuteId { get; set; }
    }
}
