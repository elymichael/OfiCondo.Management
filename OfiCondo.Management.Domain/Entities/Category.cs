
namespace OfiCondo.Management.Domain.Entities
{
    using OfiCondo.Management.Domain.Common;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Category: AuditableEntity
    {
        /// <summary>
        /// Identifier
        /// </summary>
        [Key]
        public Guid CategoryId { get; set; }
        /// <summary>
        /// Name of the category.
        /// </summary>
        [Required]
        [StringLength(75)]
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Guid? AccountId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Account Account { get; set; }
    }
}
