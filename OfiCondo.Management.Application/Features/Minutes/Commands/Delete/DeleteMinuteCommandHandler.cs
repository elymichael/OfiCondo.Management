using System;
using System.Collections.Generic;
using System.Text;

namespace OfiCondo.Management.Application.Features.Minutes.Commands.Delete
{
    using AutoMapper;
    using MediatR;
    using OfiCondo.Management.Application.Contracts.Persistence;
    using OfiCondo.Management.Application.Exceptions;
    using OfiCondo.Management.Domain.Entities;
    using System.Threading;
    using System.Threading.Tasks;
    public class DeleteMinuteCommandHandler : IRequestHandler<DeleteMinuteCommand>
    {
        private readonly IAsyncRepository<Minute> _baseRepository;
        private readonly IMapper _mapper;
        public DeleteMinuteCommandHandler(IMapper mapper, IAsyncRepository<Minute> baseRepository)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
        }
        public async Task<MediatR.Unit> Handle(DeleteMinuteCommand request, CancellationToken cancellationToken)
        {
            var itemToDelete = await _baseRepository.GetByIdAsync(request.MinuteId);

            if (itemToDelete == null)
            {
                throw new NotFoundException(nameof(Minute), request.MinuteId);
            }

            await _baseRepository.DeleteAsync(itemToDelete);

            return MediatR.Unit.Value;
        }
    }
}
