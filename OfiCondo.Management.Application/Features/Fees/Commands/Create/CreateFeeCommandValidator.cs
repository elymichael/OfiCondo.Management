namespace OfiCondo.Management.Application.Features.Fees.Commands.Create
{
    using FluentValidation;
    public class CreateFeeCommandValidator: AbstractValidator<CreateFeeCommand>
    {
        public CreateFeeCommandValidator()
        {
            RuleFor(p => p.Name)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull();
        }
    }
}
