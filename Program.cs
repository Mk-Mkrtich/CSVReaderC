using CsvReader.Models;
using CsvReader.Services;

Console.WriteLine(args);

if (args.Length < 2 || args[^2] != "--report")
{
    Console.WriteLine("Usage: dotnet run <file1.csv> <file2.csv> --report payout");
    return;
}

string reportType = args[^1];
var filePaths = args.Take(args.Length - 2);

var allEmployees = new List<Employee>();

foreach (var path in filePaths)
{
    try
    {
        allEmployees.AddRange(CsvParser.ParseFile(path));
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error in {path}: {ex.Message}");
    }
}

if (reportType == "payout")
{
    ReportGenerator.GeneratePayoutReport(allEmployees);
}
else
{
    Console.WriteLine($"Wrong Report Type: {reportType}");
}
