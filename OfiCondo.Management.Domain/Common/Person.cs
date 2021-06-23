namespace OfiCondo.Management.Domain.Common
{
    using System.ComponentModel.DataAnnotations;
    /// <summary>
    /// Person Name.
    /// </summary>
    public abstract class Person: AuditableEntity
    {
        /// <summary>
        /// Name of the person.
        /// </summary>        
        [Required]
        [StringLength(75)]
        public string Name { get; set; }
        /// <summary>
        /// Phone.
        /// </summary>
        [StringLength(20)]
        public string Phone { get; set; }
        /// <summary>
        /// Email address.
        /// </summary>
        [EmailAddress]
        public string Email { get; set; }
    }
}
