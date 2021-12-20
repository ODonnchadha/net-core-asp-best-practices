namespace GlobalTicket.Management.Infrastructure
{
    using GlobalTicket.Management.Application.Contracts.Infrastructure;
    using GlobalTicket.Management.Application.Models.Mail;
    using GlobalTicket.Management.Infrastructure.Services.Mail;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}
