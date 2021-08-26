namespace Oficondo.Management.Web.App.Contracts
{
    using Oficondo.Management.Web.App.Model;
    using Oficondo.Management.Web.App.Model.Bank;
    using Oficondo.Management.Web.App.Model.Base;
    using Oficondo.Management.Web.App.Model.PaymentMethods;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    public partial interface IClient
    {
        public HttpClient HttpClient { get; }
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest body);
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest body, CancellationToken cancellationToken);
        Task<RegistrationResponse> RegisterAsync(RegistrationRequest body);
        Task<RegistrationResponse> RegisterAsync(RegistrationRequest body, CancellationToken cancellationToken);
        Task<ICollection<AuthorizedUsers>> AllAsync();
        Task<ICollection<AuthorizedUsers>> AllAsync(CancellationToken cancellationToken);
        Task<ICollection<BankListVm>> GetAllBanksAsync();
        Task<ICollection<BankListVm>> GetAllBanksAsync(CancellationToken cancellationToken);
        Task<BankDetailVm> GetBankByIdAsync(Guid id);
        Task<BankDetailVm> GetBankByIdAsync(Guid id, CancellationToken cancellationToken);
        Task DeleteBankAsync(Guid id);
        Task DeleteBankAsync(Guid id, CancellationToken cancellationToken);
        Task<GuidActionResult> AddBankAsync(CreateBankCommand body);
        Task<GuidActionResult> AddBankAsync(CreateBankCommand body, CancellationToken cancellationToken);
        Task UpdateBankAsync(UpdateBankCommand body);
        Task UpdateBankAsync(UpdateBankCommand body, CancellationToken cancellationToken);
        /* todo */
        Task<ICollection<PaymentMethodListVm>> GetAllPaymentMethodsAsync();
        Task<ICollection<PaymentMethodListVm>> GetAllPaymentMethodsAsync(CancellationToken cancellationToken);
        Task<PaymentMethodDetailVm> GetPaymentMethodByIdAsync(int id);
        Task<PaymentMethodDetailVm> GetPaymentMethodByIdAsync(int id, CancellationToken cancellationToken);
        /* todo */
    }
}
