using Microsoft.EntityFrameworkCore;
using TesteMainteneace.Domain.Entities;
using TesteMainteneace.Persistence.Context;
using TesteMainteneace.Persistence.Interfaces;

namespace TesteMainteneace.Persistence.Repositories
{
    public class UserAuthRepository : BaseEntityGuidRepository<UserAuth>, IUserAuthRepository
    {
        public UserAuthRepository(AppDbContext context) : base(context)
        { }

        public void CreateUserOfApiAuth(List<UserAuth> users, 
                                        CancellationToken cancellationToken)
        {

            Context.Users.AddRangeAsync(users, cancellationToken);
        }

        public async Task<UserAuth> GetByUserName(string userName, CancellationToken cancellationToken)
        {
            return await Context.Users
                .FirstOrDefaultAsync(x =>
                        x.UserName == userName, cancellationToken);
        }
    }
}
