using TesteMainteneace.Domain.Entities;

namespace TesteMainteneace.Persistence.Interfaces
{
    public interface IUserAuthRepository : IBaseGuidRepository<UserAuth>
    {
        Task<UserAuth> GetByUserName(string userName, CancellationToken cancellationToken);
        void CreateUserOfApiAuth(List<UserAuth> users, CancellationToken cancellationToken);

    }
}
