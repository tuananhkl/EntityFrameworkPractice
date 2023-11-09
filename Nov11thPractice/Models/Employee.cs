namespace Nov11thPractice.Models;

public class Employee
{
    public Guid EmployeeId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public int Age { get; set; }
    public string Department { get; set; } = null!;
}