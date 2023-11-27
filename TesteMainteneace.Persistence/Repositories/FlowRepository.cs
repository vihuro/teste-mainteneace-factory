using Microsoft.EntityFrameworkCore;
using TesteMainteneace.Domain.Entities.Flow;
using TesteMainteneace.Domain.Interfaces.Flow;
using TesteMainteneace.Persistence.Context;

namespace TesteMainteneace.Persistence.Repositories
{
    public class FlowRepository : IFlowRepository
    {
        private readonly AppDbContext _context;
        public FlowRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<FlowEntity>> GetList(CancellationToken cancellationToken)
        {
            var list = await _context.Flow.ToListAsync();

            return list;
        }
    }
}
