namespace OfiCondo.Management.Application.Models.Authentication
{
    public class AuthorizedUsers
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public bool EmailConfirmed { get; set; } 
        public string Id { get; set; } 
        public string FirstName { get; set; } 
        public string LastName { get; set; }
    }
}
