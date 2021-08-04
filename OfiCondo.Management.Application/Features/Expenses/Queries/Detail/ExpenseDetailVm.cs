namespace OfiCondo.Management.Application.Features.Expenses.Queries.Detail
{
    using System;
    public class ExpenseDetailVm
    {
        public Guid ExpenseId { get; set; }
        public DateTime RecordDate { get; set; }
        public double Amount { get; set; }
        public Guid? CategoryId { get; set; }
        //public Category Category { get; set; }
        public Guid? PayeeId { get; set; }
        //public Payee Payee { get; set; }
        public int? PaymentMethodId { get; set; }
        //public PaymentMethod PaymentMethod { get; set; }
        public string Description { get; set; }
        public Guid? AttachmentId { get; set; }
        //public Attachment Attachment { get; set; }
        public Guid? CondominiumId { get; set; }
    }
}
