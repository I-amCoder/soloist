using AcmHackathonBackend.Database;
using AcmHackathonBackend.Models;
using AcmHackathonBackend.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace AcmHackathonBackend.Repositories.Projects
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Project>> GetFeaturedProjectsAsync()
        {
            return await _dbSet
                .Include(p => p.Technologies)
                .Include(p => p.Features)
                .Where(p => p.IsFeatured)
                .ToListAsync();
        }

        public async Task<IEnumerable<Project>> GetRecentProjectsAsync(int count = 10)
        {
            return await _dbSet
                .Include(p => p.Technologies)
                .Include(p => p.Features)
                .Where(p => !p.IsFeatured)
                .OrderByDescending(p => p.CreatedAt)
                .Take(count)
                .ToListAsync();
        }

        public async Task<IEnumerable<Project>> GetProjectsByTechnologyAsync(string technology)
        {
            return await _dbSet
                .Include(p => p.Technologies)
                .Include(p => p.Features)
                .Where(p => p.Technologies.Any(t => 
                    t.Name.ToLower().Contains(technology.ToLower())))
                .ToListAsync();
        }

        public async Task<IEnumerable<Project>> GetProjectsByHackathonAsync(string hackathonName)
        {
            return await _dbSet
                .Include(p => p.Technologies)
                .Include(p => p.Features)
                .Where(p => p.Hackathon.ToLower().Contains(hackathonName.ToLower()))
                .ToListAsync();
        }

        public async Task<IEnumerable<Project>> GetProjectsByStatusAsync(string status)
        {
            return await _dbSet
                .Include(p => p.Technologies)
                .Include(p => p.Features)
                .Where(p => p.Status.ToLower() == status.ToLower())
                .ToListAsync();
        }
    }
} 