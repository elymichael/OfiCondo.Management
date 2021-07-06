namespace OfiCondo.Management.Application.Features.Messages.Queries.Detail
{
    using System;
    public class MessageDetailVm
    {
        public Guid MessageId { get; set; }
        public string Description { get; set; }
        public DateTime RecordDate { get; set; }
        public Guid? CondominiumId { get; set; }
    }
}
