using TesteMainteneace.Domain.Entities.StatusOrder;

namespace TesteMainteneace.Domain.Interfaces.Flow
{
    public interface IFlowInOrderServiceRepository
    {
        Task<List<FlowOrderServiceEntity>> GetFlowByOrderServiceId(int orderServiceId);
        Task ValidateFlow(int flowId, int OrderServiceId, Guid userId);

    }
}
