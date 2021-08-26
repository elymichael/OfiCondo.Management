namespace Oficondo.Management.Web.App.Model.Condominium
{
    using System;
    public class Condominium
    {
    }
    public partial class CreateCondominiumCommand
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Quantity { get; set; }
        public Guid? AccountId { get; set; }
    }
    public partial class UpdateCondominiumCommand
    {
        public Guid CondominiumId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Quantity { get; set; }
        public Guid? AccountId { get; set; }
    }
    public partial class CondominiumDetailVm
    {
        public Guid CondominiumId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Quantity { get; set; }
    }
    public partial class CondominiumListVm
    {
        public Guid CondominiumId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Quantity { get; set; }


    }
}
