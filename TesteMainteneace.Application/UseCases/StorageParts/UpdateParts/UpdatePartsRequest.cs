using MediatR;

namespace TesteMainteneace.Application.UseCases.StorageParts.UpdateParts
{
    public sealed record UpdatePartsRequest : IRequest<List<PartsResponseDefault>>;
}
