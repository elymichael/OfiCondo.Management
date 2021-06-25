namespace OfiCondo.Management.Application.Features.Banks.Queries.List
{
    using MediatR;
    using System.Collections.Generic;

    public class GetBankListQuery: IRequest<List<BankListVm>>
    {
    }
}
