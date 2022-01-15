using Employees.BL.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Employees.BL.Contracts
{
    public interface IFileService
    {
        IEnumerable<EmployeeProject> ProcessFile(IFormFile file);
    }
}
