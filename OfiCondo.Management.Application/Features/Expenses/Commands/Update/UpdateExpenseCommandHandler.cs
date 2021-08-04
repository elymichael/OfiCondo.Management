namespace OfiCondo.Management.Application.Features.Expenses.Commands.Update
{
    using AutoMapper;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using OfiCondo.Management.Application.Contracts.Infrastructure;
    using OfiCondo.Management.Application.Contracts.Persistence;
    using OfiCondo.Management.Application.Exceptions;
    using OfiCondo.Management.Domain.Entities;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdateExpenseCommandHandler : IRequestHandler<UpdateExpenseCommand>
    {
        private readonly IExpenseRepository _baseRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<UpdateExpenseCommandHandler> _logger;
        public UpdateExpenseCommandHandler(IExpenseRepository baseRepository, IMapper mapper, IEmailService emailService, ILogger<UpdateExpenseCommandHandler> logger)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<MediatR.Unit> Handle(UpdateExpenseCommand request, CancellationToken cancellationToken)
        {
            var eventToUpdate = await _baseRepository.GetByIdAsync(request.ExpenseId);

            if (eventToUpdate == null)
            {
                throw new NotFoundException(nameof(Expense), request.ExpenseId);
            }

            var validator = new UpdateExpenseCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);

            if (validatorResult.Errors.Count > 0)
                throw new ValidationException(validatorResult);

            _mapper.Map(request, eventToUpdate, typeof(UpdateExpenseCommand), typeof(Expense));

            await _baseRepository.UpdateAsync(eventToUpdate);

            return MediatR.Unit.Value;
        }
    }
}
