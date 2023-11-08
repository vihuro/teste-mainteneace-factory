using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TesteMainteneace.Persistence.Context;

namespace TestMainteneace.Api
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<AppDbContext>()
                .UseNpgsql(config.GetConnectionString("teste_mainteneace"), b => b.MigrationsAssembly("TestMainteneace.Api"));

            return new AppDbContext(builder.Options);
        }
    }
}
