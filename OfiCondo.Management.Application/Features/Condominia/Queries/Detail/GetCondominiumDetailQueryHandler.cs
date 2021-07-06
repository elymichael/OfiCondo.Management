namespace OfiCondo.Management.Application.Features.Condominia.Queries.Detail
{
    using AutoMapper;
    using MediatR;
    using OfiCondo.Management.Application.Contracts.Persistence;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetCondominiumDetailQueryHandler : IRequestHandler<GetCondominiumDetailQuery, CondominiumDetailVm>
    {
        private readonly ICondominiumRepository _baseRepository;
        private readonly IMapper _mapper;
        public GetCondominiumDetailQueryHandler(IMapper mapper, ICondominiumRepository baseRepository)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<CondominiumDetailVm> Handle(GetCondominiumDetailQuery request, CancellationToken cancellationToken)
        {
            var @item = await _baseRepository.GetByIdAsync(request.CondominiumId);
            var itemDetailDto = _mapper.Map<CondominiumDetailVm>(@item);

            return itemDetailDto;
        }
    }
}
