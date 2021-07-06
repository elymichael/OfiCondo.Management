namespace OfiCondo.Management.Application.Features.PaymentMethod.Queries.Detail
{
    using MediatR;
    public class GetPaymentMethodDetailQuery : IRequest<PaymentMethodDetailVm>
    {
        public int PaymentMethodId { get; set; }
    }
}
