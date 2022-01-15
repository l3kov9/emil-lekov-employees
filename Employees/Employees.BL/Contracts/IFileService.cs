using Employees.BL.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employees.BL.Contracts
{
    public interface IFileService
    {
        Task<IEnumerable<EmployeeProject>> ProcessFileAsync(IFormFile file);
    }
}
