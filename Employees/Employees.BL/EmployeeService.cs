using Employees.BL.Contracts;
using Employees.BL.Models;
using System.Collections.Generic;
using System.Linq;

namespace Employees.BL
{
    public class EmployeeService : IEmployeesService
    {
        private static Dictionary<int, IList<PairOfEmployees>> _pairs;

        public EmployeeService()
        {
            _pairs = new Dictionary<int, IList<PairOfEmployees>>();
        }

        public IEnumerable<PairOfEmployees> GetLongestPairs(IEnumerable<EmployeeProject> employeeProjects)
        {
            var groupedProjects = employeeProjects
                .GroupBy(x => x.ProjectId)
                .ToDictionary(x => x.Key, x => x.ToList());

            foreach (var project in groupedProjects)
            {
                GetLongestPairs(project.Value);
            }


            return _pairs.OrderByDescending(x => x.Key).FirstOrDefault().Value;
        }

        private static void GetLongestPairs(IReadOnlyList<EmployeeProject> value)
        {
            for (var i = 0; i < value.Count - 1; i++)
            {
                CompareEmployee(value[i], value.Skip(i + 1));
            }
        }

        private static void CompareEmployee(EmployeeProject e1, IEnumerable<EmployeeProject> comparedEmployees)
        {
            foreach (var e2 in comparedEmployees)
            {
                var startDate = e1.DateFrom > e2.DateFrom ? e1.DateFrom : e2.DateFrom;
                var endDate = e1.DateTo < e2.DateTo ? e1.DateTo : e2.DateTo;

                var diff = (endDate - startDate).Days + 1;

                if (diff <= 0 || _pairs.Any(x => x.Key > diff))
                    continue;

                if (_pairs.ContainsKey(diff))
                {
                    _pairs[diff].Add(new PairOfEmployees()
                    {
                        FirstEmployeeId = e1.EmployeeId,
                        SecondEmployeeId = e2.EmployeeId,
                        ProjectId = e1.ProjectId,
                        DaysWorked = diff
                    });
                }
                else
                {
                    _pairs[diff] = new List<PairOfEmployees>() { new()
                    {
                        FirstEmployeeId = e1.EmployeeId,
                        SecondEmployeeId = e2.EmployeeId,
                        ProjectId = e1.ProjectId,
                        DaysWorked = diff
                    } };
                }
            }
        }
    }
}
