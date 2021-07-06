namespace OfiCondo.Management.Application.Features.Units.Commands.Delete
{
    using MediatR;
    using System;
    public class DeleteUnitCommand: IRequest
    {
        public Guid UnitId { get; set; }
    }
}
