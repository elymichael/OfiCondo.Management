namespace OfiCondo.Management.Application.Features.Messages.Queries.List
{
    using AutoMapper;
    using MediatR;
    using OfiCondo.Management.Application.Contracts.Persistence;
    using OfiCondo.Management.Domain.Entities;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetMessageListQueryHandler : IRequestHandler<GetMessageListQuery, List<MessageListVm>>
    {
        private readonly IAsyncRepository<Message> _baseRepository;
        private readonly IMapper _mapper;
        public GetMessageListQueryHandler(IMapper mapper, IAsyncRepository<Message> baseRepository)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
        }
        public async Task<List<MessageListVm>> Handle(GetMessageListQuery request, CancellationToken cancellationToken)
        {
            var records = (await _baseRepository.ListAllAsync()).OrderBy(x => x.RecordDate);
            return _mapper.Map<List<MessageListVm>>(records);
        }
    }
}
