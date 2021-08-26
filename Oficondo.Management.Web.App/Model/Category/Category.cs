namespace Oficondo.Management.Web.App.Model.Category
{
    using System;
    public class Category
    {
    }
    public partial class CreateCategoryCommand
    {
        public string Name { get; set; }
        public Guid? AccountId { get; set; }
    }
    public partial class UpdateCategoryCommand
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public Guid? AccountId { get; set; }
    }
    public partial class CategoryDetailVm
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
    }
    public partial class CategoryListVm
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
    }
}
