namespace OfiCondo.Management.Application.Features.Units.Commands.Create
{
    using FluentValidation;
    using OfiCondo.Management.Application.Contracts.Persistence;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateUnitCommandValidator : AbstractValidator<CreateUnitCommand>
    {
        private readonly IUnitRepository _baseRepository;
        public CreateUnitCommandValidator(IUnitRepository baseRepository)
        {
            _baseRepository = baseRepository;

            RuleFor(p => p.Name)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(e => e)
                .MustAsync(IsUnique)
                .WithMessage("A unit with the same name already exists.");
        }

        private async Task<bool> IsUnique(CreateUnitCommand e, CancellationToken token)
        {
            return !(await _baseRepository.IsUnique(e.Name));
        }
    }
}
