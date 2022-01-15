using System.Threading.Tasks;

namespace Employees.BL.Contracts
{
    public interface IEmployeesService
    {
        Task<object> GetLongestPairAsync();
    }
}
