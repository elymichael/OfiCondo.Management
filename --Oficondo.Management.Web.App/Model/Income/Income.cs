namespace Oficondo.Management.Web.App.Model.Income
{
    using System;
    public class Income
    {
    }
    public partial class CreateIncomeCommand
    {
        public DateTimeOffset RecordDate { get; set; }
        public double Amount { get; set; }
        public Guid FeeId { get; set; }
        public Guid? UnitId { get; set; }
        public string Description { get; set; }
        public Guid? AttachmentId { get; set; }
        public Guid? CondominiumId { get; set; }
    }
    public partial class UpdateIncomeCommand
    {
        public Guid IncomeId { get; set; }
        public DateTimeOffset RecordDate { get; set; }
        public double Amount { get; set; }
        public Guid FeeId { get; set; }
        public Guid? UnitId { get; set; }
        public string Description { get; set; }
        public Guid? AttachmentId { get; set; }
        public Guid? CondominiumId { get; set; }
    }
    public partial class IncomeDetailVm
    {
        public Guid IncomeId { get; set; }
        public DateTimeOffset RecordDate { get; set; }
        public double Amount { get; set; }
        public Guid FeeId { get; set; }
        public Guid? UnitId { get; set; }
        public string Description { get; set; }
        public Guid? AttachmentId { get; set; }
        public Guid? CondominiumId { get; set; }
    }
    public partial class IncomeListVm
    {
        public Guid IncomeId { get; set; }
        public DateTimeOffset RecordDate { get; set; }
        public double Amount { get; set; }
        public Guid FeeId { get; set; }
        public Guid? UnitId { get; set; }
        public string Description { get; set; }
        public Guid? AttachmentId { get; set; }
        public Guid? CondominiumId { get; set; }
    }
}
