using TesteMainteneace.Domain.Entities.Flow;

namespace TesteMainteneace.Domain.Interfaces.Flow
{
    public interface IFlowRepository
    {
        Task<List<FlowEntity>> GetList(CancellationToken cancellationToken); 
    }
}
