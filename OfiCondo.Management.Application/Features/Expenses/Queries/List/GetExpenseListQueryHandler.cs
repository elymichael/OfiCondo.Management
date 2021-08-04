namespace OfiCondo.Management.Application.Features.Expenses.Queries.List
{
    using AutoMapper;
    using MediatR;
    using OfiCondo.Management.Application.Contracts.Persistence;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetExpenseListQueryHandler : IRequestHandler<GetExpenseListQuery, List<ExpenseListVm>>
    {
        private readonly IExpenseRepository _baseRepository;
        private readonly IMapper _mapper;

        public GetExpenseListQueryHandler(IMapper mapper, IExpenseRepository baseRepository)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
        }

        public async Task<List<ExpenseListVm>> Handle(GetExpenseListQuery request, CancellationToken cancellationToken)
        {
            var records = (await _baseRepository.ListAllAsync()).OrderBy(x => x.RecordDate);
            return _mapper.Map<List<ExpenseListVm>>(records);
        }
    }
}
