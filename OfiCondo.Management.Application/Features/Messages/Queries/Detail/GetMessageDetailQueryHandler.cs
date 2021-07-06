namespace OfiCondo.Management.Application.Features.Messages.Queries.Detail
{
    using AutoMapper;
    using MediatR;
    using OfiCondo.Management.Application.Contracts.Persistence;
    using OfiCondo.Management.Domain.Entities;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetMessageDetailQueryHandler : IRequestHandler<GetMessageDetailQuery, MessageDetailVm>
    {
        private readonly IAsyncRepository<Message> _baseRepository;
        private readonly IMapper _mapper;
        public GetMessageDetailQueryHandler(IMapper mapper, IAsyncRepository<Message> baseRepository)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<MessageDetailVm> Handle(GetMessageDetailQuery request, CancellationToken cancellationToken)
        {
            var @item = await _baseRepository.GetByIdAsync(request.MessageId);
            var itemDetailDto = _mapper.Map<MessageDetailVm>(@item);

            return itemDetailDto;
        }
    }
}
