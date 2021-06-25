namespace OfiCondo.Management.Application.Features.Categories.Queries.List
{
    using MediatR;
    using System.Collections.Generic;

    public class GetCategoryListQuery: IRequest<List<CategoryListVm>>
    {
    }
}
