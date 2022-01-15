﻿using Employees.BL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employees.BL.Contracts
{
    public interface IEmployeesService
    {
        Task<object> GetLongestPairAsync(IEnumerable<EmployeeProject> employeeProjects);
    }
}
