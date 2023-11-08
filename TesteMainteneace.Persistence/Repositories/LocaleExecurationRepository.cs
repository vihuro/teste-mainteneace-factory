using Microsoft.EntityFrameworkCore;
using TesteMainteneace.Domain.Entities;
using TesteMainteneace.Domain.Interfaces;
using TesteMainteneace.Persistence.Context;

namespace TesteMainteneace.Persistence.Repositories
{
    public class LocaleExecurationRepository : BaseEntityIntRepository<LocalExecutation>, ILocaleExecutationRepository
    {
        public LocaleExecurationRepository(AppDbContext context) : base(context) { }

        public async Task<LocalExecutation> GetByNameLocale(string nameLocale,
                                                            CancellationToken cancellationToken)
        {
            var item = await Context.Locations.FirstOrDefaultAsync(cancellationToken);

            return item;
        }
    }
}
