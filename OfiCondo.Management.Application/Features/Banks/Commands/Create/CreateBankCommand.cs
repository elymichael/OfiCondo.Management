namespace OfiCondo.Management.Application.Features.Banks.Commands.Create
{
    using MediatR;
    using System;
    public class CreateBankCommand : IRequest<Guid>
    {
        public string Name { get; set; }        
        public string AccountNumber { get; set; }        
        public string Description { get; set; }        
        public Guid? AccountId { get; set; }

        public override string ToString()
        {
            return $"Bank Name: {Name}; Account Number: {AccountNumber}";
        }

    }
}
