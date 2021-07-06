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
        private readonly IBankRepository _baseRepository;
        private readonly IMapper _mapper;
        public DeleteBankCommandHandler(IMapper mapper, IBankRepository baseRepository)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
        }

        public async Task<MediatR.Unit> Handle(DeleteBankCommand request, CancellationToken cancellationToken)
        {
            var itemToDelete = await _baseRepository.GetByIdAsync(request.BankId);

            if (itemToDelete == null)
            {
                throw new NotFoundException(nameof(Bank), request.BankId);
            }

            await _baseRepository.DeleteAsync(itemToDelete);

            return MediatR.Unit.Value;
        }
    }
}
