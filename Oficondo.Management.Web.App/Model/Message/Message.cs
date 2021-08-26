namespace Oficondo.Management.Web.App.Model.Message
{
    using System;
    public class Message
    {
    }
    public partial class CreateMessageCommand
    {
        public string Description { get; set; }
        public DateTimeOffset RecordDate { get; set; }
        public Guid? CondominiumId { get; set; }
    }
    public partial class UpdateMessageCommand
    {
        public Guid MessageId { get; set; }
        public string Description { get; set; }
        public DateTimeOffset RecordDate { get; set; }        
        public Guid? CondominiumId { get; set; }
    }
    public partial class MessageDetailVm
    {
        public Guid MessageId { get; set; }
        public string Description { get; set; }
        public DateTimeOffset RecordDate { get; set; }
        public Guid? CondominiumId { get; set; }
    }
    public partial class MessageListVm
    {
        public Guid MessageId { get; set; }
        public string Description { get; set; }
        public DateTimeOffset RecordDate { get; set; }
        public Guid? CondominiumId { get; set; }
    }
}
