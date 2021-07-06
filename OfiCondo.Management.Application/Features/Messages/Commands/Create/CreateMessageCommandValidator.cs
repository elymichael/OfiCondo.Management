namespace OfiCondo.Management.Application.Features.Messages.Commands.Create
{
    using FluentValidation;
    public class CreateMessageCommandValidator : AbstractValidator<CreateMessageCommand>
    {
        public CreateMessageCommandValidator()
        {
            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
