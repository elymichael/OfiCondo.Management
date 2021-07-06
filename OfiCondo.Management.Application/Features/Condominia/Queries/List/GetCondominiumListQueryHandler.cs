namespace OfiCondo.Management.Application.Features.Condominia.Queries.List
{
    using AutoMapper;
    using MediatR;
    using OfiCondo.Management.Application.Contracts.Persistence;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetCondominiumListQueryHandler : IRequestHandler<GetCondominiumListQuery, List<CondominiumListVm>>
    {
        private readonly ICondominiumRepository _baseRepository;
        private readonly IMapper _mapper;

        public GetCondominiumListQueryHandler(IMapper mapper, ICondominiumRepository baseRepository)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
        }

        public async Task<List<CondominiumListVm>> Handle(GetCondominiumListQuery request, CancellationToken cancellationToken)
        {
            var records = (await _baseRepository.ListAllAsync()).OrderBy(x => x.Name);
            return _mapper.Map<List<CondominiumListVm>>(records);
        }
    }
}
