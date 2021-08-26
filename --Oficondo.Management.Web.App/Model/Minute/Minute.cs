namespace Oficondo.Management.Web.App.Model.Minute
{
    using System;
    public class Minute
    {
    }
    public partial class CreateMinuteCommand
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset RecordDate { get; set; }
        public Guid? CondominiumId { get; set; }
    }
    public partial class UpdateMinuteCommand
    {
        public Guid MinuteId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset RecordDate { get; set; }
        public Guid? CondominiumId { get; set; }
    }
    public partial class MinuteDetailVm
    {
        public Guid MinuteId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset RecordDate { get; set; }
        public Guid? CondominiumId { get; set; }
    }
    public partial class MinuteListVm
    {
        public Guid MinuteId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset RecordDate { get; set; }
        public Guid? CondominiumId { get; set; }
    }
}
