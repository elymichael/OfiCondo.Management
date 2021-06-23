namespace OfiCondo.Management.Infrastructure.Mail
{
    using OfiCondo.Management.Application.Contracts.Infrastructure;
    using OfiCondo.Management.Application.Models.Mail;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using SendGrid;
    using SendGrid.Helpers.Mail;
    using System.Threading.Tasks;

    public class EmailService : IEmailService
    {
        public readonly EmailSettings _emailSettings;
        public readonly ILogger<EmailService> _logger;
        public EmailService(IOptions<EmailSettings> mailSettings, ILogger<EmailService> logger)
        {
            _emailSettings = mailSettings.Value;
            _logger = logger;
        }
        public async Task<bool> SendEmail(Email email)
        {
            var client = new SendGridClient(_emailSettings.ApiKey);
            var subject = email.Subject;
            var to = new EmailAddress(email.To);
            var emailBody = email.Body;

            var from = new EmailAddress
            {
                Email = _emailSettings.FromAddress,
                Name = _emailSettings.FromName
            };

            var sendGridMessage = MailHelper.CreateSingleEmail(from, to, subject, emailBody, emailBody);
            var response = await client.SendEmailAsync(sendGridMessage);

            _logger.LogInformation("Email Sent");

            if (response.StatusCode == System.Net.HttpStatusCode.Accepted || response.StatusCode == System.Net.HttpStatusCode.OK)
                return true;

            _logger.LogError("Email sending failed");

            return false;
        }
    }
}
