namespace OfiCondo.Management.Application.Features.Categories.Queries.Detail
{
    using MediatR;
    using System;

    public class GetCategoryDetailQuery: IRequest<CategoryDetailVm>
    {
        public Guid CategoryId { get; set; }
    }
}
