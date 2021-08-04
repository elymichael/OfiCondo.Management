namespace OfiCondo.Management.Application.Features.Incomes.Commands.Create
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

    public class CreateIncomeCommandHandler : IRequestHandler<CreateIncomeCommand, Guid>
    {
        private readonly IIncomeRepository _baseRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateIncomeCommandHandler> _logger;
        public CreateIncomeCommandHandler(IMapper mapper, IIncomeRepository baseRepository, IEmailService emailService, ILogger<CreateIncomeCommandHandler> logger)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateIncomeCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateIncomeCommandValidator(_baseRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var @item = _mapper.Map<Income>(request);
            @item = await _baseRepository.AddAsync(@item);

            var email = new Email() { To = ApplicationConstants.EmailTo, Body = $"A new income was created: {request}", Subject = "A new income was created." };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Mailing about income {@item.IncomeId} failed due to an error with the mail service: {ex.Message}");
            }

            return @item.IncomeId;
        }
    }
}
