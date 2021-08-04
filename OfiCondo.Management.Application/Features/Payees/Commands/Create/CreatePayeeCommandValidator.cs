namespace OfiCondo.Management.Application.Features.Payees.Commands.Create
{
    using FluentValidation;
    using OfiCondo.Management.Application.Contracts.Persistence;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreatePayeeCommandValidator: AbstractValidator<CreatePayeeCommand>
    {
        private readonly IPayeeRepository _bankRepository;
        public CreatePayeeCommandValidator(IPayeeRepository bankRepository)
        {
            _bankRepository = bankRepository;

            RuleFor(p => p.AccountNumber)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(e => e)
                .MustAsync(IsUnique)
                .WithMessage("A account number with the same name already exists.");
        }

        private async Task<bool> IsUnique(CreatePayeeCommand e, CancellationToken token)
        {
            return !(await _bankRepository.IsUnique(e.AccountNumber));
        }
    }
}
