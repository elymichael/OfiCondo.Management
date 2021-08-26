namespace Oficondo.Management.Web.App.Model.Expense
{
    using System;
    public class Expense
    {
    }
    public partial class CreateExpenseCommand
    {
        public DateTimeOffset RecordDate { get; set; }
        public double Amount { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? PayeeId { get; set; }
        public int? PaymentMethodId { get; set; }
        public string Description { get; set; }
        public Guid? AttachmentId { get; set; }
        public Guid? CondominiumId { get; set; }
    }

    public partial class UpdateExpenseCommand
    {
        public Guid ExpenseId { get; set; }
        public DateTimeOffset RecordDate { get; set; }
        public double Amount { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? PayeeId { get; set; }
        public int? PaymentMethodId { get; set; }
        public string Description { get; set; }
        public Guid? AttachmentId { get; set; }
        public Guid? CondominiumId { get; set; }
    }
    public partial class ExpenseDetailVm
    {
        public Guid ExpenseId { get; set; }
        public DateTimeOffset RecordDate { get; set; }
        public double Amount { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? PayeeId { get; set; }
        public int? PaymentMethodId { get; set; }
        public string Description { get; set; }
        public Guid? AttachmentId { get; set; }
        public Guid? CondominiumId { get; set; }
    }
    public partial class ExpenseListVm
    {
        public Guid ExpenseId { get; set; }
        public DateTimeOffset RecordDate { get; set; }
        public double Amount { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? PayeeId { get; set; }
        public int? PaymentMethodId { get; set; }
        public string Description { get; set; }
        public Guid? AttachmentId { get; set; }
        public Guid? CondominiumId { get; set; }


    }
}
