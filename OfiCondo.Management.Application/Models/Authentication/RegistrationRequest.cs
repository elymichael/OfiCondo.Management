namespace OfiCondo.Management.Application.Models.Authentication
{
    using System.ComponentModel.DataAnnotations;
    public class RegistrationRequest
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        public string UserName { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }        
        [MinLength(10), MaxLength(20)]
        public string Phone { get; set; }
    }
}
