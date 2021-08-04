namespace OfiCondo.Management.Application.Features.Expenses.Queries.Detail
{
    using AutoMapper;
    using MediatR;
    using OfiCondo.Management.Application.Contracts.Persistence;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetExpenseDetailQueryHandler : IRequestHandler<GetExpenseDetailQuery, ExpenseDetailVm>
    {
        private readonly IExpenseRepository _baseRepository;
        private readonly IMapper _mapper;
        public GetExpenseDetailQueryHandler(IMapper mapper, IExpenseRepository baseRepository)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<ExpenseDetailVm> Handle(GetExpenseDetailQuery request, CancellationToken cancellationToken)
        {
            var @item = await _baseRepository.GetByIdAsync(request.ExpenseId);
            var itemDetailDto = _mapper.Map<ExpenseDetailVm>(@item);

            return itemDetailDto;
        }
    }
}
