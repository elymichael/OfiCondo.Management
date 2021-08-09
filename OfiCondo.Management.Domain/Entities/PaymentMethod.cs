namespace OfiCondo.Management.Domain.Entities
{
    using OfiCondo.Management.Domain.Common;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PaymentMethod: AuditableEntity
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PaymentMethodId { get; set; }
        /// <summary>
        /// Name of Payment Method.
        /// </summary>
        [Required]
        [StringLength(75)]
        public String Name { get; set; }
    }
}
