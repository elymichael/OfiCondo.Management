namespace Oficondo.Management.Web.App.Model.Fee
{
    using System;
    public class Fee
    {
    }
    public partial class CreateFeeCommand
    {
        public string Name { get; set; }
        public double Amount { get; set; }
        public DateTimeOffset DateBegin { get; set; }
        public DateTimeOffset? DateEnd { get; set; }
        public Guid? CondominiumId { get; set; }
    }
    public partial class UpdateFeeCommand
    {
        public Guid FeeId { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public DateTimeOffset DateBegin { get; set; }
        public DateTimeOffset? DateEnd { get; set; }
        public Guid? CondominiumId { get; set; }
    }
    public partial class FeeDetailVm
    {
        public Guid FeeId { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public DateTimeOffset DateBegin { get; set; }
        public DateTimeOffset? DateEnd { get; set; }
        public Guid? CondominiumId { get; set; }
    }
    public partial class FeeListVm
    {
        public Guid FeeId { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public DateTimeOffset DateBegin { get; set; }
        public DateTimeOffset? DateEnd { get; set; }
        public Guid? CondominiumId { get; set; }
    }
}
