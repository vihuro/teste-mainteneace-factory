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
        public Task MainteneaceEnd()
        {
            throw new NotImplementedException();
        }

        public Task MainteneaceInvalid()
        {
            throw new NotImplementedException();
        }

        public Task MainteneaceStart()
        {
            throw new NotImplementedException();
        }

        public Task OrderServiceEnd()
        {
            throw new NotImplementedException();
        }

        public Task WaitingAtribuation(int flowId, int OrderServiceId, Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task WaitingMainteneace()
        {
            throw new NotImplementedException();
        }

        public Task WaitingMainteneace(int flowId, int orderServiceId, Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task WaitingOrderServiceInvalid(int flowId, int orderServiceId, Guid userId)
        {
            var flowInOrderService = await _context.FlowInOrderService
                                    .SingleOrDefaultAsync(f => f.FlowId == flowId);

            if (flowInOrderService.InitialUserFlow == null)
            {
                flowInOrderService.InitialUserFlow = new InitialUserFlow
                {
                    DateCreateded = DateTime.UtcNow,
                    FlowOrderServiceId = flowId,
                    UserInitialId = userId
                };
            }
        }
        public async Task<List<FlowOrderServiceEntity>> GetFlowByOrderServiceId(int orderServiceId)
        {
            var listFlow = await _context.FlowInOrderService
                                    .Where(x => x.OrderServiceId == orderServiceId)
                                    .ToListAsync();

            return listFlow;

        }

        public Task WaitingParts()
        {
            throw new NotImplementedException();
        }
    }
}
