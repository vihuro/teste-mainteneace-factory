using MediatR;

namespace TesteMainteneace.Application.UseCases.StorageParts.GetPartsNotRegistered
{
    public sealed record GetPartsNotRegisteredRequest : IRequest<List<PartsResponseDefault>>;
}
