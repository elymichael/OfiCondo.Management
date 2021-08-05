namespace OfiCondo.Management.Application.Features.Minutes.Commands.Delete
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
    public class DeleteMinuteCommandHandler : IRequestHandler<DeleteMinuteCommand>
    {
        private readonly IAsyncRepository<Minute> _baseRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteMinuteCommandHandler> _logger;
        public DeleteMinuteCommandHandler(IMapper mapper, IAsyncRepository<Minute> baseRepository, ILogger<DeleteMinuteCommandHandler> logger)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
            _logger = logger;
        }
        public async Task<MediatR.Unit> Handle(DeleteMinuteCommand request, CancellationToken cancellationToken)
        {
            var itemToDelete = await _baseRepository.GetByIdAsync(request.MinuteId);

            if (itemToDelete == null)
            {
                throw new NotFoundException(nameof(Minute), request.MinuteId);
            }

            await _baseRepository.DeleteAsync(itemToDelete);

            _logger.LogInformation($"{DateTime.Now:yyyyMMdd hh:mm:ss} - [{nameof(Minute)}] was deleted.", request);

            return MediatR.Unit.Value;
        }
    }
}
