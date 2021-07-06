using System;
using System.Collections.Generic;
using System.Text;

namespace OfiCondo.Management.Application.Features.Units.Queries.Detail
{
    using AutoMapper;
    using MediatR;
    using OfiCondo.Management.Application.Contracts.Persistence;
    using OfiCondo.Management.Domain.Entities;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetUnitDetailQueryHandler : IRequestHandler<GetUnitDetailQuery, UnitDetailVm>
    {
        private readonly IUnitRepository _baseRepository;
        private readonly IMapper _mapper;
        public GetUnitDetailQueryHandler(IMapper mapper, IUnitRepository baseRepository)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<UnitDetailVm> Handle(GetUnitDetailQuery request, CancellationToken cancellationToken)
        {
            var @item = await _baseRepository.GetByIdAsync(request.UnitId);
            var itemDetailDto = _mapper.Map<UnitDetailVm>(@item);

            return itemDetailDto;
        }
    }
}
