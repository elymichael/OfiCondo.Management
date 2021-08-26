namespace Oficondo.Management.Web.App.Contracts
{
    using Oficondo.Management.Web.App.Model;
    using Oficondo.Management.Web.App.Model.PaymentMethods;
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
        /* todo */
        Task<ICollection<PaymentMethodListVm>> GetAllPaymentMethodsAsync();
        Task<ICollection<PaymentMethodListVm>> GetAllPaymentMethodsAsync(CancellationToken cancellationToken);
        Task<PaymentMethodDetailVm> GetPaymentMethodByIdAsync(int id);
        Task<PaymentMethodDetailVm> GetPaymentMethodByIdAsync(int id, CancellationToken cancellationToken);
        /* todo */
    }
}
