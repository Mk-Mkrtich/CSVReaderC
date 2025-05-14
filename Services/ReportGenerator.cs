using CsvReader.Models;

namespace CsvReader.Services;

public static class ReportGenerator
{
    public static void GeneratePayoutReport(List<Employee> employees)
    {
        var grouped = employees.GroupBy(e => e.Department);

        foreach (var group in grouped)
        {
            Console.WriteLine($"{group.Key}");

            Console.WriteLine($"  {"name",-20} {"hours",5} {"rate",5} {"payout",8}");
            foreach (var emp in group)
            {
                Console.WriteLine($"  {emp.Name,-20} {emp.HoursWorked,5} {emp.HourlyRate,5} ${emp.Payout,7}");
            }

            int totalHours = group.Sum(e => e.HoursWorked);
            decimal totalPay = group.Sum(e => e.Payout);

            Console.WriteLine($"{"",28} {totalHours,5} ${totalPay,7}");
            Console.WriteLine();
        }
    }
}
