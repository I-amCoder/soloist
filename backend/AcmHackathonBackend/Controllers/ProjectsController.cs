using AcmHackathonBackend.Models;
using AcmHackathonBackend.Repositories.Projects;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using AutoMapper;
using AcmHackathonBackend.Models.ResponseModels;

namespace AcmHackathonBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;
        private readonly JsonSerializerOptions _jsonOptions;

        public ProjectsController(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
            _jsonOptions = new JsonSerializerOptions
            {
                ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles,
                WriteIndented = true
            };
        }

        // GET: api/projects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectResponseModel>>> GetAllProjects()
        {
            try
            {
                var featuredProjects = await _projectRepository.GetFeaturedProjectsAsync();
                var recentProjects = await _projectRepository.GetRecentProjectsAsync();
                
                var allProjects = featuredProjects.Concat(recentProjects);
                var response = _mapper.Map<IEnumerable<ProjectResponseModel>>(allProjects);
                
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error retrieving projects", error = ex.Message });
            }
        }

        // GET: api/projects/featured
        [HttpGet("featured")]
        public async Task<ActionResult<IEnumerable<ProjectResponseModel>>> GetFeaturedProjects()
        {
            try
            {
                var projects = await _projectRepository.GetFeaturedProjectsAsync();
                var response = _mapper.Map<IEnumerable<ProjectResponseModel>>(projects);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error retrieving featured projects", error = ex.Message });
            }
        }

        // GET: api/projects/recent
        [HttpGet("recent")]
        public async Task<ActionResult<IEnumerable<Project>>> GetRecentProjects()
        {
            try
            {
                var projects = await _projectRepository.GetRecentProjectsAsync();
                return Ok(projects);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error retrieving recent projects", error = ex.Message });
            }
        }

        // GET: api/projects/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProjectById(int id)
        {
            try
            {
                var project = await _projectRepository.GetByIdAsync(id);
                if (project == null)
                {
                    return NotFound(new { message = $"Project with ID {id} not found" });
                }
                return Ok(project);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error retrieving project", error = ex.Message });
            }
        }

        // GET: api/projects/technology/{tech}
        [HttpGet("technology/{tech}")]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjectsByTechnology(string tech)
        {
            try
            {
                var projects = await _projectRepository.GetProjectsByTechnologyAsync(tech);
                return Ok(projects);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error retrieving projects by technology", error = ex.Message });
            }
        }

        // GET: api/projects/hackathon/{hackathon}
        [HttpGet("hackathon/{hackathon}")]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjectsByHackathon(string hackathon)
        {
            try
            {
                var projects = await _projectRepository.GetProjectsByHackathonAsync(hackathon);
                return Ok(projects);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error retrieving projects by hackathon", error = ex.Message });
            }
        }

        // GET: api/projects/status/{status}
        [HttpGet("status/{status}")]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjectsByStatus(string status)
        {
            try
            {
                var projects = await _projectRepository.GetProjectsByStatusAsync(status);
                return Ok(projects);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error retrieving projects by status", error = ex.Message });
            }
        }
    }
} 