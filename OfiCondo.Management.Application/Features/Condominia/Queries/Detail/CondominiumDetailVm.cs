namespace OfiCondo.Management.Application.Features.Condominia.Queries.Detail
{
    using System;
    public class CondominiumDetailVm
    {
        public Guid CondominiumId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Quantity { get; set; }
    }
}
