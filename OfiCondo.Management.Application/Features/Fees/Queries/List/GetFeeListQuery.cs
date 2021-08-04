namespace OfiCondo.Management.Application.Features.Fees.Queries.List
{
    using MediatR;
    using System.Collections.Generic;
    public class GetFeeListQuery : IRequest<List<FeeListVm>>
    {
    }
}
