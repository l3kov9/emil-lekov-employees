using Employees.BL.Contracts;
using Employees.BL.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Employees.BL
{
    public class FileService : IFileService
    {
        private static readonly CultureInfo CultureInfo = new("en-US");
        private static readonly string[] Formats = new[] { "yyyy-MM-dd", "yyyy-M-d", "yyyy-d-M", "yyyy-dd-MM", "M-d-yyyy", "dd-MM-yyyy", "MM-dd-yyyy", "M.d.yyyy", "dd.MM.yyyy", "MM.dd.yyyy" }
            .Union(CultureInfo.DateTimeFormat.GetAllDateTimePatterns())
            .ToArray();
        private static DateTime _currentTime;

        public FileService()
        {
            _currentTime = DateTime.Now;
        }

        public async Task<IEnumerable<EmployeeProject>> ProcessFileAsync(IFormFile file)
        {
            var result = new List<EmployeeProject>();

            using var reader = new StreamReader(file.OpenReadStream());
            while (reader.Peek() >= 0)
            {
                var line = await reader.ReadLineAsync();

                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }

                var emp = ConvertToEmployeeProject(line);
                result.Add(emp);
            }

            return result;
        }

        private static EmployeeProject ConvertToEmployeeProject(string line)
        {
            var tokens = line.Split(", ", StringSplitOptions.RemoveEmptyEntries);

            return new EmployeeProject()
            {
                EmployeeId = int.Parse(tokens[0]),
                ProjectId = int.Parse(tokens[1]),
                DateFrom = FormatDate(tokens[2]),
                DateTo = FormatDate(tokens[3])
            };
        }

        private static DateTime FormatDate(string value)
            => DateTime.TryParseExact(value, Formats, CultureInfo, DateTimeStyles.AssumeLocal, out var result)
                ? result 
                : _currentTime;
    }
}
