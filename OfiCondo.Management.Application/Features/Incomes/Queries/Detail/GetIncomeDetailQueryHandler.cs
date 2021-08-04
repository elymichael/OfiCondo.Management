namespace OfiCondo.Management.Application.Features.Incomes.Queries.Detail
{
    using AutoMapper;
    using MediatR;
    using OfiCondo.Management.Application.Contracts.Persistence;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetIncomeDetailQueryHandler : IRequestHandler<GetIncomeDetailQuery, IncomeDetailVm>
    {
        private readonly IIncomeRepository _baseRepository;
        private readonly IMapper _mapper;
        public GetIncomeDetailQueryHandler(IMapper mapper, IIncomeRepository baseRepository)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<IncomeDetailVm> Handle(GetIncomeDetailQuery request, CancellationToken cancellationToken)
        {
            var @item = await _baseRepository.GetByIdAsync(request.IncomeId);
            var itemDetailDto = _mapper.Map<IncomeDetailVm>(@item);

            return itemDetailDto;
        }
    }
}
