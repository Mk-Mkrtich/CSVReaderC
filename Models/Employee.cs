namespace CsvReader.Models;

public class Employee
{
    public string Name { get; set; } = "";
    public string Department { get; set; } = "";
    public int HoursWorked { get; set; }
    public decimal HourlyRate { get; set; }

    public decimal Payout => HoursWorked * HourlyRate;
}
