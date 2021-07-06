namespace OfiCondo.Management.Application.Features.Minutes.Queries.List
{
    using AutoMapper;
    using MediatR;
    using OfiCondo.Management.Application.Contracts.Persistence;
    using OfiCondo.Management.Domain.Entities;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetMinuteListQueryHandler : IRequestHandler<GetMinuteListQuery, List<MinuteListVm>>
    {
        private readonly IAsyncRepository<Minute> _baseRepository;
        private readonly IMapper _mapper;
        public GetMinuteListQueryHandler(IMapper mapper, IAsyncRepository<Minute> baseRepository)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
        }
        public async Task<List<MinuteListVm>> Handle(GetMinuteListQuery request, CancellationToken cancellationToken)
        {
            var records = (await _baseRepository.ListAllAsync()).OrderBy(x => x.Title);
            return _mapper.Map<List<MinuteListVm>>(records);
        }
    }
}
