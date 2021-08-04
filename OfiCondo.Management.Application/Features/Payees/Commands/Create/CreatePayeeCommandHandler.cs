namespace OfiCondo.Management.Application.Features.Payees.Commands.Create
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
    public class CreatePayeeCommandHandler : IRequestHandler<CreatePayeeCommand, Guid>
    {
        private readonly IPayeeRepository _baseRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreatePayeeCommandHandler> _logger;
        public CreatePayeeCommandHandler(IMapper mapper, IPayeeRepository baseRepository, IEmailService emailService, ILogger<CreatePayeeCommandHandler> logger)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreatePayeeCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreatePayeeCommandValidator(_baseRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var @item = _mapper.Map<Payee>(request);
            @item = await _baseRepository.AddAsync(@item);

            var email = new Email() { To = ApplicationConstants.EmailTo, Body = $"A new payee account was created: {request}", Subject = "A new payee was created." };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Mailing about bank {@item.PayeeId} failed due to an error with the mail service: {ex.Message}");
            }

            return @item.PayeeId;
        }
    }
}
