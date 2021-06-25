namespace OfiCondo.Management.Application.Features.Banks.Queries.Detail
{
    using MediatR;
    using System;

    public class GetBankDetailQuery : IRequest<BankDetailVm>
    {
        public Guid BankId { get; set; }
    }
}
