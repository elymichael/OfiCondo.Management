namespace OfiCondo.Management.Application.Features.Condominia.Queries.Detail
{
    using MediatR;
    using System;
    public class GetCondominiumDetailQuery: IRequest<CondominiumDetailVm>
    {
        public Guid CondominiumId { get; set; }
    }
}
