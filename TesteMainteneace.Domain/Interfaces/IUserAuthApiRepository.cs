

using TesteMainteneace.Domain.Entities;

namespace TesteMainteneace.Domain.Interfaces
{
    public interface IUserAuthApiRepository
    {
        Task<List<UserAuthApi>> GetList();
    }
}
