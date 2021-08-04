namespace OfiCondo.Management.Application.Features.Incomes.Queries.Detail
{
    using System;
    public class IncomeDetailVm
    {
        public Guid IncomeId { get; set; }
        public DateTime RecordDate { get; set; }
        public double Amount { get; set; }
        public Guid FeeId { get; set; }
        //public Fee Fee { get; set; }
        public Guid? UnitId { get; set; }
        //public Unit Unit { get; set; }
        public string Description { get; set; }
        public Guid? AttachmentId { get; set; }
        //public Attachment Attachment { get; set; }
        public Guid? CondominiumId { get; set; }
    }
}
