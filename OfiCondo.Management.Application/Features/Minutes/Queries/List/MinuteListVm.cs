namespace OfiCondo.Management.Application.Features.Minutes.Queries.List
{
    using System;
    public class MinuteListVm
    {
        public Guid MinuteId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime RecordDate { get; set; }
        public Guid? CondominiumId { get; set; }
    }
}
