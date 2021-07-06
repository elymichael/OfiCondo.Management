namespace OfiCondo.Management.Application.Features.Units.Commands.Create
{
    using MediatR;
    using System;
    public class CreateUnitCommand: IRequest<Guid>
    {
        public string Name { get; set; }     
        public Guid CondominiumId { get; set; }
    }
}
