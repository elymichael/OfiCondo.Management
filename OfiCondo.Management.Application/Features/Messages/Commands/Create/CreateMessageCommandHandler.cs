namespace OfiCondo.Management.Application.Features.Messages.Commands.Create
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
    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, Guid>
    {
        private readonly IAsyncRepository<Message> _baseRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateMessageCommandHandler> _logger;
        public CreateMessageCommandHandler(IMapper mapper, IAsyncRepository<Message> baseRepository, IEmailService emailService, ILogger<CreateMessageCommandHandler> logger)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
            _emailService = emailService;
            _logger = logger;
        }
        public async Task<Guid> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateMessageCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            var @item = _mapper.Map<Message>(request);
            @item = await _baseRepository.AddAsync(@item);

            _logger.LogInformation($"{DateTime.Now:yyyyMMdd hh:mm:ss} - New [{nameof(Message)}] was created.", request);

            return @item.MessageId;
        }
    }
}
