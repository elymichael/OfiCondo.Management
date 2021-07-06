using System;
using System.Collections.Generic;
using System.Text;

namespace OfiCondo.Management.Application.Features.Minutes.Commands.Update
{
    using AutoMapper;
    using MediatR;
    using OfiCondo.Management.Application.Contracts.Persistence;
    using OfiCondo.Management.Application.Exceptions;
    using OfiCondo.Management.Domain.Entities;
    using System.Threading;
    using System.Threading.Tasks;
    public class UpdateMinuteCommandHandler : IRequestHandler<UpdateMinuteCommand>
    {
        private readonly IAsyncRepository<Minute> _baseRepository;
        private readonly IMapper _mapper;
        public UpdateMinuteCommandHandler(IMapper mapper, IAsyncRepository<Minute> baseRepository)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
        }

        public async Task<MediatR.Unit> Handle(UpdateMinuteCommand request, CancellationToken cancellationToken)
        {
            var itemToUpdate = await _baseRepository.GetByIdAsync(request.MinuteId);

            if (itemToUpdate == null)
            {
                throw new NotFoundException(nameof(Minute), request.MinuteId);
            }

            var validator = new UpdateMinuteCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);

            if (validatorResult.Errors.Count > 0)
                throw new ValidationException(validatorResult);

            _mapper.Map(request, itemToUpdate, typeof(UpdateMinuteCommand), typeof(Minute));

            await _baseRepository.UpdateAsync(itemToUpdate);

            return MediatR.Unit.Value;
        }
    }
}
