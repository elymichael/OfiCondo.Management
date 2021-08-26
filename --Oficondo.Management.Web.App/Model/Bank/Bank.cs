namespace Oficondo.Management.Web.App.Model.Bank
{
    using System;
    public class Bank
    {
        public Guid BankId { get; set; }
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public string Description { get; set; }
        public Guid? AccountId { get; set; }
    }
    public partial class CreateBankCommand
    {
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public string Description { get; set; }
        public Guid? AccountId { get; set; }
    }

    public partial class UpdateBankCommand
    {
        public Guid BankId { get; set; }
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public string Description { get; set; }
        public Guid? AccountId { get; set; }


    }
    public partial class BankDetailVm
    {
        public Guid BankId { get; set; }
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public string Description { get; set; }
    }
    public partial class BankListVm
    {
        public Guid BankId { get; set; }
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public string Description { get; set; }
    }
}
