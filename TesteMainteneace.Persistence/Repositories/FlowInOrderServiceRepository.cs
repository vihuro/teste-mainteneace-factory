using Microsoft.EntityFrameworkCore;
using TesteMainteneace.Domain.Entities.OrderFlow.UserFlow;
using TesteMainteneace.Domain.Entities.StatusOrder;
using TesteMainteneace.Domain.Interfaces.Flow;
using TesteMainteneace.Persistence.Context;

namespace TesteMainteneace.Persistence.Repositories
{
    public class FlowInOrderServiceRepository : IFlowInOrderServiceRepository
    {
        private readonly AppDbContext _context;
        public FlowInOrderServiceRepository(AppDbContext context)
        {
            _context = context;
        }



        public async Task<List<FlowOrderServiceEntity>> GetFlowByOrderServiceId(int orderServiceId)
        {
            var listFlow = await _context.FlowInOrderService
                                    .Where(x => x.OrderServiceId == orderServiceId)
                                    .ToListAsync();

            return listFlow;

        }



        public async Task ValidateFlow(int flowId, int OrderServiceId, Guid userId)
        {
            var entity = await _context.FlowInOrderService
                        .Include(u => u.InitialUserFlow)
                        .Include(u => u.EndUserFlow)
                        .SingleOrDefaultAsync(f => f.Id == flowId);

            if (entity.InitialUserFlow == null)
            {
                entity.InitialUserFlow = new InitialUserFlow
                {
                    DateCreateded = DateTime.UtcNow,
                    FlowOrderServiceId = flowId,
                    UserInitialId = userId
                };
            }
            else
            {
                entity.EndUserFlow = new EndUserFlow
                {
                    DateEnd = DateTime.UtcNow,
                    FlowOrderServiceId = flowId,
                    UserEndId = userId
                };
            }
        }
    }
}
