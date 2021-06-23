namespace OfiCondo.Management.Domain.Entities
{
    using OfiCondo.Management.Domain.Common;
    using System;
    using System.ComponentModel.DataAnnotations;
    public class Income: AuditableEntity
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        [Key]
        public Guid IncomeId { get; set; }
        /// <summary>
        /// Record's date.
        /// </summary>
        [Required]
        public DateTime RecordDate { get; set; }
        /// <summary>
        /// Income's Amount.
        /// </summary>
        [Required]
        public double Amount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public Guid FeeId { get; set; }
        /// <summary>
        /// Relation Fee / Income.
        /// </summary>
        public Fee Fee { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Guid? UnitId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Unit Unit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(800)]
        public string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Guid? AttachmentId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Attachment Attachment { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Guid? CondominiumId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Condominium Condominium { get; set; }
    }
}
