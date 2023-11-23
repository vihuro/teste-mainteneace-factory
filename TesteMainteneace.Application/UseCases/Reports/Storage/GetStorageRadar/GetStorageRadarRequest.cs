using MediatR;


namespace TesteMainteneace.Application.UseCases.Reports.Storage.GetStorageRadar
{
    public record class GetStorageRadarRequest : IRequest<List<GetStorageRadarResponse>>;
}
