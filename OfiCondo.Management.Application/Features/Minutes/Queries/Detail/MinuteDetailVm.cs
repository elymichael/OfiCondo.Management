namespace OfiCondo.Management.Application.Features.Minutes.Queries.Detail
{
    using System;
    public class MinuteDetailVm
    {
        public Guid MinuteId { get; set; }        
        public string Title { get; set; }        
        public string Description { get; set; }        
        public DateTime RecordDate { get; set; }        
        public Guid? CondominiumId { get; set; }
    }
}
