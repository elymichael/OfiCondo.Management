namespace OfiCondo.Management.Application.Features.Payees.Commands.Create
{
    using MediatR;
    using System;
    public class CreatePayeeCommand: IRequest<Guid>
    {
        public string AccountNumber { get; set; }
        public Guid AccountId { get; set; }
    }
}
