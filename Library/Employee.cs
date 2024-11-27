namespace CansoleLibrary;

public class Employee
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Position { get; set; }
    public double Salary { get; set; }
    public int DepartmentId { get; set; }

    public Employee(int employeeId, string name, int age, string position, double salary, int departmentId)
    {
        EmployeeId = employeeId;
        Name = name;
        Age = age;
        Position = position;
        Salary = salary;
        DepartmentId = departmentId;
    }
}
