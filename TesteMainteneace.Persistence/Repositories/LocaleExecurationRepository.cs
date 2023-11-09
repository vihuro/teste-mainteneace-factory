using Microsoft.EntityFrameworkCore;
using TesteMainteneace.Domain.Entities.Location;
using TesteMainteneace.Domain.Interfaces.Location;
using TesteMainteneace.Persistence.Context;

namespace TesteMainteneace.Persistence.Repositories
{
    public class LocaleExecurationRepository : BaseEntityIntRepository<LocalExecutationEntity>, ILocaleExecutationRepository
    {
        public LocaleExecurationRepository(AppDbContext context) : base(context) { }

        public async Task<LocalExecutationEntity> GetByNameLocale(string nameLocale,
                                                            CancellationToken cancellationToken)
        {
            var item = await Context.Locations.FirstOrDefaultAsync(cancellationToken);

            return item;
        }

        public async Task<List<LocalExecutationEntity>> GetWithUser(CancellationToken cancellationToken)
        {
            var item = await Context.Locations
                .Include(u => u.UserAuth)
                .ToListAsync(cancellationToken);

            return item;
        }
    }
}
