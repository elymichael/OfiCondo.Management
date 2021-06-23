namespace OfiCondo.Management.Domain.Entities
{
    using OfiCondo.Management.Domain.Common;
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Owner of the unit.
    /// </summary>
    public class Owner : Person
    {
        /// <summary>
        /// Identifier for GUID.
        /// </summary>        
        [Key]
        public Guid OwnerId { get; set; }
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
