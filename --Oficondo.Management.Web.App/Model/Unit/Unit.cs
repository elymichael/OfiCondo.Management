namespace Oficondo.Management.Web.App.Model.Unit
{
    using System;
    public class Unit
    {
    }
    public partial class CreateUnitCommand
    {
        public string Name { get; set; }
        public Guid CondominiumId { get; set; }


    }
    public partial class UpdateUnitCommand
    {
        public Guid UnitId { get; set; }
     
        public string Name { get; set; }

        public Guid? OwnerId { get; set; }

        public Guid CondominiumId { get; set; }
    }
    public partial class UnitListVm
    {
        public Guid UnitId { get; set; }
        public string Name { get; set; }
        public Guid? OwnerId { get; set; }
        public Guid CondominiumId { get; set; }
    }
    public partial class UnitDetailVm
    {
        public Guid UnitId { get; set; }
        public string Name { get; set; }
        public Guid? OwnerId { get; set; }
        public Guid CondominiumId { get; set; }


    }
}
