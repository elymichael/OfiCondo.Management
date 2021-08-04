namespace OfiCondo.Management.Application.Features.Expenses.Commands.Update
{
    using FluentValidation;
    public class UpdateExpenseCommandValidator: AbstractValidator<UpdateExpenseCommand>
    {
        public UpdateExpenseCommandValidator()
        {
            RuleFor(p => p.RecordDate)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull();
        }
    }
}
