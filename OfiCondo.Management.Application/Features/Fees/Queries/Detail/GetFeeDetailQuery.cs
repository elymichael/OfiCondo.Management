namespace OfiCondo.Management.Application.Features.Fees.Queries.Detail
{
    using MediatR;
    using System;
    public class GetFeeDetailQuery : IRequest<FeeDetailVm>
    {
        public Guid FeeId { get; set; }
    }
}
