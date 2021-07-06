namespace OfiCondo.Management.Application.Features.Banks.Commands.Update
{
    using AutoMapper;
    using MediatR;
    using OfiCondo.Management.Application.Contracts.Persistence;
    using OfiCondo.Management.Application.Exceptions;
    using OfiCondo.Management.Domain.Entities;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdateBankCommandHandler: IRequestHandler<UpdateBankCommand>
    {
        private readonly IBankRepository _baseRepository;
        private readonly IMapper _mapper;
        public UpdateBankCommandHandler(IMapper mapper, IBankRepository baseRepository)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<MediatR.Unit> Handle(UpdateBankCommand request, CancellationToken cancellationToken)
        {
            var eventToUpdate = await _baseRepository.GetByIdAsync(request.BankId);

            if (eventToUpdate == null)
            {
                throw new NotFoundException(nameof(Bank), request.BankId);
            }

            var validator = new UpdateBankCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);

            if (validatorResult.Errors.Count > 0)
                throw new ValidationException(validatorResult);

            _mapper.Map(request, eventToUpdate, typeof(UpdateBankCommand), typeof(Bank));

            await _baseRepository.UpdateAsync(eventToUpdate);

            return MediatR.Unit.Value;
        }
    }
}
