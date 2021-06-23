namespace OfiCondo.Management.Domain.Entities
{
    using OfiCondo.Management.Domain.Common;
    using System;
    using System.ComponentModel.DataAnnotations;
    /// <summary>
    /// Payee of the class.
    /// </summary>
    public class Payee: Person
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        [Key]
        public Guid PayeeId { get; set; }
        /// <summary>
        /// Account number.
        /// </summary>
        [Required]
        public string AccountNumber { get; set; }
        /// <summary>
        /// Relation between Account and Blocks.
        /// </summary>
        public Guid AccountId { get; set; }
        /// <summary>
        /// Relation Payee / Account.
        /// </summary>
        public Account Account { get; set; }
    }
}
