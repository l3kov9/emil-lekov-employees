using Employees.BL.Contracts;
using Employees.BL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public IEnumerable<PairOfEmployees> Post([FromForm] IFormFile file)
        {
            var employeeProjects = _fileService.ProcessFile(file);
            var result = _employeesService.GetLongestPairs(employeeProjects);

            return result;
        }
    }
}

