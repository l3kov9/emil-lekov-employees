using System.Collections.Generic;
using System.Threading.Tasks;
using Employees.BL.Contracts;
using Employees.BL.Models;

namespace Employees.BL
{
    public class EmployeeService : IEmployeesService
    {
        public Task<object> GetLongestPairAsync(IEnumerable<EmployeeProject> employeeProjects)
        {
            throw new System.NotImplementedException();
        }
    }
}
