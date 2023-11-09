using AutoMapper;
using TesteMainteneace.Domain.Entities.System;

namespace TesteMainteneace.Application.UseCases.Logs.CreateLogs
{
    public class CreateLogsMapper : Profile
    {
        public CreateLogsMapper()
        {
            CreateMap<CreateLogsRequest, LogsEntity>()
                .ForMember(x => x.DateTimeCreated, map => map.MapFrom(src => DateTime.UtcNow));
            CreateMap<LogsEntity, CreateLogsResponse>();
        }
    }
}
