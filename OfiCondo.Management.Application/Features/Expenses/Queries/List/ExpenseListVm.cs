using System;
using System.Collections.Generic;
using System.Text;

namespace OfiCondo.Management.Application.Features.Expenses.Queries.List
{
    public class ExpenseListVm
    {
        public Guid ExpenseId { get; set; }
        public DateTime RecordDate { get; set; }
        public double Amount { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? PayeeId { get; set; }
        public int? PaymentMethodId { get; set; }
        public string Description { get; set; }
        public Guid? AttachmentId { get; set; }
        public Guid? CondominiumId { get; set; }
    }
}
