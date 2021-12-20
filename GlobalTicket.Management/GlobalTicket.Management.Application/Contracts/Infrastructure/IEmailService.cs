namespace GlobalTicket.Management.Application.Contracts.Infrastructure
{
    using GlobalTicket.Management.Application.Models.Mail;
    using System.Threading.Tasks;

    public interface IEmailService
    {
        Task<bool> Send(Email email);
    }
}
