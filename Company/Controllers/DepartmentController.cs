using AutoMapper;
using Company.Irepository;
using Company.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DepartmentController> _logger;
        private readonly IMapper _mapper;

        public DepartmentController(IUnitOfWork unitOfWork, ILogger<DepartmentController> logger, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        { 
            try
            {
                var departments = await  _unitOfWork.Departments.GetAll();
                var results = _mapper.Map<List<DepartmentDTO>>(departments);
                return Ok(results);
            }
            catch (Exception ex)
            { 
                _logger.LogError(ex,$"Something went wrong in the name of {nameof(GetDepartments)}");
                return StatusCode(500, "Internal Server Error. Try again later. ");
            }

        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetDepartment(int id)
        {
            try
            {
                var department = await _unitOfWork.Departments.Get(q => q.Id == id, new List<string> { "Employees"});
                var results = _mapper.Map<DepartmentDTO>(department);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the name of {nameof(GetDepartment)}");
                return StatusCode(500, "Internal Server Error. Try again later. ");
            }

        }
    }
}
