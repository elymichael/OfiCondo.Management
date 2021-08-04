namespace OfiCondo.Management.Application.Features.Expenses.Commands.Create
{
    using FluentValidation;
    using OfiCondo.Management.Application.Contracts.Persistence;

    public class CreateExpenseCommandValidator: AbstractValidator<CreateExpenseCommand>
    {
        private readonly IExpenseRepository _baseRepository;
        public CreateExpenseCommandValidator(IExpenseRepository baseRepository)
        {
            _baseRepository = baseRepository;
            RuleFor(p => p.RecordDate)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull();
        }
    }
}
