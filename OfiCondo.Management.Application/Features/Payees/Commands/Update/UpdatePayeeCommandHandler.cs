namespace OfiCondo.Management.Application.Features.Payees.Commands.Update
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

    public class UpdatePayeeCommandHandler : IRequestHandler<UpdatePayeeCommand>
    {
        private readonly IPayeeRepository _baseRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdatePayeeCommandHandler> _logger;
        public UpdatePayeeCommandHandler(IMapper mapper, IPayeeRepository baseRepository, ILogger<UpdatePayeeCommandHandler> logger)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<MediatR.Unit> Handle(UpdatePayeeCommand request, CancellationToken cancellationToken)
        {
            var eventToUpdate = await _baseRepository.GetByIdAsync(request.PayeeId);

            if (eventToUpdate == null)
            {
                throw new NotFoundException(nameof(Bank), request.PayeeId);
            }

            var validator = new UpdatePayeeCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);

            if (validatorResult.Errors.Count > 0)
                throw new ValidationException(validatorResult);

            _mapper.Map(request, eventToUpdate, typeof(UpdatePayeeCommand), typeof(Payee));

            await _baseRepository.UpdateAsync(eventToUpdate);

            _logger.LogInformation($"{DateTime.Now:yyyyMMdd hh:mm:ss} - [{nameof(Payee)}] was updated.", request);

            return MediatR.Unit.Value;
        }
    }
}
