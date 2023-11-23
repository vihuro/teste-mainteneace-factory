
using TesteMainteneace.Domain.Entities.Reports;

namespace TesteMainteneace.Domain.Interfaces.Reports
{
    public interface IReportsStorage
    {
        Task<List<ReportsStorageEntity>> GetAll();
    }
}
