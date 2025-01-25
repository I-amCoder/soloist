using AcmHackathonBackend.Models;
using AcmHackathonBackend.Repositories.Executives;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using AutoMapper;
using AcmHackathonBackend.Models.ResponseModels;

namespace AcmHackathonBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExecutivesController : ControllerBase
    {
        private readonly IExecutiveRepository _executiveRepository;
        private readonly IMapper _mapper;

        public ExecutivesController(IExecutiveRepository executiveRepository, IMapper mapper)
        {
            _executiveRepository = executiveRepository;
            _mapper = mapper;
        }

        // GET: api/executives
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExecutiveResponseModel>>> GetAllExecutives()
        {
            try
            {
                var executives = await _executiveRepository.GetAllAsync();
                var response = _mapper.Map<IEnumerable<ExecutiveResponseModel>>(executives);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error retrieving executives", error = ex.Message });
            }
        }

        // GET: api/executives/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ExecutiveResponseModel>> GetExecutiveById(int id)
        {
            try
            {
                var executive = await _executiveRepository.GetByIdAsync(id);
                if (executive == null)
                {
                    return NotFound(new { message = "Executive not found" });
                }

                var response = _mapper.Map<ExecutiveResponseModel>(executive);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error retrieving executive", error = ex.Message });
            }
        }

        // GET: api/executives/role/{role}
        [HttpGet("role/{role}")]
        public async Task<ActionResult<IEnumerable<ExecutiveResponseModel>>> GetExecutivesByRole(string role)
        {
            try
            {
                var executives = await _executiveRepository.GetExecutivesByRoleAsync(role);
                var response = _mapper.Map<IEnumerable<ExecutiveResponseModel>>(executives);
                return Ok(response);
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