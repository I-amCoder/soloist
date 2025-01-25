using AcmHackathonBackend.Models;
using AcmHackathonBackend.Repositories.Events;
using Microsoft.AspNetCore.Mvc;

namespace AcmHackathonBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;

        public EventsController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        // GET: api/events
        [HttpGet]
        public async Task<ActionResult<object>> GetAllEvents()
        {
            try
            {
                var upcoming = await _eventRepository.GetUpcomingEventsAsync();
                var past = await _eventRepository.GetPastEventsAsync();
                return Ok(new { upcoming, past });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error retrieving events", error = ex.Message });
            }
        }

        // GET: api/events/upcoming
        [HttpGet("upcoming")]
        public async Task<ActionResult<IEnumerable<Event>>> GetUpcomingEvents()
        {
            try
            {
                var events = await _eventRepository.GetUpcomingEventsAsync();
                return Ok(events);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error retrieving upcoming events", error = ex.Message });
            }
        }

        // GET: api/events/past
        [HttpGet("past")]
        public async Task<ActionResult<IEnumerable<Event>>> GetPastEvents()
        {
            try
            {
                var events = await _eventRepository.GetPastEventsAsync();
                return Ok(events);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error retrieving past events", error = ex.Message });
            }
        }

        // GET: api/events/{slug}
        [HttpGet("{slug}")]
        public async Task<ActionResult<Event>> GetEventBySlug(string slug)
        {
            try
            {
                var @event = await _eventRepository.GetEventBySlugAsync(slug);
                if (@event == null)
                {
                    return NotFound(new { message = "Event not found" });
                }
                return Ok(@event);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error retrieving event", error = ex.Message });
            }
        }

        // GET: api/events/range
        [HttpGet("range")]
        public async Task<ActionResult<IEnumerable<Event>>> GetEventsByDateRange(
            [FromQuery] DateTime startDate,
            [FromQuery] DateTime endDate)
        {
            try
            {
                var events = await _eventRepository.GetEventsByDateRangeAsync(startDate, endDate);
                return Ok(events);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error retrieving events by date range", error = ex.Message });
            }
        }
    }
}