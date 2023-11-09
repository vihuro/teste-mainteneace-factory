using TesteMainteneace.Domain.Entities.User;
using TesteMainteneace.Domain.Interfaces.Base;

namespace TesteMainteneace.Domain.Interfaces.User
{
    public interface IUserAuthRepository : IBaseGuidRepository<UserAuth>
    {
        Task<UserAuth> GetByUserName(string userName, CancellationToken cancellationToken);
        void CreateUserOfApiAuth(List<UserAuth> users, CancellationToken cancellationToken);

    }
}
