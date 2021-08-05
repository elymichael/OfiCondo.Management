namespace OfiCondo.Management.Application.Features.Condominia.Commands.Delete
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

    public class DeleteCondominiumCommandHandler : IRequestHandler<DeleteCondominiumCommand>
    {
        private readonly ICondominiumRepository _baseRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<DeleteCondominiumCommandHandler> _logger;
        public DeleteCondominiumCommandHandler(IMapper mapper, ICondominiumRepository baseRepository, IEmailService emailService, ILogger<DeleteCondominiumCommandHandler> logger)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<MediatR.Unit> Handle(DeleteCondominiumCommand request, CancellationToken cancellationToken)
        {
            var itemToDelete = await _baseRepository.GetByIdAsync(request.CondominiumId);

            if (itemToDelete == null)
            {
                throw new NotFoundException(nameof(Condominium), request.CondominiumId);
            }

            await _baseRepository.DeleteAsync(itemToDelete);

            var email = new Email() { To = ApplicationConstants.EmailTo, Body = $"A condominium account was deleted: {request}", Subject = "A condominium was deleted." };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Mailing about condominium {itemToDelete.CondominiumId} failed due to an error with the mail service: {ex.Message}");
            }

            return MediatR.Unit.Value;
        }
    }
}
