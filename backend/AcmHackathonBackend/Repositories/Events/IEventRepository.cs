using AcmHackathonBackend.Models;
using AcmHackathonBackend.Repositories.Common;

namespace AcmHackathonBackend.Repositories.Events
{
    public interface IEventRepository : IBaseRepository<Event>
    {
        Task<IEnumerable<Event>> GetUpcomingEventsAsync();
        Task<IEnumerable<Event>> GetPastEventsAsync();
        Task<Event?> GetEventBySlugAsync(string slug);
        Task<IEnumerable<Event>> GetEventsByDateRangeAsync(DateTime startDate, DateTime endDate);
    }
} 