namespace OfiCondo.Management.Application.Features.Accounts.Commands.Delete
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
    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand>
    {
        private readonly IAsyncRepository<Account> _baseRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<DeleteAccountCommandHandler> _logger;

        public DeleteAccountCommandHandler(IMapper mapper, IAsyncRepository<Account> baseRepository, IEmailService emailService, ILogger<DeleteAccountCommandHandler> logger)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<MediatR.Unit> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            var itemToDelete = await _baseRepository.GetByIdAsync(request.AccountId);

            if (itemToDelete == null)
            {
                throw new NotFoundException(nameof(Account), request.AccountId);
            }

            await _baseRepository.DeleteAsync(itemToDelete);

            var email = new Email() { To = ApplicationConstants.EmailTo, Body = $"Account was deleted: {request}", Subject = "Account was deleted." };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Mailing about account {itemToDelete.AccountId} failed due to an error with the mail service: {ex.Message}");
            }

            return MediatR.Unit.Value;
        }
    }
}
