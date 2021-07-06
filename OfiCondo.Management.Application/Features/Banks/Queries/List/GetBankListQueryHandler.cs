namespace OfiCondo.Management.Application.Features.Banks.Queries.List
{
    using AutoMapper;
    using MediatR;
    using OfiCondo.Management.Application.Contracts.Persistence;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetBankListQueryHandler: IRequestHandler<GetBankListQuery, List<BankListVm>>
    {
        private readonly IBankRepository _baseRepository;
        private readonly IMapper _mapper;

        public GetBankListQueryHandler(IMapper mapper, IBankRepository baseRepository)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
        }

        public async Task<List<BankListVm>> Handle(GetBankListQuery request, CancellationToken cancellationToken)
        {
            var records = (await _baseRepository.ListAllAsync()).OrderBy(x => x.Name);
            return _mapper.Map<List<BankListVm>>(records);
        }
    }
}
