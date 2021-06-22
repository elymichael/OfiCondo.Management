namespace OfiCondo.Management.Domain.Entities
{
    using OfiCondo.Management.Domain.Common;
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
        public string Id { get; set; }
    }
}
