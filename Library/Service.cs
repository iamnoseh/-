namespace CansoleLibrary;

public class Service
{
    private List<Employee> employees = new List<Employee>();
    private List<Department> departments = new List<Department>();
    private int nextEmployeeId = 1;
    private int nextDepartmentId = 1;

    public void CreateDepartment(string name)
    {
        try
        {
            var department = new Department(nextDepartmentId++, name);
            departments.Add(department);
            Console.WriteLine("Отдел успешно добавлен!");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
        finally
        {
            System.Console.WriteLine("Операция завершена.");
        }
    }

    public void GetAllDepartments()
    {
        try
        {
            Console.WriteLine("Список всех отделов:");
            foreach (var dept in departments)
            {
                Console.WriteLine($"ID: {dept.DepartmentId} | Название: {dept.Name}");
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
        finally
        {
            System.Console.WriteLine("Операция завершена.");
        }
    }

    public Department GetDepartmentById(int departmentId)
    {
        return departments.FirstOrDefault(d => d.DepartmentId == departmentId);
    }

    public void DeleteDepartment(int departmentId)
    {
        try
        {

            var department = GetDepartmentById(departmentId);
            if (department != null)
            {
                departments.Remove(department);
                Console.WriteLine("Отдел успешно удалён!");
            }
            else
            {
                Console.WriteLine("Отдел с указанным ID не найден.");
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }

    public void CreateEmployee(string name, int age, string position, double salary, int departmentId)
    {
        try
        {
            if (GetDepartmentById(departmentId) == null)
            {
                Console.WriteLine("Ошибка: Отдел с указанным ID не найден.");
                return;
            }

            var employee = new Employee(nextEmployeeId++, name, age, position, salary, departmentId);
            employees.Add(employee);
            Console.WriteLine("Сотрудник успешно добавлен!");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
        finally
        {
            System.Console.WriteLine("Операция завершена.");
        }
    }

    public void GetAllEmployees()
    {
        try
        {
            Console.WriteLine("Список всех сотрудников:");
            foreach (var emp in employees)
            {
                var department = GetDepartmentById(emp.DepartmentId);
                Console.WriteLine($"ID: {emp.EmployeeId} | Имя: {emp.Name} | Возраст: {emp.Age} | Должность: {emp.Position} | Зарплата: {emp.Salary} | Отдел: {department?.Name}");
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
        finally
        {
            System.Console.WriteLine("Операция завершена.");
        }
    }

    public Employee GetEmployeeById(int employeeId)
    {
        return employees.FirstOrDefault(e => e.EmployeeId == employeeId);
    }

    public void DeleteEmployee(int employeeId)
    {
        var employee = GetEmployeeById(employeeId);
        if (employee != null)
        {
            employees.Remove(employee);
            Console.WriteLine("Сотрудник успешно удалён!");
        }
        else
        {
            Console.WriteLine("Сотрудник с указанным ID не найден.");
        }
    }

    public void FilterEmployeesByDepartment(int departmentId)
    {
        var filteredEmployees = employees.Where(e => e.DepartmentId == departmentId).ToList();
        if (filteredEmployees.Any())
        {
            foreach (var emp in filteredEmployees)
            {
                Console.WriteLine($"ID: {emp.EmployeeId} | Имя: {emp.Name} | Возраст: {emp.Age} | Должность: {emp.Position} | Зарплата: {emp.Salary}");
            }
        }
        else
        {
            Console.WriteLine("Сотрудники в указанном отделе не найдены.");
        }
    }
    public void FilterEmployeesBySalary(double minSalary)
    {
        var filteredEmployees = employees.Where(e => e.Salary > minSalary).ToList();
        if (filteredEmployees.Any())
        {
            foreach (var emp in filteredEmployees)
            {
                Console.WriteLine($"ID: {emp.EmployeeId} | Имя: {emp.Name} | Зарплата: {emp.Salary} | Должность: {emp.Position}");
            }
        }
        else
        {
            Console.WriteLine("Сотрудники с зарплатой выше указанного уровня не найдены.");
        }
    }
}
