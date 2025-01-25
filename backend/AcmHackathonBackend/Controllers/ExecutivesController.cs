using AcmHackathonBackend.Models;
using AcmHackathonBackend.Repositories.Executives;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AcmHackathonBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExecutivesController : ControllerBase
    {
        private readonly IExecutiveRepository _executiveRepository;
        private readonly JsonSerializerOptions _jsonOptions;

        public ExecutivesController(IExecutiveRepository executiveRepository)
        {
            _executiveRepository = executiveRepository;
            _jsonOptions = new JsonSerializerOptions
            {
                ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles,
                WriteIndented = true
            };
        }

        // GET: api/executives
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetAllExecutives()
        {
            try
            {
                var executives = await _executiveRepository.GetAllAsync();
                var executivesList = executives.Select(e => new
                {
                    e.Id,
                    e.Name,
                    e.Role,
                    e.Image,
                    e.Description,
                    e.Department,
                    e.Year,
                    SocialLinks = e.SocialLinks == null ? null : new
                    {
                        e.SocialLinks.LinkedIn,
                        e.SocialLinks.Github,
                        e.SocialLinks.Twitter
                    }
                });

                return Ok(executivesList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error retrieving executives", error = ex.Message });
            }
        }

        // GET: api/executives/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetExecutiveById(int id)
        {
            try
            {
                var executive = await _executiveRepository.GetByIdAsync(id);
                if (executive == null)
                {
                    return NotFound(new { message = "Executive not found" });
                }

                var executiveDto = new
                {
                    executive.Id,
                    executive.Name,
                    executive.Role,
                    executive.Image,
                    executive.Description,
                    executive.Department,
                    executive.Year,
                    SocialLinks = executive.SocialLinks == null ? null : new
                    {
                        executive.SocialLinks.LinkedIn,
                        executive.SocialLinks.Github,
                        executive.SocialLinks.Twitter
                    }
                };

                return Ok(executiveDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error retrieving executive", error = ex.Message });
            }
        }

        // GET: api/executives/role/{role}
        [HttpGet("role/{role}")]
        public async Task<ActionResult<IEnumerable<object>>> GetExecutivesByRole(string role)
        {
            try
            {
                var executives = await _executiveRepository.GetExecutivesByRoleAsync(role);
                var executivesList = executives.Select(e => new
                {
                    e.Id,
                    e.Name,
                    e.Role,
                    e.Image,
                    e.Description,
                    e.Department,
                    e.Year,
                    SocialLinks = e.SocialLinks == null ? null : new
                    {
                        e.SocialLinks.LinkedIn,
                        e.SocialLinks.Github,
                        e.SocialLinks.Twitter
                    }
                });

                return Ok(executivesList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error retrieving executives by role", error = ex.Message });
            }
        }

        // GET: api/executives/department/{department}
        [HttpGet("department/{department}")]
        public async Task<ActionResult<IEnumerable<Executive>>> GetExecutivesByDepartment(string department)
        {
            try
            {
                var executives = await _executiveRepository.GetExecutivesByDepartmentAsync(department);
                return Ok(executives);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error retrieving executives by department", error = ex.Message });
            }
        }

        // GET: api/executives/year/{year}
        [HttpGet("year/{year}")]
        public async Task<ActionResult<IEnumerable<Executive>>> GetExecutivesByYear(string year)
        {
            try
            {
                var executives = await _executiveRepository.GetExecutivesByYearAsync(year);
                return Ok(executives);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error retrieving executives by year", error = ex.Message });
            }
        }
    }
}