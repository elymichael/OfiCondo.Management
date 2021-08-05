namespace OfiCondo.Management.Application.Features.Fees.Queries.Detail
{
    using AutoMapper;
    using MediatR;
    using OfiCondo.Management.Application.Contracts.Persistence;
    using OfiCondo.Management.Domain.Entities;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetFeeDetailQueryHandler : IRequestHandler<GetFeeDetailQuery, FeeDetailVm>
    {
        private readonly IAsyncRepository<Bank> _baseRepository;
        private readonly IMapper _mapper;
        public GetFeeDetailQueryHandler(IMapper mapper, IAsyncRepository<Bank> baseRepository)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<FeeDetailVm> Handle(GetFeeDetailQuery request, CancellationToken cancellationToken)
        {
            var @item = await _baseRepository.GetByIdAsync(request.FeeId);
            var itemDetailDto = _mapper.Map<FeeDetailVm>(@item);

            return itemDetailDto;
        }
    }
}
