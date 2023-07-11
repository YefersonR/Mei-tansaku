using Core.Application.Interface.Services;
using Core.Domain.Settings;
using Infrastructure.Shared.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Shared
{
    public static class EmailRegistration
    {
        public static void AddShareInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MailSettings>(configuration.GetSection("MailSettings"));
            services.AddTransient<IEmailService, EmailService>();

        }
    }
}