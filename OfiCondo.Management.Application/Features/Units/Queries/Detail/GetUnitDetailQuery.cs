namespace OfiCondo.Management.Application.Features.Units.Queries.Detail
{
    using MediatR;
    using System;
    public class GetUnitDetailQuery : IRequest<UnitDetailVm>
    {
        public Guid UnitId { get; set; }
    }
}
