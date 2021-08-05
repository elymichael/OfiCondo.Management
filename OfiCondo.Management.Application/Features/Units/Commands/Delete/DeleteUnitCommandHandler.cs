namespace OfiCondo.Management.Application.Features.Units.Commands.Delete
{
    using AutoMapper;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using OfiCondo.Management.Application.Contracts.Persistence;
    using OfiCondo.Management.Application.Exceptions;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteUnitCommandHandler : IRequestHandler<DeleteUnitCommand>
    {
        private readonly IUnitRepository _baseRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteUnitCommandHandler> _logger;
        public DeleteUnitCommandHandler(IMapper mapper, IUnitRepository baseRepository, ILogger<DeleteUnitCommandHandler> logger)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
            _logger = logger;
        }

        public async Task<MediatR.Unit> Handle(DeleteUnitCommand request, CancellationToken cancellationToken)
        {
            var itemToDelete = await _baseRepository.GetByIdAsync(request.UnitId);

            if (itemToDelete == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.Unit), request.UnitId);
            }

            await _baseRepository.DeleteAsync(itemToDelete);

            _logger.LogInformation($"{DateTime.Now:yyyyMMdd hh:mm:ss} - [Unit] was deleted.", request);

            return MediatR.Unit.Value;
        }
    }
}
