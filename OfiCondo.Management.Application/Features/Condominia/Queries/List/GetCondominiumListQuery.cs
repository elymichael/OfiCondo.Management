namespace OfiCondo.Management.Application.Features.Condominia.Queries.List
{
    using MediatR;
    using System.Collections.Generic;
    public class GetCondominiumListQuery : IRequest<List<CondominiumListVm>>
    {
    }
}
