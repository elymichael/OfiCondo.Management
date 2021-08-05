namespace OfiCondo.Management.Application.Features.Accounts.Commands.Update
{
    using MediatR;
    using System;

    public class UpdateAccountCommand: IRequest
    {
        public Guid AccountId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
