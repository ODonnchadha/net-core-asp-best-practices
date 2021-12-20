namespace GlobalTicket.Management.Persistence
{
    using GlobalTicket.Management.Application.Contracts.Persistence;
    using GlobalTicket.Management.Persistence.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GlobalTicketDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("GlobalTicketManagementConnectionString"));
            });

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
