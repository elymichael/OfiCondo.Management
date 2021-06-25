namespace OfiCondo.Management.Application.Features.Banks.Commands.Create
{
    using AutoMapper;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using OfiCondo.Management.Application.Constants;
    using OfiCondo.Management.Application.Contracts.Infrastructure;
    using OfiCondo.Management.Application.Contracts.Persistence;
    using OfiCondo.Management.Application.Models.Mail;
    using OfiCondo.Management.Domain.Entities;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateBankCommandHandler : IRequestHandler<CreateBankCommand, Guid>
    {
        private readonly IBankRepository _bankRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateBankCommandHandler> _logger;

        public CreateBankCommandHandler(IMapper mapper, IBankRepository bankRepository, IEmailService emailService, ILogger<CreateBankCommandHandler> logger)
        {
            _mapper = mapper;
            _bankRepository = bankRepository;
            _emailService = emailService;
            _logger = logger;
        }
        public async Task<Guid> Handle(CreateBankCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateBankCommandValidator(_bankRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var @bank = _mapper.Map<Bank>(request);
            @bank = await _bankRepository.AddAsync(@bank);

            var email = new Email() { To = ApplicationConstants.EmailTo, Body = $"A new bank account was created: {request}", Subject = "A new bank was created." };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Mailing about bank {@bank.BankId} failed due to an error with the mail service: {ex.Message}");
            }

            return @bank.BankId;
        }
    }
}
