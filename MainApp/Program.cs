
using CansoleLibrary;


Service service = new Service();
bool exit = false;
System.Console.WriteLine("Hello world !");

while (!exit)
{
        Console.WriteLine("Добро пожаловать в систему управления сотрудниками!");
        Console.WriteLine("1. Добавить сотрудника");
        Console.WriteLine("2. Просмотреть всех сотрудников");
        Console.WriteLine("3. Найти сотрудника по ID");
        Console.WriteLine("4. Удалить сотрудника");
        Console.WriteLine("5. Фильтр сотрудников по отделу");
        Console.WriteLine("6. Показать сотрудников с зарплатой выше заданной");
        Console.WriteLine("7. Управление отделами");
        Console.WriteLine("8. Выход");
        Console.Write("Выберите действие: ");

        try
        {
                int choice = int.Parse(Console.ReadLine()!);
                switch (choice)
                {
                        case 1:
                                Console.Write("Введите имя сотрудника: ");
                                string name = Console.ReadLine()!;
                                Console.Write("Введите возраст сотрудника: ");
                                int age = int.Parse(Console.ReadLine()!);
                                Console.Write("Введите должность сотрудника: ");
                                string position = Console.ReadLine()!;
                                Console.Write("Введите зарплату сотрудника: ");
                                double salary = double.Parse(Console.ReadLine()!);
                                Console.Write("Введите ID отдела: ");
                                int departmentId = int.Parse(Console.ReadLine()!);
                                service.CreateEmployee(name, age, position, salary, departmentId);
                                break;
                        case 2:
                                service.GetAllEmployees();
                                break;
                        case 3:
                                Console.Write("Введите ID сотрудника: ");
                                int employeeId = int.Parse(Console.ReadLine());
                                var employee = service.GetEmployeeById(employeeId);
                                if (employee != null)
                                {
                                        Console.WriteLine($"ID: {employee.EmployeeId} | Имя: {employee.Name} | Возраст: {employee.Age} | Должность: {employee.Position} | Зарплата: {employee.Salary}");
                                }
                                else
                                {
                                        Console.WriteLine("Сотрудник с указанным ID не найден.");
                                }
                                break;
                        case 4:
                                Console.Write("Введите ID сотрудника для удаления: ");
                                employeeId = int.Parse(Console.ReadLine());
                                service.DeleteEmployee(employeeId);
                                break;
                        case 5:
                                Console.Write("Введите ID отдела для фильтрации: ");
                                departmentId = int.Parse(Console.ReadLine());
                                service.FilterEmployeesByDepartment(departmentId);
                                break;
                        case 6:
                                Console.Write("Введите минимальный уровень зарплаты: ");
                                double minSalary = double.Parse(Console.ReadLine());
                                service.FilterEmployeesBySalary(minSalary);
                                break;
                        case 7:
                                ManageDepartments(service);
                                break;
                        case 8:
                                exit = true;
                                Console.WriteLine("Программа завершена. До свидания!");
                                break;
                        default:
                                Console.WriteLine("Неверный выбор, попробуйте снова.");
                                break;
                }
        }
        catch (FormatException)
        {
                Console.WriteLine("Ошибка: Некорректный ввод данных.");
        }
        catch (Exception ex)
        {
                Console.WriteLine($"Ошибка: {ex.Message}");
        }
        finally
        {
                Console.WriteLine("Операция завершена.");
        }
}


static void ManageDepartments(Service service)
{
        bool back = false;
        while (!back)
        {
                Console.WriteLine("\nУправление отделами:");
                Console.WriteLine("1. Добавить новый отдел");
                Console.WriteLine("2. Просмотреть все отделы");
                Console.WriteLine("3. Найти отдел по ID");
                Console.WriteLine("4. Удалить отдел");
                Console.WriteLine("5. Назад");
                Console.Write("Введите действие: ");

                try
                {
                        int choice = int.Parse(Console.ReadLine());
                        switch (choice)
                        {
                                case 1:
                                        Console.Write("Введите название отдела: ");
                                        string name = Console.ReadLine();
                                        service.CreateDepartment(name);
                                        break;
                                case 2:
                                        service.GetAllDepartments();
                                        break;
                                case 3:
                                        Console.Write("Введите ID отдела: ");
                                        int departmentId = int.Parse(Console.ReadLine());
                                        var department = service.GetDepartmentById(departmentId);
                                        if (department != null)
                                        {
                                                Console.WriteLine($"ID: {department.DepartmentId} | Название: {department.Name}");
                                        }
                                        else
                                        {
                                                Console.WriteLine("Отдел с указанным ID не найден.");
                                        }
                                        break;

                                case 4:
                                        Console.Write("Введите ID отдела для удаления: ");
                                        departmentId = int.Parse(Console.ReadLine());
                                        service.DeleteDepartment(departmentId);
                                        break;
                                case 5:
                                        back = true;
                                        break;
                                default:
                                        Console.WriteLine("Неверный выбор, попробуйте снова.");
                                        break;
                        }
                }
                catch (FormatException)
                {
                        Console.WriteLine("Ошибка: Некорректный ввод данных.");
                }
                catch (Exception ex)
                {
                        Console.WriteLine($"Ошибка: {ex.Message}");
                }
                finally
                {
                        Console.WriteLine("Операция завершена.");
                }
        }
}
