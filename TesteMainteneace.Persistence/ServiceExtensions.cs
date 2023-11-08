using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TesteMainteneace.Domain.Interfaces;
using TesteMainteneace.Persistence.Context;
using TesteMainteneace.Persistence.Interfaces;
using TesteMainteneace.Persistence.Repositories;
using TesteMainteneace.Persistence.Utils;

namespace TesteMainteneace.Persistence
{
    public static class ServiceExtensions
    {
        public static void ConfigurePersistenteApp(this IServiceCollection services,
                                                    IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("teste_mainteneace");
            services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(connectionString));

            services.Configure<AndressApiAuth>(op =>
            {
                op.Andress = configuration.GetSection("AndressApiAuth:Andress").Value;
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserAuthRepository, UserAuthRepository>();
            services.AddScoped<IUserAuthApiRepository, UserAuthApiRepository>();

        }
    }
}
