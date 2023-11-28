using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TesteMainteneace.Domain.Interfaces.Flow;
using TesteMainteneace.Domain.Interfaces.Location;
using TesteMainteneace.Domain.Interfaces.Order;
using TesteMainteneace.Domain.Interfaces.Reports;
using TesteMainteneace.Domain.Interfaces.Storage;
using TesteMainteneace.Domain.Interfaces.System;
using TesteMainteneace.Domain.Interfaces.User;
using TesteMainteneace.Persistence.Context;
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
            services.AddSingleton<MongoDbContext>();

            services.Configure<AndressReportRadar>(op =>
            {
                op.Andress = configuration.GetSection("AndressReportRadar:Andress").Value;
                op.Password = configuration.GetSection("AndressReportRadar:Password").Value;
                op.User = configuration.GetSection("AndressReportRadar:User").Value;
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserAuthRepository, UserAuthRepository>();
            services.AddScoped<IUserAuthApiRepository, UserAuthApiRepository>();
            services.AddScoped<ILocaleExecutationRepository, LocaleExecurationRepository>();
            services.AddScoped<ILogsRepository, LogsRepository>();
            services.AddScoped<IOrderServiceRepository, OrderServiceRepository>();
            services.AddScoped<IReportsStorage, ReportsStorage>();
            services.AddScoped<IStoragePartsRepository, StoragePartsRepository>();
            services.AddScoped<IFlowRepository, FlowRepository>();
            services.AddScoped<IFlowInOrderServiceRepository, FlowInOrderServiceRepository>();

        }

    }
}
