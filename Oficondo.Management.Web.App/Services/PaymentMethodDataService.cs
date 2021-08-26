namespace Oficondo.Management.Web.App.Services
{
    using AutoMapper;
    using Blazored.LocalStorage;
    using Oficondo.Management.Web.App.Contracts;
    using Oficondo.Management.Web.App.Services.Base;
    using Oficondo.Management.Web.App.ViewModels;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PaymentMethodDataService : BaseDataService, IPaymentMethodDataService
    {
        private readonly IMapper _mapper;
        public PaymentMethodDataService(IClient client, IMapper mapper, ILocalStorageService localStorage): base(client, localStorage)
        {
            _mapper = mapper;
        }
        public async Task<List<PaymentMethodViewModel>> GetAllPaymentMethods()
        {
            await AddBearerToken();

            var allPaymentMethods = await _client.GetAllPaymentMethodsAsync();
            var mappedPaymentMethods = _mapper.Map<ICollection<PaymentMethodViewModel>>(allPaymentMethods);
            return mappedPaymentMethods.ToList();
        }

        public async Task<PaymentMethodViewModel> GetPaymentMethodById(int id)
        {
            await AddBearerToken();

            var allPaymentMethods = await _client.GetPaymentMethodByIdAsync(id);
            var mappedPaymentMethods = _mapper.Map<PaymentMethodViewModel>(allPaymentMethods);
            return mappedPaymentMethods;
        }
    }
}
