namespace OfiCondo.Management.Application.Features.Minutes.Queries.Detail
{
    using AutoMapper;
    using MediatR;
    using OfiCondo.Management.Application.Contracts.Persistence;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetMinuteDetailQueryHandler : IRequestHandler<GetMinuteDetailQuery, MinuteDetailVm>
    {
        private readonly ICondominiumRepository _baseRepository;
        private readonly IMapper _mapper;
        public GetMinuteDetailQueryHandler(IMapper mapper, ICondominiumRepository baseRepository)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<MinuteDetailVm> Handle(GetMinuteDetailQuery request, CancellationToken cancellationToken)
        {
            var @item = await _baseRepository.GetByIdAsync(request.MinuteId);
            var itemDetailDto = _mapper.Map<MinuteDetailVm>(@item);

            return itemDetailDto;
        }
    }
}
