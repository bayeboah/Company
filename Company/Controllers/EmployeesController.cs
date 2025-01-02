using AutoMapper;
using Company.Irepository;
using Company.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EmployeesController> _logger;
        private readonly IMapper _mapper;

        public EmployeesController(IUnitOfWork unitOfWork, ILogger<EmployeesController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var employees = await _unitOfWork.Employees.GetAll();
                var results = _mapper.Map<List<EmployeesDTO>>(employees);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the name of {nameof(GetEmployees)}");
                return StatusCode(500, "Internal Server Error. Try again later. ");
            }

        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            try
            {
                var employee = await _unitOfWork.Employees.Get(q => q.Id == id, new List<string> { "Department" });
                var results = _mapper.Map<EmployeesDTO>(employee);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the name of {nameof(GetEmployee)}");
                return StatusCode(500, "Internal Server Error. Try again later. ");
            }

        }
    }
}
