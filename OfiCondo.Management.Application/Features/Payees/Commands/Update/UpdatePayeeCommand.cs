namespace OfiCondo.Management.Application.Features.Payees.Commands.Update
{
    using MediatR;
    using System;
    public class UpdatePayeeCommand: IRequest
    {
        public Guid PayeeId { get; set; }
        public string AccountNumber { get; set; }
        public Guid AccountId { get; set; }
    }
}
