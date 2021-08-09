namespace OfiCondo.Management.Application.Features.Payees.Queries.Detail
{
    using AutoMapper;
    using MediatR;
    using OfiCondo.Management.Application.Contracts.Persistence;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetPayeeDetailQueryHandler : IRequestHandler<GetPayeeDetailQuery, PayeeDetailVm>
    {
        private readonly IPayeeRepository _baseRepository;
        private readonly IMapper _mapper;
        public GetPayeeDetailQueryHandler(IMapper mapper, IPayeeRepository baseRepository)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<PayeeDetailVm> Handle(GetPayeeDetailQuery request, CancellationToken cancellationToken)
        {
            var @item = await _baseRepository.GetByIdAsync(request.PayeeId);
            var itemDetailDto = _mapper.Map<PayeeDetailVm>(@item);

            return itemDetailDto;
        }
    }
}
