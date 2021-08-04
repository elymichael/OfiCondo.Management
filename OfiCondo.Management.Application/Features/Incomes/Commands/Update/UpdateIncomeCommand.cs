namespace OfiCondo.Management.Application.Features.Incomes.Commands.Update
{
    using MediatR;
    using System;
    public class UpdateIncomeCommand: IRequest
    {
        public Guid IncomeId { get; set; }
        public DateTime RecordDate { get; set; }
        public double Amount { get; set; }
        public Guid FeeId { get; set; }
        public Guid? UnitId { get; set; }
        public string Description { get; set; }
        public Guid? AttachmentId { get; set; }
        public Guid? CondominiumId { get; set; }
    }
}
