namespace OfiCondo.Management.Application.Features.Banks.Commands.Create
{
    using FluentValidation;
    using OfiCondo.Management.Application.Contracts.Persistence;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateBankCommandValidator: AbstractValidator<CreateBankCommand>
    {
        private readonly IBankRepository _bankRepository;
        public CreateBankCommandValidator(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;

            RuleFor(p => p.Name)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(e => e)
                .MustAsync(IsUnique)
                .WithMessage("A bank with the same name already exists.");
        }

        private async Task<bool> IsUnique(CreateBankCommand e, CancellationToken token)
        {
            return !(await _bankRepository.IsUnique(e.Name));            
        }
    }
}
