namespace OfiCondo.Management.Application.Features.Minutes.Commands.Create
{
    using FluentValidation;
    public class CreateMinuteCommandValidator : AbstractValidator<CreateMinuteCommand>
    {
        public CreateMinuteCommandValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
