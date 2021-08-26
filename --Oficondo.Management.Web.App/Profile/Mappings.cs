namespace Oficondo.Management.Web.App.Profile
{
    using AutoMapper;
    using Oficondo.Management.Web.App.Model.Bank;
    using Oficondo.Management.Web.App.Model.PaymentMethods;
    using Oficondo.Management.Web.App.ViewModels;

    public class Mappings: Profile
    {
        public Mappings()
        {
            CreateMap<CreateBankCommand, BankViewModel>().ReverseMap();
            CreateMap<BankDetailVm, BankViewModel>().ReverseMap();
            CreateMap<BankListVm, BankViewModel>().ReverseMap();

            CreateMap<PaymentMethod, PaymentMethodViewModel>().ReverseMap();
            CreateMap<PaymentMethodDetailVm, PaymentMethodViewModel>().ReverseMap();
            CreateMap<PaymentMethodDetailVm, PaymentMethodViewModel>().ReverseMap();
        }
    }
}
