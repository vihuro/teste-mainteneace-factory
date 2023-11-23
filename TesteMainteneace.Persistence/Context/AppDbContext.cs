using Microsoft.EntityFrameworkCore;
using TesteMainteneace.Domain.Entities.Daily;
using TesteMainteneace.Domain.Entities.Flow;
using TesteMainteneace.Domain.Entities.Location;
using TesteMainteneace.Domain.Entities.Order;
using TesteMainteneace.Domain.Entities.OrderFlow.UserFlow;
using TesteMainteneace.Domain.Entities.StorageParts;
using TesteMainteneace.Domain.Entities.User;

namespace TesteMainteneace.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        public DbSet<UserAuth> Users { get; set; }
        public DbSet<OrderServiceEntity> Orders { get; set; }
        public DbSet<FlowEntity> Flow { get; set; }
        public DbSet<InitialUserFlow> InitialUserFlow { get; set; }
        public DbSet<DailyEntity> Daily { get; set; }
        public DbSet<EndUserFlow> EndUserFlow { get; set; }
        public DbSet<LocalExecutationEntity> Locations { get; set; }
        public DbSet<StoragePartsEntity> StorageParts { get; set; }

    }
}
