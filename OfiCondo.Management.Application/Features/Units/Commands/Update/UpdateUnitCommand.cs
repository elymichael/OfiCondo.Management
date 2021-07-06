namespace OfiCondo.Management.Application.Features.Units.Commands.Update
{
    using MediatR;
    using System;
    public class UpdateUnitCommand: IRequest
    {
        public Guid UnitId { get; set; }        
        public string Name { get; set; }        
        public Guid? OwnerId { get; set; }        
        public Guid CondominiumId { get; set; }
    }
}
