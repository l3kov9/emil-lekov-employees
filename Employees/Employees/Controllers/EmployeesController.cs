using Employees.BL.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Employees.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesService _employeesService;
        private readonly IFileService _fileService;

        public EmployeesController(IEmployeesService employeesService, IFileService fileService)
        {
            _employeesService = employeesService;
            _fileService = fileService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] IFormFile file)
        {
            var employeeProjects = await _fileService.ProcessFileAsync(file);
            var result = _employeesService.GetLongestPairs(employeeProjects);

            return (ActionResult)result;
        }
    }
}

