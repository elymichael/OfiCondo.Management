namespace OfiCondo.Management.Application.Features.Banks.Commands.Create
{
    using AutoMapper;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using OfiCondo.Management.Application.Contracts.Infrastructure;
    using OfiCondo.Management.Application.Contracts.Persistence;
    using OfiCondo.Management.Domain.Entities;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateBankCommandHandler : IRequestHandler<CreateBankCommand, Guid>
    {
        private readonly IBankRepository _baseRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateBankCommandHandler> _logger;

        public CreateBankCommandHandler(IMapper mapper, IBankRepository baseRepository, IEmailService emailService, ILogger<CreateBankCommandHandler> logger)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
            _emailService = emailService;
            _logger = logger;
        }
        public async Task<Guid> Handle(CreateBankCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateBankCommandValidator(_baseRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var @item = _mapper.Map<Bank>(request);
            @item = await _baseRepository.AddAsync(@item);

            _logger.LogInformation($"{DateTime.Now:yyyyMMdd hh:mm:ss} - New [{nameof(Bank)}] was created.", request);
            
            return @item.BankId;
        }
    }
}
