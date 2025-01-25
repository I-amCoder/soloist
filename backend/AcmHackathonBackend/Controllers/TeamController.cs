using AcmHackathonBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AcmHackathonBackend.Database;
using System.Text.Json;

namespace AcmHackathonBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly JsonSerializerOptions _jsonOptions;

        public TeamController(ApplicationDbContext context)
        {
            _context = context;
            _jsonOptions = new JsonSerializerOptions
            {
                ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles,
                WriteIndented = true
            };
        }

        // GET: api/team/executives
        [HttpGet("executives")]
        public async Task<ActionResult<IEnumerable<object>>> GetExecutives()
        {
            try
            {
                var executives = await _context.Executives
                    .Include(e => e.SocialLinks)
                    .Select(e => new
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Role = e.Role,
                        Image = e.Image,
                        Description = e.Description,
                        Department = e.Department,
                        Year = e.Year,
                        SocialLinks = e.SocialLinks != null ? new
                        {
                            LinkedIn = e.SocialLinks.LinkedIn,
                            Github = e.SocialLinks.Github,
                            Twitter = e.SocialLinks.Twitter
                        } : null
                    })
                    .ToListAsync();

                return Ok(executives);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error retrieving executives", error = ex.Message });
            }
        }

        // GET: api/team/executives/{id}
        [HttpGet("executives/{id}")]
        public async Task<ActionResult<object>> GetExecutive(int id)
        {
            try
            {
                var executive = await _context.Executives
                    .Include(e => e.SocialLinks)
                    .Where(e => e.Id == id)
                    .Select(e => new
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Role = e.Role,
                        Image = e.Image,
                        Description = e.Description,
                        Department = e.Department,
                        Year = e.Year,
                        SocialLinks = e.SocialLinks != null ? new
                        {
                            LinkedIn = e.SocialLinks.LinkedIn,
                            Github = e.SocialLinks.Github,
                            Twitter = e.SocialLinks.Twitter
                        } : null
                    })
                    .FirstOrDefaultAsync();

                if (executive == null)
                {
                    return NotFound(new { message = "Executive not found" });
                }

                return Ok(executive);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error retrieving executive", error = ex.Message });
            }
        }

        // GET: api/team/executives/role/{role}
        [HttpGet("executives/role/{role}")]
        public async Task<ActionResult<IEnumerable<object>>> GetExecutivesByRole(string role)
        {
            try
            {
                var executives = await _context.Executives
                    .Include(e => e.SocialLinks)
                    .Where(e => e.Role.ToLower() == role.ToLower())
                    .Select(e => new
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Role = e.Role,
                        Image = e.Image,
                        Description = e.Description,
                        Department = e.Department,
                        Year = e.Year,
                        SocialLinks = e.SocialLinks != null ? new
                        {
                            LinkedIn = e.SocialLinks.LinkedIn,
                            Github = e.SocialLinks.Github,
                            Twitter = e.SocialLinks.Twitter
                        } : null
                    })
                    .ToListAsync();

                return Ok(executives);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error retrieving executives by role", error = ex.Message });
            }
        }
    }
} 