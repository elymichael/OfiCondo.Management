namespace OfiCondo.Management.Domain.Entities
{
    using OfiCondo.Management.Domain.Common;
    using System.ComponentModel.DataAnnotations;
    /// <summary>
    /// Payee of the class.
    /// </summary>
    public class Payee: Person
    {
        /// <summary>
        /// Account number.
        /// </summary>
        [Key]
        public string AccountNumber { get; set; }
        /// <summary>
        /// Relation between Account and Blocks.
        /// </summary>
        public string Account_Id { get; set; }
    }
}
