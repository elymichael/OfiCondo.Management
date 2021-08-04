namespace OfiCondo.Management.Application.Features.Payees.Commands.Delete
{
    using AutoMapper;
    using MediatR;
    using OfiCondo.Management.Application.Contracts.Persistence;
    using OfiCondo.Management.Application.Exceptions;
    using OfiCondo.Management.Domain.Entities;
    using System.Threading;
    using System.Threading.Tasks;
    public class DeletePayeeCommandHandler : IRequestHandler<DeletePayeeCommand>
    {
        private readonly IPayeeRepository _baseRepository;
        private readonly IMapper _mapper;
        public DeletePayeeCommandHandler(IMapper mapper, IPayeeRepository baseRepository)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
        }

        public async Task<MediatR.Unit> Handle(DeletePayeeCommand request, CancellationToken cancellationToken)
        {
            var itemToDelete = await _baseRepository.GetByIdAsync(request.PayeeId);

            if (itemToDelete == null)
            {
                throw new NotFoundException(nameof(Payee), request.PayeeId);
            }

            await _baseRepository.DeleteAsync(itemToDelete);

            return MediatR.Unit.Value;
        }
    }
}
