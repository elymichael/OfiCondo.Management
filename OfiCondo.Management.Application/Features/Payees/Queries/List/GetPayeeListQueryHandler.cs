namespace OfiCondo.Management.Application.Features.Payees.Queries.List
{
    using AutoMapper;
    using MediatR;
    using OfiCondo.Management.Application.Contracts.Persistence;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetPayeeListQueryHandler : IRequestHandler<GetPayeeListQuery, List<PayeeListVm>>
    {
        private readonly IBankRepository _baseRepository;
        private readonly IMapper _mapper;

        public GetPayeeListQueryHandler(IMapper mapper, IBankRepository baseRepository)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
        }

        public async Task<List<PayeeListVm>> Handle(GetPayeeListQuery request, CancellationToken cancellationToken)
        {
            var records = (await _baseRepository.ListAllAsync()).OrderBy(x => x.Name);
            return _mapper.Map<List<PayeeListVm>>(records);
        }
    }
}
