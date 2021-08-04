namespace OfiCondo.Management.Application.Features.Expenses.Commands.Create
{
    using MediatR;
    using System;
    public class CreateExpenseCommand: IRequest<Guid>
    {        
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
