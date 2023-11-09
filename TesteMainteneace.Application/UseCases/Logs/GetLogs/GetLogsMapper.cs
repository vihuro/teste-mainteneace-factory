
using AutoMapper;
using TesteMainteneace.Domain.Entities;

namespace TesteMainteneace.Application.UseCases.Logs.GetLogs
{
    public class GetLogsMapper : Profile
    {
        public GetLogsMapper() 
        {
            CreateMap<LogsEntity, GetLogsResponse>();
        }
    }
}
