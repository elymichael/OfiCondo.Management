namespace OfiCondo.Management.Application.Features.Incomes.Commands.Delete
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

    public class DeleteIncomeCommandHandler: IRequestHandler<DeleteIncomeCommand>
    {
        private readonly IIncomeRepository _baseRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteIncomeCommandHandler> _logger;
        public DeleteIncomeCommandHandler(IMapper mapper, IIncomeRepository baseRepository, ILogger<DeleteIncomeCommandHandler> logger)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
            _logger = logger;
        }

        public async Task<MediatR.Unit> Handle(DeleteIncomeCommand request, CancellationToken cancellationToken)
        {
            var itemToDelete = await _baseRepository.GetByIdAsync(request.IncomeId);

            if (itemToDelete == null)
            {
                throw new NotFoundException(nameof(Income), request.IncomeId);
            }

            await _baseRepository.DeleteAsync(itemToDelete);

            _logger.LogInformation($"{DateTime.Now:yyyyMMdd hh:mm:ss} - [{nameof(Income)}] was deleted.", request);

            return MediatR.Unit.Value;
        }
    }
}
