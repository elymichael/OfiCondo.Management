namespace OfiCondo.Management.Application.Features.Minutes.Commands.Update
{
    using FluentValidation;
    public class UpdateMinuteCommandValidator : AbstractValidator<UpdateMinuteCommand>
    {
        public UpdateMinuteCommandValidator()
        {
            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
