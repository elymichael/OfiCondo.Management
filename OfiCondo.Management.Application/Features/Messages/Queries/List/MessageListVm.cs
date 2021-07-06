namespace OfiCondo.Management.Application.Features.Messages.Queries.List
{
    using System;
    public class MessageListVm
    {
        public Guid MessageId { get; set; }
        public string Description { get; set; }
        public DateTime RecordDate { get; set; }
        public Guid? CondominiumId { get; set; }
    }
}
