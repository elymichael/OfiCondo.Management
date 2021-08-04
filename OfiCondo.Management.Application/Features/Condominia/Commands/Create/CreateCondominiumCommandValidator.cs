namespace OfiCondo.Management.Application.Features.Condominia.Commands.Create
{
    using FluentValidation;
    using OfiCondo.Management.Application.Contracts.Persistence;
    using OfiCondo.Management.Domain.Entities;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateCondominiumCommandValidator : AbstractValidator<CreateCondominiumCommand>
    {
        private readonly ICondominiumRepository _baseRepository;
        public CreateCondominiumCommandValidator(ICondominiumRepository baseRepository)
        {
            _baseRepository = baseRepository;

            RuleFor(p => p.Name)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MaximumLength(75).WithMessage("{PropertyName} must not exceed 75 characters.");

            RuleFor(e => e)
                .MustAsync(IsUnique)
                .WithMessage("A condominium with the same name already exists.");
        }

        private async Task<bool> IsUnique(CreateCondominiumCommand e, CancellationToken token)
        {
            return !(await _baseRepository.IsUnique(e.Name));
        }
    }
}
