namespace OfiCondo.Management.Application.Features.Minutes.Commands.Create
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
    public class CreateMinuteCommandHandler : IRequestHandler<CreateMinuteCommand, Guid>
    {
        private readonly IAsyncRepository<Minute> _baseRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateMinuteCommandHandler> _logger;
        public CreateMinuteCommandHandler(IMapper mapper, IAsyncRepository<Minute> baseRepository, IEmailService emailService, ILogger<CreateMinuteCommandHandler> logger)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
            _emailService = emailService;
            _logger = logger;
        }
        public async Task<Guid> Handle(CreateMinuteCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateMinuteCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            var @item = _mapper.Map<Minute>(request);
            @item = await _baseRepository.AddAsync(@item);

            _logger.LogInformation($"{DateTime.Now:yyyyMMdd hh:mm:ss} - New [{nameof(Minute)}] was created.", request);

            return @item.MinuteId;
        }
    }
}
