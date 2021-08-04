namespace OfiCondo.Management.Application.Features.Payees.Commands.Delete
{
    using MediatR;
    using System;

    public class DeletePayeeCommand: IRequest
    {
        public Guid PayeeId { get; set; }
    }
}
