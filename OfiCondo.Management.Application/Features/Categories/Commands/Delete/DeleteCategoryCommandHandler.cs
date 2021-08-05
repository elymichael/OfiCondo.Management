namespace OfiCondo.Management.Application.Features.Categories.Commands.Delete
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
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IAsyncRepository<Category> _baseRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteCategoryCommandHandler> _logger;
        public DeleteCategoryCommandHandler(IMapper mapper, IAsyncRepository<Category> baseRepository, ILogger<DeleteCategoryCommandHandler> logger)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
            _logger = logger;
        }
        public async Task<MediatR.Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var itemToDelete = await _baseRepository.GetByIdAsync(request.CategoryId);

            if (itemToDelete == null)
            {
                throw new NotFoundException(nameof(Category), request.CategoryId);
            }

            await _baseRepository.DeleteAsync(itemToDelete);

            _logger.LogInformation($"{DateTime.Now:yyyyMMdd hh:mm:ss} - [{nameof(Category)}] was deleted.", request);

            return MediatR.Unit.Value;
        }
    }
}
