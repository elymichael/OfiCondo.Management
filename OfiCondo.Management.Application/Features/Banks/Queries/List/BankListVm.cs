namespace OfiCondo.Management.Application.Features.Banks.Queries.List
{
    using System;
    public class BankListVm
    {
        public Guid BankId { get; set; }
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public string Description { get; set; }
    }
}
