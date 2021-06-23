namespace OfiCondo.Management.Domain.Entities
{
    using OfiCondo.Management.Domain.Common;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Minute: AuditableEntity
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        [Key]
        public Guid MinuteId { get; set; }
        /// <summary>
        /// Name of the Minute.
        /// </summary>
        [Required]
        [StringLength(75)]
        public string Title { get; set; }
        /// <summary>
        /// Description of the minute.
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
        /// Relation Condominium / Minute.
        /// </summary>
        public Condominium Condominium { get; set; }
    }
}
