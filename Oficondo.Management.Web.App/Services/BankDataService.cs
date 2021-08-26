using AutoMapper;
using Blazored.LocalStorage;
using Oficondo.Management.Web.App.Contracts;
using Oficondo.Management.Web.App.ViewModels;
using Oficondo.Management.Web.App.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oficondo.Management.Web.App.Model.Base;
using Oficondo.Management.Web.App.Model.Bank;

namespace Oficondo.Management.Web.App.Services
{
    public class BankDataService : BaseDataService, IBankDataService
    {
        private readonly IMapper _mapper;
        public BankDataService(IClient client, IMapper mapper, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<List<BankViewModel>> GetAllBanks()
        {
            AddBearerToken();

            var allItems = await _client.GetAllPaymentMethodsAsync();
            var mappedItems = _mapper.Map<ICollection<BankViewModel>>(allItems);
            return mappedItems.ToList();
        }
        public async Task<BankViewModel> GetBankById(int id)
        {
            await AddBearerToken();

            var item = await _client.GetPaymentMethodByIdAsync(id);
            var mappedItem = _mapper.Map<BankViewModel>(item);
            return mappedItem;
        }

        public async Task<ApiResponse<GuidActionResult>> CreateBank(BankViewModel item)
        {
            try
            {
                CreateBankCommand itemCommand = _mapper.Map<CreateBankCommand>(item);
                var newId = await _client.AddBankAsync(itemCommand);
                return new ApiResponse<GuidActionResult>() { Data = newId, Success = true };
            }
            catch(ApiException ex)
            {
                return ConvertApiExceptions<GuidActionResult>(ex);
            }
        }

        public async Task<ApiResponse<GuidActionResult>> UpdateBank(BankViewModel item)
        {
            try
            {
                UpdateBankCommand itemCommand = _mapper.Map<UpdateBankCommand>(item);
                await _client.UpdateBankAsync(itemCommand);
                return new ApiResponse<GuidActionResult>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<GuidActionResult>(ex);
            }
        }

        public async Task<ApiResponse<GuidActionResult>> DeleteBank(Guid id)
        {
            try
            {                
                await _client.DeleteBankAsync(id);
                return new ApiResponse<GuidActionResult>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<GuidActionResult>(ex);
            }
        }
    }
}
