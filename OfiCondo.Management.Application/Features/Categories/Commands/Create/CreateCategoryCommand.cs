namespace OfiCondo.Management.Application.Features.Categories.Commands.Create
{
    using MediatR;
    using System;
    public class  CreateCategoryCommand: IRequest<Guid>
    {
        public string Name { get; set; }        
        public Guid? AccountId { get; set; }
    }
}
