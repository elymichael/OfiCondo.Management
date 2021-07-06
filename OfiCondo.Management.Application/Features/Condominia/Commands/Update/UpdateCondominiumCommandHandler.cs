namespace OfiCondo.Management.Application.Features.Condominia.Commands.Update
{
    using AutoMapper;
    using MediatR;
    using OfiCondo.Management.Application.Contracts.Persistence;
    using OfiCondo.Management.Application.Exceptions;
    using OfiCondo.Management.Domain.Entities;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdateBankCommandHandler : IRequestHandler<UpdateCondominiumCommand>
    {
        private readonly ICondominiumRepository _baseRepository;
        private readonly IMapper _mapper;
        public UpdateBankCommandHandler(IMapper mapper, ICondominiumRepository baseRepository)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<MediatR.Unit> Handle(UpdateCondominiumCommand request, CancellationToken cancellationToken)
        {
            var eventToUpdate = await _baseRepository.GetByIdAsync(request.CondominiumId);

            if (eventToUpdate == null)
            {
                throw new NotFoundException(nameof(Condominium), request.CondominiumId);
            }

            var validator = new UpdateCondominiumCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);

            if (validatorResult.Errors.Count > 0)
                throw new ValidationException(validatorResult);

            _mapper.Map(request, eventToUpdate, typeof(UpdateCondominiumCommand), typeof(Condominium));

            await _baseRepository.UpdateAsync(eventToUpdate);

            return MediatR.Unit.Value;
        }
    }
}
