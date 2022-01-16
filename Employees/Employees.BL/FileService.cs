using Employees.BL.Contracts;
using Employees.BL.Helpers;
using Employees.BL.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

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

        public IEnumerable<EmployeeProject> ProcessFile(IFormFile file)
        {
            var result = new List<EmployeeProject>();

            ReadFile(file, result);

            return result;
        }

        private static void ReadFile(IFormFile file, ICollection<EmployeeProject> result)
        {
            var reader = new StreamReader(file.OpenReadStream());
            while (reader.Peek() >= 0)
            {
                var line = reader.ReadLine();

                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }

                result.Add(ConvertToEmployeeProject(line));
            }
        }

        private static EmployeeProject ConvertToEmployeeProject(string line)
        {
            var tokens = line.Split(",", StringSplitOptions.TrimEntries);

            if (tokens.Length != 4)
            {
                throw new ArgumentException(Constants.InvalidParameters(line));
            }

            return new EmployeeProject()
            {
                EmployeeId = ValidateId(tokens[0]),
                ProjectId = ValidateId(tokens[1]),
                DateFrom = ValidateDate(tokens[2]),
                DateTo = ValidateDate(tokens[3])
            };
        }

        private static int ValidateId(string value)
        {
            if (int.TryParse(value, out var number))
            {
                return number;
            }

            throw new ArgumentException(Constants.InvalidArgument("Id", value));
        }

        private static DateTime ValidateDate(string value)
        {

            if (DateTime.TryParseExact(value, Formats, CultureInfo, DateTimeStyles.AssumeLocal, out DateTime result))
            {
                return result;
            }

            if (string.IsNullOrEmpty(value) || value.Equals("NULL"))
            {
                return _currentTime;
            }

            throw new ArgumentException(Constants.InvalidArgument("Date", value));
        }
    }
}
