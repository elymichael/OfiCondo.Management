namespace OfiCondo.Management.Application.Features.Fees.Commands.Create
{
    using MediatR;
    using System;
    public class CreateFeeCommand: IRequest<Guid>
    {        
        public string Name { get; set; }
        public double Amount { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }
        public Guid? CondominiumId { get; set; }
    }
}
