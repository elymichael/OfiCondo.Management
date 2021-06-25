namespace OfiCondo.Management.Application.Features.Banks.Commands.Update
{
    using MediatR;
    using System;
    public class UpdateBankCommand: IRequest
    {
        public Guid BankId { get; set; }
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public string Description { get; set; }
        public Guid? AccountId { get; set; }
    }
}
