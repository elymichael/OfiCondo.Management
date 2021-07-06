namespace OfiCondo.Management.Application.Features.Condominia.Commands.Create
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

    public class CreateCondominiumCommandHandler : IRequestHandler<CreateCondominiumCommand, Guid>
    {
        private readonly ICondominiumRepository _baseRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateCondominiumCommandHandler> _logger;

        public CreateCondominiumCommandHandler(IMapper mapper, ICondominiumRepository baseRepository, IEmailService emailService, ILogger<CreateCondominiumCommandHandler> logger)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
            _emailService = emailService;
            _logger = logger;
        }
        public async Task<Guid> Handle(CreateCondominiumCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateCondominiumCommandValidator(_baseRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var @item = _mapper.Map<Condominium>(request);
            @item = await _baseRepository.AddAsync(@item);

            var email = new Email() { To = ApplicationConstants.EmailTo, Body = $"A new condominium account was created: {request}", Subject = "A new bank was created." };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Mailing about condominium {@item.CondominiumId} failed due to an error with the mail service: {ex.Message}");
            }

            return @item.CondominiumId;
        }
    }
}
