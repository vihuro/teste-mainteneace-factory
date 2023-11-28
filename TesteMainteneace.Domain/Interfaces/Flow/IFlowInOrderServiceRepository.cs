using TesteMainteneace.Domain.Entities.StatusOrder;

namespace TesteMainteneace.Domain.Interfaces.Flow
{
    public interface IFlowInOrderServiceRepository
    {
        Task WaitingAtribuation(int flowId, int OrderServiceId, Guid userId);
        Task WaitingOrderServiceInvalid(int flowId, int OrderServiceId, Guid userId);
        Task<List<FlowOrderServiceEntity>> GetFlowByOrderServiceId(int orderServiceId);
        Task WaitingMainteneace(int flowId, int orderServiceId, Guid userId);
        Task MainteneaceStart();
        Task WaitingParts();
        Task MainteneaceEnd();
        Task MainteneaceInvalid();
        Task OrderServiceEnd();
    }
}
