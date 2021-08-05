namespace OfiCondo.Management.Application.Features.Banks.Commands.Update
{
    using AutoMapper;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using OfiCondo.Management.Application.Contracts.Persistence;
    using OfiCondo.Management.Application.Exceptions;
    using OfiCondo.Management.Domain.Entities;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdateBankCommandHandler: IRequestHandler<UpdateBankCommand>
    {
        private readonly IBankRepository _baseRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateBankCommandHandler> _logger;
        public UpdateBankCommandHandler(IMapper mapper, IBankRepository baseRepository, ILogger<UpdateBankCommandHandler> logger)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
            _logger = logger;
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

            _logger.LogInformation($"{DateTime.Now:yyyyMMdd hh:mm:ss} - [{nameof(Bank)}] was update.", request);

            return MediatR.Unit.Value;
        }
    }
}
