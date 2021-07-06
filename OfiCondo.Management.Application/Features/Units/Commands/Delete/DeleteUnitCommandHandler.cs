namespace OfiCondo.Management.Application.Features.Units.Commands.Delete
{
    using AutoMapper;
    using MediatR;
    using OfiCondo.Management.Application.Contracts.Persistence;
    using OfiCondo.Management.Application.Exceptions;    
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteUnitCommandHandler : IRequestHandler<DeleteUnitCommand>
    {
        private readonly IUnitRepository _baseRepository;
        private readonly IMapper _mapper;
        public DeleteUnitCommandHandler(IMapper mapper, IUnitRepository baseRepository)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
        }

        public async Task<MediatR.Unit> Handle(DeleteUnitCommand request, CancellationToken cancellationToken)
        {
            var itemToDelete = await _baseRepository.GetByIdAsync(request.UnitId);

            if (itemToDelete == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.Unit), request.UnitId);
            }

            await _baseRepository.DeleteAsync(itemToDelete);

            return MediatR.Unit.Value;
        }
    }
}
