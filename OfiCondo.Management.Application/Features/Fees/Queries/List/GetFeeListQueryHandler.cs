namespace OfiCondo.Management.Application.Features.Fees.Queries.List
{
    using AutoMapper;
    using MediatR;
    using OfiCondo.Management.Application.Contracts.Persistence;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetFeeListQueryHandler : IRequestHandler<GetFeeListQuery, List<FeeListVm>>
    {
        private readonly IBankRepository _baseRepository;
        private readonly IMapper _mapper;

        public GetFeeListQueryHandler(IMapper mapper, IBankRepository baseRepository)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
        }

        public async Task<List<FeeListVm>> Handle(GetFeeListQuery request, CancellationToken cancellationToken)
        {
            var records = (await _baseRepository.ListAllAsync()).OrderBy(x => x.Name);
            return _mapper.Map<List<FeeListVm>>(records);
        }
    }    
}
