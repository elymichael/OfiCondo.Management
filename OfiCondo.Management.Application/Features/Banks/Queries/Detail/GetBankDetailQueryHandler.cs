namespace OfiCondo.Management.Application.Features.Banks.Queries.Detail
{
    using AutoMapper;
    using MediatR;
    using OfiCondo.Management.Application.Contracts.Persistence;
    using OfiCondo.Management.Domain.Entities;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetBankDetailQueryHandler : IRequestHandler<GetBankDetailQuery, BankDetailVm>
    {
        private readonly IAsyncRepository<Bank> _baseRepository;        
        private readonly IMapper _mapper;
        public GetBankDetailQueryHandler(IMapper mapper, IAsyncRepository<Bank> baseRepository)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<BankDetailVm> Handle(GetBankDetailQuery request, CancellationToken cancellationToken)
        {
            var @item = await _baseRepository.GetByIdAsync(request.BankId);
            var itemDetailDto = _mapper.Map<BankDetailVm>(@item);

            return itemDetailDto;
        }
    }
}
