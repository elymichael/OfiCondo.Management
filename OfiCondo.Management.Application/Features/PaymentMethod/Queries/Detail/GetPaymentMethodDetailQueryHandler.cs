namespace OfiCondo.Management.Application.Features.PaymentMethod.Queries.Detail
{
    using AutoMapper;
    using MediatR;
    using OfiCondo.Management.Application.Contracts.Persistence;
    using OfiCondo.Management.Domain.Entities;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetPaymentMethodDetailQueryHandler : IRequestHandler<GetPaymentMethodDetailQuery, PaymentMethodDetailVm>
    {
        private readonly IPaymentMethodRepository _baseRepository;
        private readonly IMapper _mapper;
        public GetPaymentMethodDetailQueryHandler(IMapper mapper, IPaymentMethodRepository baseRepository)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<PaymentMethodDetailVm> Handle(GetPaymentMethodDetailQuery request, CancellationToken cancellationToken)
        {
            var @item = await _baseRepository.GetByIntIdAsync(request.PaymentMethodId);
            var itemDetailDto = _mapper.Map<PaymentMethodDetailVm>(@item);

            return itemDetailDto;
        }
    }
}
