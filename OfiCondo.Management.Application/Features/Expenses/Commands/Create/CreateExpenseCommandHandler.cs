namespace OfiCondo.Management.Application.Features.Expenses.Commands.Create
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

    public class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommand, Guid>
    {
        private readonly IExpenseRepository _baseRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateExpenseCommandHandler> _logger;
        public CreateExpenseCommandHandler(IExpenseRepository baseRepository, IMapper mapper, IEmailService emailService, ILogger<CreateExpenseCommandHandler> logger)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateExpenseCommandValidator(_baseRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var @item = _mapper.Map<Expense>(request);
            @item = await _baseRepository.AddAsync(@item);

            _logger.LogInformation($"{DateTime.Now:yyyyMMdd hh:mm:ss} - New [{nameof(Expense)}] was created.", request);

            return @item.ExpenseId;
        }
    }
}
