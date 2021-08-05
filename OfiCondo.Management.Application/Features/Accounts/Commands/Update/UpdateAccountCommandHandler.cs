namespace OfiCondo.Management.Application.Features.Accounts.Commands.Update
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
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand>
    {
        private readonly IAsyncRepository<Account> _baseRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<UpdateAccountCommandHandler> _logger;

        public UpdateAccountCommandHandler(IMapper mapper, IAsyncRepository<Account> baseRepository, IEmailService emailService, ILogger<UpdateAccountCommandHandler> logger)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<MediatR.Unit> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            var eventToUpdate = await _baseRepository.GetByIdAsync(request.AccountId);

            if (eventToUpdate == null)
            {
                throw new NotFoundException(nameof(Account), request.AccountId);
            }

            _mapper.Map(request, eventToUpdate, typeof(UpdateAccountCommand), typeof(Account));

            await _baseRepository.UpdateAsync(eventToUpdate);

            var email = new Email() { To = ApplicationConstants.EmailTo, Body = $"Account was updated: {request}", Subject = "Account was updated." };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Mailing about account {eventToUpdate.AccountId} failed due to an error with the mail service: {ex.Message}");
            }

            return MediatR.Unit.Value;
        }
    }
}
