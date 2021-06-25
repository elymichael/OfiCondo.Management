namespace OfiCondo.Management.Application.Features.Categories.Commands.Delete
{
    using MediatR;
    using System;
    public class DeleteCategoryCommand: IRequest
    {
        public Guid CategoryId { get; set; }
    }
}
