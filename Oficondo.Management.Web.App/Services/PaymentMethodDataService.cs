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

            var allItems = await _client.GetAllPaymentMethodsAsync();
            var mappedItems = _mapper.Map<ICollection<PaymentMethodViewModel>>(allItems);
            return mappedItems.ToList();
        }

        public async Task<PaymentMethodViewModel> GetPaymentMethodById(int id)
        {
            await AddBearerToken();

            var item = await _client.GetPaymentMethodByIdAsync(id);
            var mappedItem = _mapper.Map<PaymentMethodViewModel>(item);
            return mappedItem;
        }
    }
}
