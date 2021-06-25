namespace OfiCondo.Management.Application.Features.PaymentMethod.Queries.List
{
    using AutoMapper;
    using MediatR;
    using OfiCondo.Management.Application.Contracts.Persistence;
    using OfiCondo.Management.Domain.Entities;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetPaymentMethodListQueryHandler : IRequestHandler<GetPaymentMethodListQuery, List<PaymentMethodListVm>>
    {
        private readonly IAsyncRepository<PaymentMethod> _baseRepository;
        private readonly IMapper _mapper;
        public GetPaymentMethodListQueryHandler(IMapper mapper, IAsyncRepository<PaymentMethod> baseRepository)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
        }
        public async Task<List<PaymentMethodListVm>> Handle(GetPaymentMethodListQuery request, CancellationToken cancellationToken)
        {
            var records = (await _baseRepository.ListAllAsync()).OrderBy(x => x.Name);
            return _mapper.Map<List<PaymentMethodListVm>>(records);
        }
    }
}
