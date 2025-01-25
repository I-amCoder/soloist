using AcmHackathonBackend.Models;
using AcmHackathonBackend.Repositories.Common;

namespace AcmHackathonBackend.Repositories.Projects
{
    public interface IProjectRepository : IBaseRepository<Project>
    {
        Task<IEnumerable<Project>> GetFeaturedProjectsAsync();
        Task<IEnumerable<Project>> GetRecentProjectsAsync(int count = 10);
        Task<IEnumerable<Project>> GetProjectsByTechnologyAsync(string technology);
        Task<IEnumerable<Project>> GetProjectsByHackathonAsync(string hackathonName);
        Task<IEnumerable<Project>> GetProjectsByStatusAsync(string status);
    }
} 