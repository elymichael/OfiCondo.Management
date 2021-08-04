namespace OfiCondo.Management.Application.Features.Fees.Commands.Delete
{
    using AutoMapper;
    using MediatR;
    using OfiCondo.Management.Application.Contracts.Persistence;
    using OfiCondo.Management.Application.Exceptions;
    using OfiCondo.Management.Domain.Entities;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteFeeCommandHandler : IRequestHandler<DeleteFeeCommand>
    {
        private readonly IFeeRepository _baseRepository;
        private readonly IMapper _mapper;
        public DeleteFeeCommandHandler(IMapper mapper, IFeeRepository baseRepository)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
        }

        public async Task<MediatR.Unit> Handle(DeleteFeeCommand request, CancellationToken cancellationToken)
        {
            var itemToDelete = await _baseRepository.GetByIdAsync(request.FeeId);

            if (itemToDelete == null)
            {
                throw new NotFoundException(nameof(Fee), request.FeeId);
            }

            await _baseRepository.DeleteAsync(itemToDelete);

            return MediatR.Unit.Value;
        }
    }
}
