namespace OfiCondo.Management.Application.Features.Incomes.Commands.Create
{
    using FluentValidation;
    using OfiCondo.Management.Application.Contracts.Persistence;

    class CreateIncomeCommandValidator: AbstractValidator<CreateIncomeCommand>
    {
        private readonly IIncomeRepository _baseRepository;
        public CreateIncomeCommandValidator(IIncomeRepository baseRepository)
        {
            _baseRepository = baseRepository;

            RuleFor(p => p.RecordDate)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull();
        }
    }
}
