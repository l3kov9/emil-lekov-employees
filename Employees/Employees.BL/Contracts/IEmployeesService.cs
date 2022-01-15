using Employees.BL.Models;
using System.Collections.Generic;

namespace Employees.BL.Contracts
{
    public interface IEmployeesService
    {
        IEnumerable<PairOfEmployees> GetLongestPairs(IEnumerable<EmployeeProject> employeeProjects);
    }
}
