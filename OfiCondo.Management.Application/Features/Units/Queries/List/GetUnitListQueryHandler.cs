namespace OfiCondo.Management.Application.Features.Units.Queries.List
{
    using AutoMapper;
    using MediatR;
    using OfiCondo.Management.Application.Contracts.Persistence;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetUnitListQueryHandler : IRequestHandler<GetUnitListQuery, List<UnitListVm>>
    {
        private readonly IUnitRepository _baseRepository;
        private readonly IMapper _mapper;

        public GetUnitListQueryHandler(IMapper mapper, IUnitRepository baseRepository)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
        }

        public async Task<List<UnitListVm>> Handle(GetUnitListQuery request, CancellationToken cancellationToken)
        {
            var records = (await _baseRepository.ListAllAsync()).OrderBy(x => x.Name);
            return _mapper.Map<List<UnitListVm>>(records);
        }
    }
}
