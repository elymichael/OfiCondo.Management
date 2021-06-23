using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OfiCondo.Management.Domain.Entities
{
    public class Unit
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        [Key]
        public Guid UnitId { get; set; }
        /// <summary>
        /// Name of the unit (apartment) (ex. "Apto 3A").
        /// </summary>
        [Required]
        [StringLength(75)]
        public string Name { get; set; }
        /// <summary>
        /// Owner of the unit (apartment).
        /// </summary>        
        [Required]
        public Guid OwnerId { get; set; }
        /// <summary>
        /// Owner relation.
        /// </summary>
        public Owner Owner { get; set; }
        /// <summary>
        /// Relation between Blocks and Units.
        /// </summary>
        public Guid CondominiumId { get; set; }
        /// <summary>
        /// Condominium relation.
        /// </summary>
        public Condominium Condominium { get; set; }
    }
}
