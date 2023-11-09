using AutoMapper;
using TesteMainteneace.Domain.Entities;

namespace TesteMainteneace.Application.UseCases.Logs.CreateLogs
{
    public class CreateLogsMapper : Profile
    {
        public CreateLogsMapper()
        {
            CreateMap<CreateLogsRequest, LogsEntity>();
            CreateMap<LogsEntity, CreateLogsResponse>();
        }
    }
}
