using System;

public class Employee
{
    private int Id;
    private string Name;
    private string DepartmentName;
    public object MemberName { get; internal set; }
    public event EventHandler MethodCalled; 
    public Employee(int id, string name, string departmentName)
    {
        Id = id;
        Name = name;
        DepartmentName = departmentName;
    }
    public int GetId()
    {
        MethodCalled?.Invoke(this, EventArgs.Empty);
        return Id;
    }

    public string GetName()
    {
        MethodCalled?.Invoke(this, EventArgs.Empty);
        return Name;
    }

    public string GetDepartmentName()
    {
        MethodCalled?.Invoke(this, EventArgs.Empty);
        return DepartmentName;
    }
    public void UpdateId(int id)
    {
        Id = id;
    }

    public void UpdateName(string name)
    {
        Name = name;
    }
    public void UpdateDepartmentName(string departmentName)
    {
        DepartmentName = departmentName;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Employee details:");
        Console.Write("Id: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Department Name: ");
        string departmentName = Console.ReadLine();
 
        Employee employee = new Employee(id, name, departmentName);
        employee.MethodCalled += (sender, eventArgs) =>
        {
            Console.WriteLine($"{sender.GetType().Name}.{((Employee)sender).MemberName}() method called");
        };

        Console.WriteLine($"Id: {employee.GetId()}");
        Console.WriteLine($"Name: {employee.GetName()}");
        Console.WriteLine($"Department Name: {employee.GetDepartmentName()}");
        employee.UpdateId(100);
        employee.UpdateName("John Doe");
        employee.UpdateDepartmentName("HR");
        Console.WriteLine("\nAfter update:");
        Console.WriteLine($"Id: {employee.GetId()}");
        Console.WriteLine($"Name: {employee.GetName()}");
        Console.WriteLine($"Department Name: {employee.GetDepartmentName()}");
    }
}
