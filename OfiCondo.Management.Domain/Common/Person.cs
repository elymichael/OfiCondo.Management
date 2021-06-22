namespace OfiCondo.Management.Domain.Common
{
    /// <summary>
    /// Person Name.
    /// </summary>
    public abstract class Person
    {
        /// <summary>
        /// Name of the person.
        /// </summary>        
        public string Name { get; set; }
        /// <summary>
        /// Phone.
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Email address.
        /// </summary>
        public string Email { get; set; }
    }
}
