namespace OfiCondo.Management.Application.Features.Condominia.Commands.Create
{
    using MediatR;
    using System;
    public class CreateCondominiumCommand: IRequest<Guid>
    {        
        public string Name { get; set; }
        public string Address { get; set; }
        public int Quantity { get; set; }
        public Guid? AccountId { get; set; }
    }
}
