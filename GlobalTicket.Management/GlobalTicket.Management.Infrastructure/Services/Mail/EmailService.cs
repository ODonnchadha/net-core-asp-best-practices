namespace GlobalTicket.Management.Infrastructure.Services.Mail
{
    using GlobalTicket.Management.Application.Contracts.Infrastructure;
    using GlobalTicket.Management.Application.Models.Mail;
    using Microsoft.Extensions.Options;
    using SendGrid;
    using SendGrid.Helpers.Mail;
    using System.Threading.Tasks;

    public class EmailService : IEmailService
    {
        public EmailSettings settings;
        public EmailService(IOptions<EmailSettings> settings) => this.settings = settings.Value;

        public async Task<bool> Send(Email email)
        {
            var client = new SendGridClient(settings.ApiKey);

            var subject = email.Subject;
            var to = new EmailAddress(email.To);
            var body = email.Body;

            var from = new EmailAddress { Email = settings.FromAddress, Name = settings.FromName };
            var message = MailHelper.CreateSingleEmail(from, to, subject, body, body);

            var response = await client.SendEmailAsync(message);

            if (response.StatusCode == System.Net.HttpStatusCode.Accepted || response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }

            return false;
        }
    }
}
