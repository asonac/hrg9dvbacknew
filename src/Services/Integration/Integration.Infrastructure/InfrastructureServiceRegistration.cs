using Integration.Application.Contracts.Infrastructure;
using Integration.Application.Contracts.Persistence;
using Integration.Application.Models;
using Integration.Infrastructure.ExternalServices;
using Integration.Infrastructure.Mail;
using Integration.Infrastructure.Persistence;
using Integration.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;



namespace Integration.Infrastructure
{
    public static class InfrasctructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient();
            services.AddDbContext<Context>(options => options.UseSqlServer(configuration.GetConnectionString("UserConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IIntegrationRepository, IntegrationRepository>();
            services.AddScoped<IHttpRequester, HttpRequester>();

            services.Configure<EmailSettings>(c => configuration.GetSection("Config:EmailSettings"));
            services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}
