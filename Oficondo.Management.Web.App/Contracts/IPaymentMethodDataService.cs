namespace Oficondo.Management.Web.App.Contracts
{
    using Oficondo.Management.Web.App.ViewModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IPaymentMethodDataService
    {
        Task<List<PaymentMethodViewModel>> GetAllPaymentMethods();
        Task<PaymentMethodViewModel> GetPaymentMethodById(int id);
    }
}

