namespace OfiCondo.Management.Application.Features.Banks.Commands.Delete
{
    using MediatR;
    using System;

    public class DeleteBankCommand: IRequest
    {
        public Guid BankId { get; set; }
    }
}
