namespace OfiCondo.Management.Application.Contracts.Infrastructure
{
    using OfiCondo.Management.Application.Models.Mail;
    using System.Threading.Tasks;
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
