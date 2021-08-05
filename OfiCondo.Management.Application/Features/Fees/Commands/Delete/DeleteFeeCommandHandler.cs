namespace OfiCondo.Management.Application.Features.Fees.Commands.Delete
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

    public class DeleteFeeCommandHandler : IRequestHandler<DeleteFeeCommand>
    {
        private readonly IFeeRepository _baseRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteFeeCommandHandler> _logger;
        public DeleteFeeCommandHandler(IMapper mapper, IFeeRepository baseRepository, ILogger<DeleteFeeCommandHandler> logger)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
            _logger = logger;
        }

        public async Task<MediatR.Unit> Handle(DeleteFeeCommand request, CancellationToken cancellationToken)
        {
            var itemToDelete = await _baseRepository.GetByIdAsync(request.FeeId);

            if (itemToDelete == null)
            {
                throw new NotFoundException(nameof(Fee), request.FeeId);
            }

            await _baseRepository.DeleteAsync(itemToDelete);

            _logger.LogInformation($"{DateTime.Now:yyyyMMdd hh:mm:ss} - [{nameof(Fee)}] was deleted.", request);

            return MediatR.Unit.Value;
        }
    }
}
