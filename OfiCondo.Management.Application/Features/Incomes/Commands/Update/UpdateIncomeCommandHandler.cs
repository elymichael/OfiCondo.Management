namespace OfiCondo.Management.Application.Features.Incomes.Commands.Update
{
    using AutoMapper;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using OfiCondo.Management.Application.Contracts.Infrastructure;
    using OfiCondo.Management.Application.Contracts.Persistence;
    using OfiCondo.Management.Application.Exceptions;
    using OfiCondo.Management.Domain.Entities;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdateIncomeCommandHandler : IRequestHandler<UpdateIncomeCommand>
    {
        private readonly IIncomeRepository _baseRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<UpdateIncomeCommandHandler> _logger;
        public UpdateIncomeCommandHandler(IIncomeRepository baseRepository, IMapper mapper, IEmailService emailService, ILogger<UpdateIncomeCommandHandler> logger)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<MediatR.Unit> Handle(UpdateIncomeCommand request, CancellationToken cancellationToken)
        {
            var eventToUpdate = await _baseRepository.GetByIdAsync(request.IncomeId);

            if (eventToUpdate == null)
            {
                throw new NotFoundException(nameof(Income), request.IncomeId);
            }

            var validator = new UpdateIncomeCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);

            if (validatorResult.Errors.Count > 0)
                throw new ValidationException(validatorResult);

            _mapper.Map(request, eventToUpdate, typeof(UpdateIncomeCommand), typeof(Bank));

            await _baseRepository.UpdateAsync(eventToUpdate);

            _logger.LogInformation($"{DateTime.Now:yyyyMMdd hh:mm:ss} - [{nameof(Income)}] was updated.", request);

            return MediatR.Unit.Value;
        }
    }
}
