namespace OfiCondo.Management.Application.Features.Messages.Commands.Delete
{
    using AutoMapper;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using OfiCondo.Management.Application.Contracts.Persistence;
    using OfiCondo.Management.Application.Exceptions;
    using OfiCondo.Management.Domain.Entities;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    public class DeleteMessageCommandHandler : IRequestHandler<DeleteMessageCommand>
    {
        private readonly IAsyncRepository<Message> _baseRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteMessageCommandHandler> _logger;
        public DeleteMessageCommandHandler(IMapper mapper, IAsyncRepository<Message> baseRepository, ILogger<DeleteMessageCommandHandler> logger)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
            _logger = logger;
        }
        public async Task<MediatR.Unit> Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
        {
            var itemToDelete = await _baseRepository.GetByIdAsync(request.MessageId);

            if (itemToDelete == null)
            {
                throw new NotFoundException(nameof(Message), request.MessageId);
            }

            await _baseRepository.DeleteAsync(itemToDelete);

            _logger.LogInformation($"{DateTime.Now:yyyyMMdd hh:mm:ss} - [{nameof(Message)}] was deleted.", request);

            return MediatR.Unit.Value;
        }
    }
}
