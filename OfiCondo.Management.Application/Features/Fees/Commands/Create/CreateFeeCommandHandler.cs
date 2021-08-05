namespace OfiCondo.Management.Application.Features.Fees.Commands.Create
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

    public class CreateFeeCommandHandler : IRequestHandler<CreateFeeCommand, Guid>
    {
        private readonly IFeeRepository _baseRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateFeeCommandHandler> _logger;
        public CreateFeeCommandHandler(IMapper mapper, IFeeRepository baseRepository, IEmailService emailService, ILogger<CreateFeeCommandHandler> logger)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateFeeCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateFeeCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var @item = _mapper.Map<Fee>(request);
            @item = await _baseRepository.AddAsync(@item);

            var email = new Email() { To = ApplicationConstants.EmailTo, Body = $"A new fee account was created: {request}", Subject = "A new fee was created." };

            _logger.LogInformation($"{DateTime.Now:yyyyMMdd hh:mm:ss} - New [{nameof(Fee)}] was created.", request);

            return @item.FeeId;
        }
    }
}
