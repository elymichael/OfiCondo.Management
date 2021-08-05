namespace OfiCondo.Management.Application.Features.Fees.Commands.Update
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

    public class UpdateFeeCommandHandler : IRequestHandler<UpdateFeeCommand>
    {
        private readonly IFeeRepository _baseRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateFeeCommandHandler> _logger;
        public UpdateFeeCommandHandler(IMapper mapper, IFeeRepository baseRepository, ILogger<UpdateFeeCommandHandler> logger)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<MediatR.Unit> Handle(UpdateFeeCommand request, CancellationToken cancellationToken)
        {
            var eventToUpdate = await _baseRepository.GetByIdAsync(request.FeeId);

            if (eventToUpdate == null)
            {
                throw new NotFoundException(nameof(Fee), request.FeeId);
            }

            var validator = new UpdateFeeCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);

            if (validatorResult.Errors.Count > 0)
                throw new ValidationException(validatorResult);

            _mapper.Map(request, eventToUpdate, typeof(UpdateFeeCommand), typeof(Fee));

            await _baseRepository.UpdateAsync(eventToUpdate);

            _logger.LogInformation($"{DateTime.Now:yyyyMMdd hh:mm:ss} - [{nameof(Fee)}] was updated.", request);

            return MediatR.Unit.Value;
        }
    }
}
