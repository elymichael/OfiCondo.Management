namespace OfiCondo.Management.Application.Features.Condominia.Commands.Delete
{
    using AutoMapper;
    using MediatR;
    using OfiCondo.Management.Application.Contracts.Persistence;
    using OfiCondo.Management.Application.Exceptions;
    using OfiCondo.Management.Domain.Entities;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteCondominiumCommandHandler : IRequestHandler<DeleteCondominiumCommand>
    {
        private readonly ICondominiumRepository _baseRepository;
        private readonly IMapper _mapper;
        public DeleteCondominiumCommandHandler(IMapper mapper, ICondominiumRepository baseRepository)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
        }

        public async Task<MediatR.Unit> Handle(DeleteCondominiumCommand request, CancellationToken cancellationToken)
        {
            var itemToDelete = await _baseRepository.GetByIdAsync(request.CondominiumId);

            if (itemToDelete == null)
            {
                throw new NotFoundException(nameof(Condominium), request.CondominiumId);
            }

            await _baseRepository.DeleteAsync(itemToDelete);

            return MediatR.Unit.Value;
        }
    }
}
