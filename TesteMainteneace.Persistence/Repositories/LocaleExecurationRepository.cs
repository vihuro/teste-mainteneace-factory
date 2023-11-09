using Microsoft.EntityFrameworkCore;
using TesteMainteneace.Domain.Entities;
using TesteMainteneace.Domain.Interfaces;
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
    }
}
