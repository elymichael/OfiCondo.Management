namespace OfiCondo.Management.Application.Features.Messages.Commands.Update
{
    using FluentValidation;
    public class UpdateMessageCommandValidator : AbstractValidator<UpdateMessageCommand>
    {
        public UpdateMessageCommandValidator()
        {
            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
