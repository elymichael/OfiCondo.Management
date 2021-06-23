namespace OfiCondo.Management.Domain.Entities
{
    using OfiCondo.Management.Domain.Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Name of the main account of the records, everything is related to an account.
    /// </summary>
    public class Account : Person
    {
        /// <summary>
        /// Identifier for GUID.
        /// </summary>        
        [Key]
        public Guid AccountId { get; set; }
        /// <summary>
        /// list of bank accounts.
        /// </summary>
        public ICollection<Bank> Banks { get; set; }
        /// <summary>
        /// List of categories related to expenses.
        /// </summary>
        public ICollection<Category> Categories { get; set; }
        /// <summary>
        /// List of condominium.
        /// </summary>
        public ICollection<Condominium> Condominia { get; set; }
    }
}
