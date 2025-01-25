using AcmHackathonBackend.Database;
using AcmHackathonBackend.Models;
using AcmHackathonBackend.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace AcmHackathonBackend.Repositories.Events
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(ApplicationDbContext context) : base(context) { }

        private IQueryable<Event> GetEventBaseQuery()
        {
            return _dbSet
                .Select(e => new Event
                {
                    Id = e.Id,
                    Slug = e.Slug,
                    Title = e.Title,
                    Date = e.Date,
                    Description = e.Description,
                    Image = e.Image,
                    FullDescription = e.FullDescription,
                    IsUpcoming = e.IsUpcoming,
                    CreatedAt = e.CreatedAt,
                    UpdatedAt = e.UpdatedAt,
                    Schedule = e.Schedule.Select(s => new EventSchedule
                    {
                        Id = s.Id,
                        Day = s.Day,
                        Activities = s.Activities.Select(a => new ScheduleActivity
                        {
                            Id = a.Id,
                            Time = a.Time,
                            Activity = a.Activity
                        }).ToList()
                    }).ToList(),
                    Rules = e.Rules.Select(r => new EventRule
                    {
                        Id = r.Id,
                        Description = r.Description
                    }).ToList(),
                    Prizes = e.Prizes.Select(p => new EventPrize
                    {
                        Id = p.Id,
                        Place = p.Place,
                        Benefits = p.Benefits.Select(b => new PrizeBenefit
                        {
                            Id = b.Id,
                            Description = b.Description
                        }).ToList()
                    }).ToList(),
                    Venue = e.Venue == null ? null : new EventVenue
                    {
                        Id = e.Venue.Id,
                        Name = e.Venue.Name,
                        Address = e.Venue.Address
                    },
                    Sponsors = e.Sponsors.Select(s => new EventSponsor
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Logo = s.Logo,
                        Website = s.Website
                    }).ToList()
                });
        }

        public async Task<IEnumerable<Event>> GetUpcomingEventsAsync()
        {
            return await GetEventBaseQuery()
                .Where(e => e.IsUpcoming)
                .OrderBy(e => e.Date)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Event>> GetPastEventsAsync()
        {
            return await GetEventBaseQuery()
                .Where(e => !e.IsUpcoming)
                .OrderByDescending(e => e.Date)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Event?> GetEventBySlugAsync(string slug)
        {
            return await GetEventBaseQuery()
                .Where(e => e.Slug == slug)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Event>> GetEventsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await GetEventBaseQuery()
                .Where(e => e.Date >= startDate && e.Date <= endDate)
                .OrderBy(e => e.Date)
                .AsNoTracking()
                .ToListAsync();
        }
    }
} 