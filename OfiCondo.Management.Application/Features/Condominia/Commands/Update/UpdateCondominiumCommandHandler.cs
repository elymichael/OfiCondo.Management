namespace OfiCondo.Management.Application.Features.Condominia.Commands.Update
{
    using AutoMapper;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using OfiCondo.Management.Application.Constants;
    using OfiCondo.Management.Application.Contracts.Infrastructure;
    using OfiCondo.Management.Application.Contracts.Persistence;
    using OfiCondo.Management.Application.Exceptions;
    using OfiCondo.Management.Application.Models.Mail;
    using OfiCondo.Management.Domain.Entities;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdateCondominiaCommandHandler : IRequestHandler<UpdateCondominiumCommand>
    {
        private readonly ICondominiumRepository _baseRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<UpdateCondominiaCommandHandler> _logger;
        public UpdateCondominiaCommandHandler(IMapper mapper, ICondominiumRepository baseRepository, IEmailService emailService, ILogger<UpdateCondominiaCommandHandler> logger)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<MediatR.Unit> Handle(UpdateCondominiumCommand request, CancellationToken cancellationToken)
        {
            var eventToUpdate = await _baseRepository.GetByIdAsync(request.CondominiumId);

            if (eventToUpdate == null)
            {
                throw new NotFoundException(nameof(Condominium), request.CondominiumId);
            }

            var validator = new UpdateCondominiumCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);

            if (validatorResult.Errors.Count > 0)
                throw new ValidationException(validatorResult);

            _mapper.Map(request, eventToUpdate, typeof(UpdateCondominiumCommand), typeof(Condominium));

            await _baseRepository.UpdateAsync(eventToUpdate);

            var email = new Email() { To = ApplicationConstants.EmailTo, Body = $"condominium account was updated: {request}", Subject = "Condominium was updated." };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Mailing about condominium {eventToUpdate.CondominiumId} failed due to an error with the mail service: {ex.Message}");
            }

            return MediatR.Unit.Value;
        }
    }
}
