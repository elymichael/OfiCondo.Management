namespace OfiCondo.Management.Application.Features.Units.Queries.List
{
    using System;
    public class UnitListVm
    {
        public Guid UnitId { get; set; }
        public string Name { get; set; }
        public Guid? OwnerId { get; set; }
        public Guid CondominiumId { get; set; }
    }
}
