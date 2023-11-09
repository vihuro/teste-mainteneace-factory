using TesteMainteneace.Domain.Entities.User;

namespace TesteMainteneace.Domain.Interfaces.User
{
    public interface IUserAuthApiRepository
    {
        Task<List<UserAuthApi>> GetList(CancellationToken cancellationToken);
    }
}
