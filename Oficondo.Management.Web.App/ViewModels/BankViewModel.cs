namespace Oficondo.Management.Web.App.ViewModels
{
    using System;
    public class BankViewModel
    {
        public Guid BankId { get; set; }
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public string Description { get; set; }
        public Guid? AccountId { get; set; }
    }
}
