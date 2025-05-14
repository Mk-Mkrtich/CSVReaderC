using CsvReader.Models;

namespace CsvReader.Services;

public static class CsvParser
{
    private static readonly string[] RateColumnNames = { "hourly_rate", "rate", "salary" };

    public static List<Employee> ParseFile(string path)
    {
        var lines = File.ReadAllLines(path);
        if (lines.Length < 2) return new List<Employee>();

        var headers = lines[0].Split(',').Select(h => h.Trim().ToLower()).ToList();

        int nameIdx = headers.IndexOf("name");
        int deptIdx = headers.IndexOf("department");
        int hoursIdx = headers.IndexOf("hours_worked");
        int rateIdx = headers.FindIndex(h => RateColumnNames.Contains(h));

        if (nameIdx == -1 || deptIdx == -1 || hoursIdx == -1 || rateIdx == -1)
            throw new Exception($"Не удалось найти нужные колонки в файле {path}");

        var employees = new List<Employee>();

        for (int i = 1; i < lines.Length; i++)
        {
            var parts = lines[i].Split(',');

            employees.Add(new Employee
            {
                Name = parts[nameIdx].Trim(),
                Department = parts[deptIdx].Trim(),
                HoursWorked = int.Parse(parts[hoursIdx]),
                HourlyRate = decimal.Parse(parts[rateIdx])
            });
        }

        return employees;
    }
}
