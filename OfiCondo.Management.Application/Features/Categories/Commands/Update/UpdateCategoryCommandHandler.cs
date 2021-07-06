namespace OfiCondo.Management.Application.Features.Categories.Commands.Update
{
    using AutoMapper;
    using MediatR;
    using OfiCondo.Management.Application.Contracts.Persistence;
    using OfiCondo.Management.Application.Exceptions;
    using OfiCondo.Management.Domain.Entities;
    using System.Threading;
    using System.Threading.Tasks;
    public class UpdateCategoryCommandHandler: IRequestHandler<UpdateCategoryCommand>
    {
        private readonly IAsyncRepository<Category> _baseRepository;
        private readonly IMapper _mapper;
        public UpdateCategoryCommandHandler(IMapper mapper, IAsyncRepository<Category> baseRepository)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
        }

        public async Task<MediatR.Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var itemToUpdate = await _baseRepository.GetByIdAsync(request.CategoryId);

            if (itemToUpdate == null)
            {
                throw new NotFoundException(nameof(Category), request.CategoryId);
            }

            var validator = new UpdateCategoryCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);

            if (validatorResult.Errors.Count > 0)
                throw new ValidationException(validatorResult);

            _mapper.Map(request, itemToUpdate, typeof(UpdateCategoryCommand), typeof(Category));

            await _baseRepository.UpdateAsync(itemToUpdate);

            return MediatR.Unit.Value;
        }
    }
}
