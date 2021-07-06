namespace OfiCondo.Management.Application.Features.Units.Queries.Detail
{
    using System;
    public class UnitDetailVm
    {
        public Guid UnitId { get; set; }
        public string Name { get; set; }
        public Guid? OwnerId { get; set; }
        public Guid CondominiumId { get; set; }
    }
}
