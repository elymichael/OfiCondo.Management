namespace OfiCondo.Management.Application.Features.Incomes.Queries.List
{
    using AutoMapper;
    using MediatR;
    using OfiCondo.Management.Application.Contracts.Persistence;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetIncomeListQueryHandler : IRequestHandler<GetIncomeListQuery, List<IncomeListVm>>
    {
        private readonly IIncomeRepository _baseRepository;
        private readonly IMapper _mapper;

        public GetIncomeListQueryHandler(IMapper mapper, IIncomeRepository baseRepository)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
        }

        public async Task<List<IncomeListVm>> Handle(GetIncomeListQuery request, CancellationToken cancellationToken)
        {
            var records = (await _baseRepository.ListAllAsync()).OrderBy(x => x.RecordDate);
            return _mapper.Map<List<IncomeListVm>>(records);
        }
    }
}
