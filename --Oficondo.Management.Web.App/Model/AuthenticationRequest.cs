namespace Oficondo.Management.Web.App.Model
{
    using System.ComponentModel.DataAnnotations;
    public class AuthenticationRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
