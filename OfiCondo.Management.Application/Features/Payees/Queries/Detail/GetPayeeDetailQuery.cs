namespace OfiCondo.Management.Application.Features.Payees.Queries.Detail
{
    using MediatR;
    using System;

    public class GetPayeeDetailQuery : IRequest<PayeeDetailVm>
    {
        public Guid PayeeId { get; set; }
    }
}
