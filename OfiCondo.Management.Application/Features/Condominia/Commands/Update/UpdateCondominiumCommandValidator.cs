namespace OfiCondo.Management.Application.Features.Condominia.Commands.Update
{
    using FluentValidation;
    public class UpdateCondominiumCommandValidator : AbstractValidator<UpdateCondominiumCommand>
    {
        public UpdateCondominiumCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
        }
    }
}
