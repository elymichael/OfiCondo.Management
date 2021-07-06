namespace OfiCondo.Management.Application.Features.Messages.Queries.Detail
{
    using MediatR;
    using System;

    public class GetMessageDetailQuery : IRequest<MessageDetailVm>
    {
        public Guid MessageId { get; set; }
    }
}
