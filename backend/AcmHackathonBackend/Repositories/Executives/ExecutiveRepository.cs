using AcmHackathonBackend.Database;
using AcmHackathonBackend.Models;
using AcmHackathonBackend.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace AcmHackathonBackend.Repositories.Executives
{
    public class ExecutiveRepository : BaseRepository<Executive>, IExecutiveRepository
    {
        public ExecutiveRepository(ApplicationDbContext context) : base(context) { }

        public override async Task<Executive?> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(e => e.SocialLinks)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public override async Task<IEnumerable<Executive>> GetAllAsync()
        {
            return await _dbSet
                .Include(e => e.SocialLinks)
                .OrderBy(e => e.Role)
                .ToListAsync();
        }

        public async Task<IEnumerable<Executive>> GetExecutivesByRoleAsync(string role)
        {
            return await _dbSet
                .Include(e => e.SocialLinks)
                .Where(e => e.Role.ToLower().Contains(role.ToLower()))
                .OrderBy(e => e.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<Executive>> GetExecutivesByDepartmentAsync(string department)
        {
            return await _dbSet
                .Include(e => e.SocialLinks)
                .Where(e => e.Department.ToLower().Contains(department.ToLower()))
                .OrderBy(e => e.Role)
                .ThenBy(e => e.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<Executive>> GetExecutivesByYearAsync(string year)
        {
            return await _dbSet
                .Include(e => e.SocialLinks)
                .Where(e => e.Year.ToLower() == year.ToLower())
                .OrderBy(e => e.Role)
                .ThenBy(e => e.Name)
                .ToListAsync();
        }
    }
} 