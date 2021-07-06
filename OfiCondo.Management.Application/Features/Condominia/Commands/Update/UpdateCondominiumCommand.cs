namespace OfiCondo.Management.Application.Features.Condominia.Commands.Update
{
    using MediatR;
    using System;
    public class UpdateCondominiumCommand: IRequest
    {
        public Guid CondominiumId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Quantity { get; set; }
        public Guid? AccountId { get; set; }
    }
}
