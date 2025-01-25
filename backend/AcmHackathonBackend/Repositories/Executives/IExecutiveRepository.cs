using AcmHackathonBackend.Models;
using AcmHackathonBackend.Repositories.Common;

namespace AcmHackathonBackend.Repositories.Executives
{
    public interface IExecutiveRepository : IBaseRepository<Executive>
    {
        Task<IEnumerable<Executive>> GetExecutivesByRoleAsync(string role);
        Task<IEnumerable<Executive>> GetExecutivesByDepartmentAsync(string department);
        Task<IEnumerable<Executive>> GetExecutivesByYearAsync(string year);
    }
} 