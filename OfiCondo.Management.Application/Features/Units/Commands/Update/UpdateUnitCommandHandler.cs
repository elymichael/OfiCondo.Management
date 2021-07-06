namespace OfiCondo.Management.Application.Features.Units.Commands.Update
{
    using AutoMapper;
    using MediatR;
    using OfiCondo.Management.Application.Contracts.Persistence;
    using OfiCondo.Management.Application.Exceptions;    
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdateUnitCommandHandler : IRequestHandler<UpdateUnitCommand>
    {
        private readonly IUnitRepository _baseRepository;
        private readonly IMapper _mapper;
        public UpdateUnitCommandHandler(IMapper mapper, IUnitRepository baseRepository)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<MediatR.Unit> Handle(UpdateUnitCommand request, CancellationToken cancellationToken)
        {
            var eventToUpdate = await _baseRepository.GetByIdAsync(request.UnitId);

            if (eventToUpdate == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.Unit), request.UnitId);
            }

            var validator = new UpdateUnitCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);

            if (validatorResult.Errors.Count > 0)
                throw new ValidationException(validatorResult);

            _mapper.Map(request, eventToUpdate, typeof(UpdateUnitCommand), typeof(Domain.Entities.Unit));

            await _baseRepository.UpdateAsync(eventToUpdate);

            return MediatR.Unit.Value;
        }
    }
}
