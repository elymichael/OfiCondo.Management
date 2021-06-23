namespace OfiCondo.Management.Domain.Entities
{
    using OfiCondo.Management.Domain.Common;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Fee : AuditableEntity
    {
        /// <summary>
        /// Identifier of the type.
        /// </summary>
        [Key]
        public Guid FeeId { get; set; }
        /// <summary>
        /// Name of the fee type.
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Default amount.
        /// </summary>
        [Required]
        public double Amount { get; set; }
        /// <summary>
        /// Begin date of the payment.
        /// </summary>
        [Required]
        public DateTime DateBegin { get; set; }
        /// <summary>
        /// Set End date when you want to close a fee.
        /// </summary>
        public DateTime? DateEnd { get; set; }
        /// <summary>
        /// Relation between Condominium and Fee.
        /// </summary>
        [Required]
        public Guid? CondominiumId { get; set; }
        /// <summary>
        /// Relation between Fee / Condominum
        /// </summary>
        public Condominium Condominium { get; set; }
    }
}
