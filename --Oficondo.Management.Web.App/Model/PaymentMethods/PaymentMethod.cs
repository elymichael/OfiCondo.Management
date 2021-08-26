namespace Oficondo.Management.Web.App.Model.PaymentMethods
{
    public class PaymentMethod
    {
        public int PaymentMethodId { get; set; }
        public string Name { get; set; }
    }
    public partial class PaymentMethodDetailVm
    {
        public int PaymentMethodId { get; set; }
        public string Name { get; set; }
    }
    public partial class PaymentMethodListVm
    {
        public int PaymentMethodId { get; set; }
        public string Name { get; set; }
    }
}
