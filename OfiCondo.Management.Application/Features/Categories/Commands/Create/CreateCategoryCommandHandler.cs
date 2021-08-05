namespace OfiCondo.Management.Application.Features.Categories.Commands.Create
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
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
    {
        private readonly IAsyncRepository<Category> _baseRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateCategoryCommandHandler> _logger;
        public CreateCategoryCommandHandler(IMapper mapper, IAsyncRepository<Category> baseRepository, IEmailService emailService, ILogger<CreateCategoryCommandHandler> logger)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
            _emailService = emailService;
            _logger = logger;
        }
        public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateCategoryCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            var @category = _mapper.Map<Category>(request);
            @category = await _baseRepository.AddAsync(@category);

            var email = new Email() { To = ApplicationConstants.EmailTo, Body = $"A new category account was created: {request}", Subject = "A new category was created." };

            _logger.LogInformation($"{DateTime.Now:yyyyMMdd hh:mm:ss} - New [{nameof(Category)}] was created.", request);

            return @category.CategoryId;
        }
    }
}
