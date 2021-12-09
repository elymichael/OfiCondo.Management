namespace OfiCondo.Management.Application.Models.Authentication
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class UserInfo
    {
        [Required]
        public Guid UserId { get; set; }
        
        [Phone]
        [MinLength(10), MaxLength(20)]
        public string Phone { get; set; }
    }
}
