namespace OfiCondo.Management.Application.Features.Incomes.Commands.Update
{
    using FluentValidation;
    public class UpdateIncomeCommandValidator: AbstractValidator<UpdateIncomeCommand>
    {
        public UpdateIncomeCommandValidator()
        {
            RuleFor(p => p.RecordDate)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull();
        }
    }
}
