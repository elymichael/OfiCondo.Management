using System;
using System.Collections.Generic;
using System.Text;

namespace OfiCondo.Management.Application.Features.Messages.Commands.Delete
{
    using AutoMapper;
    using MediatR;
    using OfiCondo.Management.Application.Contracts.Persistence;
    using OfiCondo.Management.Application.Exceptions;
    using OfiCondo.Management.Domain.Entities;
    using System.Threading;
    using System.Threading.Tasks;
    public class DeleteMessageCommandHandler : IRequestHandler<DeleteMessageCommand>
    {
        private readonly IAsyncRepository<Message> _baseRepository;
        private readonly IMapper _mapper;
        public DeleteMessageCommandHandler(IMapper mapper, IAsyncRepository<Message> baseRepository)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
        }
        public async Task<MediatR.Unit> Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
        {
            var itemToDelete = await _baseRepository.GetByIdAsync(request.MessageId);

            if (itemToDelete == null)
            {
                throw new NotFoundException(nameof(Message), request.MessageId);
            }

            await _baseRepository.DeleteAsync(itemToDelete);

            return MediatR.Unit.Value;
        }
    }
}
