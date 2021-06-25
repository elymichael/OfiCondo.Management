namespace OfiCondo.Management.Application.Features.Banks.Queries.Detail
{    
    using System;

    public class  BankDetailVm
    {
        public Guid BankId { get; set; }
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public string Description { get; set; }
    }
}
