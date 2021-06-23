namespace OfiCondo.Management.Domain.Entities
{
    using OfiCondo.Management.Domain.Common;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Bank: AuditableEntity
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        [Key]
        public Guid BankId { get; set; }
        /// <summary>
        /// Name of the bank.
        /// </summary>
        [Required]
        [StringLength(75)]
        public string Name { get; set; }
        /// <summary>
        /// Account number.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string AccountNumber { get; set; }
        /// <summary>
        /// Short description.
        /// </summary>
        [StringLength(800)]
        public string Description { get; set; }
        /// <summary>
        /// Id of the main account.
        /// </summary>
        public Guid? AccountId { get; set; }
        /// <summary>
        /// Account.
        /// </summary>
        public Account Account { get; set; }
    }
}
