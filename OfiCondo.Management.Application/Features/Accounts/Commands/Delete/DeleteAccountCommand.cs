namespace OfiCondo.Management.Application.Features.Accounts.Commands.Delete
{
    using MediatR;
    using System;
    public class DeleteAccountCommand : IRequest
    {
        public Guid AccountId { get; set; }
    }
}
