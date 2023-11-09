using Microsoft.EntityFrameworkCore;
using TesteMainteneace.Domain.Entities;

namespace TesteMainteneace.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        { }
        public DbSet<UserAuth> Users { get; set; }
        public DbSet<OrderServiceEntity> Orders { get; set; }
        public DbSet<LocalExecutationEntity> Locations { get; set; }
    }
}
