namespace OfiCondo.Management.Application.Features.Payees.Commands.Delete
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
    public class DeletePayeeCommandHandler : IRequestHandler<DeletePayeeCommand>
    {
        private readonly IPayeeRepository _baseRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeletePayeeCommandHandler> _logger;
        public DeletePayeeCommandHandler(IMapper mapper, IPayeeRepository baseRepository, ILogger<DeletePayeeCommandHandler> logger)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
            _logger = logger;
        }

        public async Task<MediatR.Unit> Handle(DeletePayeeCommand request, CancellationToken cancellationToken)
        {
            var itemToDelete = await _baseRepository.GetByIdAsync(request.PayeeId);

            if (itemToDelete == null)
            {
                throw new NotFoundException(nameof(Payee), request.PayeeId);
            }

            await _baseRepository.DeleteAsync(itemToDelete);

            _logger.LogInformation($"{DateTime.Now:yyyyMMdd hh:mm:ss} - [{nameof(Payee)}] was deleted.", request);

            return MediatR.Unit.Value;
        }
    }
}
