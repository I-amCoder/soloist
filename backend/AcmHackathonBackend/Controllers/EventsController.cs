using AcmHackathonBackend.Models;
using AcmHackathonBackend.Repositories.Events;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using AcmHackathonBackend.Models.ResponseModels;

namespace AcmHackathonBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public EventsController(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        // GET: api/events
        [HttpGet]
        public async Task<ActionResult<EventsResponseModel>> GetAllEvents()
        {
            try
            {
                var upcoming = await _eventRepository.GetUpcomingEventsAsync();
                var past = await _eventRepository.GetPastEventsAsync();
                
                var response = new EventsResponseModel
                {
                    Upcoming = _mapper.Map<List<EventResponseModel>>(upcoming),
                    Past = _mapper.Map<List<EventResponseModel>>(past)
                };
                
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error retrieving events", error = ex.Message });
            }
        }

        // GET: api/events/upcoming
        [HttpGet("upcoming")]
        public async Task<ActionResult<IEnumerable<EventResponseModel>>> GetUpcomingEvents()
        {
            try
            {
                var events = await _eventRepository.GetUpcomingEventsAsync();
                var response = _mapper.Map<IEnumerable<EventResponseModel>>(events);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error retrieving upcoming events", error = ex.Message });
            }
        }

        // GET: api/events/past
        [HttpGet("past")]
        public async Task<ActionResult<IEnumerable<EventResponseModel>>> GetPastEvents()
        {
            try
            {
                var events = await _eventRepository.GetPastEventsAsync();
                var response = _mapper.Map<IEnumerable<EventResponseModel>>(events);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error retrieving past events", error = ex.Message });
            }
        }

        // GET: api/events/{slug}
        [HttpGet("{slug}")]
        public async Task<ActionResult<EventResponseModel>> GetEventBySlug(string slug)
        {
            try
            {
                var @event = await _eventRepository.GetEventBySlugAsync(slug);
                if (@event == null)
                {
                    return NotFound(new { message = "Event not found" });
                }
                var response = _mapper.Map<EventResponseModel>(@event);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error retrieving event", error = ex.Message });
            }
        }

        // GET: api/events/range
        [HttpGet("range")]
        public async Task<ActionResult<IEnumerable<EventResponseModel>>> GetEventsByDateRange(
            [FromQuery] DateTime startDate,
            [FromQuery] DateTime endDate)
        {
            try
            {
                var events = await _eventRepository.GetEventsByDateRangeAsync(startDate, endDate);
                var response = _mapper.Map<IEnumerable<EventResponseModel>>(events);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error retrieving events by date range", error = ex.Message });
            }
        }
    }
}