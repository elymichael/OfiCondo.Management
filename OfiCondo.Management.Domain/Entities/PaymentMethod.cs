namespace OfiCondo.Management.Domain.Entities
{
    using OfiCondo.Management.Domain.Common;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class PaymentMethod: AuditableEntity
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        [Key]
        public int PaymentMethodId { get; set; }
        /// <summary>
        /// Name of Payment Method.
        /// </summary>
        [Required]
        [StringLength(75)]
        public String Name { get; set; }
    }
}
