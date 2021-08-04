namespace OfiCondo.Management.Application.Features.Fees.Queries.Detail
{
    using System;
    public class FeeDetailVm
    {
        public Guid FeeId { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }
        public Guid? CondominiumId { get; set; }
    }
}
