using AutoMapper;
using TesteMainteneace.Domain.Entities.Reports;

namespace TesteMainteneace.Application.UseCases.Reports.Storage.GetStorageRadar
{
    public class GetStorageRadarMapper : Profile
    {
        public GetStorageRadarMapper() 
        {
            CreateMap<ReportsStorageEntity, GetStorageRadarResponse>();
        }
    }
}
