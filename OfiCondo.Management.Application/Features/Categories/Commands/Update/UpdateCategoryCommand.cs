namespace OfiCondo.Management.Application.Features.Categories.Commands.Update
{
    using MediatR;
    using System;
    public class UpdateCategoryCommand: IRequest
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public Guid? AccountId { get; set; }
    }
}
