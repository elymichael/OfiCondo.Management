namespace OfiCondo.Management.Application.Features.Banks.Commands.Delete
{
    using AutoMapper;
    using MediatR;
    using OfiCondo.Management.Application.Contracts.Persistence;
    using OfiCondo.Management.Application.Exceptions;
    using OfiCondo.Management.Domain.Entities;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteBankCommandHandler : IRequestHandler<DeleteBankCommand>
    {
        private readonly IBankRepository _bankRepository;
        private readonly IMapper _mapper;
        public DeleteBankCommandHandler(IMapper mapper, IBankRepository bankRepository)
        {
            _mapper = mapper;
            _bankRepository = bankRepository;
        }

        public async Task<MediatR.Unit> Handle(DeleteBankCommand request, CancellationToken cancellationToken)
        {
            var itemToDelete = await _bankRepository.GetByIdAsync(request.BankId);

            if (itemToDelete == null)
            {
                throw new NotFoundException(nameof(Bank), request.BankId);
            }

            await _bankRepository.DeleteAsync(itemToDelete);

            return MediatR.Unit.Value;
        }
    }
}
