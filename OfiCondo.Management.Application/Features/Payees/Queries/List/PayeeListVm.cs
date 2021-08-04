namespace OfiCondo.Management.Application.Features.Payees.Queries.List
{
    using System;
    public class PayeeListVm
    {
        public Guid PayeeId { get; set; }        
        public string AccountNumber { get; set; }
        public Guid AccountId { get; set; }
    }
}
