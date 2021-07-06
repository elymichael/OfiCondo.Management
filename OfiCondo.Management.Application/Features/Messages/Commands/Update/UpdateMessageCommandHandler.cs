using System;
using System.Collections.Generic;
using System.Text;

namespace OfiCondo.Management.Application.Features.Messages.Commands.Update
{
    using AutoMapper;
    using MediatR;
    using OfiCondo.Management.Application.Contracts.Persistence;
    using OfiCondo.Management.Application.Exceptions;
    using OfiCondo.Management.Domain.Entities;
    using System.Threading;
    using System.Threading.Tasks;
    public class UpdateMessageCommandHandler : IRequestHandler<UpdateMessageCommand>
    {
        private readonly IAsyncRepository<Message> _baseRepository;
        private readonly IMapper _mapper;
        public UpdateMessageCommandHandler(IMapper mapper, IAsyncRepository<Message> baseRepository)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
        }

        public async Task<MediatR.Unit> Handle(UpdateMessageCommand request, CancellationToken cancellationToken)
        {
            var itemToUpdate = await _baseRepository.GetByIdAsync(request.MessageId);

            if (itemToUpdate == null)
            {
                throw new NotFoundException(nameof(Message), request.MessageId);
            }

            var validator = new UpdateMessageCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);

            if (validatorResult.Errors.Count > 0)
                throw new ValidationException(validatorResult);

            _mapper.Map(request, itemToUpdate, typeof(UpdateMessageCommand), typeof(Message));

            await _baseRepository.UpdateAsync(itemToUpdate);

            return MediatR.Unit.Value;
        }
    }
}
