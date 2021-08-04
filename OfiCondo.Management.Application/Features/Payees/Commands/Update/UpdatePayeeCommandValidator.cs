namespace OfiCondo.Management.Application.Features.Payees.Commands.Update
{
    using FluentValidation;
    public class UpdatePayeeCommandValidator: AbstractValidator<UpdatePayeeCommand>
    {
        public UpdatePayeeCommandValidator()
        {
            RuleFor(p => p.AccountNumber)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull();
        }
    }
}
