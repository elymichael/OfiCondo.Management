namespace OfiCondo.Management.Application.Features.Payees.Queries.Detail
{
    using System;
    public class PayeeDetailVm
    {
        public Guid PayeeId { get; set; }
        public string AccountNumber { get; set; }
        public Guid AccountId { get; set; }
    }
}
