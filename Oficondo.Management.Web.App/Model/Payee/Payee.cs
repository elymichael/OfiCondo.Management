namespace Oficondo.Management.Web.App.Model.Payee
{
    using System;
    public class Payee
    {
    }
    public partial class CreatePayeeCommand
    {
        public string AccountNumber { get; set; }
        public Guid AccountId { get; set; }
    }

    public partial class UpdatePayeeCommand
    {
        public Guid PayeeId { get; set; }
        public string AccountNumber { get; set; }
        public Guid AccountId { get; set; }
    }
    public partial class PayeeDetailVm
    {
        public Guid PayeeId { get; set; }
        public string AccountNumber { get; set; }
        public Guid AccountId { get; set; }
    }
    public partial class PayeeListVm
    {
        public Guid PayeeId { get; set; }
        public string AccountNumber { get; set; }
        public Guid AccountId { get; set; }
    }
}
