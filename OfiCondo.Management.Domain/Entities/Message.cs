namespace OfiCondo.Management.Domain.Entities
{
    using OfiCondo.Management.Domain.Common;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Message: AuditableEntity
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        [Key]
        public Guid MessageId { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        [Required]
        [StringLength(800)]
        public string Description { get; set; }
        /// <summary>
        /// Creation date.
        /// </summary>
        [Required]
        public DateTime RecordDate { get; set; }        
        /// <summary>
        /// Relation between Blocks and Units.
        /// </summary>
        public Guid? CondominiumId { get; set; }
        /// <summary>
        /// Relation condominiun / Message.
        /// </summary>
        public Condominium Condominium { get; set; }
    }
}
