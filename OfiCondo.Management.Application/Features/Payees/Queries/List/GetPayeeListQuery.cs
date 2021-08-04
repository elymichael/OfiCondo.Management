namespace OfiCondo.Management.Application.Features.Payees.Queries.List
{
    using MediatR;
    using System.Collections.Generic;
    public class GetPayeeListQuery : IRequest<List<PayeeListVm>>
    {
    }
}
