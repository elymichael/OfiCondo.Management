namespace OfiCondo.Management.Application.Features.Categories.Queries.Detail
{
    using AutoMapper;
    using MediatR;
    using OfiCondo.Management.Application.Contracts.Persistence;
    using OfiCondo.Management.Domain.Entities;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetCategoryDetailQueryHandler: IRequestHandler<GetCategoryDetailQuery, CategoryDetailVm>
    {

        private readonly IAsyncRepository<Category> _baseRepository;
        private readonly IMapper _mapper;
        public GetCategoryDetailQueryHandler(IMapper mapper, IAsyncRepository<Category> baseRepository)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
        }

        public async Task<CategoryDetailVm> Handle(GetCategoryDetailQuery request, CancellationToken cancellationToken)
        {
            var @item = await _baseRepository.GetByIdAsync(request.CategoryId);
            var itemDetailDto = _mapper.Map<CategoryDetailVm>(@item);

            return itemDetailDto;
        }
    }
}
