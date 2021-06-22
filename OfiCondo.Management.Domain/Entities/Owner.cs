namespace OfiCondo.Management.Domain.Entities
{
    using OfiCondo.Management.Domain.Common;
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
        public string Id { get; set; }
    }
}
