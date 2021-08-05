namespace OfiCondo.Management.Application.Features.Expenses.Commands.Delete
{
    using AutoMapper;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using OfiCondo.Management.Application.Contracts.Infrastructure;
    using OfiCondo.Management.Application.Contracts.Persistence;
    using OfiCondo.Management.Application.Exceptions;
    using OfiCondo.Management.Domain.Entities;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteExpenseCommandHandler : IRequestHandler<DeleteExpenseCommand>
    {
        private readonly IExpenseRepository _baseRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<DeleteExpenseCommandHandler> _logger;
        public DeleteExpenseCommandHandler(IExpenseRepository baseRepository, IMapper mapper, IEmailService emailService, ILogger<DeleteExpenseCommandHandler> logger)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<MediatR.Unit> Handle(DeleteExpenseCommand request, CancellationToken cancellationToken)
        {
            var itemToDelete = await _baseRepository.GetByIdAsync(request.ExpenseId);

            if (itemToDelete == null)
            {
                throw new NotFoundException(nameof(Expense), request.ExpenseId);
            }

            await _baseRepository.DeleteAsync(itemToDelete);

            _logger.LogInformation($"{DateTime.Now:yyyyMMdd hh:mm:ss} - [{nameof(Expense)}] was deleted.", request);

            return MediatR.Unit.Value;
        }
    }
}
