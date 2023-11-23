

using MediatR;

namespace TesteMainteneace.Application.UseCases.StorageParts.GetAllParts
{
    public sealed record GetAllPartsRequest: IRequest<List<PartsResponseDefault>>;
}
