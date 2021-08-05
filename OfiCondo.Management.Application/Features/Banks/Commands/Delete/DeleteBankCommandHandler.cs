namespace OfiCondo.Management.Application.Features.Banks.Commands.Delete
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

    public class DeleteBankCommandHandler : IRequestHandler<DeleteBankCommand>
    {
        private readonly IBankRepository _baseRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteBankCommandHandler> _logger;
        public DeleteBankCommandHandler(IMapper mapper, IBankRepository baseRepository, ILogger<DeleteBankCommandHandler> logger)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
            _logger = logger;
        }

        public async Task<MediatR.Unit> Handle(DeleteBankCommand request, CancellationToken cancellationToken)
        {
            var itemToDelete = await _baseRepository.GetByIdAsync(request.BankId);

            if (itemToDelete == null)
            {
                throw new NotFoundException(nameof(Bank), request.BankId);
            }

            await _baseRepository.DeleteAsync(itemToDelete);

            _logger.LogInformation($"{DateTime.Now:yyyyMMdd hh:mm:ss} - [{nameof(Bank)}] was deleted.", request);

            return MediatR.Unit.Value;
        }
    }
}
