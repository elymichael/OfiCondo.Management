namespace OfiCondo.Management.Application.Features.Incomes.Commands.Delete
{
    using AutoMapper;
    using MediatR;
    using OfiCondo.Management.Application.Contracts.Persistence;
    using OfiCondo.Management.Application.Exceptions;
    using OfiCondo.Management.Domain.Entities;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteIncomeCommandHandler: IRequestHandler<DeleteIncomeCommand>
    {
        private readonly IIncomeRepository _baseRepository;
        private readonly IMapper _mapper;
        public DeleteIncomeCommandHandler(IMapper mapper, IIncomeRepository baseRepository)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
        }

        public async Task<MediatR.Unit> Handle(DeleteIncomeCommand request, CancellationToken cancellationToken)
        {
            var itemToDelete = await _baseRepository.GetByIdAsync(request.IncomeId);

            if (itemToDelete == null)
            {
                throw new NotFoundException(nameof(Income), request.IncomeId);
            }

            await _baseRepository.DeleteAsync(itemToDelete);

            return MediatR.Unit.Value;
        }
    }
}
