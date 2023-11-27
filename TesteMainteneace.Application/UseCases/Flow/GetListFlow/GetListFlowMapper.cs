

using AutoMapper;
using TesteMainteneace.Domain.Entities.Flow;

namespace TesteMainteneace.Application.UseCases.Flow.GetListFlow
{
    public class GetListFlowMapper : Profile
    {
        public GetListFlowMapper() 
        {
            CreateMap<FlowEntity, FlowResponseDefault>();
        }
    }
}
