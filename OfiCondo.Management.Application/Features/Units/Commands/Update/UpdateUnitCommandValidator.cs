namespace OfiCondo.Management.Application.Features.Units.Commands.Update
{
    using FluentValidation;
    public class UpdateUnitCommandValidator : AbstractValidator<UpdateUnitCommand>
    {
        public UpdateUnitCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
        }
    }
}
